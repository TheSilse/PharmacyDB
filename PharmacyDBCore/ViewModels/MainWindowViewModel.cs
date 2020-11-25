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
using PharmacyDBCore.Views;

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
        public LoadFormCommand LoadForm => new LoadFormCommand(this);

        public MainWindowViewModel()
        {
            DataGrid = ((MainWindow)Application.Current.MainWindow).dataGrid;
            
        }

    }
}
