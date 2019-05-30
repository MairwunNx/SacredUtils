using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace SacredUtils.resources.bin
{
    public static class DownloadApplicationUpdateTool
    {
        public static void Download()
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileTaskAsync("https://drive.google.com/uc?export=download&id=1Q2syd-44j_VAWDPHnoujdkNl6vRnNADw", "mnxupdater.exe").Wait();

                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(() =>
                    MainWindow.MainWindowInstance.UpdateLbl.Visibility = Visibility.Visible));
            }
        }
    }
}
