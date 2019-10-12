using Horizon.XmlRpc.Core;

namespace HomematicCore.Homematic.Client.Entities 
{
    public class DeviceDescription 
    {
        /// <summary>
        ///     Gets or sets the type of the device.
        /// </summary>
        [XmlRpcMember("TYPE")]
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the address of the device or channel.
        /// </summary>
        [XmlRpcMember("ADDRESS")]
        public string Address { get; set; }

        /// <summary>
        ///     Gets or sets the RF address of the device (optional).
        /// </summary>
        [XmlRpcMember("RF_ADDRESS")]
        public int RfAddress { get; set; }

        /// <summary>
        ///     Gets or sets channels addresses of this device.
        /// </summary>
        /// <remark> Only set for devices. </remark>
        [XmlRpcMember("CHILDREN")]
        public string[] ChildAddresses { get; set; }

        /// <summary>
        ///     Gets or sets the parent device address for a channel.
        /// </summary>
        /// <remark> Empty for devices. </remark>
        [XmlRpcMember("PARENT")]
        public string ParentAddress { get; set; }

        /// <summary>
        ///     Gets or sets the type of the parent device.
        /// </summary>
        /// <remark> Only for channels </remark>
        [XmlRpcMember("PARENT_TYPE")]
        public string ParentType { get; set; }

        /// <summary>
        ///     Gets or sets the index of the device channel.
        /// </summary>
        /// <remark> Only for channels </remark>
        [XmlRpcMember("INDEX")]
        public int Index { get; set; }

        /// <summary>
        ///     Gets or sets a flag indicating whether secure transmission is active
        ///     on this channel.
        /// </summary>
        [XmlRpcMember("AES_ACTIVE")]
        public int AesActive { get; set; }

        /// <summary>
        ///     Gets or sets the names of available parameter sets 
        ///     on this device channel
        /// </summary>
        [XmlRpcMember("PARAMSETS")]
        public string[] ParameterSets { get; set; }
        
        /// <summary>
        ///     Gets or sets the version of the installed firmware.
        /// </summary>
        [XmlRpcMember("FIRMWARE")]
        public string InstalledFirmware { get; set; }

        /// <summary>
        ///     Gets or sets the version of an available firmware.
        /// </summary>
        [XmlRpcMember("AVAILABLE_FIRMWARE")]
        public string AvailableFirmware { get; set; }

        /// <summary>
        ///     Gets or sets the direction of the device channel.
        ///     0 = None, 1 = Sender, 2 = Receiver
        /// </summary>
        /// <remark> Only for channels </remark>
        [XmlRpcMember("DIRECTION")]
        public int Direction { get; set; }

        // Todo: Add other parameters
    }
}