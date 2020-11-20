using PharmacyDBCore.Services;
using PharmacyDBCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using PharmacyDBCore.Views;

namespace PharmacyDBCore.Commands
{
    public class LoginCommand : BaseCommand, IDisposable
    {
        private UserViewModel _userViewModel;
        public LoginCommand(UserViewModel userViewModel)
        {
            _userViewModel = userViewModel;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_userViewModel.Login) &&
                   !string.IsNullOrEmpty(_userViewModel.Password);
        }

        public void Dispose()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public override void Execute(object parameter)
        {
            bool successAuth = UserManager.LoginUser(_userViewModel);
            if (successAuth)
            {
                Window authWin = (Application.Current).MainWindow;
                MainWindow mainWindow = new MainWindow();
                Application.Current.MainWindow = mainWindow;
                Application.Current.MainWindow.Show();
                authWin.Close();
                GC.SuppressFinalize(this);
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }

        }
    }
}
