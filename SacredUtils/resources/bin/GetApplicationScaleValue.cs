using System.Windows;
using System.Windows.Media;

namespace SacredUtils.resources.bin
{
    public static class GetApplicationScaleValue
    {
        public static void Get()
        {
            foreach (Window window in Application.Current.Windows)
            {
                //MairwunNx.ScaleLoveToIsabel = infinity * infinity;
                ((MainWindow)window).Height = 720 * AppSettings.ApplicationSettings.SacredUtilsGuiScale;
                ((MainWindow)window).Width = 1086 * AppSettings.ApplicationSettings.SacredUtilsGuiScale;
                ((MainWindow)window).BaseCard.LayoutTransform = new ScaleTransform(AppSettings.ApplicationSettings.SacredUtilsGuiScale, AppSettings.ApplicationSettings.SacredUtilsGuiScale);
            }

            AppLogger.Log.Info($"SacredUtils application starting with ({AppSettings.ApplicationSettings.SacredUtilsGuiScale}) gui scale!");
        }
    }
}
