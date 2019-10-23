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

        public bool IsBusy { get; private set; }

        public InstallationModeDialogViewModel InstallationModeDialogViewModel { get; private set; }

        public DevicesViewModel(
            IHomematicDaemon homematicDaemon, 
            ParameterDialogViewModel parameterDialogViewModel, 
            InstallationModeDialogViewModel installationModeDialogViewModel)
        {
            _homematicDaemon = homematicDaemon;
            ParameterDialogViewModel = parameterDialogViewModel;
            InstallationModeDialogViewModel = installationModeDialogViewModel;

            LoadedDevices = new List<Device>();
        }

        public IEnumerable<Device> LoadedDevices { get; set; }

        public async Task InitializeAsync()
        {
            IsBusy = true;
            LoadedDevices = await _homematicDaemon.GetDevicesAsync();
            IsBusy = false;
        }

        public void ShowParameterSet(Device device, string parameterSetName)
        {
            ParameterDialogViewModel.OpenParameterDialog(device.Address, parameterSetName);
        }

        public void EnableInstallationMode() 
        {
            InstallationModeDialogViewModel.Show();
        }
    }
}
