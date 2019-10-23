using System.Collections.Generic;
using AutoMapper;
using HomematicCore.Homematic.Daemon.Domain;

namespace HomematicCore.Homematic.Daemon.Profiles
{
    public class ServiceMessagesConverter : 
        ITypeConverter<object[][], IEnumerable<ServiceMessage>>
    {
        public IEnumerable<ServiceMessage> Convert(object[][] source, IEnumerable<ServiceMessage> destination, ResolutionContext context)
        {
            var serviceMessages = new List<ServiceMessage>();

            // From Homematic specification: 
            // The return value is an array with one element per message. 
            // Each message itself is an array with three fields (Address, Service Id, Value)
            foreach (var rawMessage in source)
            {
                serviceMessages.Add(new ServiceMessage
                {
                    SenderAddress = (string)rawMessage[0],
                    ServiceMessageId = (string)rawMessage[1],
                    Value = rawMessage[2],
                });
            }

            return serviceMessages;
        }
    }
}
