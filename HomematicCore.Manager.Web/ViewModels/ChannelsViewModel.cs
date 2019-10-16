using System.Collections.Generic;
using HomematicCore.Homematic.Daemon;
using HomematicCore.Homematic.Daemon.Domain;

namespace HomematicCore.Manager.Web.ViewModels
{
    public class ChannelsViewModel
    {
        private string _parentAddress;

        public string ParentAddress 
        {
            get => _parentAddress;
            set 
            {
                _parentAddress = value;
                OnParentAddressChanged();
            }
        }
        public IEnumerable<Channel> AvailableChannels { get; set; }
        
        private readonly IHomematicDaemon _homematicDaemon;


        public ChannelsViewModel(IHomematicDaemon homematicDaemon)
        {
            _homematicDaemon = homematicDaemon;
        }

        public void LoadParameterSet(Channel channel, string parameterSetName)
        {
            var desc = _homematicDaemon.GetParameterSetDescription(channel.Address, parameterSetName);
            var val = _homematicDaemon.GetParameterSet(channel.Address, parameterSetName);
        }

        private void OnParentAddressChanged()
        {
            AvailableChannels = _homematicDaemon.GetDevice(ParentAddress)?.Channels;
        }
    }
}
