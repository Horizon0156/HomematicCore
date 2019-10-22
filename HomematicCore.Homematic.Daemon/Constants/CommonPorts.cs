using System;

namespace HomematicCore.Homematic.Daemon.Constants
{
    /// <summary>
    ///     Constants for common Homematic port configurations.
    /// </summary>
    public static class CommonPorts
    {
        /// <summary>
        ///     The default port for Homematic Wired (BidcosWired)
        /// </summary>
        public static int HomematicWired => 2000;

        /// <summary>
        ///     The default port for legacy Homematic (BidcosRf)
        /// </summary>
        public static int Homematic => 2001;

        /// <summary>
        ///     The default port for HomematicIp
        /// </summary>
        public static int HomematicIp => 2010;
    }
}
