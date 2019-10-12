namespace HomematicCore.Homematic.Daemon.Domain
{
    /// <summary>
    ///     Enumeration for directions of a channel.
    /// </summary>
    public enum ChannelDirection
    {
        /// <summary>
        ///     Channel does not transport anything and therefore cannot be linked
        /// </summary>
        None,

        /// <summary>
        ///     Channel is a sender
        /// </summary>
        Sender,

        /// <summary>
        ///     Channel is a receiver
        /// </summary>
        Receiver
    }
}