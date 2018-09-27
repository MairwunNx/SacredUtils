using Config.Net;
using SacredUtils.resources.bin.application;
using SacredUtils.resources.bin.logger;
using WPFSharp.Globalizer;

namespace SacredUtils.resources.bin.getting
{
    public static class ApplicationTheme
    {
        public static void Get()
        {
            ApplicationSettings.IApplicationSettings themeSettings = new ConfigurationBuilder<ApplicationSettings.IApplicationSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            ApplicationInfo.Theme = themeSettings.ColorTheme == "light" ? "light" : "dark";

            GlobalizedApplication.Instance.StyleManager.SwitchStyle
                (ApplicationInfo.Theme == "light" ? "Light.xaml" : "Dark.xaml");

            Logger.Log.Info($"Application starting with {ApplicationInfo.Theme} theme ...");
        }
    }
}
