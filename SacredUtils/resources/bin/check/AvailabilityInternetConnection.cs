using System.Net.NetworkInformation;

namespace SacredUtils.resources.bin.check
{
    public static class AvailabilityInternetConnection
    {
        public static bool Connect = NetworkInterface.GetIsNetworkAvailable();
    }
}
