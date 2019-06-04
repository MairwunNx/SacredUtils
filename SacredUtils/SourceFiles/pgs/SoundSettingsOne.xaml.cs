using SacredUtils.resources.prp;
using static SacredUtils.SourceFiles.Logger;

namespace SacredUtils.resources.pgs
{
    public partial class SoundSettingsOne
    {
        public SoundSettingsOne()
        {
            InitializeComponent(); DataContext = new GameSoundSettingsOneProperty();

            Log.Info("Initialization components for game sound settings one done!");
        }
    }
}
