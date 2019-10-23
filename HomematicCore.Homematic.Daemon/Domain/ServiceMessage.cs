
namespace HomematicCore.Homematic.Daemon.Domain
{
    /// <summary>
    ///     A service message send by a device or channel.
    /// </summary>
    public class ServiceMessage
    {
        /// <summary>
        ///     Gets or sets the address of the device / channel that sends this service message
        /// </summary>
        public string SenderAddress { get; set; }

        /// <summary>
        ///     Gets or sets the ID of this service message.
        /// </summary>
        public string ServiceMessageId { get; set; }

        /// <summary>
        ///     Gets or sets an optional value.
        /// </summary>
        public object Value { get; set; }
    }
}
