using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HomematicCore.Manager.Web.ViewModels
{
    public abstract class DialogViewModelBase : INotifyPropertyChanged
    {
        public event EventHandler OpenRequested;

        public event EventHandler CloseRequested;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnOpenRequested() 
        {
            var handler = OpenRequested;
            handler?.Invoke(this, EventArgs.Empty);
        }

        protected void OnCloseRequested() 
        {
            var handler = CloseRequested;
            handler?.Invoke(this, EventArgs.Empty);
        }

        protected void SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
        {
            property = value;
            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
