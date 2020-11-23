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
        public object ItemsSource { get; set; }
        public object SelectedItem { get; set; }
        public object LastSelectedItem { get; set; }
        public LoadDataCommand LoadData => new LoadDataCommand(this);
        public UpdateDataCommand UpdateData => new UpdateDataCommand(this);

        public void GenerateDataGrid<T>(List<T> sourceItems)
        {
            ItemsSource = new BindingList<T>(sourceItems);
            BindingList<T> bindingList = (BindingList<T>)ItemsSource;
            DataGrid.ItemsSource = bindingList;
            ((BindingList<T>)ItemsSource).ListChanged += MainWindowViewModel_ListChanged;

            DataGrid.SelectionChanged += DataGrid_SelectionChanged;
            DataGrid.AutoGeneratingColumn += DataGrid_AutoGeneratingColumn;
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
                    switch (DataType)
                    {
                        case DataType.Appointments:
                            {
                                GenerateDataGrid(db.Appointments.Select(t => new AppointmentViewModel(t)).ToList());
                                break;
                            }
                        case DataType.Clients:
                            {
                                GenerateDataGrid(db.Clients.Select(t=> new ClientViewModel(t)).ToList());
                                break;
                            }
                        case DataType.Drugs:
                            {
                                GenerateDataGrid(db.Drugs.Select(t => new DrugViewModel(t)).ToList());
                                break;
                            }
                        case DataType.Employees:
                            {
                                GenerateDataGrid(db.Employees.Select(t => new EmployeeViewModel(t)).ToList());
                                break;
                            }
                        case DataType.Orders:
                            {
                                GenerateDataGrid(db.Orders.Select(t => new OrderViewModel(t)).ToList());
                                break;
                            }
                        case DataType.Suppliers:
                            {
                                GenerateDataGrid(db.Suppliers.Select(t => new SupplierViewModel(t)).ToList());
                                break;
                            }
                        default:
                            {
                                throw new ArgumentOutOfRangeException();
                            }
                    }
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
                    switch (DataType)
                    {
                        case DataType.Appointments:
                            {
                                if (added)
                                {
                                    BindingList<AppointmentViewModel> list = (BindingList<AppointmentViewModel>)sender;
                                    db.Appointments.UpdateRange(list.Select(t=>t.GetAppointment()));
                                }
                                else if (deleted)
                                {
                                    db.Appointments.Remove(((AppointmentViewModel)LastSelectedItem).GetAppointment());
                                }
                                else if (changed)
                                {
                                    db.Appointments.Update(((AppointmentViewModel)LastSelectedItem).GetAppointment());
                                }
                                break;
                            }
                        case DataType.Clients:
                            {
                                if (added)
                                {
                                    BindingList<ClientViewModel> list = (BindingList<ClientViewModel>)sender;
                                    db.Clients.UpdateRange(list.Select(t=>t.GetClient()));
                                }
                                else if (deleted)
                                {
                                    db.Clients.Remove(((ClientViewModel)LastSelectedItem).GetClient());
                                }
                                else if (changed)
                                {
                                    db.Clients.Update(((ClientViewModel)LastSelectedItem).GetClient());
                                }
                                break;
                            }
                        case DataType.Drugs:
                            {
                                if (added)
                                {
                                    BindingList<DrugViewModel> list = (BindingList<DrugViewModel>)sender;
                                    db.Drugs.UpdateRange(list.Select(t=>t.GetDrug()));
                                }
                                else if (deleted)
                                {
                                    db.Drugs.Remove(((DrugViewModel)LastSelectedItem).GetDrug());
                                }
                                else if (changed)
                                {
                                    db.Drugs.Update(((DrugViewModel)LastSelectedItem).GetDrug());
                                }
                                break;
                            }
                        case DataType.Employees:
                            {
                                if (added)
                                {
                                    BindingList<EmployeeViewModel> list = (BindingList<EmployeeViewModel>)sender;
                                    db.Employees.UpdateRange(list.Select(t => t.GetEmployee()));
                                }
                                else if (deleted)
                                {
                                    db.Employees.Remove(((EmployeeViewModel)LastSelectedItem).GetEmployee());
                                }
                                else if (changed)
                                {
                                    db.Employees.Update(((EmployeeViewModel)LastSelectedItem).GetEmployee());
                                }
                                break;
                            }
                        case DataType.Orders:
                            {
                                if (added)
                                {
                                    BindingList<OrderViewModel> list = (BindingList<OrderViewModel>)sender;
                                    db.Orders.UpdateRange(list.Select(t => t.GetOrder()));
                                }
                                else if (deleted)
                                {
                                    db.Orders.Remove(((OrderViewModel)LastSelectedItem).GetOrder());
                                }
                                else if (changed)
                                {
                                    db.Orders.Update(((OrderViewModel)LastSelectedItem).GetOrder());
                                }
                                break;
                            }
                        case DataType.Suppliers:
                            {
                                if (added)
                                {
                                    BindingList<SupplierViewModel> list = (BindingList<SupplierViewModel>)sender;
                                    db.Suppliers.UpdateRange(list.Select(t => t.GetSupplier()));
                                }
                                else if (deleted)
                                {
                                    db.Suppliers.Remove(((SupplierViewModel)LastSelectedItem).GetSupplier());
                                }
                                else if (changed)
                                {
                                    db.Suppliers.Update(((SupplierViewModel)LastSelectedItem).GetSupplier());
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
