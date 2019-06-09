using System;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using static SacredUtils.SourceFiles.Logger;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;

namespace SacredUtils.SourceFiles.utils
{
    public static class NetworkUtils
    {
        public static readonly Lazy<bool> IsConnected = new Lazy<bool>(() =>
        {
            if (!Settings.EnableCheckInternetConnection) return true;
            try
            {
                using WebClient webClient = new WebClient();
                using (webClient.OpenRead(Settings.InternetConnectionPingProvider))
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
            if (!Settings.EnableCheckInternetConnection)
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
            if (!Settings.VisibleNoConnectionImage ||
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
