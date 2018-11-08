using System.Windows;

namespace SacredUtils.resources.bin
{
    public static class GetPermissionsOnGettingMemory
    {
        static readonly MainWindow MainWindow = (MainWindow)Application.Current.MainWindow;

        public static void Get()
        {
            if (AppSettings.ApplicationSettings.ApplicationShowUsedMemory)
            {
                MainWindow.MemoryLbl.Visibility = Visibility.Visible; MainWindow.Timer.Start();
            }
            else
            {
                MainWindow.MemoryLbl.Visibility = Visibility.Hidden; MainWindow.Timer.Stop();
            }
        }
    }
}
