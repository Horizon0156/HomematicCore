using System;
using Horizon.XmlRpc.Core;

namespace HomematicCore.Homematic.Client.Entities
{
    /// <summary>
    ///     Defines a whitelist record for HmIP device registration.
    /// </summary>
    public class HmIpWhitelistValue
    {
        /// <summary>
        ///     Gets or sets the full STGIN address of the device
        /// </summary>
        [XmlRpcMember("ADDRESS")]
        public string Address { get; set; }

        /// <summary>
        ///     Gets the mode for the key comparision.
        /// </summary>
        /// <remarks>
        ///     Only LOCAL is right now supported by HmIP.
        /// </remarks>
        [XmlRpcMember("KEY_MODE")]
        public string KeyMode => "LOCAL";

        /// <summary>
        ///     Gets or sets the hexadeximal key of the device (16 Byte)
        /// </summary>
        [XmlRpcMember("KEY")]
        public string Key { get; set; }
    }
}
