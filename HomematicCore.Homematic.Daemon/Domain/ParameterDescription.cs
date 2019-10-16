
namespace HomematicCore.Homematic.Daemon.Domain
{
    public class ParameterDescription
    {
        public string ParameterType { get; set; }
        public int Operations { get; set; }
        public int Flags { get; set; }
        public object DefaultValue { get; set; }
        public object MinValue { get; set; }
        public object MaxValue { get; set; }
        public string Unit { get; set; }
        public int TabOrder { get; set; }
        public string Control { get; set; }
        public string[] ValueList { get; set; }
    }
}