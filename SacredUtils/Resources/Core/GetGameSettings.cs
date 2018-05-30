using System;
using log4net;
using System.IO;
using System.Text;
using System.Windows;

namespace SacredUtils.Resources.Core
{
    public class GetGameSettings
    {
        private static readonly ILog Log = LogManager.GetLogger("LOGGER");

        public void LoadGameSettings() // Загружаем игровые настройки.
        {
            Log.Info("Загрузка всех активных настроек SacredUnderworld");

            try
            {
                var text = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i].Contains("DETAILLEVEL : 0"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).GraphicsQualityCmbBox.SelectedIndex = 0;

                                Log.Info("Настройка SacredUnderworld \"DETAILLEVEL\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("DETAILLEVEL : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).GraphicsQualityCmbBox.SelectedIndex = 1;

                                Log.Info("Настройка SacredUnderworld \"DETAILLEVEL\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("DETAILLEVEL : 2"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).GraphicsQualityCmbBox.SelectedIndex = 2;

                                Log.Info("Настройка SacredUnderworld \"DETAILLEVEL\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"LANGUAGE\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("LANGUAGE : EN"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).InterfaceLanguageCmbBox.SelectedIndex = 1;

                                Log.Info("Настройка SacredUnderworld \"LANGUAGE\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"LANGUAGE\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_SPEEDSETTINGS : 0"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ConnectTypeCmbBox.SelectedIndex = 2;

                                Log.Info("Настройка SacredUnderworld \"NETWORK_SPEEDSETTINGS\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_SPEEDSETTINGS : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ConnectTypeCmbBox.SelectedIndex = 1;

                                Log.Info("Настройка SacredUnderworld \"NETWORK_SPEEDSETTINGS\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_SPEEDSETTINGS : 2"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ConnectTypeCmbBox.SelectedIndex = 0;

                                Log.Info("Настройка SacredUnderworld \"NETWORK_SPEEDSETTINGS\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"SOUNDQUALITY\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"SOUNDQUALITY\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"SOUNDQUALITY\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("PICKUPANIM : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).AnimationToggleBtn.IsChecked = true;

                                Log.Info("Настройка SacredUnderworld \"PICKUPANIM\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"PICKUPAUTO\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"PICKUPAUTO\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"PICKUPAUTO\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"SOUND\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("SHOWMOVIE : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ShowMoviesToggleBtn.IsChecked = true;

                                Log.Info("Настройка SacredUnderworld \"SHOWMOVIE\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"AUTOSAVE\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"ACCEPT_LICENSE\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("COMPAT_VIDEO : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).CompatibilityModeToggleBtn.IsChecked = true;

                                Log.Info("Настройка SacredUnderworld \"COMPAT_VIDEO\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("SHOWPOTIONS : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).DopingBarToggleBtn.IsChecked = true;

                                Log.Info("Настройка SacredUnderworld \"SHOWPOTIONS\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("SHOW_ENEMYINFO : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).EnemyInfoToggleBtn.IsChecked = true;

                                Log.Info("Настройка SacredUnderworld \"SHOW_ENEMYINFO\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("UNIQUE_COLOR : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).RainbowChatToggleBtn.IsChecked = true;

                                Log.Info("Настройка SacredUnderworld \"UNIQUE_COLOR\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("NETLOG : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetLoggingToggleBtn.IsChecked = true;

                                Log.Info("Настройка SacredUnderworld \"NETLOG\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"LOGGING\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_CDKEY_HIDE : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).HideCdKeyToggleBtn.IsChecked = true;

                                Log.Info("Настройка SacredUnderworld \"NETWORK_CDKEY_HIDE\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"LADDER_EXPORT\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("SHOW_HEROINFO : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).PlayerInfoToggleBtn.IsChecked = true;

                                Log.Info("Настройка SacredUnderworld \"SHOW_HEROINFO\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("FONTAA : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).FontSmoothToggleBtn.IsChecked = true;

                                Log.Info("Настройка SacredUnderworld \"FONTAA\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("FORCE_BLACK_SHADOW : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).OpaqueShadowsToggleBtn.IsChecked = true;

                                Log.Info("Настройка SacredUnderworld \"FORCE_BLACK_SHADOW\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("GFX_LIMIT128 : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).MemoryLimitToggleBtn.IsChecked = true;

                                Log.Info("Настройка SacredUnderworld \"GFX_LIMIT128\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("FSAA_FILTER : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ImageSmoothingToggleBtn.IsChecked = true;

                                Log.Info("Настройка SacredUnderworld \"FSAA_FILTER\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("FULLSCREEN : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).FullScreenModeToggleBtn.IsChecked = true;

                                Log.Info("Настройка SacredUnderworld \"FULLSCREEN\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"DEFAULT_SKILLS\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"EXPLOREMAP\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("TASKBAR_ICONS : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).DamageIconsToggleBtn.IsChecked = true;

                                Log.Info("Настройка SacredUnderworld \"TASKBAR_ICONS\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"AUTOTRACKENEMY\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("WAITRETRACE : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).VerticalSyncToggleBtn.IsChecked = true;

                                Log.Info("Настройка SacredUnderworld \"WAITRETRACE\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"VIOLENCE\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"COMBINE_SLOTS\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("GFX32 : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ColorDepthToggleBtn.IsChecked = true;

                                Log.Info("Настройка SacredUnderworld \"GFX32\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("SCREEN_QUAKE : 1"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).EarthquakeEffectToggleBtn.IsChecked = true;

                                Log.Info("Настройка SacredUnderworld \"SCREEN_QUAKE\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"FONTFILTER\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_IP_ADDRESS : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ServerIpTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);

                                Log.Info("Настройка SacredUnderworld \"NETWORK_IP_ADDRESS\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_PORT_LISTEN : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ServerPortTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);

                                Log.Info("Настройка SacredUnderworld \"NETWORK_PORT_LISTEN\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_SESSION : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ServerNameTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);

                                Log.Info("Настройка SacredUnderworld \"NETWORK_SESSION\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_PLAYER : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ServerNickNameTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);

                                Log.Info("Настройка SacredUnderworld \"NETWORK_PLAYER\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_PASSWORD : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ServerPasswordTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);

                                Log.Info("Настройка SacredUnderworld \"NETWORK_PASSWORD\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("GFXLOADING : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).PictureStartTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);

                                Log.Info("Настройка SacredUnderworld \"GFXLOADING\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("GFXSTARTUP : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).PictureSaveLoadTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);

                                Log.Info("Настройка SacredUnderworld \"GFXSTARTUP\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("NETWORK_LOBBY : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ServerLobbyTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);

                                Log.Info("Настройка SacredUnderworld \"NETWORK_LOBBY\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"AUTOSAVEDELAY\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"CHAT_LINES\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("CHAT_DELAY : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ChatTextDelaySlider.Value = int.Parse(text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2));

                                Log.Info("Настройка SacredUnderworld \"CHAT_DELAY\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("CHAT_ALPHA : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ChatTransparentSlider.Value = int.Parse(text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2));

                                Log.Info("Настройка SacredUnderworld \"CHAT_ALPHA\" загружена.");
                            }
                        }
                    }

                    if (text[i].Contains("MINIMAP_ALPHA : "))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).MapTransparentSlider.Value = int.Parse(text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2));

                                Log.Info("Настройка SacredUnderworld \"MINIMAP_ALPHA\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"WARNING_LEVEL\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"NIGHT_DARKNESS\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"MUSICVOLUME\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"SFXVOLUME\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"VOICEVOLUME\" загружена.");
                            }
                        }
                    }
                }

                Log.Info("Все активные настройки SacredUnderworld были загружены без ошибок.");

                Log.Info("Получаем не загруженные функции всех настроек SacredUnderworld.");

                using (StreamReader sr = new StreamReader("Settings.cfg"))
                {
                    string contents = sr.ReadToEnd();

                    if (!contents.Contains("DETAILLEVEL"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).GraphicsQualityCmbBox.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"DETAILLEVEL\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"LANGUAGE\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("NETWORK_SPEEDSETTINGS"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ConnectTypeCmbBox.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"NETWORK_SPEEDSETTINGS\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"SOUNDQUALITY\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("PICKUPANIM"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).AnimationToggleBtn.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"PICKUPANIM\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"PICKUPAUTO\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"SOUND\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("SHOWMOVIE"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ShowMoviesToggleBtn.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"SHOWMOVIE\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"AUTOSAVE\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"ACCEPT_LICENSE\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("COMPAT_VIDEO"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).CompatibilityModeToggleBtn.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"COMPAT_VIDEO\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("SHOWPOTIONS"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).DopingBarToggleBtn.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"SHOWPOTIONS\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("SHOW_ENEMYINFO"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).EnemyInfoToggleBtn.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"SHOW_ENEMYINFO\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("UNIQUE_COLOR"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).RainbowChatToggleBtn.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"UNIQUE_COLOR\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("NETLOG"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).NetLoggingToggleBtn.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"NETLOG\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"LOGGING\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("NETWORK_CDKEY_HIDE"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).HideCdKeyToggleBtn.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"NETWORK_CDKEY_HIDE\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"LADDER_EXPORT\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("SHOW_HEROINFO"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).PlayerInfoToggleBtn.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"SHOW_HEROINFO\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("FONTAA"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).FontSmoothToggleBtn.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"FONTAA\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("FORCE_BLACK_SHADOW"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).OpaqueShadowsToggleBtn.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"FORCE_BLACK_SHADOW\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("GFX_LIMIT128"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).MemoryLimitToggleBtn.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"GFX_LIMIT128\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("FSAA_FILTER"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ImageSmoothingToggleBtn.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"FSAA_FILTER\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("FULLSCREEN"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).FullScreenModeToggleBtn.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"FULLSCREEN\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"DEFAULT_SKILLS\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"EXPLOREMAP\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("TASKBAR_ICONS"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).DamageIconsToggleBtn.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"TASKBAR_ICONS\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"AUTOTRACKENEMY\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("WAITRETRACE"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).VerticalSyncToggleBtn.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"WAITRETRACE\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"VIOLENCE\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"COMBINE_SLOTS\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("GFX32"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ColorDepthToggleBtn.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"GFX32\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("SCREEN_QUAKE"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).EarthquakeEffectToggleBtn.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"SCREEN_QUAKE\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"FONTFILTER\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("NETWORK_IP_ADDRESS"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ServerIpTxBox.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"NETWORK_IP_ADDRESS\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("NETWORK_PORT_LISTEN"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ServerPortTxBox.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"NETWORK_PORT_LISTEN\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("NETWORK_SESSION"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ServerNameTxBox.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"NETWORK_SESSION\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("NETWORK_PLAYER"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ServerNickNameTxBox.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"NETWORK_PLAYER\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("NETWORK_PASSWORD"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ServerPasswordTxBox.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"NETWORK_PASSWORD\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("GFXLOADING"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).PictureStartTxBox.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"GFXLOADING\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("GFXSTARTUP"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).PictureSaveLoadTxBox.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"GFXSTARTUP\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("NETWORK_LOBBY"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ServerLobbyTxBox.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"NETWORK_LOBBY\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"AUTOSAVEDELAY\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"CHAT_LINES\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("CHAT_DELAY"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ChatTextDelaySlider.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"CHAT_DELAY\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("CHAT_ALPHA"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).ChatTransparentSlider.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"CHAT_ALPHA\" не была загружена.");
                            }
                        }
                    }

                    if (!contents.Contains("MINIMAP_ALPHA"))
                    {
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window.GetType() == typeof(MainWindow))
                            {
                                ((MainWindow)window).MapTransparentSlider.IsEnabled = false;

                                Log.Warn("Настройка SacredUnderworld \"MINIMAP_ALPHA\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"WARNING_LEVEL\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"NIGHT_DARKNESS\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"MUSICVOLUME\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"SFXVOLUME\" не была загружена.");
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

                                Log.Warn("Настройка SacredUnderworld \"VOICEVOLUME\" не была загружена.");
                            }
                        }
                    }

                    Log.Info("Все не загруженные настройки SacredUnderworld были обнаружены и пропущены.");
                }

                Log.Info("Процессы получения игровых настроек завершен без ошибок.");
            }
            catch (Exception exception)
            {
                Log.Fatal("При загрузке активных настроек произошла ошибка."); Log.Fatal(exception.ToString());

                Log.Info("Завершение фоновых процессов и задачь. Выход из приложения."); Environment.Exit(0);
            }
        }
    }
}
