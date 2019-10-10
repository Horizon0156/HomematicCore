using System;
using System.Collections.Generic;
using AutoMapper;
using HomematicCore.Homematic.Client;
using HomematicCore.Homematic.Client.Factories;
using HomematicCore.Homematic.Daemon.Domain;

namespace HomematicCore.Homematic.Daemon
{
    /// <summary>
    ///     Implementation of a Homematic Daemon using XmlRpc to connect to 
    ///     the proper CCU / service endoint.
    /// </summary>
    public class HomematicDaemon : IHomematicDaemon
    {
        private readonly IHomematicClient _homematicClient;
        private readonly IMapper _mapper;

        /// <summary>
        ///     Creates a new instance of the Homematic daemon.
        /// </summary>
        /// <param name="clientFactory"> An instance of a Homematic client factory. </param>
        /// <param name="mapper"> An instance of a configured mapper. </param>
        /// <param name="configuration"> The configuration of this daemon. </param>
        public HomematicDaemon(
            IHomematicClientFactory clientFactory, 
            IMapper mapper,
            DaemonConfiguration configuration)
        {
            _homematicClient = clientFactory.CreateHomematicClient(
                configuration.EndpointAddress, 
                configuration.Port);
            _mapper = mapper;
        }

        /// <inheritdoc />
        public IEnumerable<Device> GetDevices()
        {
            var deviceDescriptions = this._homematicClient.ListDevices();
            var convertedDevices = new Dictionary<string, Device>();

            foreach (var deviceDescription in deviceDescriptions) 
            {
                var isDevice = string.IsNullOrEmpty(deviceDescription.ParentAddress);
                
                if (isDevice) 
                {
                    convertedDevices.Add(
                        deviceDescription.Address, 
                        _mapper.Map<Device>(deviceDescription));
                }
            }

            foreach (var deviceDescription in deviceDescriptions) 
            {
                var isChannel = !string.IsNullOrEmpty(deviceDescription.ParentAddress);

                if (isChannel)
                {
                    var parentDevice = convertedDevices[deviceDescription.ParentAddress];
                    parentDevice.Channels.Add(_mapper.Map<Channel>(deviceDescription));
                }
            }
            return convertedDevices.Values;
        }
    }
}
