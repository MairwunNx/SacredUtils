using System.IO;
using System.Linq;
using System.Text;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;

namespace SacredUtils.SourceFiles.bin
{
    public static class GetSacredGameSettingValue
    {
        public static object Get(string prefix, bool isBool, bool isLanguage)
        {
            string[] text = File.ReadAllLines(Settings.SacredConfigurationFile, Encoding.ASCII);
            string line = text.FirstOrDefault(x => x.StartsWith(prefix));

            if (Settings.EnableLoggingLoadedSettings)
            {
                Logger.Log.Info($"Loading \\ Applying Sacred game setting value for {prefix.Split(':')[0].Replace(" ", "")} ...");
            }

            if (isBool) return line?.Substring(prefix.Length) == "1";

            if (isLanguage)
            {
                return line != null ? line.Substring(prefix.Length) : "NULL";
            }

            return line?.Substring(prefix.Length);
        }
    }
}
