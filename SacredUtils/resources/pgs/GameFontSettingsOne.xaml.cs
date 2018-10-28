using SacredUtils.resources.prp;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.pgs
{
    public partial class GameFontSettingsOne
    {
        public GameFontSettingsOne()
        {
            InitializeComponent(); DataContext = new GameFontSettingsOneProperty();

            Log.Info("Initialization components for game font settings one done!");
        }
    }
}
