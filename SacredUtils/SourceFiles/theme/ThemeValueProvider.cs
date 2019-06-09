using static SacredUtils.SourceFiles.Logger;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;
using static WPFSharp.Globalizer.GlobalizedApplication;

namespace SacredUtils.SourceFiles.theme
{
    public static class ThemeValueProvider
    {
        public static void AssignThemeValue()
        {
            Instance.StyleManager.SwitchStyle(
                Settings.ApplicationUiTheme == Theme.Dark
                    ? "dark.xaml"
                    : "light.xaml"
            );

            Log.Info(
                $"SacredUtils application starting with {Settings.ApplicationUiTheme} theme"
            );
        }
    }
}
