using System.Diagnostics;

namespace SacredUtils.resources.dlg
{
    public partial class ApplicationChangeLogDialog
    {
        public ApplicationChangeLogDialog() => InitializeComponent();


        private void BaseButtonYes_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Process.Start("https://github.com/MairwunNx/SacredUtils/blob/master/CHANGELOG.md");

            BaseDialog.IsOpen = false;
        }

        private void BaseButtonNo_Click(object sender, System.Windows.RoutedEventArgs e) => BaseDialog.IsOpen = false;
    }
}
