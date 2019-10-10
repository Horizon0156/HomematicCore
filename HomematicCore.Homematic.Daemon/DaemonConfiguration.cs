
namespace HomematicCore.Homematic.Daemon
{
    /// <summary>
    ///     Configration properties for the Homematic Daemon.
    /// </summary>
    public class DaemonConfiguration
    {
        /// <summary>
        ///     Creates a daemon configuration. 
        /// </summary>
        /// <param name="endpointAddress"> Endpoint address of the CCU / service where the daemon connects to. </param>
        /// <param name="port"> The corresponding port. </param>
        public DaemonConfiguration(string endpointAddress, int port)
        {
            EndpointAddress = endpointAddress;
            Port = port;
        }

        /// <summary>
        ///     Gets the endpoint address of the CCU / service where the daemon connects to.
        /// </summary>
        public string EndpointAddress { get; set; }

        /// <summary>
        ///     Gets the port.
        /// </summary>
        public int Port { get; set; }
    }
}
