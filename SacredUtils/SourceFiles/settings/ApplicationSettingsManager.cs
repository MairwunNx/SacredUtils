using System.IO;
using Newtonsoft.Json;

namespace SacredUtils.SourceFiles.settings
{
    public static class ApplicationSettingsManager
    {
        public static ApplicationSettings Settings = new ApplicationSettings();

        public static void LoadSettings()
        {
            if (!File.Exists(ApplicationInfo.ConfigFolder)) return;
            string json = File.ReadAllText(ApplicationInfo.ConfigFolder);
            Settings = JsonConvert.DeserializeObject<ApplicationSettings>(json);
        }

        public static void SaveSettings()
        {
            string output = JsonConvert.SerializeObject(Settings, Formatting.Indented);
            File.WriteAllText("here.txt", output);
        }
    }
}
