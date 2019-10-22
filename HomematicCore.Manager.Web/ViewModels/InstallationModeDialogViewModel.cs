using System;
using System.Threading.Tasks;
using HomematicCore.Homematic.Daemon;
using HomematicCore.Homematic.Daemon.Domain;

namespace HomematicCore.Manager.Web.ViewModels
{
    public class InstallationModeDialogViewModel : DialogViewModelBase
    {
        private readonly IHomematicDaemon _homematicDaemon;

        public bool IsAutoDiscoveryEnable { get; set; }

        public DateTime InstallationModeExpirationTime { get; private set; }

        public bool IsInstallationModeActive { get; private set; }

        public HmIpDeviceKey DeviceKey { get; set; }

        public int Duration { get; set; }

        public InstallationModeDialogViewModel(IHomematicDaemon homematicDaemon)
        {
            Duration = 60;
            IsAutoDiscoveryEnable = true;
            DeviceKey = new HmIpDeviceKey();

            _homematicDaemon = homematicDaemon;
        }

        public async Task InitializeAsync()
        {
            var remainingSeconds = _homematicDaemon.GetRemainingSecondsInInstallationMode();

            if (remainingSeconds > 0) 
            {
                await WaitForInstallationModeExpirationAsync(remainingSeconds);
            }
        }

        public void Show()
        {
            OnOpenRequested();
        }

        public async Task StartDiscoveryAsync()
        {
            if (IsAutoDiscoveryEnable)
            {
                _homematicDaemon.EnableInstallationMode(Duration);
            }
            else
            {
                _homematicDaemon.EnableInstallationModeWithWhitelist(new[] { DeviceKey }, Duration);
            }
            
            await WaitForInstallationModeExpirationAsync(Duration);
        }

        public async Task WaitForInstallationModeExpirationAsync(int remainingSeconds) 
        {
            IsInstallationModeActive = true;
            InstallationModeExpirationTime = DateTime.Now.AddSeconds(remainingSeconds);

            await Task.Delay(remainingSeconds * 1000);
            IsInstallationModeActive = false;
        }

        public void Close()
        {
            OnCloseRequested();
        }
    }
}
