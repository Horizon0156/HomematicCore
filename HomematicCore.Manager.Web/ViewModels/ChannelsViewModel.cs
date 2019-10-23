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

        public ParameterDialogViewModel ParameterDialogViewModel { get; }

        public IEnumerable<Channel> AvailableChannels { get; set; }
        
        private readonly IHomematicDaemon _homematicDaemon;

        public ChannelsViewModel(IHomematicDaemon homematicDaemon, ParameterDialogViewModel parameterDialogViewModel)
        {
            _homematicDaemon = homematicDaemon;
            ParameterDialogViewModel = parameterDialogViewModel;
        }

        public void ShowParameterSet(Channel channel, string parameterSetName)
        {
            ParameterDialogViewModel.OpenParameterDialog(channel.Address, parameterSetName);
        }

        // Todo: Handle properly
        private async void OnParentAddressChanged()
        {
            AvailableChannels = (await _homematicDaemon.GetDeviceAsync(ParentAddress))?.Channels;
        }
    }
}
