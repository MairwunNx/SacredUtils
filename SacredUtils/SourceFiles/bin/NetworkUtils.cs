using System;
using System.Net;
using static SacredUtils.Logger;

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
            catch (Exception)
            {
                return false;
            }
        }

        public static void LogStatus()
        {
            if (AppSettings.ApplicationSettings.DisableCheckInternetConnection)
            {
                Log.Warn("Checking for internet connection was skipped!");
            }

            if (Connect())
            {
                Log.Info("SacredUtils application running in online mode!");
            }
            else
            {
                Log.Warn("SacredUtils application running in offline mode!");
            }
        }
    }
}
