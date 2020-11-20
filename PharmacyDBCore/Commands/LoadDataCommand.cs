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
    public class LoadDataCommand : BaseCommand, IDisposable
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
            _window.LoadDataGrid(tableName);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }
        ~LoadDataCommand()
        {
            Dispose();
        }
    }
}
