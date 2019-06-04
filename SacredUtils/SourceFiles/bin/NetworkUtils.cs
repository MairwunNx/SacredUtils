using System.Net;

namespace SacredUtils.SourceFiles.bin
{
    public static class NetworkUtils
    {
        public static bool Connect()
        {
            if (AppSettings.ApplicationSettings.DisableCheckInternetConnection) return true;
            try
            {
                using WebClient webClient = new WebClient();
                using (webClient.OpenRead(
                    AppSettings.ApplicationSettings.InternetConnectionPingProvider
                ))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static void LogStatus()
        {
            if (AppSettings.ApplicationSettings.DisableCheckInternetConnection) return;

            if (!Connect()) AppLogger.Log.Warn("SacredUtils application running in offline mode!");
            else AppLogger.Log.Info("SacredUtils application running in online mode!");
        }
    }
}
