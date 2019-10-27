using System;
using System.Linq;
using System.Threading.Tasks;
using HomematicCore.Homematic.Daemon;

namespace HomematicCore.Manager.Web.ViewModels
{
    public class DaemonStatusViewModel
    {
        private readonly IHomematicDaemon _daemon;

        public bool IsBusy { get; set; }

        public bool IsConnected { get; set; }

        public int? DutyCycleInPercent { get; set; }

        public DaemonStatusViewModel(IHomematicDaemon daemon)
        {
            _daemon = daemon;
        }

        public async Task InitializeAsync() 
        {
            IsBusy = true;

            var interfaces = await _daemon.GetInterfacesAsync();
            var defaultInterface = interfaces.FirstOrDefault(i => i.IsDefault);

            IsConnected = defaultInterface?.IsConnected ?? false;
            DutyCycleInPercent = defaultInterface?.DutyCycleInPercent;
            
            IsBusy = false;
        }
    }
}
