// SimpleApps / WcWpfMvvm / ObservableObject.cs
//
// This ViewModel file is overhead to any WPF MVVM application
// and should never need to be modified.
//

using System.ComponentModel;

namespace AppViewModel
{
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent (string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler (this, new PropertyChangedEventArgs (propertyName));
        }
    }
}
