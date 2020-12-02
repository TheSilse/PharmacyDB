using PharmacyDBCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Windows.Data;
using System.ComponentModel;
using PharmacyDBCore.Database;
using PharmacyDBCore.Database.Models;
using PharmacyDBCore.Views;

namespace PharmacyDBCore.Commands
{
    public class LoadDataCommand : BaseCommand
    {
        private MainWindowViewModel _window;
        public LoadDataCommand(MainWindowViewModel window)
        {
            _window = window;
            
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            string tableName = (string)parameter;
            LoadDataGrid(tableName);
        }
        public void GenerateDataGrid<T>(List<T> sourceItems)
        {
            _window.ItemsSource = new BindingList<T>(sourceItems);
            BindingList<T> bindingList = (BindingList<T>)_window.ItemsSource;
            _window.DataGrid.ItemsSource = bindingList;
            ((BindingList<T>)_window.ItemsSource).ListChanged += MainWindowViewModel_ListChanged;
            

        }
        public void LoadDataGrid(string tableName)
        {
            _window.DataType = Enum.Parse<DataType>(tableName, true);
            _window.DataGrid.AutoGeneratingColumn += DataGrid_AutoGeneratingColumn;
            _window.DataGrid.SelectionChanged += DataGrid_SelectionChanged;
            try
            {
                using (DatabaseContext db = new DatabaseContext())
                {
                    switch (_window.DataType)
                    {
                        case DataType.Appointments:
                            {
                                GenerateDataGrid(db.Appointments.Select(t => new AppointmentViewModel(t)).ToList());
                                break;
                            }
                        case DataType.Clients:
                            {
                                GenerateDataGrid(db.Clients.Select(t => new ClientViewModel(t)).ToList());
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
        #region Events
        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "NextCommand" ||
                e.Column.Header.ToString() == "PrevCommand" ||
                e.Column.Header.ToString() == "SaveCommand" ||
                e.Column.Header.ToString() == "Appointment" ||
                e.Column.Header.ToString() == "Supplier" ||
                e.Column.Header.ToString() == "User" ||
                e.Column.Header.ToString() == "Employee" ||
                e.Column.Header.ToString() == "Client")
                
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((DataGrid)sender).SelectedItem != null)
            {
                _window.LastSelectedItem = ((DataGrid)sender).SelectedItem;
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
                    switch (_window.DataType)
                    {
                        case DataType.Appointments:
                            {
                                if (added)
                                {
                                    BindingList<AppointmentViewModel> list = (BindingList<AppointmentViewModel>)sender;
                                    Appointment newItem = list.ToList().Last().GetAppointment();
                                    newItem.Id = list.Count;
                                    db.Appointments.Add(newItem);
                                }
                                else if (deleted)
                                {
                                    db.Appointments.Remove(((AppointmentViewModel)_window.LastSelectedItem).GetAppointment());
                                }
                                else if (changed)
                                {
                                    db.Appointments.Update(((AppointmentViewModel)_window.LastSelectedItem).GetAppointment());
                                }
                                break;
                            }
                        case DataType.Clients:
                            {
                                if (added)
                                {
                                    BindingList<ClientViewModel> list = (BindingList<ClientViewModel>)sender;
                                    Client newItem = list.ToList().Last().GetClient();
                                    newItem.Id = list.Count;
                                    db.Clients.Add(newItem);
                                }
                                else if (deleted)
                                {
                                    db.Clients.Remove(((ClientViewModel)_window.LastSelectedItem).GetClient());
                                }
                                else if (changed)
                                {
                                    db.Clients.Update(((ClientViewModel)_window.LastSelectedItem).GetClient());
                                }
                                break;
                            }
                        case DataType.Drugs:
                            {
                                if (added)
                                {
                                    BindingList<DrugViewModel> list = (BindingList<DrugViewModel>)sender;
                                    Drug newItem = list.ToList().Last().GetDrug();
                                    newItem.Id = list.Count;
                                    db.Drugs.Add(newItem);
                                }
                                else if (deleted)
                                {
                                    db.Drugs.Remove(((DrugViewModel)_window.LastSelectedItem).GetDrug());
                                }
                                else if (changed)
                                {
                                    db.Drugs.Update(((DrugViewModel)_window.LastSelectedItem).GetDrug());
                                }
                                break;
                            }
                        case DataType.Employees:
                            {
                                if (added)
                                {
                                    BindingList<EmployeeViewModel> list = (BindingList<EmployeeViewModel>)sender;
                                    Employee newItem = list.ToList().Last().GetEmployee();
                                    newItem.Id = list.Count;
                                    db.Employees.Add(newItem);
                                }
                                else if (deleted)
                                {
                                    db.Employees.Remove(((EmployeeViewModel)_window.LastSelectedItem).GetEmployee());
                                }
                                else if (changed)
                                {
                                    db.Employees.Update(((EmployeeViewModel)_window.LastSelectedItem).GetEmployee());
                                }
                                break;
                            }
                        case DataType.Orders:
                            {
                                if (added)
                                {
                                    BindingList<OrderViewModel> list = (BindingList<OrderViewModel>)sender;
                                    Order newItem = list.ToList().Last().GetOrder();
                                    newItem.Id = list.Count;
                                    db.Orders.Add(newItem);
                                }
                                else if (deleted)
                                {
                                    db.Orders.Remove(((OrderViewModel)_window.LastSelectedItem).GetOrder());
                                }
                                else if (changed)
                                {
                                    db.Orders.Update(((OrderViewModel)_window.LastSelectedItem).GetOrder());
                                }
                                break;
                            }
                        case DataType.Suppliers:
                            {
                                if (added)
                                {
                                    BindingList<SupplierViewModel> list = (BindingList<SupplierViewModel>)sender;
                                    Supplier newItem = list.ToList().Last().GetSupplier();
                                    newItem.Id = list.Count;
                                    db.Suppliers.Add(newItem);
                                }
                                else if (deleted)
                                {
                                    db.Suppliers.Remove(((SupplierViewModel)_window.LastSelectedItem).GetSupplier());
                                }
                                else if (changed)
                                {
                                    db.Suppliers.Update(((SupplierViewModel)_window.LastSelectedItem).GetSupplier());
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

        #endregion
    }
}
