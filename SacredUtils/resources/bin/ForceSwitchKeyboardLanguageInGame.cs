using Ionic.Zip;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SacredUtils.resources.bin
{
    public static class ForceSwitchKeyboardLanguageInGame
    {
        public static void RegisterApplication()
        {
            Directory.CreateDirectory("$SacredUtils\\temp");

            AppLogger.Log.Info("Creating temp folder for keyla switching language done!");

            File.WriteAllBytes("$SacredUtils\\temp\\hotkeyreg.reg", Properties.Resources.HotKeyReg);

            AppLogger.Log.Info("Creating keyla switching language data application done!");

            Process regeditProcess = Process.Start("regedit.exe", "/s $SacredUtils\\temp\\hotkeyreg.reg");
            regeditProcess?.WaitForExit();

            AppLogger.Log.Info("Register application in regedit for switching lang done!");

            File.Delete("$SacredUtils\\temp\\hotkeyreg.reg");

            AppLogger.Log.Info("Delete keyla switching language data application done!");

            CreateApplication();
        }

        private static void CheckAvailabilityProcess()
        {
            DispatcherTimer timer = new DispatcherTimer();

            timer.Interval = new TimeSpan(0, 0, AppSettings.ApplicationSettings.DelayCheckingSacredProcess);

            timer.Tick += (s, e) =>
            {
                Process[] pname = Process.GetProcessesByName("Sacred");

                if (pname.Length == 0) { RemoveApplication(); }
            };

            timer.Start();
        }

        private static void CreateApplication()
        {
            try
            {
                File.WriteAllBytes("$SacredUtils\\temp\\keyla.zip", Properties.Resources.keyla);

                AppLogger.Log.Info("Creating keyla switching language application archive done!");

                Directory.CreateDirectory("$SacredUtils\\temp\\keyla\\data");

                AppLogger.Log.Info("Creating keyla switching language application data folder done!");

                using (ZipFile zip = ZipFile.Read("$SacredUtils\\temp\\keyla.zip"))
                {
                    foreach (ZipEntry e in zip)
                    {
                        try
                        {
                            e.Extract("$SacredUtils\\temp\\keyla\\data", ExtractExistingFileAction.OverwriteSilently);
                        }
                        catch (Exception exception)
                        {
                            AppLogger.Log.Error(exception.ToString);
                        }
                    }

                    zip.Dispose();
                }

                AppLogger.Log.Info("Creating keyla switching language application done!");

                File.Delete("$SacredUtils\\temp\\keyla.zip");

                AppLogger.Log.Info("Remove keyla switching language application archive done!");

                AppLogger.Log.Info("Runing keyla switching language application ...");

                Process.Start("$SacredUtils\\temp\\keyla\\data\\keyla.exe");

                CheckAvailabilityProcess();
            }
            catch (Exception e)
            {
                AppLogger.Log.Error(e.ToString);
            }
        }

        private static void RemoveApplication()
        {
            foreach (Process process in Process.GetProcessesByName("keyla")) { process.Kill(); }
            foreach (Process process in Process.GetProcessesByName("ctfmon")) { process.Kill(); }

            AppLogger.Log.Info("Shutting down keyla switching language application done!");

            try
            {
                Directory.Delete("$SacredUtils\\temp", true);
            }
            catch (Exception e)
            {
                AppLogger.Log.Error(e.ToString);
            }
        }
    }
}
