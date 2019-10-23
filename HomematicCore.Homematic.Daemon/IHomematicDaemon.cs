using System.Collections.Generic;
using System.Threading.Tasks;
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
        Task<IEnumerable<Device>> GetDevicesAsync(bool forceReload = false);

        /// <summary>
        ///     Gets a specific devices registered at the daemon.
        /// </summary>
        /// <param name="address"> The address of the device </param>
        /// <param name="forceReload"> 
        ///     Flag indicating whether the devices has to be loaded from 
        ///     the daemon instead of return cached ones. 
        /// </param> 
        /// <returns> Devices if found, otherwise <c>null</c>. </returns>
        Task<Device> GetDeviceAsync(string address, bool forceReload = false);

        /// <summary>
        ///     Gets the given parameter set description for a specific device / channel.
        /// </summary>
        /// <param name="address"> Address of the device / channel </param>
        /// <param name="parameterSetName"> Name of the parameter set (e.g. VALUES) </param>
        /// <returns> Parameter set description by parameter name </returns>
        ParameterSetDescription GetParameterSetDescription(string address, string parameterSetName);

        /// <summary>
        ///     Gets the given parameter value set for a specific device / channel.
        /// </summary>
        /// <param name="address"> Address of the device / channel </param>
        /// <param name="parameterSetName"> Name of the parameter set (e.g. VALUES) </param>
        /// <returns> Parameter values by parameter name </returns>
        ParameterSet GetParameterSet(string address, string parameterSetName);

        /// <summary>
        ///     Sets a parameter in the VALUE set on a device / channel.
        /// </summary>
        /// <param name="address"> The address of the device / channel. </param>
        /// <param name="valueKey"> The name of the parameter (e.g. STATE) </param>
        /// <param name="value"> The value. </param>
        void SetValue(string address, string valueKey, object value);

        void PutParamset(string address, string parameterSetName, ParameterSet parameterSet);

        /// <summary>
        ///     Gets the remaining time the daemon is in installation mode.
        /// </summary>
        /// <returns> 
        ///     The remaining time in seconds. 
        ///     <c>0</c> if the installation mode is disabled. 
        /// </returns>
        int GetRemainingSecondsInInstallationMode();

        /// <summary>
        ///     Disables the installation mode.
        /// </summary>
        void DisableInstallationMode();

        /// <summary>
        ///     Enables the installation mode for a number of seconds.
        /// </summary>
        /// <param name="secods"> The number of seconds, defaults to 60 </param>
        void EnableInstallationMode(int secods = 60);

        // <summary>
        ///     Enables the trusted installation mode for a number of seconds.
        /// </summary>
        /// <param name="whitelist"> List of trusted HmIP devices keys (see QR Code) </param>
        /// <param name="secods"> The number of seconds, defaults to 60 </param>
        /// <remarks> Only for HmIP daemons </remarks>
        void EnableInstallationModeWithWhitelist(IEnumerable<HmIpDeviceKey> whitelist, int seconds = 60);

        /// <summary>
        ///     Gets all pending service messages.
        /// </summary>
        /// <returns> List of service messages. </returns>
        Task<IEnumerable<ServiceMessage>> GetServiceMessagesAsync();
    }
}
