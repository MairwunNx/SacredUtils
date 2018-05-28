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
using FontFamily = System.Drawing.FontFamily;
using Application = System.Windows.Forms.Application;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace SacredUtils
{
    public partial class MainWindow
    {
        private const string AppSettings = "Settings.su";

        private const string GameSettings = "Settings.cfg";

        private readonly string _appname = Path.GetFileName(Application.ExecutablePath);

        private static readonly ILog Log = LogManager.GetLogger("LOGGER");

        public MainWindow() // Главный метод программы, вызовы других методов.
        {
            Logger.InitLogger();

            Log.Info("Вызываем метод проверки конфигурации лога из другого класса.");

            var checkLogConfiguration = new CheckLogConfiguration();
            checkLogConfiguration.GetAvailableLogConfig();

            Log.Info("Вызываем метод проверки конфигурации SacredUtils из другого класса.");

            var checkAppConfiguration = new CheckAppConfiguration();
            checkAppConfiguration.GetAvailableAppConfig();

            Log.Info("Вызываем метод удаления временных файлов из другого класса.");
            
            var checkAppTempFiles = new CheckAppTempFiles();
            checkAppTempFiles.CheckAvailableTempFiles();

            Log.Info("Вызываем метод инициализации компонентов SacredUtils из другого класса.");

            InitializeComponent();

            Log.Info("Вызываем метод проверки обновления из другого класса.");

            CheckAppUpdates checkAppUpdates = new CheckAppUpdates();

            #pragma warning disable CS4014 // Так как этот вызов не ожидается, выполнение существующего метода продолжается до завершения вызова.
            checkAppUpdates.GetAvailableAppUpdatesAsync();
            #pragma warning restore CS4014 // Так как этот вызов не ожидается, выполнение существующего метода продолжается до завершения вызова.

            Log.Info("Вызываем метод проверки настроек SacredUtils из другого класса.");
            
            GetAppSettings getAppSettings = new GetAppSettings();
            getAppSettings.LoadAppSettings();

            Log.Info("Вызываем метод проверки настроек SacredUnderworld из другого класса.");
            
            GetGameSettings getGameSettings = new GetGameSettings();
            getGameSettings.LoadGameSettings();
        }
        
        public void SetSettingsValue(string s, string v)
        {
            if (!File.Exists(GameSettings))
            {
                Log.Fatal("Файл конфигурации игры внезапно пропал!!! Он будет восстановлен.");

                Log.Info("Создаем файл конфигурации игры из ресурсов программы.");

                try
                {
                    File.WriteAllBytes("Settings.cfg", Properties.Resources.GameSettings);

                    Log.Info("Файл конфигурации игры был создан без ошибок.");
                }
                catch (Exception exception)
                {
                    Log.Fatal("Создание файла конфигурации закончилось с ошибкой."); Log.Fatal(exception.ToString());

                    Log.Info("Завершение фоновых процессов и задачь. Выход из приложения."); Environment.Exit(0);
                }
            }

            
            var text = File.ReadAllLines(GameSettings, Encoding.ASCII);

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains(s + " : ")) { text[i] = s + " : " + v; File.WriteAllLines(GameSettings, text); }
            }
        }

        public void SetSettingsValueForFont(string s, string v)
        {
            if (!File.Exists(GameSettings))
            {
                Log.Fatal("Файл конфигурации игры внезапно пропал!!! Он будет восстановлен.");

                Log.Info("Создаем файл конфигурации игры из ресурсов программы.");

                try
                {
                    File.WriteAllBytes("Settings.cfg", Properties.Resources.GameSettings);

                    Log.Info("Файл конфигурации игры был создан без ошибок.");
                }
                catch (Exception exception)
                {
                    Log.Fatal("Создание файла конфигурации закончилось с ошибкой."); Log.Fatal(exception.ToString());

                    Log.Info("Завершение фоновых процессов и задачь. Выход из приложения."); Environment.Exit(0);
                }
            }

            
            var text = File.ReadAllLines(GameSettings, Encoding.ASCII);

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains(s)) { text[i] = s + v; File.WriteAllLines(GameSettings, text); }
            }
        }

        public void SetSettingsValueWithDouble(string s, double v)
        {
            if (!File.Exists(GameSettings))
            {
                Log.Fatal("Файл конфигурации игры внезапно пропал!!! Он будет восстановлен.");

                Log.Info("Создаем файл конфигурации игры из ресурсов программы.");

                try
                {
                    File.WriteAllBytes("Settings.cfg", Properties.Resources.GameSettings);

                    Log.Info("Файл конфигурации игры был создан без ошибок.");
                }
                catch (Exception exception)
                {
                    Log.Fatal("Создание файла конфигурации закончилось с ошибкой."); Log.Fatal(exception.ToString());

                    Log.Info("Завершение фоновых процессов и задачь. Выход из приложения."); Environment.Exit(0);
                }
            }

            
            var text = File.ReadAllLines(GameSettings, Encoding.ASCII);

            for (int i = 0; i < text.Length; i++)
            {
                
                if (text[i].Contains(s + " : ")) { text[i] = s + " : " + v; File.WriteAllLines(GameSettings, text); }
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) { DragMove(); }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Log.Info("Завершение фоновых процессов и задачь. Выход из приложения."); Environment.Exit(0);
        }
        
        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ChangeColor_Click(object sender, RoutedEventArgs e)
        {
            var colorPicker = new ColorWindow(); colorPicker.Show();
        }

        private void SettingsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SettingsListBox.SelectedIndex == 0)
            {
                foreach (Grid c in SettingsGrid.Children.OfType<Grid>())
                {
                    if (c.IsVisible) { c.Visibility = Visibility.Hidden; }
                }

                NotSelectedLbl.Visibility = Visibility.Hidden;

                GraphicsSettings01Grid.Visibility = Visibility.Visible;
            }

            if (SettingsListBox.SelectedIndex == 1)
            {
                foreach (Grid c in SettingsGrid.Children.OfType<Grid>())
                {
                    if (c.IsVisible) { c.Visibility = Visibility.Hidden; }
                }

                NotSelectedLbl.Visibility = Visibility.Hidden;

                GraphicsSettings02Grid.Visibility = Visibility.Visible;
            }

            if (SettingsListBox.SelectedIndex == 2)
            {
                foreach (Grid c in SettingsGrid.Children.OfType<Grid>())
                {
                    if (c.IsVisible) { c.Visibility = Visibility.Hidden; }
                }

                NotSelectedLbl.Visibility = Visibility.Hidden;

                SoundSettingsGrid.Visibility = Visibility.Visible;
            }

            if (SettingsListBox.SelectedIndex == 3)
            {
                foreach (Grid c in SettingsGrid.Children.OfType<Grid>())
                {
                    if (c.IsVisible) { c.Visibility = Visibility.Hidden; }
                }

                NotSelectedLbl.Visibility = Visibility.Hidden;

                NetworkSettings01Grid.Visibility = Visibility.Visible;
            }

            if (SettingsListBox.SelectedIndex == 4)
            {
                foreach (Grid c in SettingsGrid.Children.OfType<Grid>())
                {
                    if (c.IsVisible) { c.Visibility = Visibility.Hidden; }
                }

                NotSelectedLbl.Visibility = Visibility.Hidden;

                NetworkSettings02Grid.Visibility = Visibility.Visible;
            }

            if (SettingsListBox.SelectedIndex == 5)
            {
                foreach (Grid c in SettingsGrid.Children.OfType<Grid>())
                {
                    if (c.IsVisible) { c.Visibility = Visibility.Hidden; }
                }

                NotSelectedLbl.Visibility = Visibility.Hidden;

                ChatSettingsGrid.Visibility = Visibility.Visible;
            }

            if (SettingsListBox.SelectedIndex == 6)
            {
                foreach (Grid c in SettingsGrid.Children.OfType<Grid>())
                {
                    if (c.IsVisible) { c.Visibility = Visibility.Hidden; }
                }

                NotSelectedLbl.Visibility = Visibility.Hidden;

                GameSettings01Grid.Visibility = Visibility.Visible;
            }

            if (SettingsListBox.SelectedIndex == 7)
            {
                foreach (Grid c in SettingsGrid.Children.OfType<Grid>())
                {
                    if (c.IsVisible) { c.Visibility = Visibility.Hidden; }
                }

                NotSelectedLbl.Visibility = Visibility.Hidden;

                GameSettings02Grid.Visibility = Visibility.Visible;
            }

            if (SettingsListBox.SelectedIndex == 8)
            {
                foreach (Grid c in SettingsGrid.Children.OfType<Grid>())
                {
                    if (c.IsVisible) { c.Visibility = Visibility.Hidden; }
                }

                NotSelectedLbl.Visibility = Visibility.Hidden;

                FontsSettingsGrid.Visibility = Visibility.Visible;
            }

            if (SettingsListBox.SelectedIndex == 9)
            {
                foreach (Grid c in SettingsGrid.Children.OfType<Grid>())
                {
                    if (c.IsVisible) { c.Visibility = Visibility.Hidden; }
                }

                NotSelectedLbl.Visibility = Visibility.Hidden;

                OtherSettingsGrid.Visibility = Visibility.Visible;
            }

            if (SettingsListBox.SelectedIndex == 10)
            {
                foreach (Grid c in SettingsGrid.Children.OfType<Grid>())
                {
                    if (c.IsVisible) { c.Visibility = Visibility.Hidden; }
                }

                NotSelectedLbl.Visibility = Visibility.Hidden;

                ModdingSettingsGrid.Visibility = Visibility.Visible;
            }

            if (SettingsListBox.SelectedIndex == 11)
            {
                foreach (Grid c in SettingsGrid.Children.OfType<Grid>())
                {
                    if (c.IsVisible) { c.Visibility = Visibility.Hidden; }
                }

                NotSelectedLbl.Visibility = Visibility.Hidden;

                AppSettingsGrid.Visibility = Visibility.Visible;
            }

            if (SettingsListBox.SelectedIndex == 12)
            {
                foreach (Grid c in SettingsGrid.Children.OfType<Grid>())
                {
                    if (c.IsVisible) { c.Visibility = Visibility.Hidden; }
                }

                NotSelectedLbl.Visibility = Visibility.Hidden;

                AboutGrid.Visibility = Visibility.Visible;
            }

            if (SettingsListBox.SelectedIndex == 14)
            {
                if (CloseProgramToggleBtn.IsChecked == true)
                {
                    if (ChangeImputLangToggleBtn.IsChecked == true)
                    {
                        if (File.Exists("Sacred.exe"))
                        {
                            
                            Log.Info("Запускаем Sacred.exe с параметрами : Изменить язык ввода, выйди из приложения.");
                            Process.Start("Sacred.exe"); InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));

                            Environment.Exit(0);
                        }
                    }
                    else if (ChangeImputLangToggleBtn.IsChecked == false)
                    {
                        Log.Info("Запускаем Sacred.exe с параметрами : Выйди из приложения.");

                        if (File.Exists("Sacred.exe")) { Process.Start("Sacred.exe"); Environment.Exit(0); }
                    }
                }
                else if (MinimizeProgramToggleBtn.IsChecked == true)
                {
                    if (ChangeImputLangToggleBtn.IsChecked == true)
                    {
                        if (File.Exists("Sacred.exe"))
                        {
                            Log.Info("Запускаем Sacred.exe с параметрами : Изменить язык ввода, свернуть приложение.");

                            Process.Start("Sacred.exe"); InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));

                            WindowState = WindowState.Minimized;
                        }
                    }
                    else if (ChangeImputLangToggleBtn.IsChecked == false)
                    {
                        Log.Info("Запускаем Sacred.exe с параметрами : Свернуть приложение.");

                        if (File.Exists("Sacred.exe")) { Process.Start("Sacred.exe"); WindowState = WindowState.Minimized; }
                    }
                }
                else { if (File.Exists("Sacred.exe")) { Process.Start("Sacred.exe"); } }
            }

            if (SettingsListBox.SelectedIndex == 15)
            {
                Log.Info("Завершение фоновых процессов и задачь. Перезагрузка приложения.");

                Process.Start(_appname); Environment.Exit(0);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Log.Info("Создаем файл лицензии Apache 2.0 для SacredUtils.");
            
            File.WriteAllBytes("license.txt", Properties.Resources.license);

            Log.Info("Файл лицензии Apache 2.0 для SacredUtils был создан без ошибок.");

            Log.Info("Загружаем коллекцию шрифтов для SacredUtils.");
            
            List<string> fonts = new List<string>();
            InstalledFontCollection installedFonts = new InstalledFontCollection();
            foreach (FontFamily font in installedFonts.Families) { fonts.Add(font.Name); }

            FontLibraryCmbBox.ItemsSource = fonts;

            Log.Info("Коллекция шрифтов загружена без ошибок.");

            var text = File.ReadAllLines(GameSettings, Encoding.ASCII);

            Log.Info("Подготавливаем коллекцию шрифтов для FontsCombobox.");

            try
            {
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
            }
            catch (Exception exception)
            {
                Log.Error("Загрузка шрифтов в FontsCombobox завершена с ошибкой."); Log.Error(exception.ToString());
            }

            var text1 = File.ReadAllLines("Settings.su", Encoding.ASCII);

            Log.Info("Загружаем цветовые схемы для SacredUtils.");

            for (var i = 0; i < text1.Length; i++)
            {
                if (text1[i].Contains("User interface color SacredUtils = default") || text1[i].Contains("User interface color SacredUtils = indigo"))
                {
                    var colorWindow = new ColorWindow(); colorWindow.Close();

                    colorWindow.ChangeColor("#7986cb", "#303f9f", "#3f51b5", "#c5cae9", "Indigo", "#FFFFFFFF");
                }

                if (text1[i].Contains("User interface color SacredUtils = red"))
                {
                    var colorWindow = new ColorWindow(); colorWindow.Close();

                    colorWindow.ChangeColor("#e57373", "#d32f2f", "#f44336", "#ffcdd2", "Red", "#FFFFFFFF");
                }

                if (text1[i].Contains("User interface color SacredUtils = pink"))
                {
                    var colorWindow = new ColorWindow(); colorWindow.Close();

                    colorWindow.ChangeColor("#f06292", "#c2185b", "#e91e63", "#f8bbd0", "Pink", "#FFFFFFFF");
                }

                if (text1[i].Contains("User interface color SacredUtils = purple"))
                {
                    var colorWindow = new ColorWindow(); colorWindow.Close();

                    colorWindow.ChangeColor("#ba68c8", "#7b1fa2", "#9c27b0", "#e1bee7", "Purple", "#FFFFFFFF");
                }

                if (text1[i].Contains("User interface color SacredUtils = deeppurple"))
                {
                    var colorWindow = new ColorWindow(); colorWindow.Close();

                    colorWindow.ChangeColor("#9575cd", "#512da8", "#673ab7", "#d1c4e9", "DeepPurple", "#FFFFFFFF");
                }

                if (text1[i].Contains("User interface color SacredUtils = blue"))
                {
                    var colorWindow = new ColorWindow(); colorWindow.Close();

                    colorWindow.ChangeColor("#64b5f6", "#1976d2", "#2196f3", "#bbdefb", "Blue", "#FFFFFFFF");
                }

                if (text1[i].Contains("User interface color SacredUtils = lightblue"))
                {
                    var colorWindow = new ColorWindow(); colorWindow.Close();

                    colorWindow.ChangeColor("#4fc3f7", "#0288d1", "#03a9f4", "#b3e5fc", "LightBlue", "#000000");
                }

                if (text1[i].Contains("User interface color SacredUtils = cyan"))
                {
                    var colorWindow = new ColorWindow(); colorWindow.Close();

                    colorWindow.ChangeColor("#4dd0e1", "#0097a7", "#00bcd4", "#b2ebf2", "Cyan", "#000000");
                }

                if (text1[i].Contains("User interface color SacredUtils = teal"))
                {
                    var colorWindow = new ColorWindow(); colorWindow.Close();

                    colorWindow.ChangeColor("#4db6ac", "#00796b", "#009688", "#b2dfdb", "Teal", "#ffffff");
                }

                if (text1[i].Contains("User interface color SacredUtils = green"))
                {
                    var colorWindow = new ColorWindow(); colorWindow.Close();

                    colorWindow.ChangeColor("#81c784", "#388e3c", "#4caf50", "#c8e6c9", "Green", "#ffffff");
                }

                if (text1[i].Contains("User interface color SacredUtils = lightgreen"))
                {
                    var colorWindow = new ColorWindow(); colorWindow.Close();

                    colorWindow.ChangeColor("#aed581", "#689f38", "#8bc34a", "#dcedc8", "LightGreen", "#000000");
                }

                if (text1[i].Contains("User interface color SacredUtils = lime"))
                {
                    var colorWindow = new ColorWindow(); colorWindow.Close();

                    colorWindow.ChangeColor("#dce775", "#afb42b", "#cddc39", "#f0f4c3", "Lime", "#000000");
                }

                if (text1[i].Contains("User interface color SacredUtils = yellow"))
                {
                    var colorWindow = new ColorWindow(); colorWindow.Close();

                    colorWindow.ChangeColor("#fff176", "#fbc02d", "#ffeb3b", "#fff9c4", "Yellow", "#000000");
                }

                if (text1[i].Contains("User interface color SacredUtils = amber"))
                {
                    var colorWindow = new ColorWindow(); colorWindow.Close();

                    colorWindow.ChangeColor("#ffd54f", "#ffa000", "#ffc107", "#ffecb3", "Amber", "#000000");
                }

                if (text1[i].Contains("User interface color SacredUtils = orange"))
                {
                    var colorWindow = new ColorWindow(); colorWindow.Close();

                    colorWindow.ChangeColor("#ffb74d", "#f57c00", "#ff9800", "#ffe0b2", "Orange", "#000000");
                }

                if (text1[i].Contains("User interface color SacredUtils = deeporange"))
                {
                    var colorWindow = new ColorWindow(); colorWindow.Close();

                    colorWindow.ChangeColor("#ff8a65", "#e64a19", "#ff5722", "#ffccbc", "DeepOrange", "#000000");
                }

                if (text1[i].Contains("User interface color SacredUtils = brown"))
                {
                    var colorWindow = new ColorWindow(); colorWindow.Close();

                    colorWindow.ChangeColor("#a1887f", "#5d4037", "#795548", "#d7ccc8", "Brown", "#ffffff");
                }

                if (text1[i].Contains("User interface color SacredUtils = grey"))
                {
                    var colorWindow = new ColorWindow(); colorWindow.Close();

                    colorWindow.ChangeColor("#e0e0e0", "#616161", "#9e9e9e", "#f5f5f5", "Grey", "#000000");
                }

                if (text1[i].Contains("User interface color SacredUtils = bluegrey"))
                {
                    var colorWindow = new ColorWindow(); colorWindow.Close();

                    colorWindow.ChangeColor("#90a4ae", "#455a64", "#607d8b", "#cfd8dc", "BlueGrey", "#ffffff");
                }

                if (text1[i].Contains("User interface color SacredUtils = black"))
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

            Log.Info("Цветовые схемы для SacredUtils были загружены без ошибок.");
        }
        
        private void ImageSmoothingToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("FSAA_FILTER", ImageSmoothingToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void MemoryLimitToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("GFX_LIMIT128", MemoryLimitToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void CompatibilityModeToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("COMPAT_VIDEO", CompatibilityModeToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void ColorDepthToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("GFX32", ColorDepthToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void VerticalSyncToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("WAITRETRACE", VerticalSyncToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void OpaqueShadowsToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("FORCE_BLACK_SHADOW", OpaqueShadowsToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void FullScreenModeToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("FULLSCREEN", FullScreenModeToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void ShowMoviesToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("SHOWMOVIE", ShowMoviesToggleBtn.IsChecked == true ? "1" : "0");

            SetSettingsValue("SHOWEXTRO", ShowMoviesToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void GraphicsQualityCmbBox_DropDownClosed(object sender, EventArgs e)
        {
            if (GraphicsQualityCmbBox.SelectedIndex == 0) { SetSettingsValue("DETAILLEVEL", "0"); }

            if (GraphicsQualityCmbBox.SelectedIndex == 1) { SetSettingsValue("DETAILLEVEL", "1"); }

            if (GraphicsQualityCmbBox.SelectedIndex == 2) { SetSettingsValue("DETAILLEVEL", "2"); }
        }

        private void MapTransparentSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<Double> e)
        {
            SetSettingsValueWithDouble("MINIMAP_ALPHA", MapTransparentSlider.Value);
        }

        private void NightDarknessSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SetSettingsValueWithDouble("NIGHT_DARKNESS", NightDarknessSlider.Value);
        }

        private void PictureStartTxBox_KeyUp(object sender, KeyEventArgs e)
        {
            SetSettingsValue("GFXSTARTUP", PictureStartTxBox.Text);
        }

        private void PictureSaveLoadTxBox_KeyUp(object sender, KeyEventArgs e)
        {
            SetSettingsValue("GFXLOADING", PictureSaveLoadTxBox.Text);
        }

        private void InterfaceLanguageCmbBox_DropDownClosed(object sender, EventArgs e)
        {
            if (InterfaceLanguageCmbBox.SelectedIndex == 0) { SetSettingsValue("LANGUAGE", "RU"); }

            if (InterfaceLanguageCmbBox.SelectedIndex == 1) { SetSettingsValue("LANGUAGE", "EN"); }

            if (InterfaceLanguageCmbBox.SelectedIndex == 2) { SetSettingsValue("LANGUAGE", "DE"); }
        }

        private void SoundToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("SOUND", SoundToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void SoundQualityCmbBox_DropDownClosed(object sender, EventArgs e)
        {
            if (SoundQualityCmbBox.SelectedIndex == 0) { SetSettingsValue("SOUNDQUALITY", "0"); }

            if (SoundQualityCmbBox.SelectedIndex == 1) { SetSettingsValue("SOUNDQUALITY", "1"); }

            if (SoundQualityCmbBox.SelectedIndex == 2) { SetSettingsValue("SOUNDQUALITY", "2"); }
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

        private void NetLoggingToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("NETLOG", NetLoggingToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void HideCdKeyToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("NETWORK_CDKEY_HIDE", HideCdKeyToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void PlayerInfoToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("SHOW_HEROINFO", PlayerInfoToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void LadderExportToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("LADDER_EXPORT", LadderExportToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void LicenseToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("ACCEPT_LICENSE", LicenseToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void ConnectTypeCmbBox_DropDownClosed(object sender, EventArgs e)
        {
            if (ConnectTypeCmbBox.SelectedIndex == 0) { SetSettingsValue("NETWORK_SPEEDSETTINGS", "2"); }

            if (ConnectTypeCmbBox.SelectedIndex == 1) { SetSettingsValue("NETWORK_SPEEDSETTINGS", "1"); }

            if (ConnectTypeCmbBox.SelectedIndex == 2) { SetSettingsValue("NETWORK_SPEEDSETTINGS", "0"); }
        }

        private void ServerIpTxBox_KeyUp(object sender, KeyEventArgs e)
        {
            SetSettingsValue("NETWORK_IP_ADDRESS", ServerIpTxBox.Text);
        }

        private void ServerPortTxBox_KeyUp(object sender, KeyEventArgs e)
        {
            SetSettingsValue("NETWORK_PORT_LISTEN", ServerPortTxBox.Text);
        }

        private void ServerNameTxBox_KeyUp(object sender, KeyEventArgs e)
        {
            SetSettingsValue("NETWORK_SESSION", ServerNameTxBox.Text);
        }

        private void ServerNickNameTxBox_KeyUp(object sender, KeyEventArgs e)
        {
            SetSettingsValue("NETWORK_PLAYER", ServerNickNameTxBox.Text);
        }

        private void ServerPasswordTxBox_KeyUp(object sender, KeyEventArgs e)
        {
            SetSettingsValue("NETWORK_PASSWORD", ServerPasswordTxBox.Text);
        }

        private void ServerLobbyTxBox_KeyUp(object sender, KeyEventArgs e)
        {
            SetSettingsValue("NETWORK_LOBBY", ServerLobbyTxBox.Text);
        }

        private void RainbowChatToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("UNIQUE_COLOR", RainbowChatToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void ChatLinesSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SetSettingsValueWithDouble("CHAT_LINES", ChatLinesSlider.Value);
        }

        private void ChatTextDelaySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SetSettingsValueWithDouble("CHAT_DELAY", ChatTextDelaySlider.Value);
        }

        private void ChatTransparentSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SetSettingsValueWithDouble("CHAT_ALPHA", ChatTransparentSlider.Value);
        }

        private void DopingBarToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("SHOWPOTIONS", DopingBarToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void EnemyInfoToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("SHOW_ENEMYINFO", EnemyInfoToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void AnimationToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("PICKUPANIM", AnimationToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void AutosaveToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("AUTOSAVE", AutosaveToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void EarthquakeEffectToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("SCREEN_QUAKE", EarthquakeEffectToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void DefaultSkillsToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("DEFAULT_SKILLS", DefaultSkillsToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void WarFogToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("EXPLOREMAP", WarFogToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void FontSmoothToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("FONTAA", FontSmoothToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void FontFilteringToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("FONTFILTER", FontFilteringToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void LogToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("LOGGING", LogToggleBtn.IsChecked == true ? "1" : "0");
        }

        private void DamageIconsToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetSettingsValue("TASKBAR_ICONS", DamageIconsToggleBtn.IsChecked == true ? "1" : "0");
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

        private void FontLibraryCmbBox_DropDownClosed(object sender, EventArgs e)
        {
//            FontsTestLbl.FontFamily = new System.Windows.Media.FontFamily(FontLibraryCmbBox.Text);

            SetSettingsValueForFont("FONT : 1, ", "\"" + FontLibraryCmbBox.Text + "\"" + ", 10");
            SetSettingsValueForFont("FONT : 2, ", "\"" + FontLibraryCmbBox.Text + "\"" + ", 10");
            SetSettingsValueForFont("FONT : 3, ", "\"" + FontLibraryCmbBox.Text + "\"" + ", 12");
            SetSettingsValueForFont("FONT : 4, ", "\"" + FontLibraryCmbBox.Text + "\"" + ", 15");
            SetSettingsValueForFont("FONT : 5, ", "\"" + FontLibraryCmbBox.Text + "\"" + ", 12");
            SetSettingsValueForFont("FONT : 6, ", "\"" + FontLibraryCmbBox.Text + "\"" + ", 12");
            SetSettingsValueForFont("FONT : 7, ", "\"" + FontLibraryCmbBox.Text + "\"" + ", 8");
        }

        private void PickupSettingsCmbBox_DropDownClosed(object sender, EventArgs e)
        {
            if (PickupSettingsCmbBox.SelectedIndex == 0) { SetSettingsValue("PICKUPAUTO", "0"); }

            if (PickupSettingsCmbBox.SelectedIndex == 1) { SetSettingsValue("PICKUPAUTO", "1"); }

            if (PickupSettingsCmbBox.SelectedIndex == 2) { SetSettingsValue("PICKUPAUTO", "2"); }
        }

        private void AutosaveDelaySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SetSettingsValueWithDouble("AUTOSAVEDELAY", AutosaveDelaySlider.Value);
        }

        private void WarningPercentSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SetSettingsValueWithDouble("WARNING_LEVEL", WarningPercentSlider.Value);
        }

        private void VeteranModInstallBtn_Click(object sender, RoutedEventArgs e)
        {
            Log.Info("Подготовка к установке Veteran Mod сложности.");

            Log.Info("Создаем директории для Veteran Mod если их нет.");
            
            Directory.CreateDirectory("bin"); Directory.CreateDirectory("PAK");

            Log.Info("Директории для Veteran Mod были созданы без ошибок.");

            Log.Info("Устанавливаем Balance.bin в директорию bin.");
            
            File.WriteAllBytes(@"bin" + "/" + "balance.bin", Properties.Resources.SacredBalanceVeteran);

            Log.Info("Установка Balance.bin в директорию bin выполнена без ошибок.");

            Log.Info("Устанавливаем Creature.pak в директорию PAK.");
            
            File.WriteAllBytes(@"PAK" + "/" + "creature.pak", Properties.Resources.SacredCreatureVeteran);

            Log.Info("Установка Creature.pak в директорию PAK выполнена без ошибок.");

            Log.Info("Установка Veteran Mod завершилась без ошибок.");
        }

        private void VeteranModUnistallBtn_Click(object sender, RoutedEventArgs e)
        {
            Log.Info("Подготовка к удалению Veteran Mod сложности.");

            Log.Info("Создаем директории для стандартной сложности если их нет.");
            
            Directory.CreateDirectory("bin"); Directory.CreateDirectory("PAK");

            Log.Info("Директории для стандартной сложности были созданы без ошибок.");

            Log.Info("Устанавливаем Balance.bin в директорию bin.");
            
            File.WriteAllBytes(@"bin" + "/" + "balance.bin", Properties.Resources.SacredBalanceVanilla);

            Log.Info("Установка Balance.bin в директорию bin выполнена без ошибок.");

            Log.Info("Устанавливаем Creature.pak в директорию PAK.");
            
            File.WriteAllBytes(@"PAK" + "/" + "creature.pak", Properties.Resources.SacredCreatureVanilla);

            Log.Info("Установка Creature.pak в директорию PAK выполнена без ошибок.");

            Log.Info("Установка стандартной сложности завершилась без ошибок.");
        }

        private void SacredNewInstallBtn_Click(object sender, RoutedEventArgs e)
        {
            Log.Info("Подготовка к обновлению Sacred до 2.29.14 версии.");
            
            File.WriteAllBytes("Sacred.exe", Properties.Resources.SacredPatched22914);

            Log.Info("Обновление Sacred до 2.29.14 версии прошла успешно.");
        }

        private void SacredNewUnistallBtn_Click(object sender, RoutedEventArgs e)
        {
            Log.Info("Подготовка к обновлению Sacred до 2.28.01 версии.");

            File.WriteAllBytes("Sacred.exe", Properties.Resources.SacredPatched228);

            Log.Info("Обновление Sacred до 2.28.01 версии прошла успешно.");
        }

        private void CompileGlobalResBtn_Click(object sender, RoutedEventArgs e)
        {
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
                }
                catch (Exception exception)
                {
                    Log.Error("Произошла критическая ошибка во время компиляции global.res."); Log.Error(exception.ToString());
                }
            }
            else
            {
                Log.Error("Процесс компиляции global.res завершился с ошибкой. Проверьте его наличие.");
            }
        }

        private void DecompileGlobalResBtn_Click(object sender, RoutedEventArgs e)
        {
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
                }
                catch (Exception exception)
                {
                    Log.Error("Произошла критическая ошибка во время декомпиляции global.res."); Log.Error(exception.ToString());
                }
            }
            else
            {
                Log.Error("Процесс декомпиляции global.res завершился с ошибкой. Проверьте его наличие.");
            }
        }

        private void AdvancedErrorLogToggleBtn_Click(object sender, RoutedEventArgs e)
        {  
            if (AdvancedErrorLogToggleBtn.IsChecked == true) 
            {
                var fileAllText = File.ReadAllLines(AppSettings);
                fileAllText[18] = "# - Show advanced errors-exceptions in log = true                  #";
                File.WriteAllLines(AppSettings, fileAllText);
            }
            else if (AdvancedErrorLogToggleBtn.IsChecked == false)
            {
                var fileAllText = File.ReadAllLines(AppSettings);
                fileAllText[18] = "# - Show advanced errors-exceptions in log = false                 #";
                File.WriteAllLines(AppSettings, fileAllText);
            }

        }

        private void AutomaticalyInstallUpdates_Click(object sender, RoutedEventArgs e)
        {
            if (AutomaticalyInstallUpdates.IsChecked == true)
            {
                var fileAllText = File.ReadAllLines(AppSettings);
                fileAllText[16] = "# - Automatically get and install updates = true                   #";
                File.WriteAllLines(AppSettings, fileAllText);
            }
            else if (AutomaticalyInstallUpdates.IsChecked == false)
            {
                var fileAllText = File.ReadAllLines(AppSettings);
                fileAllText[16] = "# - Automatically get and install updates = false                  #";
                File.WriteAllLines(AppSettings, fileAllText);
            }
        }

        private void MinimizeProgramToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MinimizeProgramToggleBtn.IsChecked == true)
            {
                var fileAllText = File.ReadAllLines(AppSettings);
                fileAllText[20] = "# - Minimize the program before launching Sacred = true            #";
                File.WriteAllLines(AppSettings, fileAllText);
            }
            else if (MinimizeProgramToggleBtn.IsChecked == false)
            {
                var fileAllText = File.ReadAllLines(AppSettings);
                fileAllText[20] = "# - Minimize the program before launching Sacred = false           #";
                File.WriteAllLines(AppSettings, fileAllText);
            }
        }

        private void ChangeImputLangToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ChangeImputLangToggleBtn.IsChecked == true)
            {
                var fileAllText = File.ReadAllLines(AppSettings);
                fileAllText[22] = "# - Change the input language before running Sacred = true         #";
                File.WriteAllLines(AppSettings, fileAllText);
            }
            else if (ChangeImputLangToggleBtn.IsChecked == false)
            {
                var fileAllText = File.ReadAllLines(AppSettings);
                fileAllText[22] = "# - Change the input language before running Sacred = false        #";
                File.WriteAllLines(AppSettings, fileAllText);
            }
        }

        private void CloseProgramToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CloseProgramToggleBtn.IsChecked == true)
            {
                var fileAllText = File.ReadAllLines(AppSettings);
                fileAllText[24] = "# - Close the program after launching Sacred = true                #";
                File.WriteAllLines(AppSettings, fileAllText);
            }
            else if (CloseProgramToggleBtn.IsChecked == false)
            {
                var fileAllText = File.ReadAllLines(AppSettings);
                fileAllText[24] = "# - Close the program after launching Sacred = false               #";
                File.WriteAllLines(AppSettings, fileAllText);
            }
        }

        private void RestoreSettingsToggleBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RestoreSettingsToggleBtn.IsChecked == true)
            {
                var fileAllText = File.ReadAllLines(AppSettings);
                fileAllText[26] = "# - Restore Settings.cfg if it is corrupted = true                 #";
                File.WriteAllLines(AppSettings, fileAllText);
            }
            else if (RestoreSettingsToggleBtn.IsChecked == false)
            {
                var fileAllText = File.ReadAllLines(AppSettings);
                fileAllText[26] = "# - Restore Settings.cfg if it is corrupted = false                #";
                File.WriteAllLines(AppSettings, fileAllText);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D1) { SettingsListBox.SelectedIndex = 0; }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D2) { SettingsListBox.SelectedIndex = 1; }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D3) { SettingsListBox.SelectedIndex = 2; }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D4) { SettingsListBox.SelectedIndex = 3; }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D5) { SettingsListBox.SelectedIndex = 4; }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D6) { SettingsListBox.SelectedIndex = 5; }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D7) { SettingsListBox.SelectedIndex = 6; }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D8) { SettingsListBox.SelectedIndex = 7; }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D9) { SettingsListBox.SelectedIndex = 8; }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.D0) { SettingsListBox.SelectedIndex = 9; }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.Q) { SettingsListBox.SelectedIndex = 15; }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.W) { var colorPicker = new ColorWindow(); colorPicker.Show(); }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.E) { Process.Start("https://vk.cc/85SSFN"); }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.R) { Process.Start("https://vk.cc/85SSXC"); }

            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control && e.Key == Key.T) { Process.Start("https://vk.cc/85ST4b"); }
        }

        private void FeedBackBtn_Click(object sender, RoutedEventArgs e) { Process.Start("https://vk.cc/85SSFN"); }

        private void CreatorBtn_Click(object sender, RoutedEventArgs e) { Process.Start("https://vk.cc/85SSXC"); }

        private void GroupBtn_Click(object sender, RoutedEventArgs e) { Process.Start("https://vk.cc/85ST4b"); }

        private void GitHub_Click(object sender, RoutedEventArgs e) { Process.Start("https://github.com/MairwunNx/SacredUtils/"); }
    }
}