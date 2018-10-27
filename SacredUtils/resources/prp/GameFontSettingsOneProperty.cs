using SacredUtils.resources.bin;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;

namespace SacredUtils.resources.prp
{
    public class GameFontSettingsOneProperty
    {
        public List<string> FontCollection
        {
            get
            {
                List<string> fonts = new InstalledFontCollection().Families.Select(font => font.Name).ToList();

                fonts.Remove(""); return fonts;
            }
        }

        public string SelectedFont
        {
            get
            {
                string selectedFont = "";

                string[] text = File.ReadAllLines(AppSettings.ApplicationSettings.SacredConfigurationFile, Encoding.ASCII);

                string prefix = "FONT : 1, \"";

                string line = text.FirstOrDefault(x => x.StartsWith(prefix));

                if (line != null) { selectedFont = line.Substring(prefix.Length).Split('\"')[0]; }

                return selectedFont;
            }

            set => ChangeSacredGameSettingsValue.ChangeSettingFontValue(value);
        }
    }
}
