// WcWpfMvvm / ViewModel / WcPresenter.cs
//

using System;
using System.Windows.Input;
using AppModel;

namespace AppViewModel
{
    public class WcPresenter : Observable
    {
        public event EventHandler UpdateVM;

        private WcModel WordCounter;
        public WcModelBind WC { get { return WordCounter.Bind; } }

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
            this.WordCounter = model;
            this.InputLine = String.Empty;
        }

        public ICommand DoCountCommand
        {
            get { return new DelegateCommand (CountWords); }
        }

        private void CountWords()
        {
            if (UpdateVM != null)
                UpdateVM (this, EventArgs.Empty);

            if (! String.IsNullOrWhiteSpace (InputLine))
                WordCounter.Parse (InputLine);
            InputLine = String.Empty;
        }
    }
}
