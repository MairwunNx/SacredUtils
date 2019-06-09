using System.IO;
using SacredUtils.Properties;
using SacredUtils.SourceFiles.settings;
using static SacredUtils.SourceFiles.Logger;

namespace SacredUtils.SourceFiles.language
{
    public static class LanguageFileManager
    {
        public static void CreateLanguageFiles()
        {
            if (!ApplicationSettingsManager.Settings.EnableReCreatingLanguageFiles) return;
            string langPath = Path.Combine(ApplicationInfo.Root, "lang");
            Log.Info($"Language file manager path provided: {langPath}");
            File.WriteAllBytes(Path.Combine(langPath, "ru-RU", "ru-RU.xaml"), Resources.ru_RU);
            File.WriteAllBytes(Path.Combine(langPath, "en-US", "en-US.xaml"), Resources.en_US);
            Log.Info("SacredUtils language files was successfully re-created!");
        }
    }
}
