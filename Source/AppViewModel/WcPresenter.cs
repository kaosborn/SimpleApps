// AppViewModel / WcPresenter.cs
//

using System;
using System.Windows.Input;
using AppModel;
using Kaos.Mvvm;

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
            this.DoClear = new RelayCommand (() => model.ClearResults(), p => model.Bind.History.Count > 0);
            this.DoCount = new RelayCommand<string> (a => CountWords (a));
        }

        public ICommand DoClear { get; private set; }

        public ICommand DoCount { get; private set; }

        private void CountWords (string line)
        {
            if (! String.IsNullOrWhiteSpace (line))
            {
                model.Parse (line);
                InputLine = String.Empty;
            }
        }
    }
}
