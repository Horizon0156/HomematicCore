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

        public InstallationModeDialogViewModel InstallationModeDialogViewModel { get; private set; }

        public DevicesViewModel(
            IHomematicDaemon homematicDaemon, 
            ParameterDialogViewModel parameterDialogViewModel, 
            InstallationModeDialogViewModel installationModeDialogViewModel)
        {
            _homematicDaemon = homematicDaemon;
            ParameterDialogViewModel = parameterDialogViewModel;
            InstallationModeDialogViewModel = installationModeDialogViewModel;
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

        public void EnableInstallationMode() 
        {
            InstallationModeDialogViewModel.Show();
        }
    }
}
