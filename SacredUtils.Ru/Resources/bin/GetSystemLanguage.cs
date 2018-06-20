using System.IO;
using System.Threading;
using System.Globalization;

namespace SacredUtils.Resources.bin
{
    class GetSystemLanguage
    {
        public void GetCultureInfo()
        {
            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

            if (!File.Exists(".SacredUtilsData\\language.dat"))
            {
                if (currentCulture.TwoLetterISOLanguageName == "ru" || currentCulture.TwoLetterISOLanguageName == "uk" ||
                    currentCulture.TwoLetterISOLanguageName == "uk" || currentCulture.TwoLetterISOLanguageName == "ro" ||
                    currentCulture.TwoLetterISOLanguageName == "bg" || currentCulture.TwoLetterISOLanguageName == "be")
                {
                    File.WriteAllBytes(".SacredUtilsData\\language.dat", Properties.Resources.languageru);
                }
            }

            if (!File.Exists(".SacredUtilsData\\language.dat"))
            {
                if (currentCulture.TwoLetterISOLanguageName != "ru" || currentCulture.TwoLetterISOLanguageName != "uk" ||
                    currentCulture.TwoLetterISOLanguageName != "uk" || currentCulture.TwoLetterISOLanguageName != "ro" ||
                    currentCulture.TwoLetterISOLanguageName != "bg" || currentCulture.TwoLetterISOLanguageName != "be" ||
                    currentCulture.TwoLetterISOLanguageName != "de")
                {
                    File.WriteAllBytes(".SacredUtilsData\\language.dat", Properties.Resources.languageen);
                }
            }

            if (!File.Exists(".SacredUtilsData\\language.dat"))
            {
                if (currentCulture.TwoLetterISOLanguageName == "de")
                {
                    File.WriteAllBytes(".SacredUtilsData\\language.dat", Properties.Resources.languagede);
                }
            }
        }
    }
}
