using System.Diagnostics;

namespace SacredUtils.resources.dlg
{
    public partial class ApplicationPageSelectDialog
    {
        public ApplicationPageSelectDialog()
        {
            InitializeComponent(); EventSubscribe();
        }

        private void EventSubscribe()
        {
            GmailButton.Click += (s, e) => OpenLink("mailto://MairwunNx@gmail.com");
            TelegramButton.Click += (s, e) => OpenLink("tg://resolve?domain=MairwunNx");
            VkontakteButton.Click += (s, e) => OpenLink("https://vk.com/id471464980");
        }

        private void OpenLink(string link)
        {
            Process.Start(link);

            if (AppSettings.ApplicationSettings.ClosePageDialogAfterSelect)
            {
                BaseDialog.IsOpen = false;
            }
        }
    }
}
