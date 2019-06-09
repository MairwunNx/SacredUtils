using System.IO;
using SacredUtils.Properties;
using SacredUtils.SourceFiles.settings;
using static SacredUtils.SourceFiles.Logger;

namespace SacredUtils.SourceFiles.theme
{
    public static class ThemeFileManager
    {
        public static void CreateThemeFiles()
        {
            if (!ApplicationSettingsManager.Settings.EnableReCreatingThemeFiles) return;
            string thmsPath = Path.Combine(ApplicationInfo.Root, "thms");
            Log.Info($"Theme file manager path provided: {thmsPath}");
            File.WriteAllBytes(Path.Combine(thmsPath, "light.xaml"), Resources.Light);
            File.WriteAllBytes(Path.Combine(thmsPath, "dark.xaml"), Resources.Dark);
            Log.Info("SacredUtils theme files was successfully re-created!");
        }
    }
}
