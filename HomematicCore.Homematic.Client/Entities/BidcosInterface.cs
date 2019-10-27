using System;
using Horizon.XmlRpc.Core;

namespace HomematicCore.Homematic.Client.Entities
{
    public class BidcosInterface
    {
        [XmlRpcMember("ADDRESS")]
        public string Address { get; set; }

        [XmlRpcMember("DESCRIPTION")]
        public string Description { get; set; }

        [XmlRpcMember("CONNECTED")]
        public bool IsConnected { get; set; }

        [XmlRpcMember("DEFAULT")]
        public bool IsDefault { get; set; }

        [XmlRpcMember("TYPE")]
        public string Type { get; set; }

        [XmlRpcMember("FIRMWARE_VERSION")]
        public string FirmwareVersion { get; set; }

        [XmlRpcMember("DUTY_CYCLE")]
        public int DutyCycleInPercent { get; set; }
    }
}
