using PharmacyDBCore.Database;
using PharmacyDBCore.Database.Models;
using PharmacyDBCore.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using PharmacyDBCore.Views;

namespace PharmacyDBCore.Commands
{
    public class UpdateDataCommand : BaseCommand
    {
        private MainWindowViewModel _tablesViewModel;
        public UpdateDataCommand(MainWindowViewModel tablesViewModel)
        {
            _tablesViewModel = tablesViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                switch (_tablesViewModel.DataType)
                {
                    case DataType.Appointments:
                        {
                            List<Appointment> apps = db.Appointments.ToList();
                            ((MainWindow)Application.Current.MainWindow).dataGrid.ItemsSource = new BindingList<Appointment>(apps);

                            break;
                        }
                    case DataType.Clients:
                        {
                            List<Client> clients = db.Clients.ToList();
                            ((MainWindow)Application.Current.MainWindow).dataGrid.ItemsSource = new BindingList<Client>(clients);
                            break;
                        }
                    case DataType.Drugs:
                        {
                            List<Drug> drugs = db.Drugs.ToList();
                            ((MainWindow)Application.Current.MainWindow).dataGrid.ItemsSource = new BindingList<Drug>(drugs);
                            break;
                        }
                    case DataType.Employees:
                        {
                            List<Employee> employees = db.Employees.ToList();
                            ((MainWindow)Application.Current.MainWindow).dataGrid.ItemsSource = new BindingList<Employee>(employees);
                            break;
                        }
                    case DataType.Orders:
                        {
                            List<Order> orders = db.Orders.ToList();
                            ((MainWindow)Application.Current.MainWindow).dataGrid.ItemsSource = new BindingList<Order>(orders);
                            break;
                        }
                    case DataType.Suppliers:
                        {
                            List<Supplier> suppliers = db.Suppliers.ToList();
                            ((MainWindow)Application.Current.MainWindow).dataGrid.ItemsSource = new BindingList<Supplier>(suppliers);
                            break;
                        }

                }
            }
        }
    }
}