using System.Diagnostics;

namespace SacredUtils.resources.dlg
{
    public partial class ApplicationDonateSelectDialog
    {
        public ApplicationDonateSelectDialog()
        {
            InitializeComponent(); EventSubscribe();
        }

        private void EventSubscribe()
        {
            QiwiButton.Click += (s, e) => OpenLink("https://qiwi.me/mairwunnx");
            YandexButton.Click += (s, e) => OpenLink("https://money.yandex.ru/to/410015993365458");
        }

        private void OpenLink(string link)
        {
            Process.Start(link); AppLogger.Log.Info($"{link} link was opened by user");

            if (AppSettings.ApplicationSettings.CloseDonateDialogAfterSelect)
            {
                DonateSelectDialog.IsOpen = false;
            }
        }
    }
}
