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
        /// <param name="forceReload"> 
        ///     Flag indicating whether the devices has to be loaded from 
        ///     the daemon instead of return cached ones. 
        /// </param> 
        /// <returns> Set of registered devices. </returns>
        IEnumerable<Device> GetDevices(bool forceReload = false);

        /// <summary>
        ///     Gets a specific devices registered at the daemon.
        /// </summary>
        /// <param name="address"> The address of the device </param>
        /// <param name="forceReload"> 
        ///     Flag indicating whether the devices has to be loaded from 
        ///     the daemon instead of return cached ones. 
        /// </param> 
        /// <returns> Devices if found, otherwise <c>null</c>. </returns>
        Device GetDevice(string address, bool forceReload = false);
    }
}
