using System.Windows;
using System.Windows.Forms;
using Clipboard = System.Windows.Clipboard;

namespace SacredUtils.resources.dlg
{
    public partial class ApplicationConvertHtmlToSacred
    {
        public ApplicationConvertHtmlToSacred() => InitializeComponent();
        
        private void CopyNickBtn_Click(object sender, RoutedEventArgs e) => Clipboard.SetText(NickTextBox.Text);

        private void SelectColorBtn_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                string hexColor = $"{colorDialog.Color.R:x2}{colorDialog.Color.G:x2}{colorDialog.Color.B:x2}";

                string sacredColor = $"\\cff{hexColor}";

                NickTextBox.Text = NickTextBox.Text.Insert(NickTextBox.SelectionStart, sacredColor);
                NickTextBox.SelectionStart = NickTextBox.SelectionStart + sacredColor.Length;
            }
        }
    }
}
