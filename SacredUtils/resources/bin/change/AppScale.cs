using Config.Net;
using SacredUtils.resources.bin.etc;
using SacredUtils.resources.bin.get;
using SacredUtils.resources.pgs;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace SacredUtils.resources.bin.change
{
    public static class AppScale
    {
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
                GetLoggerConfig.Log.Error("An error occurred while user changed app scale");
                GetLoggerConfig.Log.Error(e.ToString);
            }
        }
    }
}
