using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace SacredUtils.resources.dlg
{
    public partial class ApplicationFontSizesDialog
    {
        public ApplicationFontSizesDialog()
        {
            InitializeComponent(); EventSubscribe();
        }

        private void EventSubscribe()
        {
            BaseSizeCategoryComboBox.SelectionChanged += LoadSize;
            BaseSizeValueTextBox.TextChanged += ChangeSize;
            BaseSizeValueTextBox.PreviewTextInput += ValidateValue;

            BaseSizeValueTextBox.IsEnabled = false;
        }

        private void LoadSize(object sender, SelectionChangedEventArgs e)
        {
            if (BaseSizeValueTextBox.IsEnabled == false) { BaseSizeValueTextBox.IsEnabled = true; }

            ComboBox comboBox = sender as ComboBox;

            string[] sizes = AppSettings.ApplicationSettings.SacredFontSizeArray.Split('|');

            if (comboBox != null) { BaseSizeValueTextBox.Text = sizes[comboBox.SelectedIndex]; }
        }

        private void ChangeSize(object sender, TextChangedEventArgs e)
        {
            string[] sizes = AppSettings.ApplicationSettings.SacredFontSizeArray.Split('|');

            BaseSizeValueTextBox.Text = BaseSizeValueTextBox.Text.Replace(" ", "");

            sizes[BaseSizeCategoryComboBox.SelectedIndex] = BaseSizeValueTextBox.Text;

            AppSettings.ApplicationSettings.SacredFontSizeArray = $"{sizes[0]}|{sizes[1]}|{sizes[2]}|{sizes[3]}|{sizes[4]}|{sizes[5]}|{sizes[6]}";

            MainWindow.FontStgOne.FontSizesTxBox.Text = AppSettings.ApplicationSettings.SacredFontSizeArray;
        }

        private void ValidateValue(object sender, TextCompositionEventArgs e) => e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
    }
}
