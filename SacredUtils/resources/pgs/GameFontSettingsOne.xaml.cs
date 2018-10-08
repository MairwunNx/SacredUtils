using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;

namespace SacredUtils.resources.pgs
{
    public partial class GameFontSettingsOne
    {
        public GameFontSettingsOne()
        {
            InitializeComponent(); GetSettings();

            AppLogger.Log.Info("Initialization components for game font settings one done!");
        }

        private void GetSettings()
        {
            List<string> fonts = new InstalledFontCollection().Families.Select(font => font.Name).ToList();

            FontNameCmbBox.ItemsSource = fonts; fonts.Remove("");

            var text = File.ReadAllLines("Settings.cfg", Encoding.ASCII);

            for (var i = 0; i < text.Length; i++)
            {
                if (text[i].Contains("FONT : 1, "))
                {
                    var tempdata0 = text[i].Substring(text[i].IndexOf("\"", StringComparison.Ordinal) + 1);

                    if (tempdata0 == text[i].Substring(text[i].IndexOf("\"", StringComparison.Ordinal) + 1))
                    {
                        var tempdata1 = tempdata0.Remove(tempdata0.LastIndexOf("\"", StringComparison.Ordinal));

                        FontNameCmbBox.SelectedItem = tempdata1;
                    }
                }
            }
        }

        private void EventSubscribe()
        {
            // todo: добавить возможность изменять значения настроек.
        }
    }
}
