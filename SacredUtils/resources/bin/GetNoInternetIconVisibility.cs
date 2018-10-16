using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace SacredUtils.resources.bin
{
    public static class GetNoInternetIconVisibility
    {
        static readonly MainWindow MainWindow = (MainWindow)Application.Current.MainWindow;

        public static void Get()
        {
            if (!CheckAvailabilityInternetConnection.Connect())
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                    MainWindow.NoConnectImage.Visibility = Visibility.Visible;
                }));
            }
        }
    }
}
