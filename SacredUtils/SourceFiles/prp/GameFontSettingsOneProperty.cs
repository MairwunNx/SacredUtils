using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using SacredUtils.SourceFiles.bin;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;

namespace SacredUtils.SourceFiles.prp
{
    public class GameFontSettingsOneProperty
    {
        public IEnumerable<string> FontCollection
        {
            get
            {
                var fonts = new InstalledFontCollection().Families.Select(
                    font => font.Name
                ).ToList();
                fonts.Remove("");
                return fonts;
            }
        }

        public string SelectedFont
        {
            get
            {
                string selectedFont = "";
                string[] text = File.ReadAllLines(Settings.SacredConfigurationFile, Encoding.ASCII);
                string prefix = "FONT : 1, \"";
                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null)
                {
                    selectedFont = line.Substring(prefix.Length).Split('\"')[0];
                }

                return selectedFont;
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingFontValue(value);
        }
    }
}
