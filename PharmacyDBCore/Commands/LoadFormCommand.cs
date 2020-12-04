using PharmacyDBCore.Database.Models;
using PharmacyDBCore.ViewModels;
using PharmacyDBCore.Views;
using PharmacyDBCore.Views.DataForms;
using System;
using System.Windows;

namespace PharmacyDBCore.Commands
{
    public class LoadFormCommand : BaseCommand
    {
        private MainWindowViewModel _window;
        public LoadFormCommand(MainWindowViewModel window)
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
            _window.DataType = Enum.Parse<DataType>(tableName, true);
            LoadForm(_window.DataType);
        }

        public void LoadForm(DataType type)
        {
            switch (type)
            {
                case DataType.Appointments:
                    {
                        ((MainWindow)(Application.Current.MainWindow)).FormGrid.Children.Add(new AppointmentForm());

                        break;
                    }
                case DataType.Clients:
                    {
                        ((MainWindow)(Application.Current.MainWindow)).FormGrid.Children.Add(new ClientForm());
                        break;
                    }
                case DataType.Drugs:
                    {
                        ((MainWindow)(Application.Current.MainWindow)).FormGrid.Children.Add(new DrugForm());
                        break;
                    }
                case DataType.Employees:
                    {
                        ((MainWindow)(Application.Current.MainWindow)).FormGrid.Children.Add(new EmployeeForm());
                        break;
                    }
                case DataType.Orders:
                    {
                        ((MainWindow)(Application.Current.MainWindow)).FormGrid.Children.Add(new OrderForm());
                        break;
                    }
                case DataType.Suppliers:
                    {
                        ((MainWindow)(Application.Current.MainWindow)).FormGrid.Children.Add(new SupplierForm());
                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(type), type, null);
                    }
            }
        }
    }
}
