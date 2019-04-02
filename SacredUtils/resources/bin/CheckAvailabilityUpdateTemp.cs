using System.IO;

namespace SacredUtils.resources.bin
{
    public static class CheckAvailabilityUpdateTemp
    {
        public static void Get()
        {
            if (AppSettings.ApplicationSettings.RemoveApplicationTempContent) return;

            string[] files = { "mnxupdater.exe", "_newVersionSacredUtilsTemp.exe", "updater-crash-report.log" };

            foreach (string file in files)
            {
                if (File.Exists(file)) File.Delete(file);
            }
        }
    }
}
