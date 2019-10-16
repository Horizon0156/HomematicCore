using System;
using System.Linq;

namespace HomematicCore.Homematic.Daemon.Domain
{
    public class EntityWithParameters
    {
        private string[] _commonParamterSetNames = new string[] {};

        public EntityWithParameters(params string[] commonParameterSetName)
        {
            _commonParamterSetNames = commonParameterSetName;
        }

        /// <summary>
        ///     Gets or sets the names of available parameter sets 
        ///     on this device
        /// </summary>
        public string[] ParameterSetNames { get; set; }

        /// <summary>
        ///     Gets or sets the names of common parameter sets 
        ///     on this channel.
        /// </summary>
        public string [] CommonParameterSetNames => GetCommonParameterSetNames();

        private string[] GetCommonParameterSetNames() 
        {
            return this.ParameterSetNames.Where(s => _commonParamterSetNames.Contains(s)).ToArray();
        }
    }
}
