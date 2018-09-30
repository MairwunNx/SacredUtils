using Config.Net;
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

        public static void Change(string scale)
        {
            try
            {
                foreach (Window window in Application.Current.Windows)
                {
                    ((MainWindow)window).Height = 720 * double.Parse(scale.Replace(",", "."));
                    ((MainWindow)window).Width = 1086 * double.Parse(scale.Replace(",", "."));
                    ((MainWindow)window).BaseCard.LayoutTransform = new ScaleTransform(double.Parse(scale.Replace(",", ".")), double.Parse(scale.Replace(",", ".")));
                }

                IAppSettings applicationSettings = new ConfigurationBuilder<IAppSettings>()
                    .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

                applicationSettings.SacredUtilsGuiScale = double.Parse(scale.Replace(",", "."));
            }
            catch (Exception e)
            {
                AppLogger.Log.Error("An error occurred while user changed app scale");
                AppLogger.Log.Error(e.ToString);
            }
        }
    }
}
