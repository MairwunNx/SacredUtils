using System.Globalization;
using System.IO;

namespace SacredUtils.resources.bin
{
    public static class GetSacredGameInstalledLang
    {
        private static int Get()
        {
            int index = 1;

            if (!Directory.Exists("scripts")) return index;

            DirectoryInfo directoryInfo = new DirectoryInfo("scripts");
            DirectoryInfo[] dirs = directoryInfo.GetDirectories();

            if (dirs.Length > 1)
            {
                switch (CultureInfo.InstalledUICulture.TwoLetterISOLanguageName)
                {
                    case "ru" when Directory.Exists("scripts\\ru"): index = 0; break;
                    case "en" when Directory.Exists("scripts\\us"): index = 1; break;
                    case "us" when Directory.Exists("scripts\\us"): index = 1; break;
                    case "de" when Directory.Exists("scripts\\de"): index = 2; break;
                    case "sp" when Directory.Exists("scripts\\sp"): index = 3; break;
                    case "fr" when Directory.Exists("scripts\\fr"): index = 4; break;
                    default: index = 1; break;
                }
            }
            else if (dirs.Length == 1)
            {
                if (Directory.Exists("scripts\\ru")) { index = 0; }
                if (Directory.Exists("scripts\\us")) { index = 1; }
                if (Directory.Exists("scripts\\de")) { index = 2; }
                if (Directory.Exists("scripts\\sp")) { index = 3; }
                if (Directory.Exists("scripts\\fr")) { index = 4; }
            }

            return index;
        }

        public static int GetLanguage()
        {
            int index = 5;
            string language = GetSacredGameSettingValue.Get("LANGUAGE : ", false, true).ToString();

            switch (language)
            {
                case "RU": index = 0; break;
                case "US": index = 1; break;
                case "DE": index = 2; break;
                case "SP": index = 3; break;
                case "FR": index = 4; break;
            }

            if (index == 5) index = Get();

            return index;
        }
    }
}
