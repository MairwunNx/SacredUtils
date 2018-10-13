using SacredUtils.resources.prp;

namespace SacredUtils.resources.pgs
{
    public partial class SoundSettingsOne
    {
        public SoundSettingsOne()
        {
            InitializeComponent(); DataContext = new GameSoundSettingsOneProperty();

            AppLogger.Log.Info("Initialization components for game sound settings one done!");
        }
    }
}
