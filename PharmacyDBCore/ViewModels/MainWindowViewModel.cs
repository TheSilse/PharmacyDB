using PharmacyDBCore.Commands;
using PharmacyDBCore.Database.Models;
using PharmacyDBCore.Views;
using System.Windows;
using System.Windows.Controls;

namespace PharmacyDBCore.ViewModels
{


    public class MainWindowViewModel : Notify
    {
        public DataType DataType { get; set; }
        public object ItemsSource { get; set; }
        public object SelectedItem { get; set; }
        public object LastSelectedItem { get; set; }
        public LoadDataCommand LoadData => new LoadDataCommand(this);
        public UpdateDataCommand UpdateData => new UpdateDataCommand(this);
        public LoadFormCommand LoadForm => new LoadFormCommand(this);
        public ExitCommand ExitCommand => new ExitCommand();
        public ShowAboutCommand ShowAboutCommand => new ShowAboutCommand();

    }
}
