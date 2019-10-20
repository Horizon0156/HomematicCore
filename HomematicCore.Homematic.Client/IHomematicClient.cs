using HomematicCore.Homematic.Client.Entities;
using Horizon.XmlRpc.Core;

namespace HomematicCore.Homematic.Client 
{
    public interface IHomematicClient
    {
        [XmlRpcMethod("listDevices")]
        DeviceDescription[] ListDevices();

        [XmlRpcMethod("getParamsetDescription")]
        XmlRpcStruct GetParamsetDescription(string address, string parameterSetName);

        [XmlRpcMethod("getParamset")]
        XmlRpcStruct GetParamset(string address, string parameterSetName);

        [XmlRpcMethod("setValue")]
        void SetValue(string address, string valueKey, object value);

        [XmlRpcMethod("putParamset")]
        void PutParamset(string address, string parameterSetName, XmlRpcStruct parameterSet);
    }
}