#region UsingDirectives.

using log4net;
using SacredUtils.Resources.bin;
using SacredUtils.Resources.wnd;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;
using static SacredUtils.Resources.bin.LanguageConstsStrings;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

#endregion

namespace SacredUtils
{
    public partial class MainWindow
    {
        #region NotifyBarControls.

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private async void SilentUpdateLbl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChangeConfiguration(16,
                "# - Automatically get and install updates = true                   #",
                "Automatically get and install updates",
                "true");

            SilentUpdateLbl.Visibility = Visibility.Hidden;

            var checkAppUpdates = new CheckAppUpdates();
            await checkAppUpdates.GetAvailableAppUpdatesAsync("silent");

            ChangeConfiguration(16,
                "# - Automatically get and install updates = false                  #",
                "Automatically get and install updates",
                "false");
        }

        #endregion

        #region ToolBarControls.

        private void ChangeColor_Click(object sender, RoutedEventArgs e)
        {
            var colorPicker = new ColorWindow(); colorPicker.Show();
        }

        private void GitHubBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/MairwunNx/SacredUtils/");
        }

        private void Forum_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://t-do.ru/sacredinternational");
        }

        #endregion

        #region FlexibleSpaceControls.

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
                RandomChangeExampleText();

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
                        if (File.Exists(SacredExeFile))
                        {
                            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));

                            Process.Start(SacredExeFile); Environment.Exit(0);
                        }
                    }
                    else if (ChangeImputLangToggleBtn.IsChecked == false)
                    {
                        if (File.Exists(SacredExeFile)) { Process.Start(SacredExeFile); Environment.Exit(0); }
                    }
                }
                else if (MinimizeProgramToggleBtn.IsChecked == true)
                {
                    if (ChangeImputLangToggleBtn.IsChecked == true)
                    {
                        if (File.Exists(SacredExeFile))
                        {
                            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));

                            Process.Start(SacredExeFile); WindowState = WindowState.Minimized;
                        }
                    }
                    else if (ChangeImputLangToggleBtn.IsChecked == false)
                    {
                        if (File.Exists(SacredExeFile)) { Process.Start(SacredExeFile); WindowState = WindowState.Minimized; }
                    }
                }
                else { if (File.Exists(SacredExeFile)) { Process.Start(SacredExeFile); } }
            }

            if (SettingsListBox.SelectedIndex == 15)
            {
                Process.Start(AppnameFile); Environment.Exit(0);
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) { DragMove(); }
        }

        #endregion

        #region SetValueMethods.

        public void SetSettingsValue(string s, string v)
        {
            if (!File.Exists(SacredSettingsFile))
            {
                try
                {
                    File.WriteAllBytes(SacredSettingsFile, Properties.Resources.GameSettings);
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception.ToString()); Environment.Exit(0);
                }
            }

            var text = File.ReadAllLines(SacredSettingsFile, Encoding.ASCII);

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains($"{s} : "))
                {
                    try
                    {
                        text[i] = $"{s} : {v}"; File.WriteAllLines(SacredSettingsFile, text);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.ToString());
                    }
                }
            }
        }

        public void SetSettingsValueForFont(string s, string v)
        {
            if (!File.Exists(SacredSettingsFile))
            {
                try
                {
                    File.WriteAllBytes(SacredSettingsFile, Properties.Resources.GameSettings);
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception.ToString()); Environment.Exit(0);
                }
            }

            var text = File.ReadAllLines(SacredSettingsFile, Encoding.ASCII);

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains(s))
                {
                    try
                    {
                        text[i] = s + v; File.WriteAllLines(SacredSettingsFile, text);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.ToString());
                    }
                }
            }
        }

        public void SetSettingsValueWithDouble(string s, double v)
        {
            if (!File.Exists(SacredSettingsFile))
            {
                try
                {
                    File.WriteAllBytes(SacredSettingsFile, Properties.Resources.GameSettings);
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception.ToString()); Environment.Exit(0);
                }
            }

            var text = File.ReadAllLines(SacredSettingsFile, Encoding.ASCII);

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains($"{s} : "))
                {
                    try
                    {
                        text[i] = $"{s} : {v}"; File.WriteAllLines(SacredSettingsFile, text);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.ToString());
                    }
                }
            }
        }

        #endregion

        #region TextBoxEventHandlers.

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

        #region ToggleButtonEventHandlers.

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

        #region ComboboxEventHandlers.

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
                if (File.Exists("scripts\\ru\\global.res"))
                {
                    File.Delete("scripts\\ru\\global.res");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("rugui");

                    SetSettingsValue("LANGUAGE", "RU");
                }
                else if (!File.Exists("scripts\\ru\\global.res"))
                {
                    Directory.CreateDirectory("scripts\\ru");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("rugui");

                    SetSettingsValue("LANGUAGE", "RU");
                }
            }

            if (InterfaceLanguageCmbBox.SelectedIndex == 1)
            {
                if (File.Exists("scripts\\us\\global.res"))
                {
                    File.Delete("scripts\\us\\global.res");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("usgui");

                    SetSettingsValue("LANGUAGE", "US");
                }
                else if (!File.Exists("scripts\\us\\global.res"))
                {
                    Directory.CreateDirectory("scripts\\us");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("usgui");

                    SetSettingsValue("LANGUAGE", "US");
                }
            }

            if (InterfaceLanguageCmbBox.SelectedIndex == 2)
            {
                if (File.Exists("scripts\\de\\global.res"))
                {
                    File.Delete("scripts\\de\\global.res");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("degui");

                    SetSettingsValue("LANGUAGE", "DE");
                }
                else if (!File.Exists("scripts\\de\\global.res"))
                {
                    Directory.CreateDirectory("scripts\\de");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("degui");

                    SetSettingsValue("LANGUAGE", "DE");
                }
            }

            if (InterfaceLanguageCmbBox.SelectedIndex == 3)
            {
                if (File.Exists("scripts\\sp\\global.res"))
                {
                    File.Delete("scripts\\sp\\global.res");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("spgui");

                    SetSettingsValue("LANGUAGE", "SP");
                }
                else if (!File.Exists("scripts\\sp\\global.res"))
                {
                    Directory.CreateDirectory("scripts\\sp");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("spgui");

                    SetSettingsValue("LANGUAGE", "SP");
                }
            }

            if (InterfaceLanguageCmbBox.SelectedIndex == 4)
            {
                if (File.Exists("scripts\\fr\\global.res"))
                {
                    File.Delete("scripts\\fr\\global.res");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("frgui");

                    SetSettingsValue("LANGUAGE", "FR");
                }
                else if (!File.Exists("scripts\\fr\\global.res"))
                {
                    Directory.CreateDirectory("scripts\\fr");

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

        public void SaveVoiceoverData(string lang)
        {
            if (File.Exists(AppVoiceoverFile))
            {
                var text = File.ReadAllLines(AppVoiceoverFile, Encoding.ASCII);

                text[3] = $"; Installed voiceover = {lang}"; File.WriteAllLines(AppVoiceoverFile, text);
            }
            else
            {
                File.WriteAllBytes(AppVoiceoverFile, Properties.Resources.voiceoverinfo);

                var text = File.ReadAllLines(AppVoiceoverFile, Encoding.ASCII);

                text[3] = $"; Installed voiceover = {lang}"; File.WriteAllLines(AppVoiceoverFile, text);
            }
        }

        private async void SoundLanguageCmbBox_DropDownClosed(object sender, EventArgs e)
        {
            if (SoundLanguageCmbBox.SelectedIndex == 0)
            {
                var soundWindow = new ComponentsWindow(); soundWindow.Show();

                var downloadComponents = new DownloadComponents();
                await downloadComponents.GetSoundComponent("ru");

                SaveVoiceoverData("ru");
            }

            if (SoundLanguageCmbBox.SelectedIndex == 1)
            {
                var soundWindow = new ComponentsWindow(); soundWindow.Show();

                var downloadComponents = new DownloadComponents();
                await downloadComponents.GetSoundComponent("us");

                SaveVoiceoverData("us");
            }

            if (SoundLanguageCmbBox.SelectedIndex == 2)
            {
                var soundWindow = new ComponentsWindow(); soundWindow.Show();

                var downloadComponents = new DownloadComponents();
                await downloadComponents.GetSoundComponent("de");

                SaveVoiceoverData("de");
            }

            if (SoundLanguageCmbBox.SelectedIndex == 3)
            {
                var soundWindow = new ComponentsWindow(); soundWindow.Show();

                var downloadComponents = new DownloadComponents();
                await downloadComponents.GetSoundComponent("sp");

                SaveVoiceoverData("sp");
            }
        }

        #endregion

        #region SliderEventHandlers.

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

        #region WindowMethodsAndHandlers.

        public MainWindow()
        {
            InitializeComponent(); DataContext = new BindingLanguageStrings();

            var checkAppUpdates = new CheckAppUpdates();

            #pragma warning disable 4014
            checkAppUpdates.GetAvailableAppUpdatesAsync("none");
            #pragma warning restore 4014

            var getAppSettings = new GetAppSettings();
            getAppSettings.LoadAppSettings();

            var getGameSettings = new GetGameSettings();
            getGameSettings.LoadGameSettings();

            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            foreach (Window w in System.Windows.Application.Current.Windows)
            {
                if (w.GetType().Assembly == currentAssembly && w is LoadingWindow)
                {
                    w.Close(); break;
                }
            }

            if (LogSacredUtilsToggleBtn.IsChecked == false)
            {
                try
                {
                    File.WriteAllText("SacredUtils-errlog.log", @"Log disabled by user (◍ • ﹏ •)");
                    LogManager.Shutdown();
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception.ToString());
                }
            }

            if (File.Exists(AppInstallInfo))
            {
                var text = File.ReadAllText(AppInstallInfo, Encoding.ASCII);

                CompileGlobalResBtn.Content = String0137;
                DecompileGlobalResBtn.Content = String0137;

                if (text.Contains("Veteranmod by ufo installed = true"))
                {
                    VeteranModUfoBtn.Content = String0007;
                }
                else if (text.Contains("Veteranmod by ufo installed = false"))
                {
                    VeteranModUfoBtn.Content = String0008;
                }

                if (text.Contains("Veteranmod dragonfix installed = true"))
                {
                    VeteranModDragonFixBtn.Content = String0007;
                }
                else if (text.Contains("Veteranmod dragonfix installed = false"))
                {
                    VeteranModDragonFixBtn.Content = String0008;
                }

                if (text.Contains("Sacred 2.29.14 patch installed = true"))
                {
                    SacredNewUpdateBtn.Content = String0007;
                }
                else if (text.Contains("Sacred 2.29.14 patch installed = false"))
                {
                    SacredNewUpdateBtn.Content = String0008;
                }

                if (text.Contains("Server multicore fix installed = true"))
                {
                    ServerMulticoreFixBtn.Content = String0007;
                }
                else if (text.Contains("Server multicore fix installed = false"))
                {
                    ServerMulticoreFixBtn.Content = String0008;
                }
            }
            else if (!File.Exists(AppInstallInfo))
            {
                Directory.CreateDirectory(AppDataFolder);

                try
                {
                    File.WriteAllBytes(AppInstallInfo, Properties.Resources.installinfo);
                }
                catch (Exception exception)
                {
                     Log.Error(exception.ToString());
                }

                VeteranModUfoBtn.Content = String0008; VeteranModDragonFixBtn.Content = String0008;
                SacredNewUpdateBtn.Content = String0008; ServerMulticoreFixBtn.Content = String0008;
            }

            if (File.Exists(AppStatisticFile))
            {
                try
                {
                    var text = File.ReadAllText(AppStatisticFile);

                    var numberOfStartups = Regex.Match(text, @"\d+").Value;

                    var newNumberOfStartups = Convert.ToInt32(numberOfStartups) + 1;

                    var fileAllText = File.ReadAllLines(AppStatisticFile);
                    fileAllText[3] = "; The program is launched " + newNumberOfStartups + " time(s)";
                    File.WriteAllLines(AppStatisticFile, fileAllText);
                }
                catch (Exception exception)
                {
                     Log.Error(exception.ToString());
                }

            }
            else if (!File.Exists(AppStatisticFile))
            {
                Directory.CreateDirectory(AppDataFolder);

                File.WriteAllBytes(AppStatisticFile, Properties.Resources.launchstat);
            }

            RandomChangeExampleText();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                InstalledFontCollection installedFonts = new InstalledFontCollection();
                List<string> fonts = installedFonts.Families.Select(font => font.Name).ToList();

                FontLibraryCmbBox.ItemsSource = fonts;
                fonts.Remove("");
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }

            var text = File.ReadAllLines(SacredSettingsFile, Encoding.ASCII);

            for (var i = 0; i < text.Length; i++)
            {
                if (text[i].Contains("FONT : 1, "))
                {
                    var tempdata0 = text[i].Substring(text[i].IndexOf("\"", StringComparison.Ordinal) + 1);

                    if (tempdata0 == text[i].Substring(text[i].IndexOf("\"", StringComparison.Ordinal) + 1))
                    {
                        var tempdata1 = tempdata0.Remove(tempdata0.LastIndexOf("\"", StringComparison.Ordinal));

                        FontLibraryCmbBox.SelectedItem = tempdata1;
                    }
                }
            }

            var text1 = File.ReadAllLines(AppSettingsFile, Encoding.ASCII);

            for (var i = 0; i < text1.Length; i++)
            {
                try
                {
                    if (text1[i].Contains(AppColorValue + " = default") ||
                        text1[i].Contains("User interface color SacredUtils = indigo"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#7986cb", "#303f9f", "#3f51b5", "#c5cae9", "Indigo", "#FFFFFFFF");
                    }

                    if (text1[i].Contains(AppColorValue + " = red"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#e57373", "#d32f2f", "#f44336", "#ffcdd2", "Red", "#FFFFFFFF");
                    }

                    if (text1[i].Contains(AppColorValue + " = pink"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#f06292", "#c2185b", "#e91e63", "#f8bbd0", "Pink", "#FFFFFFFF");
                    }

                    if (text1[i].Contains(AppColorValue + " = purple"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#ba68c8", "#7b1fa2", "#9c27b0", "#e1bee7", "Purple", "#FFFFFFFF");
                    }

                    if (text1[i].Contains(AppColorValue + " = deeppurple"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#9575cd", "#512da8", "#673ab7", "#d1c4e9", "DeepPurple", "#FFFFFFFF");
                    }

                    if (text1[i].Contains(AppColorValue + " = blue"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#64b5f6", "#1976d2", "#2196f3", "#bbdefb", "Blue", "#FFFFFFFF");
                    }

                    if (text1[i].Contains(AppColorValue + " = lightblue"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#4fc3f7", "#0288d1", "#03a9f4", "#b3e5fc", "LightBlue", "#000000");
                    }

                    if (text1[i].Contains(AppColorValue + " = cyan"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#4dd0e1", "#0097a7", "#00bcd4", "#b2ebf2", "Cyan", "#000000");
                    }

                    if (text1[i].Contains(AppColorValue + " = teal"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#4db6ac", "#00796b", "#009688", "#b2dfdb", "Teal", "#ffffff");
                    }

                    if (text1[i].Contains(AppColorValue + " = green"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#81c784", "#388e3c", "#4caf50", "#c8e6c9", "Green", "#ffffff");
                    }

                    if (text1[i].Contains(AppColorValue + " = lightgreen"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#aed581", "#689f38", "#8bc34a", "#dcedc8", "LightGreen", "#000000");
                    }

                    if (text1[i].Contains(AppColorValue + " = lime"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#dce775", "#afb42b", "#cddc39", "#f0f4c3", "Lime", "#000000");
                    }

                    if (text1[i].Contains(AppColorValue + " = yellow"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#fff176", "#fbc02d", "#ffeb3b", "#fff9c4", "Yellow", "#000000");
                    }

                    if (text1[i].Contains(AppColorValue + " = amber"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#ffd54f", "#ffa000", "#ffc107", "#ffecb3", "Amber", "#000000");
                    }

                    if (text1[i].Contains(AppColorValue + " = orange"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#ffb74d", "#f57c00", "#ff9800", "#ffe0b2", "Orange", "#000000");
                    }

                    if (text1[i].Contains(AppColorValue + " = deeporange"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#ff8a65", "#e64a19", "#ff5722", "#ffccbc", "DeepOrange", "#000000");
                    }

                    if (text1[i].Contains(AppColorValue + " = brown"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#a1887f", "#5d4037", "#795548", "#d7ccc8", "Brown", "#ffffff");
                    }

                    if (text1[i].Contains(AppColorValue + " = grey"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#e0e0e0", "#616161", "#9e9e9e", "#f5f5f5", "Grey", "#000000");
                    }

                    if (text1[i].Contains(AppColorValue + " = bluegrey"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#90a4ae", "#455a64", "#607d8b", "#cfd8dc", "BlueGrey", "#ffffff");
                    }

                    if (text1[i].Contains(AppColorValue + " = black"))
                    {
                        var colorWindow = new ColorWindow();
                        colorWindow.Close();

                        colorWindow.ChangeColor("#484848", "#000000", "#212121", "#484848", "DeepOrange", "#ffffff");

                        BrushConverter bc = new BrushConverter();

                        CardBackgroundColor.Background = (Brush) bc.ConvertFrom("#2c2c2c");

                        NotSelectedLbl.Foreground = (Brush) bc.ConvertFrom("#DDCBCBCB");

                        SettingsNameColor.Foreground = (Brush) bc.ConvertFrom("#eeeeee");

                        CardCaptionsColor.Foreground = (Brush) bc.ConvertFrom("#e0e0e0");

                        ColorCombobox.Foreground = (Brush) bc.ConvertFrom("#eeeeee");
                        ColorCombobox.Background = (Brush) bc.ConvertFrom("#2c2c2c");

                        ColorTxBox.Foreground = (Brush) bc.ConvertFrom("#eeeeee");
                    }
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }

            if (AutomaticalyInstallUpdates.IsChecked == false)
            {
                SilentUpdateLbl.Visibility = Visibility.Visible;

                var silentGetAvailableUpdate = new SilentGetAvailableUpdate();
                await Task.Run(() => silentGetAvailableUpdate.GetAvailableUpdate());

                if (SilentAvailableUpdate)
                {
                    SilentUpdateLbl.Content = $"{String0134} {SilentUpdateNewVer}.";
                }
                else if (!SilentAvailableUpdate)
                {
                    SilentUpdateLbl.Visibility = Visibility.Hidden;
                }
            }

            var changeLogShow = new ChangeLogShow();
            await Task.Run(() => changeLogShow.CheckLaunchedVersion());

            if (Changes)
            {
                FlexibleMessageBox.Show(System.Windows.Application.Current.MainWindow, Msg, Caption);
            }

            if (NotSelectedLbl.Content.ToString() == "< Select what you would like to configure. />" ||
                NotSelectedLbl.Content.ToString() == "< Wahlen Sie, was Sie konfigurieren mochten. />")
            {
                WarnLbl.Visibility = Visibility.Visible;
            }


            try
            {
                var text2 = File.ReadAllLines(AppLngErrorFile);

                if (text2[0] != "Update")
                {
                    FlexibleMessageBox.Show(this, $"{String0139}\n\n{String0140} {text2[0]}\n\n{String0141}\n\n{String0142} {text2[1]}\n\n{String0143}", $"{String0138}");
                }
                else if (text2[0] == "Update")
                {
                    FlexibleMessageBox.Show(this, $"{String0144}\n\n{String0145} {text2[1]}\n\n{String0146}\n\n{String0147} {text2[2]}\n\n{String0148}", $"{String0138}");

                    File.WriteAllBytes(".SacredUtilsData\\langversion.dat", Properties.Resources.LangVersion);
                }

                File.Delete(AppLngErrorFile);
            }
            catch
            {
                // Ignore.
            }

            if (File.Exists(AppVoiceoverFile))
            {
                var text3 = File.ReadAllLines(AppVoiceoverFile, Encoding.ASCII);

                if (text3[3] == "; Installed voiceover = ru")
                {
                    SoundLanguageCmbBox.SelectedIndex = 0;
                }

                if (text3[3] == "; Installed voiceover = us")
                {
                    SoundLanguageCmbBox.SelectedIndex = 1;
                }

                if (text3[3] == "; Installed voiceover = de")
                {
                    SoundLanguageCmbBox.SelectedIndex = 2;
                }

                if (text3[3] == "; Installed voiceover = sp")
                {
                    SoundLanguageCmbBox.SelectedIndex = 3;
                }
            }
        }

        public void RandomChangeExampleText()
        {
            var rnd = new System.Random();

            string[] randomStrings =
            {
                "It seems ... We did not find recognition in Ancaria.",
                "Lily...after all this time? - Always.",
                "Take a horse? A Wood Elf steal a horse? You fool!",
                "Famous last words: \"C++ Runtime Error\"",
                "Format C: should not be taken literally",
                "No one is missing me… *cry*",
                "I will return these 500 rubles soon.",
                "Sample Text",
                "Size matters!",
                "ScaredTits",
                "Rule #1: it's never my fault",
                "In honor of Annika, mistress of the birds.",
                "Random splash!",
                "Get it!",
                "Please, turn on the track nin10doh.",
                "Saints Flow's good, but Saints Flow with vodka, better.",
                "SAAAAAIIIINTS FLOOOOOOOW!",
                "12345 is a bad password!",
                "Thanks for using SacredUTits!",
                "'Deeper, Wider, Stiffer' Funeral Parlor",
                "X never, ever, marks the spot.",
                "Your name could be here! (Advertising Agency \"SacredUtils\")",
                "Gloomoor... One of the darker corners of Ancaria.",
                "He bought a WinRar license ...",
                "string[] randomStrings = { \"Random text.\" }",
                "Delphic - Clarion Call.",
                "Have you found my father yet?",
                "Isabella Stolyarenko. Everything.",
                "www.brazzer.com, with fun.",
                "*** STOP : 0x000001E (0x80102035, 0x8025ea21, 0xfd682e9)",
                "Unhandled Kernel exception c000047 from fa8418b4 (8025ea21)",
                "Null. System. Ctrl. Encrypted. How. Could. You. Let. Johnny. Die?",
                "Now The Real Game Begins >:) _",
                "Press Any Key to Continue ...",
                "Debug my errors please.",
                "kill-deckers.exe",
                "01100010011011110110111101100010",
                "http://deckers.die",
                "If there were no mosquito net, most likely SacredUtils you would not have seen.",
                "Sometimes the majority is just a bunch of idiots.",
                "Thank you Mario! But our Princess is in another castle!",
                "РРґРё СЃРІРѕРµР№ РґРѕСЂРѕРіРѕР№, РЎС‚Р°Р»РєРµСЂ.",
                "Urkenburgh. This is not my usual haunt.",
                "+++EMPTY+++",
                "Prince... King Valor is dead?! We are lost!",
                "I can sense that I am near my goal. It can't be much further...",
                "Ancaria is a very cozy home for goblins.",
                "<Death cry>",
                "What are you waiting for? Christmas?",
                "These are all your AVX instructions...",
                "Your best bet is to talk to Shareefa the sorceress!",
                "Sexyyyyy!",
                "Wow!",
                "85% bug free!",
                "Legal in England!",
                "Yes, sir!",
                "Call your mother!",
                "Monster infighting!",
                "Ultimate edition!",
                "Loved by millions!",
                "4% sugar!",
                "11% coffee!",
                "Kiss the sky!",
                "DRR! DRR! DRR!",
                "Google analytics!",
                "Very fun!",
                "270417!",
                "190417!",
                "260517!",
                "270202",
                "Now C# 8.0!",
                "Now VisualStudio 2019!",
                "What's up, Doc?",
                "Realy big boobs!",
                "Wow! Nice arena!",
                "Uuuuhuuaahh!!!",
                "Never go to a doctor whose office plants have died!",
                "I'm not afraid to die. I just don't want to be there when it happens.",
                "The person you have called is temporarily unavailable...",
                "Hello World!",
                "Console.WriteLine(\"Hello World!\");",
                "Who? Lost... Mother, no! Blood... Yes... I... I follow... you... home...",
                "I am to take this person safely to Wolfdale.",
                "Face the bards, who are following the Daughter of the Noble.",
                "The desert region has been successfully cleared.",
                "Your blood for the life, my friend...",
                "Water... The blood of life...",
                "That was all over much too quickly!",
                "Fine, come here, you worm - my blade is waiting for you!",
                "A strange element of flowing energy, like water!",
                "Kahari ... only Elves and fools come here by choice.",
                "UHVzc3ku",
                "Only orcs are stupid enough to cross my path!",
                "Aahhrrg... By Anducar!",
                "Brainssssss!",
                "172.0.0.1",
                "A village full of mindless farmers. Should I show them what I am?",
                "QXJvdW5kIHRoZSB3aG9yZS4gV2h5Pw==",
                "Timberton, the heart of the DeMordrey timber industry...",
                "To assassinate for humans? That was a great idea...",
                "The floor is lava!",
                "The quick brown fox jumps over the lazy dog",
                "Шустрая бурая лиса прыгает через ленивую собаку",
                "Duck, duck, goose!",
                "Mother May I?",
                "Catch!",
                "Steal the Bacon",
                "Lucky -100%! :)",
                "Set Me On Fire",
                "Send nudes",
                "Not u!",
                "skibidi papa",
                "Thanks or Have a nice day?",
                "if 11 = 20, 21 = 31, 31 = 42, Then 51 = ??",
                "6 : 2(1 + 2) = ???",
                "64 :|, 65 :|, 66 :|, 67 :|, 68 :|, 69 :), 70 :|, 71 :|, 72 :|.",
                "Press F to Pay Respects",
                "With love!",
                "Insufficient Fare",
                "More & More!",
                "And your neighbors hear ohhh & ahhh?",
                "Тяжело вставать по утрам?",
                "Is it hard to get up in the morning?",

                // Thanks shalinorus for next splashes :

                "Чего копаешься в шрифтах?",
                "What are you doing with the typefaces?",
                "Пора Анкарию спасать!",
                "It's time to save Ancaria!",
                "Могилы вскрыты, ожил прах!",
                "The graves are open, the ashes come to life!",
                "Кромсай вражин, иль ты-слабак?!",
                "Kill your enemies, or you're a wimp?!",
                "^_^ Не задерживайся,тебя уже ждут!",
                "^_^ Don't stay long! You're expected!",
                "Впиши свое имя на могилке!",
                "Write your name on the grave!",
                "Развалины Стоунхеджа ждут тебя, герой! Кроликофилам не беспокоиться!",
                "Бегом на корриду, Амон-ши, крестьяне подождут!",
                "Одинокий лич желает познакомиться:-)!",
                "Lonely lich wants to get acquainted :-)!",
                "Тут одни крестьяне да коровы — о Боги, что за скучное место!",
                "Рай для ботаников, герям—прямо!",
                "Незабываемый аттракцион «Попробуй, догони!» /от разрабов/",
                "Unforgettable attraction «Try, catch up!« /from devs/",
                "А нет здесь драконов, часть отошла в иной мир. :-)",
                "Побалуй себя пикником у водопада,такая мелочь,как дракон тебе ведь не помешает,верно?:-)",
                "Виселицы не пустуют, крестьяне голодают — образцовый тоталитарный порядок!",
                "Не проходите мимо: освободите несчастного волка, злой маг заколдовал клетку, киньте ему парочку свиных окороков!",
                "Не трудитесь искать шахты, хитрый Де-Мордри сделал их невидимыми :-)",
                "Где обещанные пирамиды и сфинкс?—дык у вас под ногами,лопатка,ну или экскаватор вам в помощь!",
                "Поговаривают, что где-то здесь есть портал в пресподнюю, но может, это всего лишь слухи..",
                "Дриады vs лесорубов, а на чьей стороне ты, если деревья поражены короедом?"
            };

            string[] shuffled = randomStrings.OrderBy(n => Guid.NewGuid()).ToArray();

            FontChangeTextInTemplate.Text = shuffled[rnd.Next(shuffled.Length)];
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

        #endregion

        #region ModdingButtonEventHandlers.

        private void VeteranModUfoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (VeteranModUfoBtn.Content.ToString() == String0008)
            {
                Directory.CreateDirectory("bin"); Directory.CreateDirectory("PAK");

                try
                {
                    File.WriteAllBytes("bin\\balance.bin", Properties.Resources.SacredBalanceVeteran);
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }

                try
                {
                    File.WriteAllBytes("PAK\\creature.pak", Properties.Resources.SacredCreatureVeteran);
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }

                Directory.CreateDirectory(AppDataFolder);

                if (File.Exists(AppInstallInfo))
                {
                    try
                    {
                        var fileAllText = File.ReadAllLines(AppInstallInfo);

                        fileAllText[3] = "; Veteranmod by ufo installed = true";
                        fileAllText[4] = "; Veteranmod dragonfix installed = false";

                        File.WriteAllLines(AppInstallInfo, fileAllText);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.ToString());
                    }

                    VeteranModUfoBtn.Content = String0007; VeteranModDragonFixBtn.Content = String0008;
                }
            }
            else if (VeteranModUfoBtn.Content.ToString() == String0007)
            {
                Directory.CreateDirectory("bin"); Directory.CreateDirectory("PAK");

                try
                {
                    File.WriteAllBytes("bin\\balance.bin", Properties.Resources.SacredBalanceVanilla);
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }

                try
                {
                    File.WriteAllBytes("PAK\\creature.pak", Properties.Resources.SacredCreatureVanilla);
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }

                Directory.CreateDirectory(AppDataFolder);

                if (File.Exists(AppInstallInfo))
                {
                    try
                    {
                        var fileAllText = File.ReadAllLines(AppInstallInfo);

                        fileAllText[3] = "; Veteranmod by ufo installed = false";
                        fileAllText[4] = "; Veteranmod dragonfix installed = false";

                        File.WriteAllLines(AppInstallInfo, fileAllText);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.ToString());
                    }

                    VeteranModUfoBtn.Content = String0008; VeteranModDragonFixBtn.Content = String0008;
                }
            }
        }
        
        private void VeteranModDragonFixBtn_Click(object sender, RoutedEventArgs e)
        {
            if (VeteranModDragonFixBtn.Content.ToString() == String0008)
            {
                Directory.CreateDirectory("bin"); Directory.CreateDirectory("PAK");

                try
                {
                    File.WriteAllBytes("bin\\balance.bin", Properties.Resources.SacredBalanceDragonFix);
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }

                try
                {
                    File.WriteAllBytes("PAK\\creature.pak", Properties.Resources.SacredCreatureDragonFix);
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }

                Directory.CreateDirectory(AppDataFolder);

                if (File.Exists(AppInstallInfo))
                {
                    try
                    {
                        var fileAllText = File.ReadAllLines(AppInstallInfo);

                        fileAllText[3] = "; Veteranmod by ufo installed = false";
                        fileAllText[4] = "; Veteranmod dragonfix installed = true";

                        File.WriteAllLines(AppInstallInfo, fileAllText);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.ToString());
                    }

                    VeteranModUfoBtn.Content = String0008; VeteranModDragonFixBtn.Content = String0007;
                }
            }
            else if (VeteranModDragonFixBtn.Content.ToString() == String0007)
            {
                Directory.CreateDirectory("bin"); Directory.CreateDirectory("PAK");

                try
                {
                    File.WriteAllBytes("bin\\balance.bin", Properties.Resources.SacredBalanceVanilla);
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }

                try
                {
                    File.WriteAllBytes("PAK\\creature.pak", Properties.Resources.SacredCreatureVanilla);
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }

                Directory.CreateDirectory(AppDataFolder);

                if (File.Exists(AppInstallInfo))
                {
                    try
                    {
                        var fileAllText = File.ReadAllLines(AppInstallInfo);

                        fileAllText[3] = "; Veteranmod by ufo installed = false";
                        fileAllText[4] = "; Veteranmod dragonfix installed = false";

                        File.WriteAllLines(AppInstallInfo, fileAllText);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.ToString());
                    }

                    VeteranModUfoBtn.Content = String0008; VeteranModDragonFixBtn.Content = String0008;
                }
            }
        }

        private async void SacredNewUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SacredNewUpdateBtn.Content.ToString() == String0008)
            {
                try
                {
                    File.Delete("Sacred.exe");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("sacred229");
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }

                Directory.CreateDirectory(AppDataFolder);

                if (File.Exists(AppInstallInfo))
                {
                    try
                    {
                        var fileAllText = File.ReadAllLines(AppInstallInfo);

                        fileAllText[5] = "; Sacred 2.29.14 patch installed = true";

                        File.WriteAllLines(AppInstallInfo, fileAllText);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.ToString());
                    }

                    SacredNewUpdateBtn.Content = String0007;
                }
            }
            else if (SacredNewUpdateBtn.Content.ToString() == String0007)
            {
                try
                {
                    File.Delete("Sacred.exe");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("sacred228");
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }

                Directory.CreateDirectory(AppDataFolder);

                if (File.Exists(AppInstallInfo))
                {
                    try
                    {
                        var fileAllText = File.ReadAllLines(AppInstallInfo);

                        fileAllText[5] = "; Sacred 2.29.14 patch installed = false";

                        File.WriteAllLines(AppInstallInfo, fileAllText);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.ToString());
                    }

                    SacredNewUpdateBtn.Content = String0008;
                }
            }
        }

        private async void ServerMulticoreFixBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ServerMulticoreFixBtn.Content.ToString() == String0008)
            {
                try
                {
                    File.Delete("Gameserver.exe");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("server229");
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }

                Directory.CreateDirectory(AppDataFolder);

                if (File.Exists(AppInstallInfo))
                {
                    try
                    {
                        var fileAllText = File.ReadAllLines(AppInstallInfo);

                        fileAllText[6] = "; Server multicore fix installed = true";

                        File.WriteAllLines(AppInstallInfo, fileAllText);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.ToString());
                    }

                    ServerMulticoreFixBtn.Content = String0007;
                }
            }
            else if (ServerMulticoreFixBtn.Content.ToString() == String0007)
            {
                try
                {
                    File.Delete("Gameserver.exe");

                    var soundWindow = new ComponentsWindow(); soundWindow.Show();

                    var downloadComponents = new DownloadComponents();
                    await downloadComponents.GetSoundComponent("server228");
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }

                Directory.CreateDirectory(AppDataFolder);

                if (File.Exists(AppInstallInfo))
                {
                    try
                    {
                        var fileAllText = File.ReadAllLines(AppInstallInfo);

                        fileAllText[6] = "; Server multicore fix installed = false";

                        File.WriteAllLines(AppInstallInfo, fileAllText);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.ToString());
                    }

                    ServerMulticoreFixBtn.Content = String0008;
                }
            }
        }

        private void CompileGlobalResBtn_Click(object sender, RoutedEventArgs e)
        {
            CompileGlobalResBtn.Content = String0009;

            if (File.Exists("global.res") && File.Exists("global.csv"))
            {
                try
                {
                    File.WriteAllBytes("Sacredres2Csv.exe", Properties.Resources.SacredRes2Csv);

                    Process.Start("Sacredres2Csv.exe", "-res -oglobal.res global.csv");

                    CompileGlobalResBtn.Content = String0010;
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
            else
            {
                CompileGlobalResBtn.Content = String0011;
            }
        }

        private void DecompileGlobalResBtn_Click(object sender, RoutedEventArgs e)
        {
            DecompileGlobalResBtn.Content = String0009;

            if (File.Exists("global.res"))
            {
                try
                {
                    File.WriteAllBytes("Sacredres2Csv.exe", Properties.Resources.SacredRes2Csv);

                    Process.Start("Sacredres2Csv.exe", "-csv -oglobal.csv global.res");

                    DecompileGlobalResBtn.Content = String0010;
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
            else
            {
                DecompileGlobalResBtn.Content = String0011;
            }
        }

        #endregion

        #region SettingsButtonEventHandlers.

        public void ChangeConfiguration(int index, string text, string func, string state)
        {
            try
            {
                var fileAllText = File.ReadAllLines(AppSettingsFile);
                fileAllText[index] = text;
                File.WriteAllLines(AppSettingsFile, fileAllText);
            }
            catch (Exception exception)
            {
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

        private void LogSacredUtilsToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LogSacredUtilsToggleBtn.IsChecked == true)
            {
                ChangeConfiguration(30,
                    "# - Enable logging of all actions of the program = true            #",
                    "Enable logging of all actions of the program",
                    "true");
            }
            else if (LogSacredUtilsToggleBtn.IsChecked == false)
            {
                ChangeConfiguration(30,
                    "# - Enable logging of all actions of the program = false           #",
                    "Enable logging of all actions of the program",
                    "false");
            }
        }

        #endregion

        #region AboutButtonEventHandlers.

        private void FeedBackBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://vk.cc/85SSFN");
        }

        private void CreatorBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://vk.cc/85SSXC");
        }

        private void DonateBtn_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://qiwi.me/mairwunnx");
        }

        #endregion

        #region LanguageButtonEventHandlers.

        private void RussiaLang_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllBytes(AppLngDataFile, Properties.Resources.languageru);

            SettingsListBox.SelectedIndex = 15;
        }

        private void EnglishLang_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllBytes(AppLngDataFile, Properties.Resources.languageen);

            SettingsListBox.SelectedIndex = 15;
        }

        private void DeutschLang_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllBytes(AppLngDataFile, Properties.Resources.languagede);

            SettingsListBox.SelectedIndex = 15;
        }

        #endregion
    }
}