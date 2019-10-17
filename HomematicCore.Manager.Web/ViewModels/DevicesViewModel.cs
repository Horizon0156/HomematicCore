using System.Collections.Generic;
using System.Threading.Tasks;
using HomematicCore.Homematic.Daemon;
using HomematicCore.Homematic.Daemon.Domain;
using Microsoft.AspNetCore.Components;

namespace HomematicCore.Manager.Web.ViewModels
{
    public class DevicesViewModel
    {
        private readonly IHomematicDaemon _homematicDaemon;

        private readonly NavigationManager _navigationManager;

        public DevicesViewModel(IHomematicDaemon homematicDaemon, NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            _homematicDaemon = homematicDaemon;
        }

        public IEnumerable<Device> LoadedDevices { get; set; }

        public Task InitializeAsync()
        {
            LoadedDevices = _homematicDaemon.GetDevices();

            return Task.CompletedTask;
        }

        public void OpenChannels(Device device)
        {
            this._navigationManager.NavigateTo($"devices/{device.Address}/channels");
        }
    }
}
