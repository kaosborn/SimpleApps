// SimpleApps / Kaos.Mvvm.AppModel / Observable.cs
//
// This file should never need to be modified.
//

using System.ComponentModel;

namespace Kaos.Mvvm.AppModel
{
    public abstract class Observable : INotifyPropertyChanged
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
