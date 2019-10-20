using System;
using System.Collections.Generic;

namespace HomematicCore.Homematic.Daemon.Domain
{
    public class ParameterSet : Dictionary<string, object>
    {
        public object GetValue(string key) 
        {
            object value = null;
            TryGetValue(key, out value);

            return value;
        }
    }
}
