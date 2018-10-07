namespace SacredUtils.resources.dlg
{
    public partial class ApplicationChangeLogDialog
    {
        public ApplicationChangeLogDialog() => InitializeComponent();

        private void OpenChangeLog_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MairwunNx/SacredUtils/blob/master/CHANGELOG.md");

            if (System.IO.File.Exists("$SacredUtils\\temp\\updated.su"))
            {
                System.IO.File.Delete("$SacredUtils\\temp\\updated.su");
            }

            ChangeLogDialog.IsOpen = false;
        }
    }
}
