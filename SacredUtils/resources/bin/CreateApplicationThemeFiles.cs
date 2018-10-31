using System.IO;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class CreateApplicationThemeFiles
    {
        public static void Create()
        {
            if (!AppSettings.ApplicationSettings.DisableReCreatingThemeFiles)
            {
                File.WriteAllBytes("$SacredUtils\\thms\\light.xaml", Properties.Resources.Light);
                File.WriteAllBytes("$SacredUtils\\thms\\dark.xaml", Properties.Resources.Dark);

                Log.Info("SacredUtils theme files was successfully re-created!");
            }
        }
    }
}
