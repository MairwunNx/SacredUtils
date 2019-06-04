using System.IO;
using System.Linq;
using System.Text;
using static SacredUtils.Logger;

namespace SacredUtils.resources.bin
{
    public static class GetSacredGameSettingValue
    {
        public static object Get(string prefix, bool isBool, bool isLanguage)
        {
            string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);
            string line = text.FirstOrDefault(x => x.StartsWith(prefix));

            if (AppSettings.ApplicationSettings.EnableLoggingLoadedSettings)
            {
                Log.Info($"Loading \\ Applying Sacred game setting value for {prefix.Split(':')[0].Replace(" ", "")} ...");
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
