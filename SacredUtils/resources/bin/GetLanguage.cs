using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace SacredUtils.resources.bin
{
    public class GetLanguage
    {
        public void Get()
        {
            GetLoggerConfig.Log.Info("Checking availability language settings");

            if (!File.Exists("$SacredUtils\\lang\\langinfo.json"))
            {
                GetLoggerConfig.Log.Info("Getting default system language settings");

                CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

                if (currentCulture.TwoLetterISOLanguageName == "ru" ||
                    currentCulture.TwoLetterISOLanguageName == "uk" ||
                    currentCulture.TwoLetterISOLanguageName == "uk" ||
                    currentCulture.TwoLetterISOLanguageName == "ro" ||
                    currentCulture.TwoLetterISOLanguageName == "bg")
                {
                    File.WriteAllBytes("$SacredUtils\\lang\\langinfo.json", Properties.Resources.langinfo_ru);
                    File.WriteAllBytes("$SacredUtils\\lang\\language.json", Properties.Resources.language_ru);
                }
                else
                {
                    File.WriteAllBytes("$SacredUtils\\lang\\langinfo.json", Properties.Resources.langinfo_en);
                    File.WriteAllBytes("$SacredUtils\\lang\\langinfo.json", Properties.Resources.language_en);
                }
            }
            else
            {
                var text = File.ReadAllLines("$SacredUtils\\lang\\langinfo.json");

                File.WriteAllBytes("$SacredUtils\\lang\\language.json",
                    text.Contains("ru") ? Properties.Resources.language_ru : Properties.Resources.language_en);

                GetLoggerConfig.Log.Info("Language settings were created in conf folder");
            }
        }
    }
}
