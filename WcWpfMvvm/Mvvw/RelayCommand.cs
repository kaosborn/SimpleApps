// SimpleApps / Mvvw / RelayCommand.cs
//
// This framework file is overhead to any WPF MVVM application
// and should never need to be modified.
//

using System;
using System.Windows.Input;

namespace Kaos.Mvvw
{
    public class RelayCommand : ICommand
    {
        private readonly Action action;

        public RelayCommand (Action action) => this.action = action;

        public void Execute (object parameter) => this.action ();

        public bool CanExecute (object parameter) => true;

        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
}
