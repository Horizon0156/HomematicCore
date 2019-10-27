
namespace HomematicCore.Homematic.Daemon.Domain
{
    public class BidcosInterface
    {
        public string Address { get; set; }

        public string Description { get; set; }

        public bool IsConnected { get; set; }

        public bool IsDefault { get; set; }

        public string Type { get; set; }

        public string FirmwareVersion { get; set; }

        public int DutyCycleInPercent { get; set; }
    }
}
