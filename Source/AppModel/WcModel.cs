using System;
using System.Collections.ObjectModel;

namespace AppModel
{
    // Here is the portion of the model suitable for data binding.
    public class WcModelBind
    {
        public ReadOnlyObservableCollection<string> History { get; private set; }

        public WcModelBind (WcModel model)
        {
            this.History = new ReadOnlyObservableCollection<string> (model.history);
        }
    }

    // This is the API portion of the model.
    public class WcModel
    {
        static private readonly char[] delimiters = new char[] {' ', '\t', '\r', '\n' };
        internal readonly ObservableCollection<string> history;
        public WcModelBind Bind { get; private set; }

        public WcModel()
        {
            this.history = new ObservableCollection<string>();
            this.Bind = new WcModelBind (this);
        }

        public void ClearResults()
        {
            history.Clear();
        }

        public int Parse (string text)
        {
            int count = text.Split (delimiters, StringSplitOptions.RemoveEmptyEntries).Length; 
            history.Add (count.ToString() + " words in '" + text + "'.");
            return count;
        }
    }
}
