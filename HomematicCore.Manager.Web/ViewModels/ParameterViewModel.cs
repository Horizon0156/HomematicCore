using HomematicCore.Homematic.Daemon.Domain;
using System.Collections.Generic;

namespace HomematicCore.Manager.Web.ViewModels
{
    public class ParameterViewModel
    {
        public string Name { get; set; }

        public object DefaultValue { get; set; }

        public string Unit { get; set; }

        public ParameterTypes ParameterType { get; set; }

        public object Value { get; set; }

        public IEnumerable<EnumMemberDescription> ValueList { get; set; }

        public int? IntValue
        {
            get => (int?)Value;
            set => Value = value;
        }

        public bool? BoolValue
        {
            get => (bool?)Value;
            set => Value = value;
        }

        public string StringValue
        {
            get => (string)Value;
            set => Value = value;
        }

        public double? DoubleValue
        {
            get => (double?)Value;
            set => Value = value;
        }
    }
}