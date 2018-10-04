using System.Net.NetworkInformation;

namespace SacredUtils.resources.bin
{
    public static class CheckAvailabilityInternetConnection
    {
        public static bool Connect()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }

        public static void GetConnect()
        {
            if (!Connect())
            {
                AppLogger.Log.Warn("SacredUtils application running in offline mode!");
            }
            else
            {
                AppLogger.Log.Info("SacredUtils application running in online mode!");
            }
        }
    }
}
