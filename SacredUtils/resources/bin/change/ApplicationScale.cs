using Config.Net;
using System;
using System.Windows;
using System.Windows.Media;

namespace SacredUtils.resources.bin.change
{
    public static class ApplicationScale
    {
        public static void Get()
        {
            IAppSettings applicationSettings = new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).Height = 720 * applicationSettings.SacredUtilsGuiScale;
                ((MainWindow)window).Width = 1086 * applicationSettings.SacredUtilsGuiScale;
                ((MainWindow)window).BaseCard.LayoutTransform = new ScaleTransform(applicationSettings.SacredUtilsGuiScale, applicationSettings.SacredUtilsGuiScale);
            }

            AppLogger.Log.Info($"Application starting with {applicationSettings.SacredUtilsGuiScale} gui scale");
        }
    }
}
