using System.Windows;
using System.Windows.Controls;
using PharmacyDBCore.ViewModels;

namespace PharmacyDBCore.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ((MainWindowViewModel)DataContext).DataGrid = ((MainWindow)Application.Current.MainWindow).dataGrid;
        }
    }
}
