
using HomematicCore.Homematic.Daemon;
using HomematicCore.Homematic.Daemon.Domain;

namespace HomematicCore.Manager.Web.ViewModels
{
    public class ParameterDialogViewModel : DialogViewModelBase
    {
        private readonly IHomematicDaemon _homematicDaemon;

        public string ParameterSetKey { get; private set; }

        public string Address { get; private set; }
        public ParameterSetDescription ParameterSetDescription { get; private set; }

        public ParameterSet ParameterSet { get; private set; }

        public ParameterDialogViewModel(IHomematicDaemon homematicDaemon)
        {
            _homematicDaemon = homematicDaemon;
        }
        public void OpenParameterDialog(string address, string parameterSetKey)
        {
            Address = address;
            ParameterSetKey = parameterSetKey;
            LoadParameterSet();
            
            OnOpenRequested();
        }

        public void LoadParameterSet()
        {
            ParameterSetDescription = _homematicDaemon.GetParameterSetDescription(Address, ParameterSetKey);
            ParameterSet = _homematicDaemon.GetParameterSet(Address, ParameterSetKey);
        }

        public void Close()
        {
            OnCloseRequested();
        }
    }
}
