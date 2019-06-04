using System;
using System.Net;

namespace SacredUtils.SourceFiles
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
            catch (Exception)
            {
                return false;
            }
        }

        public static void LogStatus()
        {
            if (AppSettings.ApplicationSettings.DisableCheckInternetConnection)
            {
                Logger.Log.Warn("Checking for internet connection was skipped!");
            }

            if (Connect())
            {
                Logger.Log.Info("SacredUtils application running in online mode!");
            }
            else
            {
                Logger.Log.Warn("SacredUtils application running in offline mode!");
            }
        }
    }
}
