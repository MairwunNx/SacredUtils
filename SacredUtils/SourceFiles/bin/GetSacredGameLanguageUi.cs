using System;

namespace SacredUtils.resources.bin
{
    public static class GetSacredGameLanguageUi
    {
        public static void Get(int value)
        {
            if (value == 0)
            {
                ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "RU");

                GetSacredGameComponentFiles.GetComponent(
                    new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/sKUKqp3W3XgcFP"),
                    Environment.ExpandEnvironmentVariables("%tmp%"),
                    "GameLangRu.zip", "scripts\\ru", "LangRu",
                    "scripts\\ru\\globalru.res", "scripts\\ru\\global.res");
            }
            else if (value == 1)
            {
                ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "US");

                GetSacredGameComponentFiles.GetComponent(
                    new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/1sni8lWA3XgcFo"),
                    Environment.ExpandEnvironmentVariables("%tmp%"),
                    "GameLangUs.zip", "scripts\\us", "LangUs",
                    "scripts\\us\\globalus.res", "scripts\\us\\global.res");
            }
            else if (value == 2)
            {
                ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "DE");

                GetSacredGameComponentFiles.GetComponent(
                    new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/ekWsMxz13XgcEr"),
                    Environment.ExpandEnvironmentVariables("%tmp%"),
                    "GameLangDe.zip", "scripts\\de", "LangDe",
                    "scripts\\de\\globalde.res", "scripts\\de\\global.res");
            }
            else if (value == 3)
            {
                ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "SP");

                GetSacredGameComponentFiles.GetComponent(
                    new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/5n-Vslep3XgcFb"),
                    Environment.ExpandEnvironmentVariables("%tmp%"),
                    "GameLangSp.zip", "scripts\\sp", "LangSp",
                    "scripts\\sp\\globalsp.res", "scripts\\sp\\global.res");
            }
            else if (value == 4)
            {
                ChangeSacredGameSettingsValue.ChangeSettingValue("LANGUAGE", "FR");

                GetSacredGameComponentFiles.GetComponent(
                    new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/2XGSFLVL3XgcF5"),
                    Environment.ExpandEnvironmentVariables("%tmp%"),
                    "GameLangFr.zip", "scripts\\fr", "LangFr",
                    "scripts\\fr\\globalfr.res", "scripts\\fr\\global.res");
            }
        }
    }
}
