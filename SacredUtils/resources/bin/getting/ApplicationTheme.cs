using Config.Net;
using SacredUtils.resources.bin.etc;
using WPFSharp.Globalizer;
using SacredUtils.resources.bin.logger;

namespace SacredUtils.resources.bin.getting
{
    public interface IThemeSettings
    {
        string ColorTheme { get; }
    }

    public static class ApplicationTheme
    {
        public static void Get()
        {
            Logger.Log.Info("Getting application color theme ...");

            IThemeSettings themeSettings = new ConfigurationBuilder<IThemeSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            ApplicationInfo.Theme = themeSettings.ColorTheme == "light" ? "light" : "dark";

            Logger.Log.Info("Getting application color theme done!");

            GlobalizedApplication.Instance.StyleManager.SwitchStyle
                (ApplicationInfo.Theme == "light" ? "Light.xaml" : "Dark.xaml");

            Logger.Log.Info($"Application starting with {ApplicationInfo.Theme} theme ...");
        }
    }
}
