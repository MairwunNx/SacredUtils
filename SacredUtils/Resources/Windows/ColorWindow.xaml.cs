using log4net;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;

namespace SacredUtils.Resources.Windows
{
    public partial class ColorWindow
    {
        public ColorWindow() { InitializeComponent(); LoadColorFromConfig(); }

        private static readonly ILog Log = LogManager.GetLogger("LOGGER");

        private void Window_KeyDown(object sender, KeyEventArgs e) { if (e.Key == Key.Escape) { Close(); } }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e) { Close(); }

        private void Card_MouseUp(object sender, MouseButtonEventArgs e) // Проверяем нажатие.
        {
            var mairwunxn = sender as Card; if (ColorCrd != null) { e.Handled = true;}
        }

        private void LoadColorFromConfig() // Тут мы загружаем все цвета из конфига.
        {
            Log.Info("Загружаем активные цветовые схемы для SacredUtils.");

            var text = File.ReadAllLines("Settings.su", Encoding.ASCII);

            BrushConverter bc = new BrushConverter();

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains("User interface color SacredUtils = default") || text[i].Contains("User interface color SacredUtils = indigo"))
                {
                    ChangeColorIndigoToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains("User interface color SacredUtils = red"))
                {
                    ChangeColorRedToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains("User interface color SacredUtils = pink"))
                {
                    ChangeColorPinkToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains("User interface color SacredUtils = purple"))
                {
                    ChangeColorPurpleToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains("User interface color SacredUtils = deeppurple"))
                {
                    ChangeColorDeppPurpleToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains("User interface color SacredUtils = blue"))
                {
                    ChangeColorBlueToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains("User interface color SacredUtils = lightblue"))
                {
                    ChangeColorLightBlueToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains("User interface color SacredUtils = cyan"))
                {
                    ChangeColorCyanToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains("User interface color SacredUtils = teal"))
                {
                    ChangeColorTealToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains("User interface color SacredUtils = green"))
                {
                    ChangeColorGreenToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains("User interface color SacredUtils = lightgreen"))
                {
                    ChangeColorLightGreenToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains("User interface color SacredUtils = lime"))
                {
                    ChangeColorLimeToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains("User interface color SacredUtils = yellow"))
                {
                    ChangeColorYellowToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains("User interface color SacredUtils = amber"))
                {
                    ChangeColorAmberToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains("User interface color SacredUtils = orange"))
                {
                    ChangeColorOrangeToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains("User interface color SacredUtils = deeporange"))
                {
                    ChangeColorDeepOrangeToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains("User interface color SacredUtils = brown"))
                {
                    ChangeColorBrownToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains("User interface color SacredUtils = bluegrey"))
                {
                    ChangeColorBlueGreyToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains("User interface color SacredUtils = grey"))
                {
                    ChangeColorGrayToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains("User interface color SacredUtils = black"))
                {
                    ChangeColorBlackToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#2c2c2c");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#eeeeee");
                }
            }

            Log.Info("Загрузка активных цветовых схем для SacredUtils завершена без ошибок.");
        }

        private void ChangeColorRedToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorRedToggleBtn.IsChecked == true)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#e57373");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#e57373");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#d32f2f");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#f44336");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#ffcdd2");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("Red");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = red                         #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на Red.");
            }
        }

        private void ChangeColorPinkToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorPinkToggleBtn.IsChecked == true)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#f06292");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#f06292");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#c2185b");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#e91e63");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#f8bbd0");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("Pink");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = pink                        #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на Pink.");
            }

        }

        private void ChangeColorPurpleToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorPurpleToggleBtn.IsChecked == true)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#ba68c8");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#ba68c8");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#7b1fa2");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#9c27b0");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#e1bee7");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("Purple");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = purple                      #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на Purple.");
            }
        }

        private void ChengeColorDeppPurpleToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorDeppPurpleToggleBtn.IsChecked == true)
            { 
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#9575cd");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#9575cd");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#512da8");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#673ab7");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#d1c4e9");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("DeepPurple");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = deeppurple                  #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на DeepPurple.");
            }
        }

        private void ChangeColorIndigoToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorIndigoToggleBtn.IsChecked == true)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#7986cb");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#7986cb");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#303f9f");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#3f51b5");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#c5cae9");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("Indigo");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = indigo                      #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на Indigo.");
            }
        }

        private void ChangeColorBlueToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorBlueToggleBtn.IsChecked == true)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#64b5f6");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#64b5f6");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#1976d2");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#2196f3");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#bbdefb");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("Blue");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = blue                        #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на Blue.");
            }
        }

        private void ChangeColorLightBlueToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorLightBlueToggleBtn.IsChecked == true)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#000000");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#000000");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#000000");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#4fc3f7");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#4fc3f7");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#0288d1");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#03a9f4");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#b3e5fc");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("LightBlue");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = lightblue                   #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на LightBlue.");
            }
        }

        private void ChangeColorCyanToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorCyanToggleBtn.IsChecked == true)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#000000");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#000000");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#000000");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#4dd0e1");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#4dd0e1");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#0097a7");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#00bcd4");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#b2ebf2");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("Cyan");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = cyan                        #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на Cyan.");
            }
        }

        private void ChangeColorTealToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorTealToggleBtn.IsChecked == true)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#4db6ac");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#4db6ac");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#00796b");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#009688");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#b2dfdb");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("Teal");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = teal                        #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на Teal.");
            }
        }

        private void ChangeColorGreenToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorGreenToggleBtn.IsChecked == true)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#81c784");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#81c784");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#388e3c");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#4caf50");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#c8e6c9");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("Green");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = green                       #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на Green.");
            }
        }

        private void ChangeColorLightGreenToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorLightGreenToggleBtn.IsChecked == true)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#000000");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#000000");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#000000");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#aed581");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#aed581");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#689f38");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#8bc34a");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#dcedc8");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("LightGreen");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = lightgreen                  #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на LightGreen.");
            }
        }

        private void ChangeColorLimeToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorLimeToggleBtn.IsChecked == true)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#000000");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#000000");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#000000");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#dce775");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#dce775");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#afb42b");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#cddc39");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#f0f4c3");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("Lime");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = lime                        #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на Lime.");
            }
        }

        private void ChangeColorYellowToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorYellowToggleBtn.IsChecked == true)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#000000");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#000000");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#000000");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#fff176");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#fff176");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#fbc02d");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#ffeb3b");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#fff9c4");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("Yellow");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = yellow                      #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на Yellow.");
            }
        }

        private void ChangeColorAmberToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorAmberToggleBtn.IsChecked == true)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#000000");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#000000");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#000000");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#ffd54f");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#ffd54f");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#ffa000");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#ffc107");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#ffecb3");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("Amber");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = amber                       #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на Amber.");
            }
        }

        private void ChangeColorOrangeToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorOrangeToggleBtn.IsChecked == true)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#000000");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#000000");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#000000");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#ffb74d");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#ffb74d");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#f57c00");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#ff9800");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#ffe0b2");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("Orange");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = orange                      #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на Orange.");
            }
        }

        private void ChangeColorDeepOrangeToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorDeepOrangeToggleBtn.IsChecked == true)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#000000");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#000000");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#000000");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#ff8a65");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#ff8a65");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#e64a19");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#ff5722");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#ffccbc");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("DeepOrange");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = deeporange                  #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на DeepOrange.");
            }
        }

        private void ChangeColorBrownToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorBrownToggleBtn.IsChecked == true)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#a1887f");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#a1887f");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#5d4037");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#795548");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#d7ccc8");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("Brown");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = brown                       #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на Brown.");
            }
        }

        private void ChangeColorGrayToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorGrayToggleBtn.IsChecked == true)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#000000");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#000000");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#000000");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#e0e0e0");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#e0e0e0");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#616161");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#9e9e9e");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#f5f5f5");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("Grey");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = grey                        #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на Grey.");
            }
        }

        private void ChangeColorBlueGreyToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorBlueGreyToggleBtn.IsChecked == true)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#90a4ae");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#90a4ae");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#455a64");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#607d8b");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#cfd8dc");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#DD323232");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("BlueGrey");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = bluegrey                    #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на BlueGrey.");
            }
        }

        private void ChangeColorBlackToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorBlackToggleBtn.IsChecked == true)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).AppCaption.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).ChangeColorIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");
                        ((MainWindow)window).GithubIcon.Foreground = (Brush)bc.ConvertFrom("#ffffff");

                        ((MainWindow)window).CloseIcon.Foreground = (Brush)bc.ConvertFrom("#484848");
                        ((MainWindow)window).MinimizeIcon.Foreground = (Brush)bc.ConvertFrom("#484848");
                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom("#000000");
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom("#212121");
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom("#484848");

                        ((MainWindow)window).SettingsCard.Background = (Brush)bc.ConvertFrom("#2c2c2c");
                        ((MainWindow)window).SelectSettingsCard.Background = (Brush)bc.ConvertFrom("#2c2c2c");
                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DDCBCBCB");
                        ((MainWindow)window).ColorLabel.Foreground = (Brush)bc.ConvertFrom("#eeeeee");
                        ((MainWindow)window).SettingsLbl.Foreground = (Brush)bc.ConvertFrom("#e0e0e0");
                        ((MainWindow)window).SettingsListBox.Foreground = (Brush)bc.ConvertFrom("#e0e0e0");
                        ((MainWindow)window).SelectSettingsLbl.Foreground = (Brush)bc.ConvertFrom("#e0e0e0");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#eeeeee");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#2c2c2c");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#eeeeee");

                        ((MainWindow)window).ColorUpdateLbl.Foreground = (Brush)bc.ConvertFrom("#eeeeee");
                        ((MainWindow)window).UpdateCard.Background = (Brush)bc.ConvertFrom("#2c2c2c");

                        var palette = new PaletteHelper();

                        palette.ReplacePrimaryColor("DeepOrange");
                    }
                }

                var fileAllText = File.ReadAllLines("Settings.su");
                fileAllText[28] = "# - User interface color SacredUtils = black                       #";
                File.WriteAllLines("Settings.su", fileAllText); Close();

                Log.Info("Цветовая схема для SacredUtils была изменена на Black.");
            }
        }
    }
}
