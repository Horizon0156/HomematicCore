using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HomematicCore.Homematic.Daemon.Domain;
using Horizon.XmlRpc.Core;

namespace HomematicCore.Homematic.Daemon.Profiles
{
    public class XmlRpcStructConverter : 
        ITypeConverter<XmlRpcStruct, ParameterSetDescription>,
        ITypeConverter<XmlRpcStruct, ParameterSet>,
        ITypeConverter<ParameterSet, XmlRpcStruct>
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

        public XmlRpcStruct Convert(ParameterSet source, XmlRpcStruct destination, ResolutionContext context)
        {
            var parameterSet =  new XmlRpcStruct();
            
            foreach (var parameter in source.Where(p => p.Value != null)) {

                parameterSet.Add(parameter.Key, parameter.Value);
            }

            return parameterSet;
        }

        private ParameterDescription ConvertParameterDescription(XmlRpcStruct source)
        {
            return new ParameterDescription
            {
                ParameterType = (ParameterTypes) Enum.Parse(typeof(ParameterTypes), source["TYPE"].ToString(), ignoreCase: true),
                Flags = (int) source["FLAGS"],
                DefaultValue = source["DEFAULT"],
                MinValue = source["MIN"],
                MaxValue = source["MAX"],
                Unit = source["UNIT"]?.ToString(),
                ValueList = source.ContainsKey("VALUE_LIST")
                     ? ConvertValueList((object[]) source["VALUE_LIST"])
                     : null
            };
        }

        private IEnumerable<EnumMemberDescription> ConvertValueList(object[] valueList)
        {
            var enumMembers = new List<EnumMemberDescription>();
            
            for (var i = 0; i < valueList.Length; i++)
            {
                var key = valueList[i].ToString();
                if (key != string.Empty)
                {
                    enumMembers.Add(new EnumMemberDescription { Key = key, Value = i });
                }
            }

            return enumMembers;
        }
    }
}
