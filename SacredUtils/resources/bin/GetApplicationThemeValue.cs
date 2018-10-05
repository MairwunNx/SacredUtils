using WPFSharp.Globalizer;

namespace SacredUtils.resources.bin
{
    public static class GetApplicationThemeValue
    {
        public static void Get()
        {
            GlobalizedApplication.Instance.StyleManager.SwitchStyle
                (AppSettings.ApplicationSettings.ColorTheme == "dark" ? "Dark.xaml" : "Light.xaml");

            AppLogger.Log.Info($"SacredUtils application starting with ({AppSettings.ApplicationSettings.ColorTheme}) theme!");
        }
    }
}
