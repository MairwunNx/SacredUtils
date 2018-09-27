using Config.Net;
using SacredUtils.resources.bin.logger;
using SacredUtils.resources.bin.open;

namespace SacredUtils.resources.pgs
{
    public interface IApplicationSettings01
    {
        bool CheckAutoUpdate { get; set; }
        bool CheckAutoAlphaUpdate { get; set; }
        bool MakeAutoBackupConfigs { get; set; }
        bool AcceptLicense { get; set; }
    }

    // ReSharper disable once InconsistentNaming
    public partial class application_settings_two
    {
        int _nums = 1;

        public application_settings_two()
        {
            InitializeComponent(); GetSettings();

            Logger.Log.Info("Initialization components for application settings two done!");
        }

        public void GetSettings()
        {
            IApplicationSettings01 applicationSettings = new ConfigurationBuilder<IApplicationSettings01>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            UpdateCheckTglBtn.IsChecked = applicationSettings.CheckAutoUpdate;

            UpdateAlphaCheckTglBtn.IsChecked = applicationSettings.CheckAutoAlphaUpdate;

            MakeBackupTglBtn.IsChecked = applicationSettings.MakeAutoBackupConfigs;

            LicenseTglBtn.IsChecked = applicationSettings.AcceptLicense;

            if (_nums == 1) { EventSubscribe(); _nums = 2; }
        }

        private void EventSubscribe()
        {
            UpdateCheckTglBtn.Click += (s, e) => ChangeUpdateCheck(false);
            UpdateAlphaCheckTglBtn.Click += (s, e) => ChangeUpdateCheck(true);
            MakeBackupTglBtn.Click += (s, e) => ChangeBackupMake();
            LicenseTglBtn.Click += (s, e) => ChangeLicenseAgreement();

            GitHubBtn.Click += (s, e) => BrowserLink.Open("https://github.com/MairwunNx/SacredUtils");
            DonateBtn.Click += (s, e) => BrowserLink.Open("https://money.yandex.ru/to/410015993365458");
            CreatorBtn.Click += (s, e) => BrowserLink.Open("https://t-do.ru/mairwunnx");
            FeedbackBtn.Click += (s, e) => BrowserLink.Open("https://docs.google.com/forms/d/1Hx4EcS7VopBFG4bxq-zdsGUmqqD2nKy2NiwzRTiQMgA/edit?usp=sharing");
            AboutBtn.Click += (s, e) => ApplicationDialog.Open("About");

            ToOnePageBtn.Click += (s, e) => SettingsPage.Open("AppSettingsOne");
        }

        private void ChangeUpdateCheck(bool alphaUpdate)
        {
            IApplicationSettings01 applicationSettings = new ConfigurationBuilder<IApplicationSettings01>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            if (!alphaUpdate)
            {
                applicationSettings.CheckAutoUpdate = UpdateCheckTglBtn.IsChecked == true;

                Logger.Log.Info($"Checking for updates set to {applicationSettings.CheckAutoUpdate} by user");
            }
            else
            {
                applicationSettings.CheckAutoAlphaUpdate = UpdateAlphaCheckTglBtn.IsChecked == true;

                Logger.Log.Info($"Checking for alpha updates set to {applicationSettings.CheckAutoAlphaUpdate} by user");
            }
        }

        private void ChangeBackupMake()
        {
            IApplicationSettings01 applicationSettings = new ConfigurationBuilder<IApplicationSettings01>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            applicationSettings.MakeAutoBackupConfigs = MakeBackupTglBtn.IsChecked == true;

            Logger.Log.Info($"Backup making settings set to {applicationSettings.MakeAutoBackupConfigs} by user");
        }

        private void ChangeLicenseAgreement()
        {
            IApplicationSettings01 applicationSettings = new ConfigurationBuilder<IApplicationSettings01>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();

            applicationSettings.AcceptLicense = LicenseTglBtn.IsChecked == true;

            Logger.Log.Info($"Accept license set to {applicationSettings.AcceptLicense} by user");
        }
    }
}
