using System;
using SacredUtils.resources.bin;
using SacredUtils.SourceFiles.bin;

namespace SacredUtils.resources.prp
{
    public class GameSoundSettingsOneProperty
    {
        public bool Sound
        {
            get => Convert.ToBoolean(GetSacredGameSettingValue.Get("SOUND : ", true, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("SOUND", value ? 1 : 0);
        }

        public int SoundQuality
        {
            get => Convert.ToInt32(GetSacredGameSettingValue.Get("SOUNDQUALITY : ", false, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("SOUNDQUALITY", value);
        }

        public int GameVoiceover
        {
            get => GetSacredGameInstalledVoiceover.Get();

            set => GetSacredGameVoiceoverLanguage.Get(value);
        }

        public int MusicVolume
        {
            get => Convert.ToInt32(GetSacredGameSettingValue.Get("MUSICVOLUME : ", false, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("MUSICVOLUME", value);
        }

        public int SfxVolume
        {
            get => Convert.ToInt32(GetSacredGameSettingValue.Get("SFXVOLUME : ", false, false));

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("SFXVOLUME", value);
        }

        public int VoiceVolume
        {
            get => Convert.ToInt32(GetSacredGameSettingValue.Get("VOICEVOLUME : ", false, false));
            
            set => ChangeSacredGameSettingsValue.ChangeSettingValue("VOICEVOLUME", value);
        }
    }
}
