using System;
using System.ServiceModel.Channels;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using SacredUtils.resources.bin;

namespace SacredUtils.resources.pgs
{
    public interface IApplicationSettings
    {
        string ColorTheme { get; }
    }

    
    // ReSharper disable once InconsistentNaming
    public partial class application_settings_one
    {
        public application_settings_one()
        {
            InitializeComponent(); GetSettings();
        }

        public void CheckKey()
        {
            if (Keyboard.IsKeyDown(Key.F5))
            {
                GetSettings();
            }
        }

        public void GetSettings()
        {
            UiLanguageCmbBox.SelectedIndex = ApplicationInfo.Lang == "ru" ? 0 : 1;
        }
    }
}
