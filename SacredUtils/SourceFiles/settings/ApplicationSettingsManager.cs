using System.Globalization;
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
            JsonSerializer serializer = new JsonSerializer
            {
                Formatting = Formatting.Indented,
                Culture = CultureInfo.InvariantCulture
            };

            using (StreamWriter sw = new StreamWriter(ApplicationInfo.ConfigFolder))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, Settings);
            }

            Logger.Log.Info($"Saving application settings to {ApplicationInfo.ConfigFolder} done");
        }
    }
}
