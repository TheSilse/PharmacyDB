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
            (DataContext as MainWindowViewModel).DataGrid = ((MainWindow)Application.Current.MainWindow).dataGrid;
        }
        
    }
}
