using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace SacredUtils.resources.bin
{
    public static class GetNoInternetIconVisibility
    {
        public static void Get()
        {
            if (!AppSettings.ApplicationSettings.VisibleNoConnectionImage ||
                CheckAvailabilityInternetConnection.Connect()) return;

            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                MainWindow.MainWindowInstance.NoConnectImage.Visibility = Visibility.Visible));
        }
    }
}
