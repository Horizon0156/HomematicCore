using System.Collections.Generic;
using HomematicCore.Homematic.Client.Entities;
using Horizon.XmlRpc.Core;

namespace HomematicCore.Homematic.Client 
{
    public interface IHomematicClient
    {
        [XmlRpcMethod("listDevices")]
        DeviceDescription[] ListDevices();
    }
}