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
        public event EventHandler UpdateVM;

        private WcModel model;
        public WcModelBind WC { get { return model.Bind; } }

        // Transient inputs like this do not belong in the model.
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
            get { return new RelayCommand (CountWords); }
        }

        private void CountWords()
        {
            if (UpdateVM != null)
                UpdateVM (this, EventArgs.Empty);

            if (! String.IsNullOrWhiteSpace (InputLine))
                model.Parse (InputLine);
            InputLine = String.Empty;
        }
    }
}
