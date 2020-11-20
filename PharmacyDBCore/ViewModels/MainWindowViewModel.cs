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
        public LoadDataCommand LoadData => new LoadDataCommand(this);
        public UpdateDataCommand UpdateData => new UpdateDataCommand(this);

        public void GenerateDataGrid<T>(IList<T> sourceItems)
        {
            DataSourse = new BindingList<T>(sourceItems);
            BindingList<T> bindingList = (BindingList<T>)DataSourse;
            DataGrid.ItemsSource = bindingList;
            ((BindingList<T>)DataSourse).ListChanged += MainWindowViewModel_ListChanged;
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
            bool addedOrDeleted = e.ListChangedType == ListChangedType.ItemAdded ||
                                  e.ListChangedType == ListChangedType.ItemDeleted;
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
                                if (addedOrDeleted)
                                {

                                }
                                else if (changed)
                                {

                                }
                                break;
                            }
                        case DataType.Clients:
                            {
                                BindingList<Client> bindingList = (BindingList<Client>)sender;
                                break;
                            }
                        case DataType.Drugs:
                            {
                                BindingList<Drug> bindingList = (BindingList<Drug>)sender;
                                break;
                            }
                        case DataType.Employees:
                            {
                                BindingList<Employee> bindingList = (BindingList<Employee>)sender;
                                break;
                            }
                        case DataType.Orders:
                            {
                                BindingList<Order> bindingList = (BindingList<Order>)sender;
                                break;
                            }
                        case DataType.Suppliers:
                            {
                                BindingList<Supplier> bindingList = (BindingList<Supplier>)sender;
                                break;
                            }
                    }
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
