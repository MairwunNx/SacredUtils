namespace SacredUtils.resources.pgs
{
    public partial class GameChatSettingsOne
    {
        public GameChatSettingsOne()
        {
            InitializeComponent(); GetSettings();

            AppLogger.Log.Info("Initialization components for game chat settings one done!");
        }

        private void GetSettings()
        {
            RainbowChatTglBtn.IsChecked = GameSettings.SacredGameSettings.UNIQUE_COLOR != 0;

            switch (GameSettings.SacredGameSettings.LANGUAGE)
            {
                case "RU": UiLanguageCmbBox.SelectedIndex = 0; break;
                case "US": UiLanguageCmbBox.SelectedIndex = 1; break;
                case "DE": UiLanguageCmbBox.SelectedIndex = 2; break;
                case "SP": UiLanguageCmbBox.SelectedIndex = 3; break;
                case "FR": UiLanguageCmbBox.SelectedIndex = 4; break;
            }

            CountChatLinesSlider.Value = GameSettings.SacredGameSettings.CHAT_LINES;
            ChatTextDelaySlider.Value = GameSettings.SacredGameSettings.CHAT_DELAY;
            ChatTransparentSlider.Value = GameSettings.SacredGameSettings.CHAT_ALPHA;

            EventSubscribe();
        }

        private void EventSubscribe()
        {
            // todo: добавить возможность изменять значения настроек.
        }
    }
}
