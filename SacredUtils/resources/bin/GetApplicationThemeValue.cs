using WPFSharp.Globalizer;

namespace SacredUtils.resources.bin
{
    public static class GetApplicationThemeValue
    {
        public static void Get()
        {
            GlobalizedApplication.Instance.StyleManager.SwitchStyle
                (AppSettings.ApplicationSettings.ColorTheme == "light" ? "Light.xaml" : "Dark.xaml");

            AppLogger.Log.Info($"Application starting with {AppSettings.ApplicationSettings.ColorTheme} theme ...");
        }
    }
}
