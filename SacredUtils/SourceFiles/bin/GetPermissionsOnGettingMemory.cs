using System.Windows;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;

namespace SacredUtils.SourceFiles.bin
{
    public static class GetPermissionsOnGettingMemory
    {
        public static void Get()
        {
            if (Settings.EnableShowDebugInfo)
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
