using System.IO;
using System.Linq;
using System.Text;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class GetSacredGameSettingValue
    {
        public static object Get(string prefix, bool isBool, bool isLanguage)
        {
            string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

            string line = text.FirstOrDefault(x => x.StartsWith(prefix));

            Log.Info($"Loading Sacred game setting value for {prefix.Split(':')[0].Replace(" ", "")} ...");

            if (isBool) { return line?.Substring(prefix.Length) == "1"; }

            if (isLanguage)
            { 
                if (line != null) { return line.Substring(prefix.Length); }

                return "NULL";
            }

            return line?.Substring(prefix.Length);
        }
    }
}
