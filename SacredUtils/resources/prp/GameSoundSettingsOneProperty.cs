using System;
using SacredUtils.resources.bin;
using System.IO;
using System.Linq;
using System.Text;

namespace SacredUtils.resources.prp
{
    public class GameSoundSettingsOneProperty
    {
        public bool Sound
        {
            get
            {
                string[] text = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                string prefix = "SOUND : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                return line != null && line.Substring(prefix.Length) == "1";
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("SOUND", value ? 1 : 0);
        }

        public int SoundQuality
        {
            get
            {
                int value = 0;

                string[] text = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                string prefix = "SOUNDQUALITY : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null) { value = Convert.ToInt32(line.Substring(prefix.Length)); }

                return value;
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("SOUNDQUALITY", value);
        }

        public int GameVoiceover
        {
            get
            {
                int value = 0;

                if (AppSettings.ApplicationSettings.GameVoiceover == "based on language")
                {
                    string[] text = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                    string prefix = "LANGUAGE : ";

                    string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                    if (line != null && line.Substring(prefix.Length) == "RU") { value = 0; }
                    if (line != null && line.Substring(prefix.Length) == "US") { value = 1; }
                    if (line != null && line.Substring(prefix.Length) == "DE") { value = 2; }
                    if (line != null && line.Substring(prefix.Length) == "SP") { value = 3; }
                }
                else
                {
                    if (AppSettings.ApplicationSettings.GameVoiceover == "RU") { value = 0; }
                    if (AppSettings.ApplicationSettings.GameVoiceover == "US") { value = 1; }
                    if (AppSettings.ApplicationSettings.GameVoiceover == "DE") { value = 2; }
                    if (AppSettings.ApplicationSettings.GameVoiceover == "SP") { value = 3; }
                }

                return value;
            }

            set
            {
                if (value == 0)
                {
                    AppSettings.ApplicationSettings.GameVoiceover = "RU";

                    GetSacredGameComponentFiles.GetComponent(
                        new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/MHPKgQql3Xg8Ek"),
                        Environment.ExpandEnvironmentVariables("%tmp%"),
                        "GameSoundRu.zip", "PAK", "SoundRu",
                        "PAK\\soundru.pak", "PAK\\sound.pak");
                }
                else if (value == 1)
                {
                    AppSettings.ApplicationSettings.GameVoiceover = "US";

                    GetSacredGameComponentFiles.GetComponent(
                        new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/cZRhldb-3Xg9fw"),
                        Environment.ExpandEnvironmentVariables("%tmp%"),
                        "GameSoundUs.zip", "PAK", "SoundUs",
                        "PAK\\soundus.pak", "PAK\\sound.pak");
                }
                else if (value == 2)
                {
                    AppSettings.ApplicationSettings.GameVoiceover = "DE";

                    GetSacredGameComponentFiles.GetComponent(
                        new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/pneWkQ1b3Xg6mG"),
                        Environment.ExpandEnvironmentVariables("%tmp%"),
                        "GameSoundDe.zip", "PAK", "SoundDe",
                        "PAK\\soundde.pak", "PAK\\sound.pak");
                }
                else if (value == 3)
                {
                    AppSettings.ApplicationSettings.GameVoiceover = "SP";

                    GetSacredGameComponentFiles.GetComponent(
                        new Uri("https://getfile.dokpub.com/yandex/get/https://yadi.sk/d/maW7dmcv3Xg8cY"),
                        Environment.ExpandEnvironmentVariables("%tmp%"),
                        "GameSoundSp.zip", "PAK", "SoundSp",
                        "PAK\\soundsp.pak", "PAK\\sound.pak");
                }
            }
        }

        public int MusicVolume
        {
            get
            {
                int value = 0;

                string[] text = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                string prefix = "MUSICVOLUME : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null) { value = Convert.ToInt32(line.Substring(prefix.Length)); }

                return value;
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("MUSICVOLUME", value);
        }

        public int SfxVolume
        {
            get
            {
                int value = 0;

                string[] text = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                string prefix = "SFXVOLUME : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null) { value = Convert.ToInt32(line.Substring(prefix.Length)); }

                return value;
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingValue("SFXVOLUME", value);
        }

        public int VoiceVolume
        {
            get
            {
                int value = 0;

                string[] text = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                string prefix = "VOICEVOLUME : ";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null) { value = Convert.ToInt32(line.Substring(prefix.Length)); }

                return value;
            }
            
            set => ChangeSacredGameSettingsValue.ChangeSettingValue("VOICEVOLUME", value);
        }
    }
}
