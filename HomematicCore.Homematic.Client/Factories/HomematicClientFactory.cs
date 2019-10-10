using HomematicCore.Homematic.Client.Proxies;
using Horizon.XmlRpc.Client;

namespace HomematicCore.Homematic.Client.Factories
{
    public class HomematicClientFactory : IHomematicClientFactory
    {
        public static IHomematicClientFactory Default => new HomematicClientFactory();
        
        public IHomematicClient CreateHomematicClient(string rpcDeamonAddress, int port)
        {
            var proxy = XmlRpcProxyGen.Create<IHomematicClientProxy>();
            proxy.Url = $"http://{rpcDeamonAddress}:{port}";
            
            return proxy;
        }
    }
}