using SacredUtils.resources.bin;
using System;

namespace SacredUtils.resources.prp
{
    public class GameChatSettingsOneProperty
    {
        public bool UniqueColor 
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("UNIQUE_COLOR : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("UNIQUE_COLOR", value ? 1 : 0);
        }

        public int Language
        {
            get => GetSacredGameInstalledLang.GetLanguage();

            set => GetSacredGameLanguageUi.Get(value);
        }

        public int ChatLines
        {
            get => Convert.ToInt32(GetSacredGameSettingValue.Get("CHAT_LINES : ", false, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("CHAT_LINES", value);
        }

        public int ChatDelay
        {
            get => Convert.ToInt32(GetSacredGameSettingValue.Get("CHAT_DELAY : ", false, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("CHAT_DELAY", value);
        }

        public int ChatAlpha
        {
            get => Convert.ToInt32(GetSacredGameSettingValue.Get("CHAT_ALPHA : ", false, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("CHAT_ALPHA", value);
        }
    }
}
