using System.Collections.Generic;
using System.Threading.Tasks;
using HomematicCore.Homematic.Daemon;
using HomematicCore.Homematic.Daemon.Domain;

namespace HomematicCore.Manager.Web.ViewModels
{
    public class DevicesViewModel
    {
        private readonly IHomematicDaemon _homematicDaemon;

        public ParameterDialogViewModel ParameterDialogViewModel { get; private set; }

        public DevicesViewModel(IHomematicDaemon homematicDaemon, ParameterDialogViewModel parameterDialogViewModel)
        {
            _homematicDaemon = homematicDaemon;
            ParameterDialogViewModel = parameterDialogViewModel;
        }

        public IEnumerable<Device> LoadedDevices { get; set; }

        public Task InitializeAsync()
        {
            LoadedDevices = _homematicDaemon.GetDevices();

            return Task.CompletedTask;
        }

        public void ShowParameterSet(Device device, string parameterSetName)
        {
            ParameterDialogViewModel.OpenParameterDialog(device.Address, parameterSetName);
        }
    }
}
