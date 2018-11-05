using SacredUtils.resources.bin;
using SacredUtils.resources.prp;
using System;
using System.Windows;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.pgs
{
    public partial class GameFontSettingsOne
    {
        public GameFontSettingsOne()
        {
            InitializeComponent(); DataContext = new GameFontSettingsOneProperty();

            if (!AppSettings.ApplicationSettings.UseCustomFontSizeValue)
            {
                Border1.Margin = new Thickness(0, 195, 0, 0);
                Border2.Margin = new Thickness(0, 246, 0, 0);
                Border3.Margin = new Thickness(0, 297, 0, 0);
                Border4.Visibility = Visibility.Collapsed;
                Border5.Margin = new Thickness(0, 348, 0, 0);
            }
            else
            {
                FontSizesTxBox.Text = AppSettings.ApplicationSettings.SacredFontSizeArray;

                FontSizesTxBox.TextChanged += (s, e) => ChangeSizeForFont();
            }

            Log.Info("Initialization components for game font settings one done!");
        }

        private void FontNameCmbBox_DropDownClosed(object sender, EventArgs e) => GC.Collect();
        
        private void ChangeSizeForFont()
        {
            AppSettings.ApplicationSettings.SacredFontSizeArray = FontSizesTxBox.Text;

            if (FontNameCmbBox.Text != "")
            {
                ChangeSacredGameSettingsValue.ChangeSettingFontValue(FontNameCmbBox.Text);
            }
        }
    }
}
