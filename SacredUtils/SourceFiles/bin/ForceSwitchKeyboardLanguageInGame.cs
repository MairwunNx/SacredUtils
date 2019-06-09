using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Threading;
using Ionic.Zip;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;

namespace SacredUtils.SourceFiles.bin
{
    public static class ForceSwitchKeyboardLanguageInGame
    {
        public static void RegisterApplication()
        {
            Directory.CreateDirectory("$SacredUtils\\temp");
            Logger.Log.Info("Creating temp folder for keyla switching language done!");
            File.WriteAllBytes("$SacredUtils\\temp\\hotkeyreg.reg", Properties.Resources.KeylaRegister);
            Logger.Log.Info("Creating keyla switching language data application done!");

            Process regeditProcess = Process.Start("regedit.exe", "/s $SacredUtils\\temp\\hotkeyreg.reg");
            regeditProcess?.WaitForExit();
            Logger.Log.Info("Register application in regedit for switching lang done!");
            File.Delete("$SacredUtils\\temp\\hotkeyreg.reg");
            Logger.Log.Info("Delete keyla switching language data application done!");
            CreateApplication();
        }

        private static void CheckAvailabilityProcess()
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, Settings.DelayCheckingSacredProcess)
            };

            timer.Tick += (s, e) =>
            {
                Process[] pname = Process.GetProcessesByName("Sacred");
                if (pname.Length != 0) return;

                RemoveApplication();
                timer.Stop();
            };

            timer.Start();
        }

        private static void CreateApplication()
        {
            File.WriteAllBytes("$SacredUtils\\temp\\keyla.zip", Properties.Resources.Keyla);
            Logger.Log.Info("Creating keyla switching language application archive done!");
            Directory.CreateDirectory("$SacredUtils\\temp\\keyla\\data");
            Logger.Log.Info("Creating keyla switching language application data folder done!");

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
                        Logger.Log.Error(exception.ToString);
                    }
                }
            }

            Logger.Log.Info("Creating keyla switching language application done!");
            File.Delete("$SacredUtils\\temp\\keyla.zip");
            Logger.Log.Info("Remove keyla switching language application archive done!");
            Logger.Log.Info("Runing keyla switching language application ...");
            Process.Start("$SacredUtils\\temp\\keyla\\data\\keyla.exe");
            CheckAvailabilityProcess();
        }

        private static void RemoveApplication()
        {
            foreach (Process process in Process.GetProcessesByName("keyla")) { process.Kill(); }

            Logger.Log.Info("Shutting down keyla switching language application done!");

            try { Directory.Delete("$SacredUtils\\temp", true); }
            catch (Exception e) { Logger.Log.Error(e.ToString); }
        }
    }
}
