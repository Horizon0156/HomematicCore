using System.Collections.Generic;
using System.Threading.Tasks;
using HomematicCore.Homematic.Daemon;
using HomematicCore.Homematic.Daemon.Domain;

namespace HomematicCore.Manager.Web.ViewModels
{
    public class DevicesViewModel
    {
        private Dictionary<string, bool> _areDetailsOpenByDeviceAddress = new Dictionary<string, bool>();
        private readonly IHomematicDaemon _homematicDaemon;

        public DevicesViewModel(IHomematicDaemon homematicDaemon)
        {
            _homematicDaemon = homematicDaemon;
        }

        public IEnumerable<Device> LoadedDevices { get; set; }

        public Task InitializeAsync()
        {
            LoadedDevices = _homematicDaemon.GetDevices();
            
            return Task.CompletedTask;
        }

        public void ToogleDetails(string deviceAddress)
        {
            this._areDetailsOpenByDeviceAddress[deviceAddress] = !AreDetailsOpen(deviceAddress);
        }

        public bool AreDetailsOpen(string deviceAddress)
        {
            return _areDetailsOpenByDeviceAddress.GetValueOrDefault(deviceAddress);
        }
    }
}
