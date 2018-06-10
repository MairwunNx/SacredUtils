using System;
using log4net;
using System.IO;
using System.Text;
using System.Windows;
using static SacredUtils.Resources.Core.AppConstStrings;

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
                                ((MainWindow)window).DetailLevelCmbBox.SelectedIndex = 1;

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
                                ((MainWindow)window).DetailLevelCmbBox.SelectedIndex = 2;

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
                                ((MainWindow)window).SoundLanguageCmbBox.SelectedIndex = 0;

                                Log.Info("Настройка SacredUnderworld \"LANGUAGE\" загружена.");
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
                                ((MainWindow)window).SoundLanguageCmbBox.SelectedIndex = 2;

                                Log.Info("Настройка SacredUnderworld \"LANGUAGE\" загружена.");
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

                                Log.Info("Настройка SacredUnderworld \"LANGUAGE\" загружена.");
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
                                ((MainWindow)window).NetworkSpeedSettingsCmbBox.SelectedIndex = 2;

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
                                ((MainWindow)window).NetworkSpeedSettingsCmbBox.SelectedIndex = 1;

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
                                ((MainWindow)window).NetworkSpeedSettingsCmbBox.SelectedIndex = 0;

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
                                ((MainWindow)window).PickupAnimToggleBtn.IsChecked = true;

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
                                ((MainWindow)window).ShowMovieToggleBtn.IsChecked = true;

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
                                ((MainWindow)window).CompatVideoToggleBtn.IsChecked = true;

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
                                ((MainWindow)window).ShowPotionsToggleBtn.IsChecked = true;

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
                                ((MainWindow)window).ShowEnemyInfoToggleBtn.IsChecked = true;

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
                                ((MainWindow)window).UniqueColorToggleBtn.IsChecked = true;

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
                                ((MainWindow)window).NetlogToggleBtn.IsChecked = true;

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
                                ((MainWindow)window).NetworkCdkeyToggleBtn.IsChecked = true;

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
                                ((MainWindow)window).ShowHeroInfoToggleBtn.IsChecked = true;

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
                                ((MainWindow)window).FontaaToggleBtn.IsChecked = true;

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
                                ((MainWindow)window).ForceBlackShadowToggleBtn.IsChecked = true;

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
                                ((MainWindow)window).GfxLimit128ToggleButton.IsChecked = true;

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
                                ((MainWindow)window).FsaaFilterToggleBtn.IsChecked = true;

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
                                ((MainWindow)window).FullscreenToggleBtn.IsChecked = true;

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
                                ((MainWindow)window).TaskbarIconsToggleBtn.IsChecked = true;

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
                                ((MainWindow)window).WaitretraceToggleBtn.IsChecked = true;

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
                                ((MainWindow)window).Gfx32ToggleBtn.IsChecked = true;

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
                                ((MainWindow)window).ScreenQuakeToggleBtn.IsChecked = true;

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
                                ((MainWindow)window).NetworkIpAddressTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);

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
                                ((MainWindow)window).NetworkPortListenTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);

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
                                ((MainWindow)window).NetworkSessionTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);

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
                                ((MainWindow)window).NetworkPlayerTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);

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
                                ((MainWindow)window).NetworkPasswordTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);

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
                                ((MainWindow)window).GfxStartupTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);

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
                                ((MainWindow)window).GfxLoadingTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);

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
                                ((MainWindow)window).NetworkLobbyTxBox.Text = text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2);

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
                                ((MainWindow)window).ChatDelaySlider.Value = int.Parse(text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2));

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
                                ((MainWindow)window).ChatAlphaSlider.Value = int.Parse(text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2));

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
                                ((MainWindow)window).MinimapAlphaSlider.Value = int.Parse(text[i].Substring(text[i].IndexOf(": ", StringComparison.Ordinal) + 2));

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
                                ((MainWindow)window).NetworkSpeedSettingsCmbBox.IsEnabled = false;

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
                                ((MainWindow)window).PickupAnimToggleBtn.IsEnabled = false;

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
                                ((MainWindow)window).ShowMovieToggleBtn.IsEnabled = false;

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
                                ((MainWindow)window).CompatVideoToggleBtn.IsEnabled = false;

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
                                ((MainWindow)window).ShowPotionsToggleBtn.IsEnabled = false;

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
                                ((MainWindow)window).ShowEnemyInfoToggleBtn.IsEnabled = false;

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
                                ((MainWindow)window).UniqueColorToggleBtn.IsEnabled = false;

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
                                ((MainWindow)window).NetlogToggleBtn.IsEnabled = false;

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
                                ((MainWindow)window).NetworkCdkeyToggleBtn.IsEnabled = false;

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
                                ((MainWindow)window).ShowHeroInfoToggleBtn.IsEnabled = false;

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
                                ((MainWindow)window).FontaaToggleBtn.IsEnabled = false;

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
                                ((MainWindow)window).ForceBlackShadowToggleBtn.IsEnabled = false;

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
                                ((MainWindow)window).GfxLimit128ToggleButton.IsEnabled = false;

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
                                ((MainWindow)window).FsaaFilterToggleBtn.IsEnabled = false;

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
                                ((MainWindow)window).FullscreenToggleBtn.IsEnabled = false;

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
                                ((MainWindow)window).TaskbarIconsToggleBtn.IsEnabled = false;

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
                                ((MainWindow)window).WaitretraceToggleBtn.IsEnabled = false;

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
                                ((MainWindow)window).Gfx32ToggleBtn.IsEnabled = false;

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
                                ((MainWindow)window).ScreenQuakeToggleBtn.IsEnabled = false;

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
                                ((MainWindow)window).NetworkIpAddressTxBox.IsEnabled = false;

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
                                ((MainWindow)window).NetworkPortListenTxBox.IsEnabled = false;

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
                                ((MainWindow)window).NetworkSessionTxBox.IsEnabled = false;

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
                                ((MainWindow)window).NetworkPlayerTxBox.IsEnabled = false;

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
                                ((MainWindow)window).NetworkPasswordTxBox.IsEnabled = false;

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
                                ((MainWindow)window).GfxStartupTxBox.IsEnabled = false;

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
                                ((MainWindow)window).GfxLoadingTxBox.IsEnabled = false;

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
                                ((MainWindow)window).NetworkLobbyTxBox.IsEnabled = false;

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
                                ((MainWindow)window).ChatDelaySlider.IsEnabled = false;

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
                                ((MainWindow)window).ChatAlphaSlider.IsEnabled = false;

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
                                ((MainWindow)window).MinimapAlphaSlider.IsEnabled = false;

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
