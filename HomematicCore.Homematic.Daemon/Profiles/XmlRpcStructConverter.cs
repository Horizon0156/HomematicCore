using AutoMapper;
using HomematicCore.Homematic.Daemon.Domain;
using Horizon.XmlRpc.Core;

namespace HomematicCore.Homematic.Daemon.Profiles
{
    public class XmlRpcStructConverter : 
        ITypeConverter<XmlRpcStruct, ParameterSetDescription>,
        ITypeConverter<XmlRpcStruct, ParameterSet>
    {
        public ParameterSetDescription Convert(XmlRpcStruct source, ParameterSetDescription destination, ResolutionContext context)
        {
            var parameterSet = new ParameterSetDescription();

            foreach (var key in source.Keys) 
            {
                parameterSet.Add(key.ToString(), ConvertParameterDescription((XmlRpcStruct) source[key]));
            }

            return parameterSet;
        }

        public ParameterSet Convert(XmlRpcStruct source, ParameterSet destination, ResolutionContext context)
        {
            var parameterSet = new ParameterSet();

            foreach (var key in source.Keys) 
            {
                parameterSet.Add(key.ToString(), source[key]);
            }

            return parameterSet;
        }

        private ParameterDescription ConvertParameterDescription(XmlRpcStruct source)
        {
            return new ParameterDescription
            {
                ParameterType = source["TYPE"]?.ToString(),
                Operations = (int) source["OPERATIONS"],
                Flags = (int) source["FLAGS"],
                DefaultValue = source["DEFAULT"],
                MinValue = source["MIN"],
                MaxValue = source["MAX"],
                Unit = source["UNIT"]?.ToString(),
                //TabOrder = (int) source["TAB_ORDER"]
                // Control = xmlRpcStruct.ContainsKey("CONTROL")
                //     ? xmlRpcStruct["Control"].ToString()
                //     : null,
                // ValueList = xmlRpcStruct.ContainsKey("VALUE_LIST")
                //     ? (string[]) xmlRpcStruct["VALUE_LIST"]
                //     : null
            };
        }
    }
}
