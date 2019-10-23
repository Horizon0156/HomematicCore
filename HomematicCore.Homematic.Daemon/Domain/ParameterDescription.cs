
using System.Collections.Generic;

namespace HomematicCore.Homematic.Daemon.Domain
{
    public class ParameterDescription
    {
        public ParameterTypes ParameterType { get; set; }

        public int Flags { get; set; }

        public object DefaultValue { get; set; }

        public object MinValue { get; set; }

        public object MaxValue { get; set; }

        public string Unit { get; set; }

        public IEnumerable<EnumMemberDescription> ValueList { get; set; }
    }
}