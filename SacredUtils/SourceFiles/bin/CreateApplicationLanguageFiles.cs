using System.IO;
using static SacredUtils.SourceFiles.Logger;

namespace SacredUtils.resources.bin
{
    public static class CreateApplicationLanguageFiles
    {
        public static void Create()
        {
            if (AppSettings.ApplicationSettings.DisableReCreatingLangFiles) return;

            File.WriteAllBytes("$SacredUtils\\lang\\ru-RU\\ru-RU.xaml", Properties.Resources.ru_RU);
            File.WriteAllBytes("$SacredUtils\\lang\\en-US\\en-US.xaml", Properties.Resources.en_US);
            Log.Info("SacredUtils language files was successfully re-created!");
        }
    }
}
