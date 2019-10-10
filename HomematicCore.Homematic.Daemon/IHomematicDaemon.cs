using System.Collections.Generic;
using HomematicCore.Homematic.Daemon.Domain;

namespace HomematicCore.Homematic.Daemon
{
    /// <summary>
    ///     Interface for a Homematic daemon.
    /// </summary>
    public interface IHomematicDaemon
    {
        /// <summary>
        ///     Gets the devices registered at the daemon.
        /// </summary>
        /// <returns> Set of registered devices. </returns>
        IEnumerable<Device> GetDevices();
    }
}
