
namespace HomematicCore.Homematic.Client.Factories
{
    public interface IHomematicClientFactory
    {
        IHomematicClient CreateHomematicClient(string rpcDeamonAddress, int port);
    }
}