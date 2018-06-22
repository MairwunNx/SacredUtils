using System.Globalization;
using System.IO;
using System.Threading;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;

namespace SacredUtils.Resources.bin
{
    class GetSystemLanguage
    {
        public void GetCultureInfo()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

            if (!File.Exists(AppLngDataFile))
            {
                if (currentCulture.TwoLetterISOLanguageName == "ru" || currentCulture.TwoLetterISOLanguageName == "uk" ||
                    currentCulture.TwoLetterISOLanguageName == "uk" || currentCulture.TwoLetterISOLanguageName == "ro" ||
                    currentCulture.TwoLetterISOLanguageName == "bg" || currentCulture.TwoLetterISOLanguageName == "be")
                {
                    File.WriteAllBytes(AppLngDataFile, Properties.Resources.languageru);
                }
            }

            if (!File.Exists(AppLngDataFile))
            {
                if (currentCulture.TwoLetterISOLanguageName != "ru" || currentCulture.TwoLetterISOLanguageName != "uk" ||
                    currentCulture.TwoLetterISOLanguageName != "uk" || currentCulture.TwoLetterISOLanguageName != "ro" ||
                    currentCulture.TwoLetterISOLanguageName != "bg" || currentCulture.TwoLetterISOLanguageName != "be" ||
                    currentCulture.TwoLetterISOLanguageName != "de")
                {
                    File.WriteAllBytes(AppLngDataFile, Properties.Resources.languageen);
                }
            }

            if (!File.Exists(AppLngDataFile))
            {
                if (currentCulture.TwoLetterISOLanguageName == "de")
                {
                    File.WriteAllBytes(AppLngDataFile, Properties.Resources.languagede);
                }
            }
        }
    }
}
