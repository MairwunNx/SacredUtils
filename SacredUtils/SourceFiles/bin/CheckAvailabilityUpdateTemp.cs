using System.IO;
using SacredUtils.SourceFiles.settings;

namespace SacredUtils.SourceFiles.bin
{
    public static class CheckAvailabilityUpdateTemp
    {
        public static void Get()
        {
            if (!ApplicationSettingsManager.Settings.EnableRemoveApplicationTempContent) return;

            string[] files =
            {
                "mnxupdater.exe",
                "_newVersionSacredUtilsTemp.exe",
                "updater-crash-report.log"
            };

            foreach (string file in files)
            {
                if (File.Exists(file)) File.Delete(file);
            }
        }
    }
}
