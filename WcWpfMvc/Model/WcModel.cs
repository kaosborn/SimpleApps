using System;
using System.Collections.ObjectModel;

namespace AppModel
{
    // This class is intended for data binding.
    // Since it is visible to the view, it provides no mutators.
    public class WcModelBind : Observable
    {
        internal readonly ObservableCollection<string> history;
        public ReadOnlyObservableCollection<string> History { get; private set; }

        public WcModelBind (WcModel model)
        {
            this.history = new ObservableCollection<string>();
            this.History = new ReadOnlyObservableCollection<string> (history);
        }
    }

    // This class provides an API to the controller.
    public class WcModel
    {
        static private readonly char[] delimiters = new char[] {' ', '\t', '\r', '\n' };
        public WcModelBind Bind { get; private set; }

        public WcModel()
        {
            this.Bind = new WcModelBind (this);
        }

        public int Parse (string text)
        {
            int count = text.Split (delimiters, StringSplitOptions.RemoveEmptyEntries).Length; 
            Bind.history.Add (count.ToString() + " words in '" + text + "'.");
            return count;
        }
    }
}
