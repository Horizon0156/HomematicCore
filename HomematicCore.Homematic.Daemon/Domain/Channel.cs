
using System.Linq;

namespace HomematicCore.Homematic.Daemon.Domain
{
    /// <summary>
    ///     Domain object for a Homematic device.
    /// </summary>
    public class Channel : EntityWithParameters
    {
        /// <summary>
        ///     Creates a new instance of a channel.
        /// </summary>
        public Channel() : base("MASTER", "VALUES")
        {
        }

        /// <summary>
        ///     Gets or sets the type of the channel.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     Gets or sets the address of the device.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     Gets or sets the device of this channel.
        /// </summary>
        public Device Device { get; set; }

        /// <summary>
        ///     Gets or sets the index of this channel.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        ///     Gets or sets the direction of this channel
        /// </summary>
        public ChannelDirection Direction { get; set; }
    }
}
