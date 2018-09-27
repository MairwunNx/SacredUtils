using Config.Net;
using SacredUtils.resources.bin.application;
using SacredUtils.resources.bin.getting;
using SacredUtils.resources.bin.logger;
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
            ApplicationSettings.IApplicationSettings applicationSettings = new ConfigurationBuilder<ApplicationSettings.IApplicationSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            ApplicationInfo.Scale = applicationSettings.SacredUtilsGuiScale;

            foreach (Window window in Application.Current.Windows)
            {
                ((MainWindow)window).Height = 720 * ApplicationInfo.Scale;
                ((MainWindow)window).Width = 1086 * ApplicationInfo.Scale;
                ((MainWindow)window).BaseCard.LayoutTransform = new ScaleTransform(ApplicationInfo.Scale, ApplicationInfo.Scale);
            }

            Logger.Log.Info($"Application starting with {ApplicationInfo.Scale} gui scale");
        }

        public static void Change()
        {
            try
            {
                foreach (Window window in Application.Current.Windows)
                {
                    ((MainWindow)window).Height = 720 * ApplicationInfo.Scale;
                    ((MainWindow)window).Width = 1086 * ApplicationInfo.Scale;
                    ((MainWindow)window).BaseCard.LayoutTransform = new ScaleTransform(ApplicationInfo.Scale, ApplicationInfo.Scale);
                }

                IApplicationSettings applicationSettings = new ConfigurationBuilder<IApplicationSettings>()
                    .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

                applicationSettings.SacredUtilsGuiScale =
                    $"{ApplicationInfo.Scale.ToString(CultureInfo.InvariantCulture).Replace(",", ".")}";
            }
            catch (Exception e)
            {
                Logger.Log.Error("An error occurred while user changed app scale");
                Logger.Log.Error(e.ToString);
            }
        }
    }
}
