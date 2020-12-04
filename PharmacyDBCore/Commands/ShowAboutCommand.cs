using PharmacyDBCore.Commands;
using PharmacyDBCore.Views;

namespace PharmacyDBCore.ViewModels
{
    public class ShowAboutCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();

        }
    }
}