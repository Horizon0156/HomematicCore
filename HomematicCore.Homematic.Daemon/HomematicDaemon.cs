using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HomematicCore.Homematic.Client;
using HomematicCore.Homematic.Client.Factories;
using HomematicCore.Homematic.Daemon.Domain;
using Horizon.XmlRpc.Core;
using Microsoft.Extensions.Caching.Memory;

namespace HomematicCore.Homematic.Daemon
{
    /// <summary>
    ///     Implementation of a Homematic Daemon using XmlRpc to connect to 
    ///     the proper CCU / service endoint.
    /// </summary>
    public class HomematicDaemon : IHomematicDaemon
    {
        private readonly IHomematicClient _homematicClient;

        private readonly IMemoryCache _cache;

        private readonly IMapper _mapper;

        private readonly int _cacheId;

        /// <summary>
        ///     Creates a new instance of the Homematic daemon.
        /// </summary>
        /// <param name="clientFactory"> An instance of a Homematic client factory. </param>
        /// <param name="mapper"> An instance of a configured mapper. </param>
        /// <param name="cache"> An instance of a memory cache. </param>
        /// <param name="configuration"> The configuration of this daemon. </param>
        public HomematicDaemon(
            IHomematicClientFactory clientFactory, 
            IMapper mapper,
            IMemoryCache cache,
            DaemonConfiguration configuration)
        {
            _cacheId = $"{configuration.EndpointAddress}{configuration.Port}".GetHashCode();
            _homematicClient = clientFactory.CreateHomematicClient(
                configuration.EndpointAddress, 
                configuration.Port);
            
            _mapper = mapper;
            _cache = cache;
        }

        /// <inheritdoc />
        public Device GetDevice(string address, bool forceReload)
        {
            return GetDevices(forceReload).FirstOrDefault(d => d.Address == address);
        }

        /// <inheritdoc />
        public IEnumerable<Device> GetDevices(bool forceReload)
        {
            if (forceReload || !_cache.TryGetValue<IEnumerable<Device>>(_cacheId, out var cachedDevices)) {

                cachedDevices = GetDevicesFromDaemon();
                _cache.Set(_cacheId, cachedDevices, new TimeSpan(0, 10, 0));
            }

            return cachedDevices;
        }

        /// <inheritdoc />
        public ParameterSetDescription GetParameterSetDescription(string address, string parameterSetName)
        {
            var result = _homematicClient.GetParamsetDescription(address, parameterSetName);

            return _mapper.Map<ParameterSetDescription>(result);
        }

        /// <inheritdoc />
        public ParameterSet GetParameterSet(string address, string parameterSetName)
        {
            var result = _homematicClient.GetParamset(address, parameterSetName);

            return _mapper.Map<ParameterSet>(result);
        }

        private IEnumerable<Device> GetDevicesFromDaemon() 
        {
            var deviceDescriptions = _homematicClient.ListDevices();
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

        /// <inheritdoc />
        public void SetValue(string address, string valueKey, object value)
        {
            _homematicClient.SetValue(address, valueKey, value);
        }

        /// <inheritdoc />
        public void PutParamset(string address, string parameterSetName, ParameterSet parameterSet)
        {
            var convertedSet = _mapper.Map<XmlRpcStruct>(parameterSet);

            _homematicClient.PutParamset(address, parameterSetName, convertedSet);
        }
    }
}
