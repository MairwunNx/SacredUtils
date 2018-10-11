using SacredUtils.resources.prp;

namespace SacredUtils.resources.pgs
{
    public partial class GameFontSettingsOne
    {
        public GameFontSettingsOne()
        {
            InitializeComponent(); DataContext = new GameFontSettingsOneProperty();

            AppLogger.Log.Info("Initialization components for game font settings one done!");
        }
    }
}
