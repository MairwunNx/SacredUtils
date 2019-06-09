using System;
using SacredUtils.SourceFiles.bin;

namespace SacredUtils.resources.prp
{
    public class GameGraphicsSettingsOneProperty
    {
        public int GraphicsQuality
        {
            get => Convert.ToInt32(GetSacredGameSettingValue.Get("DETAILLEVEL : ", false, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("DETAILLEVEL", value);
        }

        public int WaitRetrace
        {
            get => Convert.ToInt32(GetSacredGameSettingValue.Get("WAITRETRACE : ", false, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("WAITRETRACE", value);
        }

        public int MapTransparent
        {
            get => Convert.ToInt32(GetSacredGameSettingValue.Get("MINIMAP_ALPHA : ", false, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("MINIMAP_ALPHA", value);
        }

        public int NightDarkness
        {
            get => Convert.ToInt32(GetSacredGameSettingValue.Get("NIGHT_DARKNESS : ", false, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("NIGHT_DARKNESS", value);
        }
    }
}
