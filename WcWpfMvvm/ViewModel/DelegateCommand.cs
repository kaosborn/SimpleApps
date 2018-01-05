using System;
using System.Windows.Input;

namespace AppViewModel
{
    public class DelegateCommand : ICommand
    {
        private readonly Action action;

        public DelegateCommand (Action action) => this.action = action;

        public void Execute (object parameter) => this.action();

        public bool CanExecute (object parameter) => true;

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
}
