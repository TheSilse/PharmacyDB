using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using PharmacyDBCore.Database;
using PharmacyDBCore.Database.Models;
using PharmacyDBCore.ViewModels;

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
                        _tablesViewModel.DataGrid.ItemsSource = new BindingList<Appointment>(apps);
                        
                        break;
                    }
                    case DataType.Clients:
                    {
                        break;
                    }
                    case DataType.Drugs:
                    {
                        break;
                    }
                    case DataType.Employees:
                    {
                        break;
                    }
                    case DataType.Orders:
                    {
                        break;
                    }
                    case DataType.Suppliers:
                    {
                        break;
                    }
                
                }
            }
        }
    }
}