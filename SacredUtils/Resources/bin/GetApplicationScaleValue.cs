using System.Windows.Media;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class GetApplicationScaleValue
    {
        public static void Get()
        {
            // MairwunNx.ScaleLoveToIsabel = infinity * infinity;
            MainWindow.MainWindowInstance.Height = 720 * AppSettings.ApplicationSettings.SacredUtilsGuiScale;
            MainWindow.MainWindowInstance.Width = 1086 * AppSettings.ApplicationSettings.SacredUtilsGuiScale;
            MainWindow.MainWindowInstance.BaseCard.LayoutTransform = new ScaleTransform(AppSettings.ApplicationSettings.SacredUtilsGuiScale, AppSettings.ApplicationSettings.SacredUtilsGuiScale);
            
            Log.Info($"SacredUtils application starting with ({AppSettings.ApplicationSettings.SacredUtilsGuiScale}) gui scale!");
        }
    }
}
