// WcWpfMvvm / ViewModel / WcPresenter.cs
//

using System;
using System.Windows.Input;
using AppModel;
using Kaos.Mvvm;
using Kaos.Mvvm.AppModel;

namespace AppViewModel
{
    public class WcPresenter : Observable
    {
        private WcModel model;
        public WcModelBind WC { get { return model.Bind; } }

        // Transient inputs like this belong here and not in the model.
        private string input = String.Empty;
        public string InputLine
        {
            get { return input; }
            set
            {
                input = value;
                RaisePropertyChangedEvent (nameof (InputLine));
            }
        }

        public WcPresenter (WcModel model)
        {
            this.model = model;
            this.InputLine = String.Empty;
        }

        public ICommand DoCountCommand
        {
            get { return new RelayCommand<object> (CountWords); }
        }

        private void CountWords (object arg1)
        {
            var inLine = (string) arg1;
            if (! String.IsNullOrWhiteSpace (inLine))
                model.Parse (inLine);
            InputLine = String.Empty;
        }
    }
}
