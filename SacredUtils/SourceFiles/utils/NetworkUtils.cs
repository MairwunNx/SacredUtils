using System;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace SacredUtils.SourceFiles.utils
{
    public static class NetworkUtils
    {
        public static readonly Lazy<bool> IsConnected = new Lazy<bool>(() =>
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
        });

        public static void LogStatus()
        {
            if (AppSettings.ApplicationSettings.DisableCheckInternetConnection)
            {
                Logger.Log.Warn("Checking for internet connection was skipped!");
            }

            if (IsConnected.Value)
            {
                Logger.Log.Info("SacredUtils application running in online mode!");
            }
            else
            {
                Logger.Log.Warn("SacredUtils application running in offline mode!");
            }
        }

        public static void ShowNoConnection()
        {
            if (!AppSettings.ApplicationSettings.VisibleNoConnectionImage ||
                IsConnected.Value)
            {
                return;
            }

            Application.Current.Dispatcher.Invoke(
                DispatcherPriority.Background,
                new ThreadStart(() =>
                    MainWindow.MainWindowInstance.NoConnectImage.Visibility = Visibility.Visible
                )
            );
        }
    }
}
