// WcWpfMvvm / ViewModel / WcPresenter.cs
//

using System;
using System.Windows.Input;
using AppModel;

namespace AppViewModel
{
    public class WcPresenter : ObservableObject
    {
        public WcModel WordCounter { get; private set; }

        // Transient inputs like this do not belong in the model.
        // TODO: Fix so this does not cause a heap allocation on EVERY KEYSTROKE.
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

        public WcPresenter()
        {
            WordCounter = new WcModel();
            InputLine = String.Empty;
        }

        public ICommand DoCountCommand
        {
            get { return new DelegateCommand (CountWords); }
        }

        private void CountWords()
        {
            if (! String.IsNullOrWhiteSpace (InputLine))
                WordCounter.Parse (InputLine);
            InputLine = String.Empty;
        }
    }
}
