using System.Net.NetworkInformation;

namespace SacredUtils.resources.bin
{
    public static class CheckAvailabilityInternetConnection
    {
        public static bool Connect = NetworkInterface.GetIsNetworkAvailable();
    }
}
