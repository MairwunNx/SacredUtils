using System;
using SacredUtils.SourceFiles.bin;

namespace SacredUtils.resources.prp
{
    public class GameGraphicsSettingsTwoProperty
    {
        public bool RestrictionMemory
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("GFX_LIMIT128 : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("GFX_LIMIT128", value ? 1 : 0);
        }

        public bool ColorDepth
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("GFX32 : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("GFX32", value ? 1 : 0);
        }

        public bool PickupAnim
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("PICKUPANIM : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("PICKUPANIM", value ? 1 : 0);
        }

        public bool Violence
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("VIOLENCE : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("VIOLENCE", value ? 1 : 0);
        }

        public bool FullScreen
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("FULLSCREEN : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("FULLSCREEN", value ? 1 : 0);
        }

        public bool FullScreenAa
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("FSAA_FILTER : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("FSAA_FILTER", value ? 1 : 0);
        }

        public bool ShowMovie
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("SHOWMOVIE : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("SHOWMOVIE", value ? 1 : 0);
        }

        public bool ShowFinalMovie
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("SHOWEXTRO : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("SHOWEXTRO", value ? 1 : 0);
        }
    }
}
