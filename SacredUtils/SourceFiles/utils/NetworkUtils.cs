using System;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using static SacredUtils.AppSettings;
using static SacredUtils.SourceFiles.Logger;

namespace SacredUtils.SourceFiles.utils
{
    public static class NetworkUtils
    {
        public static readonly Lazy<bool> IsConnected = new Lazy<bool>(() =>
        {
            if (ApplicationSettings.DisableCheckInternetConnection) return true;
            try
            {
                using WebClient webClient = new WebClient();
                using (webClient.OpenRead(
                    ApplicationSettings.InternetConnectionPingProvider
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
            if (ApplicationSettings.DisableCheckInternetConnection)
            {
                Log.Warn("Checking for internet connection was skipped!");
            }

            if (IsConnected.Value)
            {
                Log.Info("SacredUtils application running in online mode!");
            }
            else
            {
                Log.Warn("SacredUtils application running in offline mode!");
            }
        }

        public static void ShowNoConnection()
        {
            if (!ApplicationSettings.VisibleNoConnectionImage ||
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
