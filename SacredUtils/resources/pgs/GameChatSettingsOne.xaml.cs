namespace SacredUtils.resources.pgs
{
    public partial class GameChatSettingsOne
    {
        public GameChatSettingsOne()
        {
            InitializeComponent(); DataContext = new GameSettings();

            AppLogger.Log.Info("Initialization components for game chat settings one done!");
        }
    }
}
