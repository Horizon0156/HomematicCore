using System.Collections.Generic;
using AutoMapper;
using HomematicCore.Homematic.Client.Entities;
using HomematicCore.Homematic.Daemon.Domain;
using Horizon.XmlRpc.Core;

namespace HomematicCore.Homematic.Daemon.Profiles
{
    public class EntityDomainProfile : Profile
    {
        public EntityDomainProfile()
        {
            SetupMappings();
        }

        private void SetupMappings()
        {
            CreateMap<DeviceDescription, Device>()
                .ForMember(d => d.ParameterSetNames, cfg => cfg.MapFrom(d => d.ParameterSets))
                .ForMember(d => d.IsUpdateAvailable, cfg => cfg.Ignore())
                .ForMember(d => d.Channels, cfg => cfg.Ignore())
                .ForMember(d => d.CommonParameterSetNames, cfg => cfg.Ignore());

            CreateMap<DeviceDescription, Channel>()
                .ForMember(c => c.ParameterSetNames, cfg => cfg.MapFrom(c => c.ParameterSets))
                .ForMember(c => c.Device, cfg => cfg.Ignore())
                .ForMember(d => d.CommonParameterSetNames, cfg => cfg.Ignore());

            CreateMap<XmlRpcStruct, ParameterSetDescription>()
                .ConvertUsing<XmlRpcStructConverter>();

            CreateMap<XmlRpcStruct, ParameterSet>()
                .ConvertUsing<XmlRpcStructConverter>();
        }
    }
}