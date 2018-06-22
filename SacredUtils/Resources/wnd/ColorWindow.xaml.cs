using MaterialDesignThemes.Wpf;
using SacredUtils.Resources.bin;
using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;

namespace SacredUtils.Resources.wnd
{
    public partial class ColorWindow
    {
        public ColorWindow()
        {
            InitializeComponent(); LoadColorFromConfig();
            DataContext = new BindingLanguageStrings(); 
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) { Close(); } 
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Close(); 
        }

        private void Card_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var unused = sender as Card; if (ColorCrd != null) { e.Handled = true;}
        }

        private void LoadColorFromConfig()
        {
            var text = File.ReadAllLines(AppSettingsFile, Encoding.ASCII);

            var bc = new BrushConverter();

            for (var i = 0; i < text.Length; i++)
            {
                if (text[i].Contains(AppColorValue + " = default") || text[i].Contains(AppColorValue + " = indigo"))
                {
                    ChangeColorIndigoToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = red"))
                {
                    ChangeColorRedToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = pink"))
                {
                    ChangeColorPinkToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = purple"))
                {
                    ChangeColorPurpleToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = deeppurple"))
                {
                    ChangeColorDeppPurpleToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = blue"))
                {
                    ChangeColorBlueToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = lightblue"))
                {
                    ChangeColorLightBlueToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = cyan"))
                {
                    ChangeColorCyanToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = teal"))
                {
                    ChangeColorTealToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = green"))
                {
                    ChangeColorGreenToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = lightgreen"))
                {
                    ChangeColorLightGreenToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = lime"))
                {
                    ChangeColorLimeToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = yellow"))
                {
                    ChangeColorYellowToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = amber"))
                {
                    ChangeColorAmberToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = orange"))
                {
                    ChangeColorOrangeToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = deeporange"))
                {
                    ChangeColorDeepOrangeToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = brown"))
                {
                    ChangeColorBrownToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = bluegrey"))
                {
                    ChangeColorBlueGreyToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = grey"))
                {
                    ChangeColorGrayToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = black"))
                {
                    ChangeColorBlackToggleBtn.IsChecked = true;

                    ColorCrd.Background = (Brush)bc.ConvertFrom("#2c2c2c");
                    ColorLabel.Foreground = (Brush)bc.ConvertFrom("#eeeeee");
                }
            }
        }

        public void ChangeColor(string a, string b, string c, string d, string e, string f)
        {
            try
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        var bc = new BrushConverter();

                        ((MainWindow)window).ToolSpaceElementColor.Foreground = (Brush)bc.ConvertFrom(a);

                        ((MainWindow)window).StackPanelPrimary.Background = (Brush)bc.ConvertFrom(b);
                        ((MainWindow)window).StackPanelMiddle.Background = (Brush)bc.ConvertFrom(c);
                        ((MainWindow)window).StackPanelLight.Background = (Brush)bc.ConvertFrom(d);

                        ((MainWindow)window).FlexibleSpaceElementColor.Foreground = (Brush)bc.ConvertFrom(f);

                        ((MainWindow)window).CardBackgroundColor.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DD7E7E7E");

                        ((MainWindow)window).CardCaptionsColor.Foreground = (Brush)bc.ConvertFrom("#DD404040");

                        ((MainWindow)window).SettingsNameColor.Foreground = (Brush)bc.ConvertFrom("#DD323232");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#FF000000");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#FF000000");

                        var palette = new PaletteHelper(); palette.ReplacePrimaryColor(e);
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Error(exception.ToString());
            }
        }

        private void ChangeColorRedToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorRedToggleBtn.IsChecked == true)
            {
                ChangeColor("#e57373", "#d32f2f", "#f44336", "#ffcdd2", "Red", "#FFFFFFFF");

                try
                { 
                    var fileAllText00 = File.ReadAllLines(AppSettingsFile);
                    fileAllText00[28] = "# - User interface color SacredUtils = red                         #";
                    File.WriteAllLines(AppSettingsFile, fileAllText00); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }

        private void ChangeColorPinkToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorPinkToggleBtn.IsChecked == true)
            {
                ChangeColor("#f06292", "#c2185b", "#e91e63", "#f8bbd0", "Pink", "#FFFFFFFF");

                try
                {
                    var fileAllText01 = File.ReadAllLines(AppSettingsFile);
                    fileAllText01[28] = "# - User interface color SacredUtils = pink                        #";
                    File.WriteAllLines(AppSettingsFile, fileAllText01); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }

        }

        private void ChangeColorPurpleToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorPurpleToggleBtn.IsChecked == true)
            {
                ChangeColor("#ba68c8", "#7b1fa2", "#9c27b0", "#e1bee7", "Purple", "#FFFFFFFF");

                try
                {
                    var fileAllText02 = File.ReadAllLines(AppSettingsFile);
                    fileAllText02[28] = "# - User interface color SacredUtils = purple                      #";
                    File.WriteAllLines(AppSettingsFile, fileAllText02); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }

        private void ChengeColorDeppPurpleToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorDeppPurpleToggleBtn.IsChecked == true)
            {
                ChangeColor("#9575cd", "#512da8", "#673ab7", "#d1c4e9", "DeepPurple", "#FFFFFFFF");

                try
                {
                    var fileAllText03 = File.ReadAllLines(AppSettingsFile);
                    fileAllText03[28] = "# - User interface color SacredUtils = deeppurple                  #";
                    File.WriteAllLines(AppSettingsFile, fileAllText03); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }

        private void ChangeColorIndigoToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorIndigoToggleBtn.IsChecked == true)
            {
                ChangeColor("#7986cb", "#303f9f", "#3f51b5", "#c5cae9", "Indigo", "#FFFFFFFF");

                try
                {
                    var fileAllText04 = File.ReadAllLines(AppSettingsFile);
                    fileAllText04[28] = "# - User interface color SacredUtils = indigo                      #";
                    File.WriteAllLines(AppSettingsFile, fileAllText04); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }

        private void ChangeColorBlueToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorBlueToggleBtn.IsChecked == true)
            {
                ChangeColor("#64b5f6", "#1976d2", "#2196f3", "#bbdefb", "Blue", "#FFFFFFFF");

                try
                {
                    var fileAllText05 = File.ReadAllLines(AppSettingsFile);
                    fileAllText05[28] = "# - User interface color SacredUtils = blue                        #";
                    File.WriteAllLines(AppSettingsFile, fileAllText05); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }

        private void ChangeColorLightBlueToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorLightBlueToggleBtn.IsChecked == true)
            {
                ChangeColor("#4fc3f7", "#0288d1", "#03a9f4", "#b3e5fc", "LightBlue", "#000000");

                try
                {
                    var fileAllText06 = File.ReadAllLines(AppSettingsFile);
                    fileAllText06[28] = "# - User interface color SacredUtils = lightblue                   #";
                    File.WriteAllLines(AppSettingsFile, fileAllText06); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }

        private void ChangeColorCyanToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorCyanToggleBtn.IsChecked == true)
            {
                ChangeColor("#4dd0e1", "#0097a7", "#00bcd4", "#b2ebf2", "Cyan", "#000000");

                try
                {
                    var fileAllText07 = File.ReadAllLines(AppSettingsFile);
                    fileAllText07[28] = "# - User interface color SacredUtils = cyan                        #";
                    File.WriteAllLines(AppSettingsFile, fileAllText07); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }

        private void ChangeColorTealToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorTealToggleBtn.IsChecked == true)
            {
                ChangeColor("#4db6ac", "#00796b", "#009688", "#b2dfdb", "Teal", "#ffffff");

                try
                {
                    var fileAllText08 = File.ReadAllLines(AppSettingsFile);
                    fileAllText08[28] = "# - User interface color SacredUtils = teal                        #";
                    File.WriteAllLines(AppSettingsFile, fileAllText08); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }

        private void ChangeColorGreenToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorGreenToggleBtn.IsChecked == true)
            {
                ChangeColor("#81c784", "#388e3c", "#4caf50", "#c8e6c9", "Green", "#ffffff");

                try
                {
                    var fileAllText09 = File.ReadAllLines(AppSettingsFile);
                    fileAllText09[28] = "# - User interface color SacredUtils = green                       #";
                    File.WriteAllLines(AppSettingsFile, fileAllText09); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }

        private void ChangeColorLightGreenToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorLightGreenToggleBtn.IsChecked == true)
            {
                ChangeColor("#aed581", "#689f38", "#8bc34a", "#dcedc8", "LightGreen", "#000000");

                try
                {
                    var fileAllText10 = File.ReadAllLines(AppSettingsFile);
                    fileAllText10[28] = "# - User interface color SacredUtils = lightgreen                  #";
                    File.WriteAllLines(AppSettingsFile, fileAllText10); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }

        private void ChangeColorLimeToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorLimeToggleBtn.IsChecked == true)
            {
                ChangeColor("#dce775", "#afb42b", "#cddc39", "#f0f4c3", "Lime", "#000000");

                try
                {
                    var fileAllText11 = File.ReadAllLines(AppSettingsFile);
                    fileAllText11[28] = "# - User interface color SacredUtils = lime                        #";
                    File.WriteAllLines(AppSettingsFile, fileAllText11); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }

        private void ChangeColorYellowToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorYellowToggleBtn.IsChecked == true)
            {
                ChangeColor("#fff176", "#fbc02d", "#ffeb3b", "#fff9c4", "Yellow", "#000000");

                try
                {
                    var fileAllText12 = File.ReadAllLines(AppSettingsFile);
                    fileAllText12[28] = "# - User interface color SacredUtils = yellow                      #";
                    File.WriteAllLines(AppSettingsFile, fileAllText12); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }

        private void ChangeColorAmberToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorAmberToggleBtn.IsChecked == true)
            {
                ChangeColor("#ffd54f", "#ffa000", "#ffc107", "#ffecb3", "Amber", "#000000");

                try
                {
                    var fileAllText13 = File.ReadAllLines(AppSettingsFile);
                    fileAllText13[28] = "# - User interface color SacredUtils = amber                       #";
                    File.WriteAllLines(AppSettingsFile, fileAllText13); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }

        private void ChangeColorOrangeToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorOrangeToggleBtn.IsChecked == true)
            {
                ChangeColor("#ffb74d", "#f57c00", "#ff9800", "#ffe0b2", "Orange", "#000000");

                try
                {
                    var fileAllText14 = File.ReadAllLines(AppSettingsFile);
                    fileAllText14[28] = "# - User interface color SacredUtils = orange                      #";
                    File.WriteAllLines(AppSettingsFile, fileAllText14); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }

        private void ChangeColorDeepOrangeToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorDeepOrangeToggleBtn.IsChecked == true)
            {
                ChangeColor("#ff8a65", "#e64a19", "#ff5722", "#ffccbc", "DeepOrange", "#000000");

                try
                {
                    var fileAllText15 = File.ReadAllLines(AppSettingsFile);
                    fileAllText15[28] = "# - User interface color SacredUtils = deeporange                  #";
                    File.WriteAllLines(AppSettingsFile, fileAllText15); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }

        private void ChangeColorBrownToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorBrownToggleBtn.IsChecked == true)
            {
                ChangeColor("#a1887f", "#5d4037", "#795548", "#d7ccc8", "Brown", "#ffffff");

                try
                {
                    var fileAllText16 = File.ReadAllLines(AppSettingsFile);
                    fileAllText16[28] = "# - User interface color SacredUtils = brown                       #";
                    File.WriteAllLines(AppSettingsFile, fileAllText16); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }

        private void ChangeColorGrayToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorGrayToggleBtn.IsChecked == true)
            {
                ChangeColor("#e0e0e0", "#616161", "#9e9e9e", "#f5f5f5", "Grey", "#000000");

                try
                {
                    var fileAllText17 = File.ReadAllLines(AppSettingsFile);
                    fileAllText17[28] = "# - User interface color SacredUtils = grey                        #";
                    File.WriteAllLines(AppSettingsFile, fileAllText17); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }

        private void ChangeColorBlueGreyToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorBlueGreyToggleBtn.IsChecked == true)
            {
                ChangeColor("#90a4ae", "#455a64", "#607d8b", "#cfd8dc", "BlueGrey", "#ffffff");

                try
                {
                    var fileAllText18 = File.ReadAllLines(AppSettingsFile);
                    fileAllText18[28] = "# - User interface color SacredUtils = bluegrey                    #";
                    File.WriteAllLines(AppSettingsFile, fileAllText18); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }

        private void ChangeColorBlackToggleBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ChangeColorBlackToggleBtn.IsChecked == true)
            {
                ChangeColor("#484848", "#000000", "#212121", "#484848", "DeepOrange", "#ffffff");

                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        BrushConverter bc = new BrushConverter();

                        ((MainWindow)window).CardBackgroundColor.Background = (Brush)bc.ConvertFrom("#2c2c2c");

                        ((MainWindow)window).NotSelectedLbl.Foreground = (Brush)bc.ConvertFrom("#DDCBCBCB");

                        ((MainWindow)window).SettingsNameColor.Foreground = (Brush)bc.ConvertFrom("#eeeeee");

                        ((MainWindow)window).CardCaptionsColor.Foreground = (Brush)bc.ConvertFrom("#e0e0e0");

                        ((MainWindow)window).ColorCombobox.Foreground = (Brush)bc.ConvertFrom("#eeeeee");
                        ((MainWindow)window).ColorCombobox.Background = (Brush)bc.ConvertFrom("#2c2c2c");

                        ((MainWindow)window).ColorTxBox.Foreground = (Brush)bc.ConvertFrom("#eeeeee");
                    }
                }

                try
                {
                    var fileAllText18 = File.ReadAllLines(AppSettingsFile);
                    fileAllText18[28] = "# - User interface color SacredUtils = black                       #";
                    File.WriteAllLines(AppSettingsFile, fileAllText18); Close();
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }
    }
}