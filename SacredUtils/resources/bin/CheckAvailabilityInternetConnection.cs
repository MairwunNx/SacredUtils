using System.Net.NetworkInformation;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class CheckAvailabilityInternetConnection
    {
        public static bool Connect() => NetworkInterface.GetIsNetworkAvailable();

        public static void GetConnect()
        {
            if (AppSettings.ApplicationSettings.DisableCheckInternetConnection) { return; }
            if (!Connect()) { Log.Warn("SacredUtils application running in offline mode!"); }
            else { Log.Info("SacredUtils application running in online mode!"); }
        }
    }
}
