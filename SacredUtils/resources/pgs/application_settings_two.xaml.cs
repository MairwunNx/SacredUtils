using SacredUtils.resources.bin.get;
using SacredUtils.resources.bin.open;

namespace SacredUtils.resources.pgs
{
    public interface IApplicationSettings01
    {
        string SacredStartArgs { get; set; }
        string ColorTheme { get; set; }
        string SacredUtilsGuiScale { get; set; }
    }

    // ReSharper disable once InconsistentNaming
    public partial class application_settings_two
    {
        int _nums = 1;

        public application_settings_two()
        {
            GetLoggerConfig.Log.Info("Gettings settings for application settings two ...");

            InitializeComponent(); GetSettings(); EventSubscribe();

            GetLoggerConfig.Log.Info("Gettings settings for application settings two done!");
        }

        public void EventSubscribe()
        {
            if (_nums == 1)
            {
                GitHubBtn.Click += (s, e) => OpenBrowserLink.Open("https://github.com/MairwunNx/SacredUtils");
                DonateBtn.Click += (s, e) => OpenBrowserLink.Open("https://money.yandex.ru/to/410015993365458");
                CreatorBtn.Click += (s, e) => OpenBrowserLink.Open("https://t-do.ru/mairwunnx");
                FeedbackBtn.Click += (s, e) => OpenBrowserLink.Open("https://docs.google.com/forms/d/1Hx4EcS7VopBFG4bxq-zdsGUmqqD2nKy2NiwzRTiQMgA/edit?usp=sharing");
                AboutBtn.Click += (s, e) => OpenAppDialog.Open("About");

                ToOnePageBtn.Click += (s, e) => OpenNewPage.Open("AppSettingsOne");

                _nums = 2;
            }
        }

        public void GetSettings()
        {
            
        }
    }
}
