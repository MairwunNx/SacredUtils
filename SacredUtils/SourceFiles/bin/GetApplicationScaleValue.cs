using System.Windows.Media;
using SacredUtils.SourceFiles.settings;

namespace SacredUtils.SourceFiles.bin
{
    public static class GetApplicationScaleValue
    {
        public static void Get()
        {
            // MairwunNx.ScaleLoveToIsabel = infinity * infinity;
            MainWindow.MainWindowInstance.Height = 720 * ApplicationSettingsManager.Settings.ApplicationGuiScale;
            MainWindow.MainWindowInstance.Width = 1086 * ApplicationSettingsManager.Settings.ApplicationGuiScale;
            MainWindow.MainWindowInstance.BaseCard.LayoutTransform =
                new ScaleTransform(ApplicationSettingsManager.Settings.ApplicationGuiScale, ApplicationSettingsManager.Settings.ApplicationGuiScale);

            Logger.Log.Info(
                $"SacredUtils application starting with ({ApplicationSettingsManager.Settings.ApplicationGuiScale}) gui scale!");
        }
    }
}
