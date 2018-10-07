namespace SacredUtils.resources.dlg
{
    public partial class ApplicationChangeLogDialog
    {
        public ApplicationChangeLogDialog() => InitializeComponent();

        private void OpenChangeLog_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MairwunNx/SacredUtils/blob/master/CHANGELOG.md");

            ChangeLogDialog.IsOpen = false;
        }
    }
}
