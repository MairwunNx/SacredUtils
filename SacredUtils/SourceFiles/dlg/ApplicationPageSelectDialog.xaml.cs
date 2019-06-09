using System.Diagnostics;
using SacredUtils.SourceFiles.settings;

namespace SacredUtils.SourceFiles.dlg
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

            if (ApplicationSettingsManager.Settings.ClosePageDialogAfterSelect)
            {
                BaseDialog.IsOpen = false;
            }
        }
    }
}
