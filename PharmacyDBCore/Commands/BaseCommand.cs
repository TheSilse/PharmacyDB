using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace PharmacyDBCore.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
