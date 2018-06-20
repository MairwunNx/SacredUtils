using System;
using System.IO;
using System.Text;
using System.Windows;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;

namespace SacredUtils.Resources.bin
{
    public class GetGameSettings
    {
        public void LoadGameSettings()
        {
            try
            {
                var text = File.ReadAllLines(SacredSettings, Encoding.ASCII);

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].Contains("DETAILLEVEL : 0"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).DetailLevelCmbBox.SelectedIndex = 0;
                            }
                        }
                    }

                    if (text[i].Contains("DETAILLEVEL : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).DetailLevelCmbBox.SelectedIndex = 1;
                            }
                        }
                    }

                    if (text[i].Contains("DETAILLEVEL : 2"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).DetailLevelCmbBox.SelectedIndex = 2;
                            }
                        }
                    }

                    if (text[i].Contains("LANGUAGE : RU"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).InterfaceLanguageCmbBox.SelectedIndex = 0;
                                ((MainWindow)window).SoundLanguageCmbBox.SelectedIndex = 0;
                            }
                        }
                    }

                    if (text[i].Contains("LANGUAGE : US"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).InterfaceLanguageCmbBox.SelectedIndex = 1;
                                ((MainWindow)window).SoundLanguageCmbBox.SelectedIndex = 1;
                            }
                        }
                    }

                    if (text[i].Contains("LANGUAGE : DE"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).InterfaceLanguageCmbBox.SelectedIndex = 2;
                                ((MainWindow)window).SoundLanguageCmbBox.SelectedIndex = 2;
                            }
                        }
                    }

                    if (text[i].Contains("LANGUAGE : SP"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).InterfaceLanguageCmbBox.SelectedIndex = 3;
                                ((MainWindow)window).SoundLanguageCmbBox.SelectedIndex = 3;
                            }
                        }
                    }

                    if (text[i].Contains("LANGUAGE : FR"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).InterfaceLanguageCmbBox.SelectedIndex = 4;
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_SPEEDSETTINGS : 0"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetworkSpeedSettingsCmbBox.SelectedIndex = 2;
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_SPEEDSETTINGS : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetworkSpeedSettingsCmbBox.SelectedIndex = 1;
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_SPEEDSETTINGS : 2"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetworkSpeedSettingsCmbBox.SelectedIndex = 0;
                            }
                        }
                    }

                    if (text[i].Contains("SOUNDQUALITY : 0"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).SoundQualityCmbBox.SelectedIndex = 0;
                            }
                        }
                    }

                    if (text[i].Contains("SOUNDQUALITY : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).SoundQualityCmbBox.SelectedIndex = 1;
                            }
                        }
                    }

                    if (text[i].Contains("SOUNDQUALITY : 2"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).SoundQualityCmbBox.SelectedIndex = 2;
                            }
                        }
                    }

                    if (text[i].Contains("PICKUPANIM : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).PickupAnimToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("PICKUPAUTO : 0"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).PickupSettingsCmbBox.SelectedIndex = 0;
                            }
                        }
                    }

                    if (text[i].Contains("PICKUPAUTO : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).PickupSettingsCmbBox.SelectedIndex = 1;
                            }
                        }
                    }

                    if (text[i].Contains("PICKUPAUTO : 2"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).PickupSettingsCmbBox.SelectedIndex = 2;
                            }
                        }
                    }

                    if (text[i].Contains("SOUND : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).SoundToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("SHOWMOVIE : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ShowMovieToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("AUTOSAVE : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).AutosaveToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("ACCEPT_LICENSE : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).LicenseToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("COMPAT_VIDEO : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).CompatVideoToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("SHOWPOTIONS : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ShowPotionsToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("SHOW_ENEMYINFO : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ShowEnemyInfoToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("UNIQUE_COLOR : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).UniqueColorToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("NETLOG : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetlogToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("LOGGING : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).LogToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_CDKEY_HIDE : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetworkCdkeyToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("LADDER_EXPORT : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).LadderExportToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("SHOW_HEROINFO : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ShowHeroInfoToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("FONTAA : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).FontaaToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("FORCE_BLACK_SHADOW : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ForceBlackShadowToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("GFX_LIMIT128 : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).GfxLimit128ToggleButton.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("FSAA_FILTER : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).FsaaFilterToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("FULLSCREEN : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).FullscreenToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("DEFAULT_SKILLS : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).DefaultSkillsToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("EXPLOREMAP : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).WarFogToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("TASKBAR_ICONS : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).TaskbarIconsToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("AUTOTRACKENEMY : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).TrackEnemyToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("WAITRETRACE : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).WaitretraceToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("VIOLENCE : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ViolenceToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("COMBINE_SLOTS : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).CombineSlotsToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("GFX32 : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).Gfx32ToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("SCREEN_QUAKE : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ScreenQuakeToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("FONTFILTER : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).FontFilteringToggleBtn.IsChecked = true;
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_IP_ADDRESS : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetworkIpAddressTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_PORT_LISTEN : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetworkPortListenTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_SESSION : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetworkSessionTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_PLAYER : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetworkPlayerTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_PASSWORD : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetworkPasswordTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);
                            }
                        }
                    }

                    if (text[i].Contains("GFXLOADING : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).GfxStartupTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);
                            }
                        }
                    }

                    if (text[i].Contains("GFXSTARTUP : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).GfxLoadingTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_LOBBY : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetworkLobbyTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);
                            }
                        }
                    }

                    if (text[i].Contains("AUTOSAVEDELAY : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).AutosaveDelaySlider.Value = int.Parse(text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2));
                            }
                        }
                    }

                    if (text[i].Contains("CHAT_LINES : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ChatLinesSlider.Value = int.Parse(text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2));
                            }
                        }
                    }

                    if (text[i].Contains("CHAT_DELAY : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ChatDelaySlider.Value = int.Parse(text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2));
                            }
                        }
                    }

                    if (text[i].Contains("CHAT_ALPHA : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ChatAlphaSlider.Value = int.Parse(text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2));
                            }
                        }
                    }

                    if (text[i].Contains("MINIMAP_ALPHA : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).MinimapAlphaSlider.Value = int.Parse(text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2));
                            }
                        }
                    }

                    if (text[i].Contains("WARNING_LEVEL : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).WarningPercentSlider.Value = int.Parse(text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2));
                            }
                        }
                    }

                    if (text[i].Contains("NIGHT_DARKNESS : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NightDarknessSlider.Value = int.Parse(text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2));
                            }
                        }
                    }

                    if (text[i].Contains("MUSICVOLUME : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).VolumeMusicSlider.Value = int.Parse(text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2));
                            }
                        }
                    }

                    if (text[i].Contains("SFXVOLUME : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).VolumeSfxSlider.Value = int.Parse(text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2));
                            }
                        }
                    }

                    if (text[i].Contains("VOICEVOLUME : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).VolumeVoiceSlider.Value = int.Parse(text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2));
                            }
                        }
                    }
                }

                using (StreamReader sr = new StreamReader(SacredSettings))
                {
                    string contents = sr.ReadToEnd();

                    if (!contents.Contains("DETAILLEVEL"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).DetailLevelCmbBox.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("LANGUAGE"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).InterfaceLanguageCmbBox.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("NETWORK_SPEEDSETTINGS"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetworkSpeedSettingsCmbBox.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("SOUNDQUALITY"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).SoundQualityCmbBox.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("PICKUPANIM"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).PickupAnimToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("PICKUPAUTO"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).PickupSettingsCmbBox.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("SOUND"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).SoundToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("SHOWMOVIE"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ShowMovieToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("AUTOSAVE"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).AutosaveToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("ACCEPT_LICENSE"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).LicenseToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("COMPAT_VIDEO"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).CompatVideoToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("SHOWPOTIONS"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ShowPotionsToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("SHOW_ENEMYINFO"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ShowEnemyInfoToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("UNIQUE_COLOR"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).UniqueColorToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("NETLOG"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetlogToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("LOGGING"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).LogToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("NETWORK_CDKEY_HIDE"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetworkCdkeyToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("LADDER_EXPORT"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).LadderExportToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("SHOW_HEROINFO"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ShowHeroInfoToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("FONTAA"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).FontaaToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("FORCE_BLACK_SHADOW"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ForceBlackShadowToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("GFX_LIMIT128"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).GfxLimit128ToggleButton.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("FSAA_FILTER"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).FsaaFilterToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("FULLSCREEN"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).FullscreenToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("DEFAULT_SKILLS"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).DefaultSkillsToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("EXPLOREMAP"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).WarFogToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("TASKBAR_ICONS"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).TaskbarIconsToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("AUTOTRACKENEMY"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).TrackEnemyToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("WAITRETRACE"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).WaitretraceToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("VIOLENCE"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ViolenceToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("COMBINE_SLOTS"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).CombineSlotsToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("GFX32"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).Gfx32ToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("SCREEN_QUAKE"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ScreenQuakeToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("FONTFILTER"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).FontFilteringToggleBtn.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("NETWORK_IP_ADDRESS"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetworkIpAddressTxBox.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("NETWORK_PORT_LISTEN"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetworkPortListenTxBox.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("NETWORK_SESSION"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetworkSessionTxBox.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("NETWORK_PLAYER"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetworkPlayerTxBox.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("NETWORK_PASSWORD"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetworkPasswordTxBox.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("GFXLOADING"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).GfxStartupTxBox.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("GFXSTARTUP"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).GfxLoadingTxBox.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("NETWORK_LOBBY"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetworkLobbyTxBox.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("AUTOSAVEDELAY"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).AutosaveDelaySlider.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("CHAT_LINES"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ChatLinesSlider.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("CHAT_DELAY"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ChatDelaySlider.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("CHAT_ALPHA"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ChatAlphaSlider.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("MINIMAP_ALPHA"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).MinimapAlphaSlider.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("WARNING_LEVEL"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).WarningPercentSlider.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("NIGHT_DARKNESS"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NightDarknessSlider.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("MUSICVOLUME"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).VolumeMusicSlider.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("SFXVOLUME"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).VolumeSfxSlider.IsEnabled = false;
                            }
                        }
                    }

                    if (!contents.Contains("VOICEVOLUME"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).VolumeVoiceSlider.IsEnabled = false;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                 Log.Fatal(exception.ToString()); Environment.Exit(0);
            }
        }
    }
}
