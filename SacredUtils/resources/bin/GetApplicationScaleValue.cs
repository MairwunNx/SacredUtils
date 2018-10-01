using Config.Net;
using System.Windows;
using System.Windows.Media;

namespace SacredUtils.resources.bin
{
    public static class GetApplicationScaleValue
    {
        public static void Get()
        {
            IAppSettings applicationSettings = new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            foreach (Window window in Application.Current.Windows)
            {
                //MairwunNx.ScaleLoveToIsabel = infinity * infinity;
                ((MainWindow)window).Height = 720 * applicationSettings.SacredUtilsGuiScale;
                ((MainWindow)window).Width = 1086 * applicationSettings.SacredUtilsGuiScale;
                ((MainWindow)window).BaseCard.LayoutTransform = new ScaleTransform(applicationSettings.SacredUtilsGuiScale, applicationSettings.SacredUtilsGuiScale);
            }

            AppLogger.Log.Info($"Application starting with {applicationSettings.SacredUtilsGuiScale} gui scale");
        }
    }
}
