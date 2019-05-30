using SacredUtils.resources.bin;
using System;

namespace SacredUtils.resources.prp
{
    public class GamePlaySettingsOneProperty
    {
        public int PickupMode
        {
            get => Convert.ToInt32(GetSacredGameSettingValue.Get("PICKUPAUTO : ", false, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("PICKUPAUTO", value);
        }

        public int ConnectionType
        {
            get => Convert.ToInt32(GetSacredGameSettingValue.Get("NETWORK_SPEEDSETTINGS : ", false, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("NETWORK_SPEEDSETTINGS", value);
        }

        public string PictureOnStartup
        {
            get => GetSacredGameSettingValue.Get("GFXSTARTUP : ", false, false).ToString();

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("GFXSTARTUP", value);
        }

        public string PictureOnLoad
        {
            get => GetSacredGameSettingValue.Get("GFXLOADING : ", false, false).ToString(); 

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("GFXLOADING", value);
        }

        public int WarningLevel
        {
            get => Convert.ToInt32(GetSacredGameSettingValue.Get("WARNING_LEVEL : ", false, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("WARNING_LEVEL", value);
        }
    }
}
