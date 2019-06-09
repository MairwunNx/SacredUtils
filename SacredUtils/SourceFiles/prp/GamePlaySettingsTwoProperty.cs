using System;
using SacredUtils.SourceFiles.bin;

namespace SacredUtils.resources.prp
{
    public class GamePlaySettingsTwoProperty
    {
        public bool TrackEnemy
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("AUTOTRACKENEMY : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("AUTOTRACKENEMY", value ? 1 : 0);
        }

        public bool AutoSave
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("AUTOSAVE : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("AUTOSAVE", value ? 1 : 0);
        }

        public bool DefaultSkills
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("DEFAULT_SKILLS : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("DEFAULT_SKILLS", value ? 1 : 0);
        }

        public bool DebugLog
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("LOGGING : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("LOGGING", value ? 1 : 0);
        }

        public bool DamageIcons
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("TASKBAR_ICONS : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("TASKBAR_ICONS", value ? 1 : 0);
        }

        public bool PotionBar
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("SHOWPOTIONS : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("SHOWPOTIONS", value ? 1 : 0);
        }

        public bool PlayerInfo
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("SHOW_HEROINFO : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("SHOW_HEROINFO", value ? 1 : 0);
        }

        public bool EnemyInfo
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("SHOW_ENEMYINFO : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("SHOW_ENEMYINFO", value ? 1 : 0);
        }
    }
}
