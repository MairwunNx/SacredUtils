using WPFSharp.Globalizer;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class GetApplicationThemeValue
    {
        public static void Get()
        {
            GlobalizedApplication.Instance.StyleManager.SwitchStyle(
                AppSettings.ApplicationSettings.ColorTheme == "dark" ? "dark.xaml" : "light.xaml");

            Log.Info($"SacredUtils application starting with ({AppSettings.ApplicationSettings.ColorTheme}) theme!");
        }
    }
}
