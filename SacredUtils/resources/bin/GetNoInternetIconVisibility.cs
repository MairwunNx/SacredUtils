using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace SacredUtils.resources.bin
{
    public static class GetNoInternetIconVisibility
    {
        public static void Get()
        {
            if (AppSettings.ApplicationSettings.VisibleNoConnectionImage)
            {
                if (!CheckAvailabilityInternetConnection.Connect())
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                    {
                        MainWindow.MainWindowInstance.NoConnectImage.Visibility = Visibility.Visible;
                    }));
                }
            }
        }
    }
}
