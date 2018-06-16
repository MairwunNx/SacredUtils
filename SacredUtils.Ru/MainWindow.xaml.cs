#region UsingDirectives.

using System;
using log4net;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Reflection;
using System.Diagnostics;
using System.Drawing.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Threading.Tasks;
using System.Windows.Controls;
using SacredUtils.Resources.bin;
using System.Collections.Generic;
using SacredUtils.Resources.wnd;
using System.Text.RegularExpressions;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using static SacredUtils.Resources.bin.LanguageConstsStrings;

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
                            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));

                            Process.Start(SacredExe); Environment.Exit(0);
                        }
                    }
                    else if (ChangeImputLangToggleBtn.IsChecked == false)
                    {
                        if (File.Exists(SacredExe)) { Process.Start(SacredExe); Environment.Exit(0); }
                    }
                }
                else if (MinimizeProgramToggleBtn.IsChecked == true)
                {
                    if (ChangeImputLangToggleBtn.IsChecked == true)
                    {
                        if (File.Exists(SacredExe))
                        {
                            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));

                            Process.Start(SacredExe); WindowState = WindowState.Minimized;
                        }
                    }
                    else if (ChangeImputLangToggleBtn.IsChecked == false)
                    {
                        if (File.Exists(SacredExe)) { Process.Start(SacredExe); WindowState = WindowState.Minimized; }
                    }
                }
                else { if (File.Exists(SacredExe)) { Process.Start(SacredExe); } }
            }

            if (SettingsListBox.SelectedIndex == 15)
            {
                Process.Start(Appname); Environment.Exit(0);
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
            if (!File.Exists(SacredSettings))
            {
                try
                {
                    File.WriteAllBytes(SacredSettings, Properties.Resources.GameSettings);
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception.ToString()); Environment.Exit(0);
                }
            }

            var text = File.ReadAllLines(SacredSettings, Encoding.ASCII);

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains($"{s} : "))
                {
                    try
                    {
                        text[i] = $"{s} : {v}"; File.WriteAllLines(SacredSettings, text);
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
            if (!File.Exists(SacredSettings))
            {
                try
                {
                    File.WriteAllBytes(SacredSettings, Properties.Resources.GameSettings);
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception.ToString()); Environment.Exit(0);
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
                        Log.Error(exception.ToString());
                    }
                }
            }
        }

        public void SetSettingsValueWithDouble(string s, double v)
        {
            if (!File.Exists(SacredSettings))
            {
                try
                {
                    File.WriteAllBytes(SacredSettings, Properties.Resources.GameSettings);
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception.ToString()); Environment.Exit(0);
                }
            }

            var text = File.ReadAllLines(SacredSettings, Encoding.ASCII);

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains($"{s} : "))
                {
                    try
                    {
                        text[i] = $"{s} : {v}"; File.WriteAllLines(SacredSettings, text);
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
                File.WriteAllText("SacredUtils-errlog.log", "Log disabled by user (◍ • ﹏ •)");

                LogManager.Shutdown();
            }

            if (File.Exists(AppDataFolder + "/" + AppInstallInfo))
            {
                var text = File.ReadAllText(AppDataFolder + "/" + AppInstallInfo, Encoding.ASCII);

                if (text.Contains("Veteranmod by ufo installed = true"))
                {
                    VeteranModUfoBtn.Content = $"{String0007}";
                }
                else if (text.Contains("Veteranmod by ufo installed = false"))
                {
                    VeteranModUfoBtn.Content = $"{String0008}";
                }

                if (text.Contains("Veteranmod dragonfix installed = true"))
                {
                    VeteranModDragonFixBtn.Content = $"{String0007}";
                }
                else if (text.Contains("Veteranmod dragonfix installed = false"))
                {
                    VeteranModDragonFixBtn.Content = $"{String0008}";
                }

                if (text.Contains("Sacred 2.29.14 patch installed = true"))
                {
                    SacredNewUpdateBtn.Content = $"{String0007}";
                }
                else if (text.Contains("Sacred 2.29.14 patch installed = false"))
                {
                    SacredNewUpdateBtn.Content = $"{String0008}";
                }

                if (text.Contains("Server multicore fix installed = true"))
                {
                    ServerMulticoreFixBtn.Content = $"{String0007}";
                }
                else if (text.Contains("Server multicore fix installed = false"))
                {
                    ServerMulticoreFixBtn.Content = $"{String0008}";
                }
            }
            else if (!File.Exists(AppDataFolder + "/" + AppInstallInfo))
            {
                Directory.CreateDirectory(AppDataFolder);

                try
                {
                    File.WriteAllBytes(AppDataFolder + "/" + AppInstallInfo, Properties.Resources.installinfo);
                }
                catch (Exception exception)
                {
                     Log.Error(exception.ToString());
                }

                VeteranModUfoBtn.Content = $"{String0008}"; VeteranModDragonFixBtn.Content = $"{String0008}";
                SacredNewUpdateBtn.Content = $"{String0008}"; ServerMulticoreFixBtn.Content = $"{String0008}";
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
                }
                catch (Exception exception)
                {
                     Log.Error(exception.ToString());
                }

            }
            else if (!File.Exists(AppDataFolder + "/" + AppStatistic))
            {
                Directory.CreateDirectory(".SacredUtilsData");

                File.WriteAllBytes(AppDataFolder + "/" + AppStatistic, Properties.Resources.launchstat);
            }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                InstalledFontCollection installedFonts = new InstalledFontCollection();
                List<string> fonts = installedFonts.Families.Select(font => font.Name).ToList();

                FontLibraryCmbBox.ItemsSource = fonts; fonts.Remove("");
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }

            var text = File.ReadAllLines(SacredSettings, Encoding.ASCII);

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

            var text1 = File.ReadAllLines("Settings.su", Encoding.ASCII);

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
            if (VeteranModUfoBtn.Content.ToString() == $"{String0008}")
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

                if (File.Exists(AppDataFolder + "/" + AppInstallInfo))
                {
                    try
                    {
                        var fileAllText = File.ReadAllLines($"{AppDataFolder}\\{AppInstallInfo}");

                        fileAllText[3] = "; Veteranmod by ufo installed = true";
                        fileAllText[4] = "; Veteranmod dragonfix installed = false";

                        File.WriteAllLines($"{AppDataFolder}\\{AppInstallInfo}", fileAllText);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.ToString());
                    }

                    VeteranModUfoBtn.Content = $"{String0007}"; VeteranModDragonFixBtn.Content = $"{String0008}";
                }
            }
            else if (VeteranModUfoBtn.Content.ToString() == $"{String0007}")
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

                if (File.Exists($"{AppDataFolder}\\{AppInstallInfo}"))
                {
                    try
                    {
                        var fileAllText = File.ReadAllLines($"{AppDataFolder}\\{AppInstallInfo}");

                        fileAllText[3] = "; Veteranmod by ufo installed = false";
                        fileAllText[4] = "; Veteranmod dragonfix installed = false";

                        File.WriteAllLines($"{AppDataFolder}\\{AppInstallInfo}", fileAllText);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.ToString());
                    }

                    VeteranModUfoBtn.Content = $"{String0008}"; VeteranModDragonFixBtn.Content = $"{String0008}";
                }
            }
        }
        
        private void VeteranModDragonFixBtn_Click(object sender, RoutedEventArgs e)
        {
            if (VeteranModDragonFixBtn.Content.ToString() == $"{String0008}")
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

                if (File.Exists($"{AppDataFolder}\\{AppInstallInfo}"))
                {
                    try
                    {
                        var fileAllText = File.ReadAllLines($"{AppDataFolder}\\{AppInstallInfo}");

                        fileAllText[3] = "; Veteranmod by ufo installed = false";
                        fileAllText[4] = "; Veteranmod dragonfix installed = true";

                        File.WriteAllLines($"{AppDataFolder}\\{AppInstallInfo}", fileAllText);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.ToString());
                    }

                    VeteranModUfoBtn.Content = $"{String0008}"; VeteranModDragonFixBtn.Content = $"{String0007}";
                }
            }
            else if (VeteranModDragonFixBtn.Content.ToString() == $"{String0007}")
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

                if (File.Exists($"{AppDataFolder}\\{AppInstallInfo}"))
                {
                    try
                    {
                        var fileAllText = File.ReadAllLines($"{AppDataFolder}\\{AppInstallInfo}");

                        fileAllText[3] = "; Veteranmod by ufo installed = false";
                        fileAllText[4] = "; Veteranmod dragonfix installed = false";

                        File.WriteAllLines($"{AppDataFolder}\\{AppInstallInfo}", fileAllText);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.ToString());
                    }

                    VeteranModUfoBtn.Content = $"{String0008}"; VeteranModDragonFixBtn.Content = $"{String0008}";
                }
            }
        }

        private async void SacredNewUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SacredNewUpdateBtn.Content.ToString() == $"{String0008}")
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

                if (File.Exists($"{AppDataFolder}\\{AppInstallInfo}"))
                {
                    try
                    {
                        var fileAllText = File.ReadAllLines($"{AppDataFolder}\\{AppInstallInfo}");

                        fileAllText[5] = "; Sacred 2.29.14 patch installed = true";

                        File.WriteAllLines($"{AppDataFolder}\\{AppInstallInfo}", fileAllText);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.ToString());
                    }

                    SacredNewUpdateBtn.Content = $"{String0007}";
                }
            }
            else if (SacredNewUpdateBtn.Content.ToString() == $"{String0007}")
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

                if (File.Exists($"{AppDataFolder}\\{AppInstallInfo}"))
                {
                    try
                    {
                        var fileAllText = File.ReadAllLines($"{AppDataFolder}\\{AppInstallInfo}");

                        fileAllText[5] = "; Sacred 2.29.14 patch installed = false";

                        File.WriteAllLines($"{AppDataFolder}\\{AppInstallInfo}", fileAllText);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.ToString());
                    }

                    SacredNewUpdateBtn.Content = $"{String0008}";
                }
            }
        }

        private async void ServerMulticoreFixBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ServerMulticoreFixBtn.Content.ToString() == $"{String0008}")
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

                if (File.Exists($"{AppDataFolder}\\{AppInstallInfo}"))
                {
                    try
                    {
                        var fileAllText = File.ReadAllLines($"{AppDataFolder}\\{AppInstallInfo}");

                        fileAllText[6] = "; Server multicore fix installed = true";

                        File.WriteAllLines($"{AppDataFolder}\\{AppInstallInfo}", fileAllText);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.ToString());
                    }

                    ServerMulticoreFixBtn.Content = $"{String0007}";
                }
            }
            else if (ServerMulticoreFixBtn.Content.ToString() == $"{String0007}")
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

                if (File.Exists($"{AppDataFolder}\\{AppInstallInfo}"))
                {
                    try
                    {
                        var fileAllText = File.ReadAllLines($"{AppDataFolder}\\{AppInstallInfo}");

                        fileAllText[6] = "; Server multicore fix installed = false";

                        File.WriteAllLines($"{AppDataFolder}\\{AppInstallInfo}", fileAllText);
                    }
                    catch (Exception exception)
                    {
                        Log.Error(exception.ToString());
                    }

                    ServerMulticoreFixBtn.Content = $"{String0008}";
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
                var fileAllText = File.ReadAllLines(AppSettings);
                fileAllText[index] = text;
                File.WriteAllLines(AppSettings, fileAllText);
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
    }
}