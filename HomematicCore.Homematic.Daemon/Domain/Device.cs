using System.Collections.Generic;

namespace HomematicCore.Homematic.Daemon.Domain
{
    /// <summary>
    ///     Domain object for a Homematic device.
    /// </summary>
    public class Device
    {
        /// <summary>
        ///     Creates an empty device.
        /// </summary>
        public Device()
        {
            Channels = new List<Channel>();
        }

        /// <summary>
        ///     Gets or sets the type of the device.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the address of the device.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     Gets or sets the channel of this device.
        /// </summary>
        public List<Channel> Channels { get; set; }

        /// <summary>
        ///     Gets or sets the names of available parameter sets 
        ///     on this device
        /// </summary>
        public string[] ParameterSetNames { get; set; }
        
        /// <summary>
        ///     Gets or sets the version of the installed firmware.
        /// </summary>
        public string InstalledFirmware { get; set; }

        /// <summary>
        ///     Gets or sets the version of an available firmware.
        /// </summary>
        public string AvailableFirmware { get; set; }

        /// <summary>
        ///     Gets or sets a flag indicating whether an update is available.
        /// </summary>
        public bool IsUpdateAvailable => InstalledFirmware != AvailableFirmware;
    }
}
