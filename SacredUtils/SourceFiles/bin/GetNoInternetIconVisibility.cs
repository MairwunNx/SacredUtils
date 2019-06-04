using System.Threading;
using System.Windows;
using System.Windows.Threading;
using SacredUtils.SourceFiles.bin;

namespace SacredUtils.resources.bin
{
    public static class GetNoInternetIconVisibility
    {
        public static void Get()
        {
            if (!AppSettings.ApplicationSettings.VisibleNoConnectionImage ||
                NetworkUtils.Connect()) return;

            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                MainWindow.MainWindowInstance.NoConnectImage.Visibility = Visibility.Visible));
        }
    }
}
