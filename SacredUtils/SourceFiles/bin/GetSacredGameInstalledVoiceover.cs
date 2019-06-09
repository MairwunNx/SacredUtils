using System.IO;
using System.Linq;
using System.Text;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;

namespace SacredUtils.SourceFiles.bin
{
    public static class GetSacredGameInstalledVoiceover
    {
        public static int Get()
        {
            int value = 1;

            if (ModifySettings.ModificationSettings.SacredVoiceoverLanguage == "based on language")
            {
                string[] text = File.ReadAllLines(Settings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "LANGUAGE : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null && line.Substring(prefix.Length) == "RU") { value = 0; }
                if (line != null && line.Substring(prefix.Length) == "US") { value = 1; }
                if (line != null && line.Substring(prefix.Length) == "DE") { value = 2; }
                if (line != null && line.Substring(prefix.Length) == "SP") { value = 3; }
            }
            else
            {
                if (ModifySettings.ModificationSettings.SacredVoiceoverLanguage == "RU") { value = 0; }
                if (ModifySettings.ModificationSettings.SacredVoiceoverLanguage == "US") { value = 1; }
                if (ModifySettings.ModificationSettings.SacredVoiceoverLanguage == "DE") { value = 2; }
                if (ModifySettings.ModificationSettings.SacredVoiceoverLanguage == "SP") { value = 3; }
            }

            return value;
        }
    }
}
