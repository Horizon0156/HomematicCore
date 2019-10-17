using System;

namespace HomematicCore.Manager.Web.ViewModels
{
    public abstract class DialogViewModelBase
    {
        public event EventHandler OpenRequested;

        public event EventHandler CloseRequested;

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
    }
}
