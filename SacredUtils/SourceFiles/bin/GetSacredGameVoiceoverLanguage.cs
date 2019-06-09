using System;
using SacredUtils.SourceFiles.bin;

namespace SacredUtils.resources.bin
{
    public static class GetSacredGameVoiceoverLanguage
    {
        public static void Get(int value)
        {
            if (value == 0)
            {
                ModifySettings.ModificationSettings.SacredVoiceoverLanguage = "RU";

                GetSacredGameComponentFiles.GetComponent(
                    new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/MHPKgQql3Xg8Ek"),
                    Environment.ExpandEnvironmentVariables("%tmp%"),
                    "GameSoundRu.zip", "PAK", "SoundRu",
                    "PAK\\soundru.pak", "PAK\\sound.pak");
            }
            else if (value == 1)
            {
                ModifySettings.ModificationSettings.SacredVoiceoverLanguage = "US";

                GetSacredGameComponentFiles.GetComponent(
                    new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/cZRhldb-3Xg9fw"),
                    Environment.ExpandEnvironmentVariables("%tmp%"),
                    "GameSoundUs.zip", "PAK", "SoundUs",
                    "PAK\\soundus.pak", "PAK\\sound.pak");
            }
            else if (value == 2)
            {
                ModifySettings.ModificationSettings.SacredVoiceoverLanguage = "DE";

                GetSacredGameComponentFiles.GetComponent(
                    new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/pneWkQ1b3Xg6mG"),
                    Environment.ExpandEnvironmentVariables("%tmp%"),
                    "GameSoundDe.zip", "PAK", "SoundDe",
                    "PAK\\soundde.pak", "PAK\\sound.pak");
            }
            else if (value == 3)
            {
                ModifySettings.ModificationSettings.SacredVoiceoverLanguage = "SP";

                GetSacredGameComponentFiles.GetComponent(
                    new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/maW7dmcv3Xg8cY"),
                    Environment.ExpandEnvironmentVariables("%tmp%"),
                    "GameSoundSp.zip", "PAK", "SoundSp",
                    "PAK\\soundsp.pak", "PAK\\sound.pak");
            }
        }
    }
}
