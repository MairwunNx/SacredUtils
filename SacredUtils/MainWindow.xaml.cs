#region UsingDirectives.

using System;
using log4net;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Diagnostics;
using System.Drawing.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;
using SacredUtils.Resources.Core;
using System.Collections.Generic;
using SacredUtils.Resources.Logger;
using SacredUtils.Resources.Windows;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Application = System.Windows.Forms.Application;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using static SacredUtils.Resources.Core.AppConstStrings;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

#endregion

namespace SacredUtils
{
    public partial class MainWindow
    {
        #region SacredUtilsFieldsAndStrings.

        private readonly string _appname = Path.GetFileName(Application.ExecutablePath);

        private static readonly ILog Log = LogManager.GetLogger("LOGGER");

        #endregion

        #region SacredUtilsWindowButtonHandlers.

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Log.Info("Завершение фоновых процессов и задачь. Выход из приложения."); Environment.Exit(0);
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            Log.Info("Приостановка фоновых процессов и задачь. Сворачивание приложения."); WindowState = WindowState.Minimized;
        }

        private void ChangeColor_Click(object sender, RoutedEventArgs e)
        {
            var colorPicker = new ColorWindow(); colorPicker.Show();
        }

        public void ChangeSettingsCategory(UIElement element)
        {
            foreach (Grid c in SettingsGrid.Children.OfType<Grid>())
            {
                if (c.IsVisible) { c.Visibility = Visibility.Hidden; }
            }

            NotSelectedLbl.Visibility = Visibility.Hidden;

            element.Visibility = Visibility.Visible;
        }

        private void SettingsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SettingsListBox.SelectedIndex == 0)
            {
                ChangeSettingsCategory(GraphicsSettings01Grid);
            }

            if (SettingsListBox.SelectedIndex == 1)
            {
                ChangeSettingsCategory(GraphicsSettings02Grid);
            }

            if (SettingsListBox.SelectedIndex == 2)
            {
                ChangeSettingsCategory(SoundSettingsGrid);
            }

            if (SettingsListBox.SelectedIndex == 3)
            {
                ChangeSettingsCategory(NetworkSettings01Grid);
            }

            if (SettingsListBox.SelectedIndex == 4)
            {
                ChangeSettingsCategory(NetworkSettings02Grid);
            }

            if (SettingsListBox.SelectedIndex == 5)
            {
                ChangeSettingsCategory(ChatSettingsGrid);
            }

            if (SettingsListBox.SelectedIndex == 6)
            {
                ChangeSettingsCategory(GameSettings01Grid);
            }

            if (SettingsListBox.SelectedIndex == 7)
            {
                ChangeSettingsCategory(GameSettings02Grid);
            }

            if (SettingsListBox.SelectedIndex == 8)
            {
                ChangeSettingsCategory(FontsSettingsGrid);
            }

            if (SettingsListBox.SelectedIndex == 9)
            {
                ChangeSettingsCategory(OtherSettingsGrid);
            }

            if (SettingsListBox.SelectedIndex == 10)
            {
                ChangeSettingsCategory(ModdingSettingsGrid);
            }

            if (SettingsListBox.SelectedIndex == 11)
            {
                ChangeSettingsCategory(AppSettingsGrid);
            }

            if (SettingsListBox.SelectedIndex == 12)
            {
                ChangeSettingsCategory(AboutGrid);
            }

            if (SettingsListBox.SelectedIndex == 14)
            {
                if (CloseProgramToggleBtn.IsChecked == true)
                {
                    if (ChangeImputLangToggleBtn.IsChecked == true)
                    {
                        if (File.Exists(SacredExe))
                        {
                            Log.Info("Запускаем Sacred.exe с параметрами : Изменить язык ввода, выйди из приложения.");
                            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));

                            Process.Start(SacredExe); Environment.Exit(0);
                        }
                    }
                    else if (ChangeImputLangToggleBtn.IsChecked == false)
                    {
                        Log.Info("Запускаем Sacred.exe с параметрами : Выйди из приложения.");

                        if (File.Exists(SacredExe)) { Process.Start(SacredExe); Environment.Exit(0); }
                    }
                }
                else if (MinimizeProgramToggleBtn.IsChecked == true)
                {
                    if (ChangeImputLangToggleBtn.IsChecked == true)
                    {
                        if (File.Exists(SacredExe))
                        {
                            Log.Info("Запускаем Sacred.exe с параметрами : Изменить язык ввода, свернуть приложение.");
                            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));

                            Process.Start(SacredExe); WindowState = WindowState.Minimized;
                        }
                    }
                    else if (ChangeImputLangToggleBtn.IsChecked == false)
                    {
                        Log.Info("Запускаем Sacred.exe с параметрами : Свернуть приложение.");

                        if (File.Exists(SacredExe)) { Process.Start(SacredExe); WindowState = WindowState.Minimized; }
                    }
                }
                else { if (File.Exists(SacredExe)) { Process.Start(SacredExe); } }
            }

            if (SettingsListBox.SelectedIndex == 15)
            {
                Log.Info("Завершение фоновых процессов и задачь. Перезагрузка приложения.");

                Process.Start(_appname); Environment.Exit(0);
            }
        }

        #endregion

        #region SacredUnderworldSetValueMethods.

        public void SetSettingsValue(string s, string v)
        {
            if (!File.Exists(SacredSettings))
            {
                Log.Fatal("Файл конфигурации игры внезапно пропал!!! Он будет восстановлен.");

                Log.Info("Создаем файл конфигурации игры из ресурсов программы.");

                try
                {
                    File.WriteAllBytes(SacredSettings, Properties.Resources.GameSettings);

                    Log.Info("Файл конфигурации игры был создан без ошибок.");
                }
                catch (Exception exception)
                {
                    Log.Fatal("Создание файла конфигурации закончилось с ошибкой."); Log.Fatal(exception.ToString());

                    Log.Info("Завершение фоновых процессов и задачь. Выход из приложения."); Environment.Exit(0);
                }
            }

            var text = File.ReadAllLines(SacredSettings, Encoding.ASCII);

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains(s + " : "))
                {
                    try
                    {
                        text[i] = s + " : " + v; File.WriteAllLines(SacredSettings, text);
                    }
                    catch (Exception exception)
                    {
                        Log.Error("При изменении значения " + s + " на " + v + " произошла ошибка."); Log.Error(exception.ToString());
                    }
                }
            }
        }

        public void SetSettingsValueForFont(string s, string v)
        {
            if (!File.Exists(SacredSettings))
            {
                Log.Fatal("Файл конфигурации игры внезапно пропал!!! Он будет восстановлен.");

                Log.Info("Создаем файл конфигурации игры из ресурсов программы.");

                try
                {
                    File.WriteAllBytes(SacredSettings, Properties.Resources.GameSettings);

                    Log.Info("Файл конфигурации игры был создан без ошибок.");
                }
                catch (Exception exception)
                {
                    Log.Fatal("Создание файла конфигурации закончилось с ошибкой."); Log.Fatal(exception.ToString());

                    Log.Info("Завершение фоновых процессов и задачь. Выход из приложения."); Environment.Exit(0);
                }
            }

            var text = File.ReadAllLines(SacredSettings, Encoding.ASCII);

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains(s))
                {
                    try
                    {
                        text[i] = s + v; File.WriteAllLines(SacredSettings, text);
                    }
                    catch (Exception exception)
                    {
                        Log.Error("При изменении значения " + s + " на " + v + " произошла ошибка."); Log.Error(exception.ToString());
                    }
                }
            }
        }

        public void SetSettingsValueWithDouble(string s, double v)
        {
            if (!File.Exists(SacredSettings))
            {
                Log.Fatal("Файл конфигурации игры внезапно пропал!!! Он будет восстановлен.");

                Log.Info("Создаем файл конфигурации игры из ресурсов программы.");

                try
                {
                    File.WriteAllBytes(SacredSettings, Properties.Resources.GameSettings);

                    Log.Info("Файл конфигурации игры был создан без ошибок.");
                }
                catch (Exception exception)
                {
                    Log.Fatal("Создание файла конфигурации закончилось с ошибкой."); Log.Fatal(exception.ToString());

                    Log.Info("Завершение фоновых процессов и задачь. Выход из приложения."); Environment.Exit(0);
                }
            }

            var text = File.ReadAllLines(SacredSettings, Encoding.ASCII);

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains(s + " : "))
                {
                    try
                    {
                        text[i] = s + " : " + v; File.WriteAllLines(SacredSettings, text);
                    }
                    catch (Exception exception)
                    {
                        Log.Error("При изменении значения " + s + " на " + v + " произошла ошибка."); Log.Error(exception.ToString());
                    }
                }
            }
        }

        #endregion

        #region SacredUnderworldTxBoxEventHandlers.

        private void GfxStartupTxBox_KeyUp(object sender, KeyEventArgs e)
        {
            SetSettingsValue("GFXSTARTUP", GfxStartupTxBox.Text);
        }

        private void GfxLoadingTxBox_KeyUp(object sender, KeyEventArgs e)
        {
            SetSettingsValue("GFXLOADING", GfxLoadingTxBox.Text);
        }

        private void NetworkIpAddressTxBox_KeyUp(object sender, KeyEventArgs e)
        {
            SetSettingsValue("NETWORK_IP_ADDRESS", NetworkIpAddressTxBox.Text);
        }

        private void NetworkPortListenTxBox_KeyUp(object sender, KeyEventArgs e)
        {
            SetSettingsValue("NETWORK_PORT_LISTEN", NetworkPortListenTxBox.Text);
        }

        private void NetworkSessionTxBox_KeyUp(object sender, KeyEventArgs e)
        {
            SetSettingsValue("NETWORK_SESSION", NetworkSessionTxBox.Text);
        }

        private void NetworkPlayerTxBox_KeyUp(object sender, KeyEventArgs e)
        {
            SetSettingsValue("NETWORK_PLAYER", NetworkPlayerTxBox.Text);
        }

        private void NetworkPasswordTxBox_KeyUp(object sender, KeyEventArgs e)
        {
            SetSettingsValue("NETWORK_PASSWORD", NetworkPasswordTxBox.Text);
        }

        private void NetworkLobbyTxBox_KeyUp(object sender, KeyEventArgs e)
        {
            SetSettingsValue("NETWORK_LOBBY", NetworkLobbyTxBox.Text);
        }

        #endregion

        #region SacredUnderworldToggleButtonEventHandlers.

        private void FsaaFilterToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("FSAA_FILTER", FsaaFilterToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void GfxLimit128ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("GFX_LIMIT128", GfxLimit128ToggleButton.IsChecked == true ? "1" : "0");
        }

        private void CompatVideoToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("COMPAT_VIDEO", CompatVideoToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void Gfx32ToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("GFX32", Gfx32ToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void WaitretraceToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("WAITRETRACE", WaitretraceToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void ForceBlackShadowToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("FORCE_BLACK_SHADOW", ForceBlackShadowToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void FullscreenToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("FULLSCREEN", FullscreenToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void ShowMovieToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("SHOWMOVIE", ShowMovieToggleBtn.IsChecked == true ? "1" : "0");

            SetSettingsValue("SHOWEXTRO", ShowMovieToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void SoundToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("SOUND", SoundToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void NetlogToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("NETLOG", NetlogToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void NetworkCdkeyToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("NETWORK_CDKEY_HIDE", NetworkCdkeyToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void ShowHeroInfoToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("SHOW_HEROINFO", ShowHeroInfoToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void LadderExportToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("LADDER_EXPORT", LadderExportToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void LicenseToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("ACCEPT_LICENSE", LicenseToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void UniqueColorToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("UNIQUE_COLOR", UniqueColorToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void ShowPotionsToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("SHOWPOTIONS", ShowPotionsToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void ShowEnemyInfoToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("SHOW_ENEMYINFO", ShowEnemyInfoToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void PickupAnimToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("PICKUPANIM", PickupAnimToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void AutosaveToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("AUTOSAVE", AutosaveToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void ScreenQuakeToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("SCREEN_QUAKE", ScreenQuakeToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void DefaultSkillsToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("DEFAULT_SKILLS", DefaultSkillsToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void WarFogToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("EXPLOREMAP", WarFogToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void FontaaToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("FONTAA", FontaaToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void FontFilteringToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("FONTFILTER", FontFilteringToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void LogToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("LOGGING", LogToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void TaskbarIconsToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("TASKBAR_ICONS", TaskbarIconsToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void TrackEnemyToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("AUTOTRACKENEMY", TrackEnemyToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void ViolenceToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("VIOLENCE", ViolenceToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void CombineSlotsToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("COMBINE_SLOTS", CombineSlotsToggleBtn.IsChecked == true ? "1" : "0");
        }

        #endregion

        #region SacredUnderworldComboboxEventHandlers.

        private void DetailLevelCmbBox_DropDownClosed(object sender, EventArgs e)
        {
            if (DetailLevelCmbBox.SelectedIndex == 0) { SetSettingsValue("DETAILLEVEL", "0"); }

            if (DetailLevelCmbBox.SelectedIndex == 1) { SetSettingsValue("DETAILLEVEL", "1"); }

            if (DetailLevelCmbBox.SelectedIndex == 2) { SetSettingsValue("DETAILLEVEL", "2"); }
        }

        private async void InterfaceLanguageCmbBox_DropDownClosed(object sender, EventArgs e)
        {
            if (InterfaceLanguageCmbBox.SelectedIndex == 0)
            {
                if (File.Exists("scripts" + "/" + "ru" + "/" + "global.res"))
                {
                    File.Delete("scripts" + "/" + "ru" + "/" + "global.res");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("rugui");

                    SetSettingsValue("LANGUAGE", "RU");
                }
                else if (!File.Exists("scripts" + "/" + "ru" + "/" + "global.res"))
                {
                    Directory.CreateDirectory("scripts" + "/" + "ru");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("rugui");

                    SetSettingsValue("LANGUAGE", "RU");
                }
            }

            if (InterfaceLanguageCmbBox.SelectedIndex == 1)
            {
                if (File.Exists("scripts" + "/" + "us" + "/" + "global.res"))
                {
                    File.Delete("scripts" + "/" + "us" + "/" + "global.res");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("usgui");

                    SetSettingsValue("LANGUAGE", "US");
                }
                else if (!File.Exists("scripts" + "/" + "us" + "/" + "global.res"))
                {
                    Directory.CreateDirectory("scripts" + "/" + "us");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("usgui");

                    SetSettingsValue("LANGUAGE", "US");
                }
            }

            if (InterfaceLanguageCmbBox.SelectedIndex == 2)
            {
                if (File.Exists("scripts" + "/" + "de" + "/" + "global.res"))
                {
                    File.Delete("scripts" + "/" + "de" + "/" + "global.res");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("degui");

                    SetSettingsValue("LANGUAGE", "DE");
                }
                else if (!File.Exists("scripts" + "/" + "de" + "/" + "global.res"))
                {
                    Directory.CreateDirectory("scripts" + "/" + "de");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("degui");

                    SetSettingsValue("LANGUAGE", "DE");
                }
            }

            if (InterfaceLanguageCmbBox.SelectedIndex == 3)
            {
                if (File.Exists("scripts" + "/" + "sp" + "/" + "global.res"))
                {
                    File.Delete("scripts" + "/" + "sp" + "/" + "global.res");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("spgui");

                    SetSettingsValue("LANGUAGE", "SP");
                }
                else if (!File.Exists("scripts" + "/" + "sp" + "/" + "global.res"))
                {
                    Directory.CreateDirectory("scripts" + "/" + "sp");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("spgui");

                    SetSettingsValue("LANGUAGE", "SP");
                }
            }

            if (InterfaceLanguageCmbBox.SelectedIndex == 4)
            {
                if (File.Exists("scripts" + "/" + "fr" + "/" + "global.res"))
                {
                    File.Delete("scripts" + "/" + "fr" + "/" + "global.res");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("frgui");

                    SetSettingsValue("LANGUAGE", "FR");
                }
                else if (!File.Exists("scripts" + "/" + "fr" + "/" + "global.res"))
                {
                    Directory.CreateDirectory("scripts" + "/" + "fr");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("frgui");

                    SetSettingsValue("LANGUAGE", "FR");
                }
            }
        }

        private void PickupSettingsCmbBox_DropDownClosed(object sender, EventArgs e)
        {
            if (PickupSettingsCmbBox.SelectedIndex == 0) { SetSettingsValue("PICKUPAUTO", "0"); }

            if (PickupSettingsCmbBox.SelectedIndex == 1) { SetSettingsValue("PICKUPAUTO", "1"); }

            if (PickupSettingsCmbBox.SelectedIndex == 2) { SetSettingsValue("PICKUPAUTO", "2"); }
        }

        private void FontLibraryCmbBox_DropDownClosed(object sender, EventArgs e)
        {
            SetSettingsValueForFont("FONT : 1, ", "\"" + FontLibraryCmbBox.Text + "\"" + ", 10");
            SetSettingsValueForFont("FONT : 2, ", "\"" + FontLibraryCmbBox.Text + "\"" + ", 10");
            SetSettingsValueForFont("FONT : 3, ", "\"" + FontLibraryCmbBox.Text + "\"" + ", 12");
            SetSettingsValueForFont("FONT : 4, ", "\"" + FontLibraryCmbBox.Text + "\"" + ", 15");
            SetSettingsValueForFont("FONT : 5, ", "\"" + FontLibraryCmbBox.Text + "\"" + ", 12");
            SetSettingsValueForFont("FONT : 6, ", "\"" + FontLibraryCmbBox.Text + "\"" + ", 12");
            SetSettingsValueForFont("FONT : 7, ", "\"" + FontLibraryCmbBox.Text + "\"" + ", 8");
        }

        private void NetworkSpeedSettingsCmbBox_DropDownClosed(object sender, EventArgs e)
        {
            if (NetworkSpeedSettingsCmbBox.SelectedIndex == 0) { SetSettingsValue("NETWORK_SPEEDSETTINGS", "2"); }

            if (NetworkSpeedSettingsCmbBox.SelectedIndex == 1) { SetSettingsValue("NETWORK_SPEEDSETTINGS", "1"); }

            if (NetworkSpeedSettingsCmbBox.SelectedIndex == 2) { SetSettingsValue("NETWORK_SPEEDSETTINGS", "0"); }
        }

        private void SoundQualityCmbBox_DropDownClosed(object sender, EventArgs e)
        {
            if (SoundQualityCmbBox.SelectedIndex == 0) { SetSettingsValue("SOUNDQUALITY", "0"); }

            if (SoundQualityCmbBox.SelectedIndex == 1) { SetSettingsValue("SOUNDQUALITY", "1"); }

            if (SoundQualityCmbBox.SelectedIndex == 2) { SetSettingsValue("SOUNDQUALITY", "2"); }
        }

        private async void SoundLanguageCmbBox_DropDownClosed(object sender, EventArgs e)
        {
            if (SoundLanguageCmbBox.SelectedIndex == 0)
            {
                var soundWindow = new ComponentsWindow(); soundWindow.Show();

                var downloadComponents = new DownloadComponents();
                await downloadComponents.GetSoundComponent("ru");       
            }

            if (SoundLanguageCmbBox.SelectedIndex == 1)
            {
                var soundWindow = new ComponentsWindow(); soundWindow.Show();

                var downloadComponents = new DownloadComponents();
                await downloadComponents.GetSoundComponent("us");
            }

            if (SoundLanguageCmbBox.SelectedIndex == 2)
            {
                var soundWindow = new ComponentsWindow(); soundWindow.Show();

                var downloadComponents = new DownloadComponents();
                await downloadComponents.GetSoundComponent("de");
            }

            if (SoundLanguageCmbBox.SelectedIndex == 3)
            {
                var soundWindow = new ComponentsWindow(); soundWindow.Show();

                var downloadComponents = new DownloadComponents();
                await downloadComponents.GetSoundComponent("sp");
            }
        }

        #endregion

        #region SacredUnderworldSliderEventHandlers.

        private void MinimapAlphaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<Double> e)
        {
            SetSettingsValueWithDouble("MINIMAP_ALPHA", MinimapAlphaSlider.Value);
        }

        private void NightDarknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SetSettingsValueWithDouble("NIGHT_DARKNESS", NightDarknessSlider.Value);
        }

        private void VolumeMusicSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SetSettingsValueWithDouble("MUSICVOLUME", VolumeMusicSlider.Value);
        }

        private void VolumeSfxSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SetSettingsValueWithDouble("SFXVOLUME", VolumeSfxSlider.Value);
        }

        private void VolumeVoiceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SetSettingsValueWithDouble("VOICEVOLUME", VolumeVoiceSlider.Value);
        }

        private void ChatLinesSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SetSettingsValueWithDouble("CHAT_LINES", ChatLinesSlider.Value);
        }

        private void ChatDelaySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SetSettingsValueWithDouble("CHAT_DELAY", ChatDelaySlider.Value);
        }

        private void ChatAlphaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SetSettingsValueWithDouble("CHAT_ALPHA", ChatAlphaSlider.Value);
        }

        private void AutosaveDelaySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SetSettingsValueWithDouble("AUTOSAVEDELAY", AutosaveDelaySlider.Value);
        }

        private void WarningPercentSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SetSettingsValueWithDouble("WARNING_LEVEL", WarningPercentSlider.Value);
        }

        #endregion

        #region SacredUtilsWindowMethodsAndHandlers.

        public MainWindow()
        {
            Log.Info("[MethodCall] Вызываем метод инициализации логгера.");

            Logger.InitLogger();

            Log.Info("[MethodCall] Вызов метода инициализации логгера завершен.");

            Log.Info("[MethodCall] Вызываем метод проверки файла отладки из другого класса.");

            var checkAppPdbFile = new CheckAppPdbFile();
            checkAppPdbFile.GetAvailablePdbFile();

            Log.Info("[MethodCall] Вызов метода проверки файла отладки завершен.");

            Log.Info("[MethodCall] Вызываем метод проверки файла лицензии из другого класса.");

            var checkAppLicenseFile = new CheckAppLicenseFile();
            checkAppLicenseFile.GetAvailableLicenseFile();

            Log.Info("[MethodCall] Вызов метода проверки файла лицензии завершен.");

            Log.Info("[MethodCall] Вызываем метод проверки конфигурации лога из другого класса.");

            var checkLogConfiguration = new CheckLogConfiguration();
            checkLogConfiguration.GetAvailableLogConfig();

            Log.Info("[MethodCall] Вызов метода проверки конфигурации лога завершен.");

            Log.Info("[MethodCall] Вызываем метод отправки статистики из другого класса.");

            var sendDownloadStatistic = new SendDownloadStatistic();

            Task.Run(() => sendDownloadStatistic.CheckFirstInstallAsync());

            Log.Info("[MethodCall] Вызов метода отправки статистики завершен.");

            Log.Info("[MethodCall] Вызываем метод проверки конфигурации SacredUtils из другого класса.");

            var checkAppConfiguration = new CheckAppConfiguration();
            checkAppConfiguration.GetAvailableAppConfig();

            Log.Info("[MethodCall] Вызов метода проверки конфигурации SacredUtils завершен.");

            Log.Info("[MethodCall] Вызываем метод удаления временных файлов из другого класса.");

            var checkAppTempFiles = new CheckAppTempFiles();
            checkAppTempFiles.CheckAvailableTempFiles();

            Log.Info("[MethodCall] Вызов метода удаления временных файлов завершен.");

            Log.Info("[MethodCall] Вызываем метод инициализации компонентов SacredUtils из другого класса.");

            InitializeComponent();

            Log.Info("[MethodCall] Вызов метода инициализации компонентов SacredUtils завершен.");

            Log.Info("[MethodCall] Вызываем метод проверки обновления из другого класса.");

            var checkAppUpdates = new CheckAppUpdates();

            #pragma warning disable CS4014 // Так как этот вызов не ожидается, выполнение существующего метода продолжается до завершения вызова.
            checkAppUpdates.GetAvailableAppUpdatesAsync();
            #pragma warning restore CS4014 // Так как этот вызов не ожидается, выполнение существующего метода продолжается до завершения вызова.

            Log.Info("[MethodCall] Вызов метода проверки обновления завершен.");

            Log.Info("[MethodCall] Вызываем метод проверки настроек SacredUtils из другого класса.");

            var getAppSettings = new GetAppSettings();
            getAppSettings.LoadAppSettings();

            Log.Info("[MethodCall] Вызов метода проверки настроек SacredUtils завершен.");

            Log.Info("[MethodCall] Вызываем метод проверки настроек SacredUnderworld из другого класса.");

            var getGameSettings = new GetGameSettings();
            getGameSettings.LoadGameSettings();

            Log.Info("[MethodCall] Вызов метода проверки настроек SacredUnderworld завершен.");

            Log.Info("Поиск файла для загрузки данных о статусе модификаций.");

            if (File.Exists(AppDataFolder + "/" + AppInstallInfo))
            {
                Log.Info("Файл для загрузки данных о статусе модификаций был найден.");

                var text = File.ReadAllText(AppDataFolder + "/" + AppInstallInfo, Encoding.ASCII);

                Log.Info("Загрузка данных о статусе установок модификаций.");

                if (text.Contains("Veteranmod by ufo installed = true"))
                {
                    VeteranModUfoBtn.Content = "УДАЛИТЬ";

                    Log.Info("Статус функции \"Veteranmod by ufo installed\" был загружен.");
                }
                else if (text.Contains("Veteranmod by ufo installed = false"))
                {
                    VeteranModUfoBtn.Content = "УСТАНОВИТЬ";

                    Log.Info("Статус функции \"Veteranmod by ufo installed\" был загружен.");
                }

                if (text.Contains("Veteranmod dragonfix installed = true"))
                {
                    VeteranModDragonFixBtn.Content = "УДАЛИТЬ";

                    Log.Info("Статус функции \"Veteranmod dragonfix installed\" был загружен.");
                }
                else if (text.Contains("Veteranmod dragonfix installed = false"))
                {
                    VeteranModDragonFixBtn.Content = "УСТАНОВИТЬ";

                    Log.Info("Статус функции \"Veteranmod dragonfix installed\" был загружен.");
                }

                if (text.Contains("Sacred 2.29.14 patch installed = true"))
                {
                    SacredNewUpdateBtn.Content = "УДАЛИТЬ";

                    Log.Info("Статус функции \"Sacred 2.29.14 patch installed\" был загружен.");
                }
                else if (text.Contains("Sacred 2.29.14 patch installed = false"))
                {
                    SacredNewUpdateBtn.Content = "УСТАНОВИТЬ";

                    Log.Info("Статус функции \"Sacred 2.29.14 patch installed\" был загружен.");
                }

                if (text.Contains("Server multicore fix installed = true"))
                {
                    ServerMulticoreFixBtn.Content = "УДАЛИТЬ";

                    Log.Info("Статус функции \"Server multicore fix installed\" был загружен.");
                }
                else if (text.Contains("Server multicore fix installed = false"))
                {
                    ServerMulticoreFixBtn.Content = "УСТАНОВИТЬ";

                    Log.Info("Статус функции \"Server multicore fix installed\" был загружен.");
                }

                Log.Info("Загрузка данных о статусе установок модификаций завершена без ошибок.");
            }
            else if (!File.Exists(AppDataFolder + "/" + AppInstallInfo))
            {
                Log.Warn("Файл для загрузки данных о статусе модификаций не был найден.");

                Log.Info("Создаем директорию для файла installinfo.dat.");

                Directory.CreateDirectory(AppDataFolder);

                Log.Info("Создание директории для файла installinfo.dat завершено без ошибок.");

                Log.Info("Создание файла installinfo.dat из ресурсов программы.");

                try
                {
                    File.WriteAllBytes(AppDataFolder + "/" + AppInstallInfo, Properties.Resources.installinfo);

                    Log.Info("Создание файла installinfo.dat из ресурсов программы завершено без ошибок.");
                }
                catch (Exception exception)
                {
                    Log.Error("Создание файла installinfo.dat закончилось с ошибкой."); Log.Error(exception.ToString());
                }

                VeteranModUfoBtn.Content = "УСТАНОВИТЬ"; VeteranModDragonFixBtn.Content = "УСТАНОВИТЬ";
                SacredNewUpdateBtn.Content = "УСТАНОВИТЬ"; ServerMulticoreFixBtn.Content = "УСТАНОВИТЬ";
            }

            if (File.Exists(AppDataFolder + "/" + AppStatistic))
            {
                try
                {
                    var text = File.ReadAllText(AppDataFolder + "/" + AppStatistic);

                    var numberOfStartups = Regex.Match(text, @"\d+").Value;

                    var newNumberOfStartups = Convert.ToInt32(numberOfStartups) + 1;

                    var fileAllText = File.ReadAllLines(AppDataFolder + "/" + AppStatistic);
                    fileAllText[3] = "; The program is launched " + newNumberOfStartups + " time(s)";
                    File.WriteAllLines(AppDataFolder + "/" + AppStatistic, fileAllText);

                    Log.Info("Данные о запуске SacredUtils были сохранены в launchstat.dat.");
                }
                catch (Exception exception)
                {
                    Log.Error("Операция по счету запуска SacredUtils завершилась с ошибкой."); Log.Error(exception.ToString());
                }

            }
            else if (!File.Exists(AppDataFolder + "/" + AppStatistic))
            {
                Directory.CreateDirectory(".SacredUtilsData");

                File.WriteAllBytes(AppDataFolder + "/" + AppStatistic, Properties.Resources.launchstat);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Log.Info("Загружаем коллекцию шрифтов для SacredUtils.");

            try
            {
                InstalledFontCollection installedFonts = new InstalledFontCollection();
                List<string> fonts = installedFonts.Families.Select(font => font.Name).ToList();

                FontLibraryCmbBox.ItemsSource = fonts; fonts.Remove("");

                Log.Info("Коллекция шрифтов загружена без ошибок.");
            }
            catch (Exception exception)
            {
                Log.Error("При загрузке коллекции шрифтов произошла ошибка.");

                Log.Error(exception.ToString());
            }

            var text = File.ReadAllLines(SacredSettings, Encoding.ASCII);

            Log.Info("Подготавливаем коллекцию шрифтов для FontsCombobox.");

            for (var i = 0; i < text.Length; i++)
            {
                if (text[i].Contains("FONT : 1, "))
                {
                    var tempdata0 = text[i].Substring(text[i].IndexOf("\"", StringComparison.Ordinal) + 1);

                    if (tempdata0 == text[i].Substring(text[i].IndexOf("\"", StringComparison.Ordinal) + 1))
                    {
                        var tempdata1 = tempdata0.Remove(tempdata0.LastIndexOf("\"", StringComparison.Ordinal));

                        FontLibraryCmbBox.SelectedItem = tempdata1;

                        Log.Info("Загрузка шрифтов в FontsCombobox выполнена без ошибок.");
                    }
                }
            }

            var text1 = File.ReadAllLines("Settings.su", Encoding.ASCII);

            Log.Info("Загружаем цветовые схемы для SacredUtils.");

            for (var i = 0; i < text1.Length; i++)
            {
                try
                {
                    if (text1[i].Contains(AppColorValue + " = default") || text1[i].Contains("User interface color SacredUtils = indigo"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#7986cb", "#303f9f", "#3f51b5", "#c5cae9", "Indigo", "#FFFFFFFF");
                    }

                    if (text1[i].Contains(AppColorValue + " = red"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#e57373", "#d32f2f", "#f44336", "#ffcdd2", "Red", "#FFFFFFFF");
                    }

                    if (text1[i].Contains(AppColorValue + " = pink"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#f06292", "#c2185b", "#e91e63", "#f8bbd0", "Pink", "#FFFFFFFF");
                    }

                    if (text1[i].Contains(AppColorValue + " = purple"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#ba68c8", "#7b1fa2", "#9c27b0", "#e1bee7", "Purple", "#FFFFFFFF");
                    }

                    if (text1[i].Contains(AppColorValue + " = deeppurple"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#9575cd", "#512da8", "#673ab7", "#d1c4e9", "DeepPurple", "#FFFFFFFF");
                    }

                    if (text1[i].Contains(AppColorValue + " = blue"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#64b5f6", "#1976d2", "#2196f3", "#bbdefb", "Blue", "#FFFFFFFF");
                    }

                    if (text1[i].Contains(AppColorValue + " = lightblue"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#4fc3f7", "#0288d1", "#03a9f4", "#b3e5fc", "LightBlue", "#000000");
                    }

                    if (text1[i].Contains(AppColorValue + " = cyan"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#4dd0e1", "#0097a7", "#00bcd4", "#b2ebf2", "Cyan", "#000000");
                    }

                    if (text1[i].Contains(AppColorValue + " = teal"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#4db6ac", "#00796b", "#009688", "#b2dfdb", "Teal", "#ffffff");
                    }

                    if (text1[i].Contains(AppColorValue + " = green"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#81c784", "#388e3c", "#4caf50", "#c8e6c9", "Green", "#ffffff");
                    }

                    if (text1[i].Contains(AppColorValue + " = lightgreen"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#aed581", "#689f38", "#8bc34a", "#dcedc8", "LightGreen", "#000000");
                    }

                    if (text1[i].Contains(AppColorValue + " = lime"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#dce775", "#afb42b", "#cddc39", "#f0f4c3", "Lime", "#000000");
                    }

                    if (text1[i].Contains(AppColorValue + " = yellow"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#fff176", "#fbc02d", "#ffeb3b", "#fff9c4", "Yellow", "#000000");
                    }

                    if (text1[i].Contains(AppColorValue + " = amber"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#ffd54f", "#ffa000", "#ffc107", "#ffecb3", "Amber", "#000000");
                    }

                    if (text1[i].Contains(AppColorValue + " = orange"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#ffb74d", "#f57c00", "#ff9800", "#ffe0b2", "Orange", "#000000");
                    }

                    if (text1[i].Contains(AppColorValue + " = deeporange"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#ff8a65", "#e64a19", "#ff5722", "#ffccbc", "DeepOrange", "#000000");
                    }

                    if (text1[i].Contains(AppColorValue + " = brown"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#a1887f", "#5d4037", "#795548", "#d7ccc8", "Brown", "#ffffff");
                    }

                    if (text1[i].Contains(AppColorValue + " = grey"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#e0e0e0", "#616161", "#9e9e9e", "#f5f5f5", "Grey", "#000000");
                    }

                    if (text1[i].Contains(AppColorValue + " = bluegrey"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#90a4ae", "#455a64", "#607d8b", "#cfd8dc", "BlueGrey", "#ffffff");
                    }

                    if (text1[i].Contains(AppColorValue + " = black"))
                    {
                        var colorWindow = new ColorWindow(); colorWindow.Close();

                        colorWindow.ChangeColor("#484848", "#000000", "#212121", "#484848", "DeepOrange", "#ffffff");

                        BrushConverter bc = new BrushConverter();

                        CardBackgroundColor.Background = (Brush)bc.ConvertFrom("#2c2c2c");

                        NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DDCBCBCB");

                        SettingsNameColor.Foreground = (Brush)bc.ConvertFrom("#eeeeee");

                        CardCaptionsColor.Foreground = (Brush)bc.ConvertFrom("#e0e0e0");

                        ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#eeeeee");
                        ColorCombobox.Background = (Brush)bc.ConvertFrom("#2c2c2c");

                        ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#eeeeee");
                    }
                }
                catch (Exception exception)
                {
                    Log.Error("При загрузке цветовых схем произошла ошибка.");

                    Log.Error(exception.ToString());
                }
            }

            Log.Info("Цветовые схемы для SacredUtils были загружены без ошибок.");
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D1)
            {
                SettingsListBox.SelectedIndex = 0;
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D2)
            {
                SettingsListBox.SelectedIndex = 1;
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D3)
            {
                SettingsListBox.SelectedIndex = 2;
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D4)
            {
                SettingsListBox.SelectedIndex = 3;
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D5)
            {
                SettingsListBox.SelectedIndex = 4;
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D6)
            {
                SettingsListBox.SelectedIndex = 5;
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D7)
            {
                SettingsListBox.SelectedIndex = 6;
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D8)
            {
                SettingsListBox.SelectedIndex = 7;
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D9)
            {
                SettingsListBox.SelectedIndex = 8;
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D0)
            {
                SettingsListBox.SelectedIndex = 9;
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.Q)
            {
                SettingsListBox.SelectedIndex = 15;
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.W)
            {
                var colorPicker = new ColorWindow(); colorPicker.Show();
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.E)
            {
                Process.Start("https://vk.cc/85SSFN");
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.R)
            {
                Process.Start("https://vk.cc/85SSXC");
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.T)
            {
                Process.Start("https://vk.cc/85ST4b");
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.Y)
            {
                Process.Start("https://qiwi.me/mairwunnx");
            }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.U)
            {
                Process.Start("https://github.com/MairwunNx/SacredUtils/");
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) { DragMove(); }
        }

        #endregion

        #region SacredUtilsModdingButtonEventHandlers.

        private void VeteranModUfoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (VeteranModUfoBtn.Content.ToString() == "УСТАНОВИТЬ")
            {
                Log.Info("Подготовка к установке Veteran Mod by ufo сложности.");

                Log.Info("Создаем директории для Veteran Mod by ufo если их нет.");

                Directory.CreateDirectory("bin"); Directory.CreateDirectory("PAK");

                Log.Info("Директории для Veteran Mod by ufo были созданы без ошибок.");

                Log.Info("Устанавливаем Balance.bin в директорию bin.");

                try
                {
                    File.WriteAllBytes(@"bin" + "/" + "balance.bin", Properties.Resources.SacredBalanceVeteran);

                    Log.Info("Установка Balance.bin в директорию bin выполнена без ошибок.");
                }
                catch (Exception exception)
                {
                    Log.Error("При установки Balance.bin в директорию bin произошла ошибка.");

                    Log.Error(exception.ToString());
                }

                Log.Info("Устанавливаем Creature.pak в директорию PAK.");

                try
                {
                    File.WriteAllBytes(@"PAK" + "/" + "creature.pak", Properties.Resources.SacredCreatureVeteran);

                    Log.Info("Установка Creature.pak в директорию PAK выполнена без ошибок.");
                }
                catch (Exception exception)
                {
                    Log.Error("При установки Creature.pak в директорию PAK произошла ошибка.");

                    Log.Error(exception.ToString());
                }

                Log.Info("Установка Veteran Mod by ufo завершилась без ошибок.");

                Directory.CreateDirectory(AppDataFolder);

                if (File.Exists(AppDataFolder + "/" + AppInstallInfo))
                {
                    try
                    {
                        Log.Info("Сохраняем данные о статусе установки модификаций.");

                        var fileAllText = File.ReadAllLines(AppDataFolder + "/" + AppInstallInfo);

                        fileAllText[3] = "; Veteranmod by ufo installed = true";
                        fileAllText[4] = "; Veteranmod dragonfix installed = false";

                        File.WriteAllLines(AppDataFolder + "/" + AppInstallInfo, fileAllText);

                        Log.Info("Данные о статусе установки модификаций сохранены без ошибок.");
                    }
                    catch (Exception exception)
                    {
                        Log.Error("При сохранении статуса установки модификации произошла ошибка.");

                        Log.Error(exception.ToString());
                    }

                    VeteranModUfoBtn.Content = "УДАЛИТЬ"; VeteranModDragonFixBtn.Content = "УСТАНОВИТЬ";
                }
            }
            else if (VeteranModUfoBtn.Content.ToString() == "УДАЛИТЬ")
            {
                Log.Info("Подготовка к удалению Veteran Mod сложности.");

                Log.Info("Создаем директории для стандартной сложности если их нет.");

                Directory.CreateDirectory("bin"); Directory.CreateDirectory("PAK");

                Log.Info("Директории для стандартной сложности были созданы без ошибок.");

                Log.Info("Устанавливаем Balance.bin в директорию bin.");

                try
                {
                    File.WriteAllBytes(@"bin" + "/" + "balance.bin", Properties.Resources.SacredBalanceVanilla);

                    Log.Info("Установка Balance.bin в директорию bin выполнена без ошибок.");
                }
                catch (Exception exception)
                {
                    Log.Error("При установки Balance.bin в директорию bin произошла ошибка.");

                    Log.Error(exception.ToString());
                }

                Log.Info("Устанавливаем Creature.pak в директорию PAK.");

                try
                {
                    File.WriteAllBytes(@"PAK" + "/" + "creature.pak", Properties.Resources.SacredCreatureVanilla);

                    Log.Info("Установка Creature.pak в директорию PAK выполнена без ошибок.");
                }
                catch (Exception exception)
                {
                    Log.Error("При установки Creature.pak в директорию PAK произошла ошибка.");

                    Log.Error(exception.ToString());
                }

                Log.Info("Установка стандартной сложности завершилась без ошибок.");

                Directory.CreateDirectory(AppDataFolder);

                if (File.Exists(AppDataFolder + "/" + AppInstallInfo))
                {
                    try
                    {
                        Log.Info("Сохраняем данные о статусе установки модификаций.");

                        var fileAllText = File.ReadAllLines(AppDataFolder + "/" + AppInstallInfo);

                        fileAllText[3] = "; Veteranmod by ufo installed = false";
                        fileAllText[4] = "; Veteranmod dragonfix installed = false";

                        File.WriteAllLines(AppDataFolder + "/" + AppInstallInfo, fileAllText);

                        Log.Info("Данные о статусе установки модификаций сохранены без ошибок.");
                    }
                    catch (Exception exception)
                    {
                        Log.Error("При сохранении статуса установки модификации произошла ошибка.");

                        Log.Error(exception.ToString());
                    }

                    VeteranModUfoBtn.Content = "УСТАНОВИТЬ"; VeteranModDragonFixBtn.Content = "УСТАНОВИТЬ";
                }
            }
        }
        
        private void VeteranModDragonFixBtn_Click(object sender, RoutedEventArgs e)
        {
            if (VeteranModDragonFixBtn.Content.ToString() == "УСТАНОВИТЬ")
            {
                Log.Info("Подготовка к установке Veteran Mod by MairwunNx (DragonFix) сложности.");

                Log.Info("Создаем директории для Veteran Mod by MairwunNx (DragonFix) если их нет.");

                Directory.CreateDirectory("bin"); Directory.CreateDirectory("PAK");

                Log.Info("Директории для Veteran Mod by MairwunNx (DragonFix) были созданы без ошибок.");

                Log.Info("Устанавливаем Balance.bin в директорию bin.");

                try
                {
                    File.WriteAllBytes(@"bin" + "/" + "balance.bin", Properties.Resources.SacredBalanceDragonFix);

                    Log.Info("Установка Balance.bin в директорию bin выполнена без ошибок.");
                }
                catch (Exception exception)
                {
                    Log.Error("При установки Balance.bin в директорию bin произошла ошибка.");

                    Log.Error(exception.ToString());
                }

                Log.Info("Устанавливаем Creature.pak в директорию PAK.");

                try
                {
                    File.WriteAllBytes(@"PAK" + "/" + "creature.pak", Properties.Resources.SacredCreatureDragonFix);

                    Log.Info("Установка Creature.pak в директорию PAK выполнена без ошибок.");
                }
                catch (Exception exception)
                {
                    Log.Error("При установки Creature.pak в директорию PAK произошла ошибка.");

                    Log.Error(exception.ToString());
                }

                Log.Info("Установка Veteran Mod by MairwunNx (DragonFix) завершилась без ошибок.");

                Directory.CreateDirectory(AppDataFolder);

                if (File.Exists(AppDataFolder + "/" + AppInstallInfo))
                {
                    try
                    {
                        Log.Info("Сохраняем данные о статусе установки модификаций.");

                        var fileAllText = File.ReadAllLines(AppDataFolder + "/" + AppInstallInfo);

                        fileAllText[3] = "; Veteranmod by ufo installed = false";
                        fileAllText[4] = "; Veteranmod dragonfix installed = true";

                        File.WriteAllLines(AppDataFolder + "/" + AppInstallInfo, fileAllText);

                        Log.Info("Данные о статусе установки модификаций сохранены без ошибок.");
                    }
                    catch (Exception exception)
                    {
                        Log.Error("При сохранении статуса установки модификации произошла ошибка.");

                        Log.Error(exception.ToString());
                    }

                    VeteranModUfoBtn.Content = "УСТАНОВИТЬ"; VeteranModDragonFixBtn.Content = "УДАЛИТЬ";
                }
            }
            else if (VeteranModDragonFixBtn.Content.ToString() == "УДАЛИТЬ")
            {
                Log.Info("Подготовка к удалению Veteran Mod сложности.");

                Log.Info("Создаем директории для стандартной сложности если их нет.");

                Directory.CreateDirectory("bin"); Directory.CreateDirectory("PAK");

                Log.Info("Директории для стандартной сложности были созданы без ошибок.");

                Log.Info("Устанавливаем Balance.bin в директорию bin.");

                try
                {
                    File.WriteAllBytes(@"bin" + "/" + "balance.bin", Properties.Resources.SacredBalanceVanilla);

                    Log.Info("Установка Balance.bin в директорию bin выполнена без ошибок.");
                }
                catch (Exception exception)
                {
                    Log.Error("При установки Balance.bin в директорию bin произошла ошибка.");

                    Log.Error(exception.ToString());
                }

                Log.Info("Устанавливаем Creature.pak в директорию PAK.");

                try
                {
                    File.WriteAllBytes(@"PAK" + "/" + "creature.pak", Properties.Resources.SacredCreatureVanilla);

                    Log.Info("Установка Creature.pak в директорию PAK выполнена без ошибок.");
                }
                catch (Exception exception)
                {
                    Log.Error("При установки Creature.pak в директорию PAK произошла ошибка.");

                    Log.Error(exception.ToString());
                }

                Log.Info("Установка стандартной сложности завершилась без ошибок.");

                Directory.CreateDirectory(AppDataFolder);

                if (File.Exists(AppDataFolder + "/" + AppInstallInfo))
                {
                    try
                    {
                        Log.Info("Сохраняем данные о статусе установки модификаций.");

                        var fileAllText = File.ReadAllLines(AppDataFolder + "/" + AppInstallInfo);

                        fileAllText[3] = "; Veteranmod by ufo installed = false";
                        fileAllText[4] = "; Veteranmod dragonfix installed = false";

                        File.WriteAllLines(AppDataFolder + "/" + AppInstallInfo, fileAllText);

                        Log.Info("Данные о статусе установки модификаций сохранены без ошибок.");
                    }
                    catch (Exception exception)
                    {
                        Log.Error("При сохранении статуса установки модификации произошла ошибка.");

                        Log.Error(exception.ToString());
                    }

                    VeteranModUfoBtn.Content = "УСТАНОВИТЬ"; VeteranModDragonFixBtn.Content = "УСТАНОВИТЬ";
                }
            }
        }

        private async void SacredNewUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SacredNewUpdateBtn.Content.ToString() == "УСТАНОВИТЬ")
            {
                Log.Info("Подготовка к установке Sacred 2.29.14 версии.");

                try
                {
                    File.Delete("Sacred.exe");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("sacred229");

                    Log.Info("Установка Sacred до 2.29.14 версии прошла успешно.");
                }
                catch (Exception exception)
                {
                    Log.Error("При установке Sacred 2.29.14 версии произошла ошибка.");

                    Log.Error(exception.ToString());
                }

                Directory.CreateDirectory(AppDataFolder);

                if (File.Exists(AppDataFolder + "/" + AppInstallInfo))
                {
                    try
                    {
                        Log.Info("Сохраняем данные о статусе установки модификаций.");

                        var fileAllText = File.ReadAllLines(AppDataFolder + "/" + AppInstallInfo);

                        fileAllText[5] = "; Sacred 2.29.14 patch installed = true";

                        File.WriteAllLines(AppDataFolder + "/" + AppInstallInfo, fileAllText);

                        Log.Info("Данные о статусе установки модификаций сохранены без ошибок.");
                    }
                    catch (Exception exception)
                    {
                        Log.Error("При сохранении статуса установки модификации произошла ошибка.");

                        Log.Error(exception.ToString());
                    }

                    SacredNewUpdateBtn.Content = "УДАЛИТЬ";
                }
            }
            else if (SacredNewUpdateBtn.Content.ToString() == "УДАЛИТЬ")
            {
                Log.Info("Подготовка к удалению Sacred 2.29.14 версии.");

                try
                {
                    File.Delete("Sacred.exe");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("sacred228");

                    Log.Info("Удаление Sacred 2.29.14 версии прошла успешно.");
                }
                catch (Exception exception)
                {
                    Log.Error("При удалении Sacred 2.29.14 версии произошла ошибка.");

                    Log.Error(exception.ToString());
                }

                Directory.CreateDirectory(AppDataFolder);

                if (File.Exists(AppDataFolder + "/" + AppInstallInfo))
                {
                    try
                    {
                        Log.Info("Сохраняем данные о статусе установки модификаций.");

                        var fileAllText = File.ReadAllLines(AppDataFolder + "/" + AppInstallInfo);

                        fileAllText[5] = "; Sacred 2.29.14 patch installed = false";

                        File.WriteAllLines(AppDataFolder + "/" + AppInstallInfo, fileAllText);

                        Log.Info("Данные о статусе установки модификаций сохранены без ошибок.");
                    }
                    catch (Exception exception)
                    {
                        Log.Error("При сохранении статуса установки модификации произошла ошибка.");

                        Log.Error(exception.ToString());
                    }

                    SacredNewUpdateBtn.Content = "УСТАНОВИТЬ";
                }
            }
        }

        private async void ServerMulticoreFixBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ServerMulticoreFixBtn.Content.ToString() == "УСТАНОВИТЬ")
            {
                Log.Info("Подготовка к установке Sacred GameServer MulticoreFix.");

                try
                {
                    File.Delete("Gameserver.exe");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("server229");

                    Log.Info("Установка Sacred GameServer MulticoreFix прошла успешно.");
                }
                catch (Exception exception)
                {
                    Log.Error("При установке Sacred GameServer MulticoreFix произошла ошибка.");

                    Log.Error(exception.ToString());
                }

                Directory.CreateDirectory(AppDataFolder);

                if (File.Exists(AppDataFolder + "/" + AppInstallInfo))
                {
                    try
                    {
                        Log.Info("Сохраняем данные о статусе установки модификаций.");

                        var fileAllText = File.ReadAllLines(AppDataFolder + "/" + AppInstallInfo);

                        fileAllText[6] = "; Server multicore fix installed = true";

                        File.WriteAllLines(AppDataFolder + "/" + AppInstallInfo, fileAllText);

                        Log.Info("Данные о статусе установки модификаций сохранены без ошибок.");
                    }
                    catch (Exception exception)
                    {
                        Log.Error("При сохранении статуса установки модификации произошла ошибка.");

                        Log.Error(exception.ToString());
                    }

                    ServerMulticoreFixBtn.Content = "УДАЛИТЬ";
                }
            }
            else if (ServerMulticoreFixBtn.Content.ToString() == "УДАЛИТЬ")
            {
                Log.Info("Подготовка к удалению Sacred GameServer MulticoreFix.");

                try
                {
                    File.Delete("Gameserver.exe");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("server228");

                    Log.Info("Удаление Sacred GameServer MulticoreFix прошло успешно.");
                }
                catch (Exception exception)
                {
                    Log.Error("При удалении Sacred GameServer MulticoreFix произошла ошибка.");

                    Log.Error(exception.ToString());
                }

                Directory.CreateDirectory(AppDataFolder);

                if (File.Exists(AppDataFolder + "/" + AppInstallInfo))
                {
                    try
                    {
                        Log.Info("Сохраняем данные о статусе установки модификаций.");

                        var fileAllText = File.ReadAllLines(AppDataFolder + "/" + AppInstallInfo);

                        fileAllText[6] = "; Server multicore fix installed = false";

                        File.WriteAllLines(AppDataFolder + "/" + AppInstallInfo, fileAllText);

                        Log.Info("Данные о статусе установки модификаций сохранены без ошибок.");
                    }
                    catch (Exception exception)
                    {
                        Log.Error("При сохранении статуса установки модификации произошла ошибка.");

                        Log.Error(exception.ToString());
                    }

                    ServerMulticoreFixBtn.Content = "УСТАНОВИТЬ";
                }
            }
        }

        private void CompileGlobalResBtn_Click(object sender, RoutedEventArgs e)
        {
            CompileGlobalResBtn.Content = "В ПРОЦЕССЕ";

            Log.Info("Проверяем наличие файла global.res и global.csv, для его компиляции.");

            if (File.Exists("global.res") && File.Exists("global.csv"))
            {
                Log.Info("Файл global.res и global.csv обнаружен, выполняем действия дальше.");

                Log.Info("Начинаем компилировать global.csv, в файл global.res.");

                try
                {
                    Log.Info("Создаем декомпилятор файла global.res от (автор не указан).");

                    File.WriteAllBytes("Sacredres2Csv.exe", Properties.Resources.SacredRes2Csv);

                    Log.Info("Создание компилятора файла global.res завершено без ошибок.");

                    Log.Info("Запускаем компилятор с параметрами -res -oglobal.res global.csv.");

                    Process.Start("Sacredres2Csv.exe", "-res -oglobal.res global.csv");

                    Log.Info("Процесс компиляции global.csv в global.res завершен без ошибок.");

                    CompileGlobalResBtn.Content = "ЗАВЕРШЕНО";
                }
                catch (Exception exception)
                {
                    Log.Error("Произошла ошибка во время компиляции global.res.");

                    Log.Error(exception.ToString());
                }
            }
            else
            {
                CompileGlobalResBtn.Content = "ОШИБКА";

                Log.Error("Файл Global.res (Русский) или global.csv не найден. Переустановите игру. Операция отменяется.");
            }
        }

        private void DecompileGlobalResBtn_Click(object sender, RoutedEventArgs e)
        {
            DecompileGlobalResBtn.Content = "В ПРОЦЕССЕ";

            Log.Info("Проверяем наличие файла global.res, для его декомпиляции.");

            if (File.Exists("global.res"))
            {
                Log.Info("Файл global.res обнаружен, выполняем действия дальше.");

                Log.Info("Начинаем декомпилировать global.res, в файл global.csv.");

                try
                {
                    Log.Info("Создаем декомпилятор файла global.res от (автор не указан).");

                    File.WriteAllBytes("Sacredres2Csv.exe", Properties.Resources.SacredRes2Csv);

                    Log.Info("Создание декомпилятора файла global.res завершено без ошибок.");

                    Log.Info("Запускаем декомпилятор с параметрами -csv -oglobal.csv global.res.");

                    Process.Start("Sacredres2Csv.exe", "-csv -oglobal.csv global.res");

                    Log.Info("Процесс декомпиляции global.res в global.csv завершен без ошибок.");

                    DecompileGlobalResBtn.Content = "ЗАВЕРШЕНО";
                }
                catch (Exception exception)
                {
                    Log.Error("Произошла ошибка во время декомпиляции global.res.");

                    Log.Error(exception.ToString());
                }
            }
            else
            {
                DecompileGlobalResBtn.Content = "ОШИБКА";

                Log.Error("Файл Global.res (Русский) не найден. Переустановите игру. Операция отменяется.");
            }
        }

        #endregion

        #region SacredUtilsSettingsButtonEventHandlers.

        public void ChangeConfiguration(int index, string text, string func, string state)
        {
            try
            {
                var fileAllText = File.ReadAllLines(AppSettings);
                fileAllText[index] = text;
                File.WriteAllLines(AppSettings, fileAllText);

                Log.Info("Статус функции " + "\"" + func + "\"" + " изменен на " + state + ".");
            }
            catch (Exception exception)
            {
                Log.Error("Не удалось изменить статус функции " + "\"" + func + "\"" + " на " + state + ".");

                Log.Error(exception.ToString());
            }
        }

        private void AutomaticalyInstallUpdates_Click(object sender, RoutedEventArgs e)
        {
            if (AutomaticalyInstallUpdates.IsChecked == true)
            {
                ChangeConfiguration(16,
                    "# - Automatically get and install updates = true                   #",
                    "Automatically get and install updates",
                    "true");
            }
            else if (AutomaticalyInstallUpdates.IsChecked == false)
            {
                ChangeConfiguration(16,
                    "# - Automatically get and install updates = false                  #",
                    "Automatically get and install updates",
                    "false");
            }
        }

        private void AdvancedErrorLogToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AdvancedErrorLogToggleBtn.IsChecked == true)
            {
                ChangeConfiguration(18,
                    "# - Automatically get and install alpha updates = true             #",
                    "Automatically get and install alpha updates",
                    "true");
            }
            else if (AdvancedErrorLogToggleBtn.IsChecked == false)
            {
                ChangeConfiguration(18,
                    "# - Automatically get and install alpha updates = false            #",
                    "Automatically get and install alpha updates",
                    "false");
            }
        }

        private void MinimizeProgramToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MinimizeProgramToggleBtn.IsChecked == true)
            {
                ChangeConfiguration(20,
                    "# - Minimize the program before launching Sacred = true            #",
                    "Minimize the program before launching Sacred",
                    "true");
            }
            else if (MinimizeProgramToggleBtn.IsChecked == false)
            {
                ChangeConfiguration(20,
                    "# - Minimize the program before launching Sacred = false           #",
                    "Minimize the program before launching Sacred",
                    "false");
            }
        }

        private void ChangeImputLangToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ChangeImputLangToggleBtn.IsChecked == true)
            {
                ChangeConfiguration(22,
                    "# - Change the input language before running Sacred = true         #",
                    "Change the input language before running Sacred",
                    "true");
            }
            else if (ChangeImputLangToggleBtn.IsChecked == false)
            {
                ChangeConfiguration(22,
                    "# - Change the input language before running Sacred = false        #",
                    "Change the input language before running Sacred",
                    "false");
            }
        }

        private void CloseProgramToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CloseProgramToggleBtn.IsChecked == true)
            {
                ChangeConfiguration(24,
                    "# - Close the program after launching Sacred = true                #",
                    "Close the program after launching Sacred",
                    "true");
            }
            else if (CloseProgramToggleBtn.IsChecked == false)
            {
                ChangeConfiguration(24,
                    "# - Close the program after launching Sacred = false               #",
                    "Close the program after launching Sacred",
                    "false");
            }
        }

        private void RestoreSettingsToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RestoreSettingsToggleBtn.IsChecked == true)
            {
                ChangeConfiguration(26,
                    "# - Restore Settings.cfg if it is corrupted = true                 #",
                    "Restore Settings.cfg if it is corrupted",
                    "true");
            }
            else if (RestoreSettingsToggleBtn.IsChecked == false)
            {
                ChangeConfiguration(26,
                    "# - Restore Settings.cfg if it is corrupted = false                #",
                    "Restore Settings.cfg if it is corrupted",
                    "false");
            }
        }

        #endregion

        #region SacredUtilsAboutButtonEventHandlers.

        private void FeedBackBtn_Click(object sender, RoutedEventArgs e) => Process.Start("https://vk.cc/85SSFN");

        private void CreatorBtn_Click(object sender, RoutedEventArgs e) => Process.Start("https://vk.cc/85SSXC");

        private void DonateBtn_Click(object sender, RoutedEventArgs e) => Process.Start("https://qiwi.me/mairwunnx");

        private void GitHubBtn_Click(object sender, RoutedEventArgs e) => Process.Start("https://github.com/MairwunNx/SacredUtils/");

        #endregion
    }
}