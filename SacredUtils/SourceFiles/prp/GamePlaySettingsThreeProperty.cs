using System;
using SacredUtils.SourceFiles.bin;

namespace SacredUtils.resources.prp
{
    public class GamePlaySettingsThreeProperty
    {
        public bool CombineSlots
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("COMBINE_SLOTS : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("COMBINE_SLOTS", value ? 1 : 0);
        }

        public bool AcceptLicense
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("ACCEPT_LICENSE : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("ACCEPT_LICENSE", value ? 1 : 0);
        }

        public bool FirstEnter
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("FIRST_LOGIN : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("FIRST_LOGIN", value ? 1 : 0);
        }

        public bool Earthquake
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("SCREEN_QUAKE : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("SCREEN_QUAKE", value ? 1 : 0);
        }
    }
}
