using System.Collections.Generic;
using System.Threading.Tasks;
using HomematicCore.Homematic.Daemon;
using HomematicCore.Homematic.Daemon.Domain;

namespace HomematicCore.Manager.Web.ViewModels
{
    public class ServiceMessagesViewModel
    {
        private readonly IHomematicDaemon _homematicDaemon;

        public bool IsBusy { get; set; }

        public ServiceMessagesViewModel(
            IHomematicDaemon homematicDaemon)
        {
            _homematicDaemon = homematicDaemon;
            ServiceMessages = new List<ServiceMessage>();
        }

        public IEnumerable<ServiceMessage> ServiceMessages { get; set; }

        public async Task InitializeAsync()
        {
            IsBusy = true;
            ServiceMessages = await _homematicDaemon.GetServiceMessagesAsync();
            IsBusy = false;
        }
    }
}
