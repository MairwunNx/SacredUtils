using System.Net.NetworkInformation;

namespace SacredUtils.resources.bin
{
    public static class CheckAvailabilityInternetConnection
    {
        public static bool Connect()
        {
            try
            {
                return new Ping().Send("www.google.com.mx").Status == IPStatus.Success;
            }
            catch
            {
                return false;
            }
        }
    }
}
