using System.Windows;

namespace SacredUtils.resources.bin
{
    public static class GetPermissionsOnGettingMemory
    {
        public static void Get()
        {
            if (AppSettings.ApplicationSettings.ApplicationShowUsedMemory)
            {
                MainWindow.MainWindowInstance.MemoryLbl.Visibility = Visibility.Visible; MainWindow.Timer.Start();
            }
            else
            {
                MainWindow.MainWindowInstance.MemoryLbl.Visibility = Visibility.Hidden; MainWindow.Timer.Stop();
            }
        }
    }
}
