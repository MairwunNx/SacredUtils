using static SacredUtils.AppSettings;
using static SacredUtils.SourceFiles.Logger;
using static WPFSharp.Globalizer.GlobalizedApplication;

namespace SacredUtils.SourceFiles.theme
{
    public static class ThemeValueProvider
    {
        public static void AssignThemeValue()
        {
            Instance.StyleManager.SwitchStyle(
                ApplicationSettings.ApplicationUiColorTheme == "dark"
                    ? "dark.xaml"
                    : "light.xaml"
            );

            Log.Info(
                $"SacredUtils application starting with {ApplicationSettings.ApplicationUiColorTheme} theme"
            );
        }
    }
}
