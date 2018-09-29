using Config.Net;
using SacredUtils.resources.pgs;
using System;
using System.Globalization;
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

        public static void Change()
        {
            try
            {
                foreach (Window window in Application.Current.Windows)
                {
                    ((MainWindow)window).Height = 720 * AppSummary.Scale;
                    ((MainWindow)window).Width = 1086 * AppSummary.Scale;
                    ((MainWindow)window).BaseCard.LayoutTransform = new ScaleTransform(AppSummary.Scale, AppSummary.Scale);
                }

                IApplicationSettings applicationSettings = new ConfigurationBuilder<IApplicationSettings>()
                    .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

                applicationSettings.SacredUtilsGuiScale =
                    $"{AppSummary.Scale.ToString(CultureInfo.InvariantCulture).Replace(",", ".")}";
            }
            catch (Exception e)
            {
                AppLogger.Log.Error("An error occurred while user changed app scale");
                AppLogger.Log.Error(e.ToString);
            }
        }
    }
}
