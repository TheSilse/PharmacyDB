using PharmacyDBCore.Commands;
using System.Windows;

namespace PharmacyDBCore.ViewModels
{
    public class ExitCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            Application.Current.MainWindow.Close();
        }
    }
}