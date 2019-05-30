using SacredUtils.resources.bin;
using System;

namespace SacredUtils.resources.prp
{
    public class GameGraphicsSettingsThreeProperty
    {
        public bool ForceBlackShadow
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("FORCE_BLACK_SHADOW : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("FORCE_BLACK_SHADOW", value ? 1 : 0);
        }

        public bool CompatVideo
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("COMPAT_VIDEO : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("COMPAT_VIDEO", value ? 1 : 0);
        }

        public bool FontAa
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("FONTAA : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("FONTAA", value ? 1 : 0);
        }

        public bool FullScreenAa
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("FSAA_FILTER : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("FSAA_FILTER", value ? 1 : 0);
        }

        public bool FontFilter
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("FONTFILTER : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("FONTFILTER", value ? 1 : 0);
        }
    }
}
