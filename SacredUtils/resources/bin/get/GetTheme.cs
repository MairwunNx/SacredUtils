using Config.Net;
using SacredUtils.resources.bin.etc;
using WPFSharp.Globalizer;

namespace SacredUtils.resources.bin.get
{
    public interface IThemeSettings
    {
        string ColorTheme { get; }
    }

    public static class GetTheme
    {
        public static void Get()
        {
            GetLoggerConfig.Log.Info("Getting application color theme ...");

            IThemeSettings themeSettings = new ConfigurationBuilder<IThemeSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            ApplicationInfo.Theme = themeSettings.ColorTheme == "light" ? "light" : "dark";

            GetLoggerConfig.Log.Info("Getting application color theme done!");

            GlobalizedApplication.Instance.StyleManager.SwitchStyle
                (ApplicationInfo.Theme == "light" ? "Light.xaml" : "Dark.xaml");

            GetLoggerConfig.Log.Info($"Application starting with {ApplicationInfo.Theme} theme ...");
        }
    }
}
