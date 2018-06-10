using System.IO;
using System.Text;
using System.Windows.Media;
using static SacredUtils.Resources.Core.AppConstStrings;

namespace SacredUtils.Resources.Windows
{
    public partial class ComponentsWindow
    {
        public ComponentsWindow() { InitializeComponent(); LoadColorTheme(); }

        public void LoadColorTheme()
        {
            var text =  File.ReadAllLines(AppSettings, Encoding.ASCII);

            var bc = new BrushConverter();

            for (var i = 0; i < text.Length; i++)
            {
                if (text[i].Contains(AppColorValue + " = default") || text[i].Contains(AppColorValue + " = indigo") ||
                    text[i].Contains(AppColorValue + " = red") || text[i].Contains(AppColorValue + " = pink") ||
                    text[i].Contains(AppColorValue + " = purple") ||
                    text[i].Contains(AppColorValue + " = deeppurple") || text[i].Contains(AppColorValue + " = blue") ||
                    text[i].Contains(AppColorValue + " = lightblue") || text[i].Contains(AppColorValue + " = cyan") ||
                    text[i].Contains(AppColorValue + " = teal") || text[i].Contains(AppColorValue + " = green") ||
                    text[i].Contains(AppColorValue + " = lightgreen") || text[i].Contains(AppColorValue + " = lime") ||
                    text[i].Contains(AppColorValue + " = yellow") || text[i].Contains(AppColorValue + " = amber") ||
                    text[i].Contains(AppColorValue + " = orange") ||
                    text[i].Contains(AppColorValue + " = deeporange") || text[i].Contains(AppColorValue + " = brown") ||
                    text[i].Contains(AppColorValue + " = bluegrey") || text[i].Contains(AppColorValue + " = grey"))
                {
                    ComponentInstallCard.Background = (Brush)bc.ConvertFrom("#FFFFFFFF");
                    LabelColor.Foreground = (Brush)bc.ConvertFrom("#DD404040");
                }

                if (text[i].Contains(AppColorValue + " = black"))
                {
                    ComponentInstallCard.Background = (Brush)bc.ConvertFrom("#2c2c2c");
                    LabelColor.Foreground = (Brush)bc.ConvertFrom("#eeeeee");
                }
            }
        }
    }
}
