using System;
using System.Collections;
using PharmacyDBCore.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using PharmacyDBCore.Database;
using PharmacyDBCore.Database.Models;
using PharmacyDBCore.Services;

namespace PharmacyDBCore.ViewModels
{


    public class MainWindowViewModel : Notify
    {
        public DataType DataType { get; set; }
        public DataGrid DataGrid { get; set; }
        public object DataSourse { get; set; }
        public object SelectedItem { get; set; }
        public object LastSelectedItem { get; set; }
        public LoadDataCommand LoadData => new LoadDataCommand(this);
        public UpdateDataCommand UpdateData => new UpdateDataCommand(this);

        public void GenerateDataGrid<T>(IList<T> sourceItems)
        {
            DataSourse = new BindingList<T>(sourceItems);
            BindingList<T> bindingList = (BindingList<T>)DataSourse;
            DataGrid.ItemsSource = bindingList;
            DataGrid.SelectionChanged += DataGrid_SelectionChanged;
            DataGrid.AutoGeneratingColumn += DataGrid_AutoGeneratingColumn;
            ((BindingList<T>)DataSourse).ListChanged += MainWindowViewModel_ListChanged;
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header is "Appointment" || 
                e.Column.Header is "Supplier" || 
                e.Column.Header is "User" ||
                e.Column.Header is "Employee" || 
                e.Column.Header is "Client")
                e.Column.Visibility = Visibility.Collapsed;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((DataGrid)sender).SelectedItem != null)
            {
                LastSelectedItem = ((DataGrid)sender).SelectedItem;
            }
        }

        public void LoadDataGrid(string tableName)
        {
            DataType = Enum.Parse<DataType>(tableName, true);
            try
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    dynamic list = BindingListProvider.GetDataList(DataType, db);
                    GenerateDataGrid(list);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void MainWindowViewModel_ListChanged(object sender, ListChangedEventArgs e)
        {
            bool added = e.ListChangedType == ListChangedType.ItemAdded;
            bool deleted = e.ListChangedType == ListChangedType.ItemDeleted;
            bool changed = e.ListChangedType == ListChangedType.ItemChanged;
            try
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    dynamic list = BindingListProvider.GetBindingList(DataType, sender);
                    switch (DataType)
                    {
                        case DataType.Appointments:
                            {
                                if (added)
                                {
                                    db.Appointments.UpdateRange((BindingList<Appointment>)list);
                                }
                                else if (deleted)
                                {
                                    db.Appointments.Remove((Appointment)LastSelectedItem);
                                }
                                else if (changed)
                                {
                                    db.Appointments.Update((Appointment)LastSelectedItem);
                                }
                                break;
                            }
                        case DataType.Clients:
                            {
                                if (added)
                                {
                                    db.Clients.UpdateRange((BindingList<Client>)list);
                                }
                                else if (deleted)
                                {
                                    db.Clients.Remove((Client)LastSelectedItem);
                                }
                                else if (changed)
                                {
                                    db.Clients.Update((Client)LastSelectedItem);
                                }
                                break;
                            }
                        case DataType.Drugs:
                            {
                                if (added)
                                {
                                    db.Drugs.UpdateRange((BindingList<Drug>)list);
                                }
                                else if (deleted)
                                {
                                    db.Drugs.Remove((Drug)LastSelectedItem);
                                }
                                else if (changed)
                                {
                                    db.Drugs.Update((Drug)LastSelectedItem);
                                }
                                break;
                            }
                        case DataType.Employees:
                            {
                                if (added)
                                {
                                    db.Employees.UpdateRange((BindingList<Employee>)list);
                                }
                                else if (deleted)
                                {
                                    db.Employees.Remove((Employee)LastSelectedItem);
                                }
                                else if (changed)
                                {
                                    db.Employees.Update((Employee)LastSelectedItem);
                                }
                                break;
                            }
                        case DataType.Orders:
                            {
                                if (added)
                                {
                                    db.Orders.UpdateRange((BindingList<Order>)list);
                                }
                                else if (deleted)
                                {
                                    db.Orders.Remove((Order)LastSelectedItem);
                                }
                                else if (changed)
                                {
                                    db.Orders.Update((Order)LastSelectedItem);
                                }
                                break;
                            }
                        case DataType.Suppliers:
                            {
                                if (added)
                                {
                                    db.Suppliers.UpdateRange((BindingList<Supplier>)list);
                                }
                                else if (deleted)
                                {
                                    db.Suppliers.Remove((Supplier)LastSelectedItem);
                                }
                                else if (changed)
                                {
                                    db.Suppliers.Update((Supplier)LastSelectedItem);
                                }
                                break;
                            }
                    }
                    db.SaveChanges();
                }


            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                if (exception.InnerException != null)
                {
                    MessageBox.Show(exception.InnerException.Message);
                }
            }
        }


    }
}
