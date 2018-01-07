using System;
using System.Collections.ObjectModel;

namespace AppModel
{
    public class WcModel : Observable
    {
        static private readonly char[] delimiters = new char[] {' ', '\t', '\r', '\n' };
        private readonly ObservableCollection<string> history;
        public ReadOnlyObservableCollection<string> History { get; private set; }

        public WcModel()
        {
            this.history = new ObservableCollection<string>();
            this.History = new ReadOnlyObservableCollection<string> (this.history);
        }

        public int Parse (string text)
        {
            int count = text.Split (delimiters, StringSplitOptions.RemoveEmptyEntries).Length; 
            history.Add (count.ToString() + " words in '" + text + "'.");
            return count;
        }
    }
}
