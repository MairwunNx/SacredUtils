using Ionic.Zip;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Threading;
using static SacredUtils.Logger;

namespace SacredUtils.resources.bin
{
    public static class ForceSwitchKeyboardLanguageInGame
    {
        public static void RegisterApplication()
        {
            Directory.CreateDirectory("$SacredUtils\\temp");
            Log.Info("Creating temp folder for keyla switching language done!");
            File.WriteAllBytes("$SacredUtils\\temp\\hotkeyreg.reg", Properties.Resources.KeylaRegister);
            Log.Info("Creating keyla switching language data application done!");

            Process regeditProcess = Process.Start("regedit.exe", "/s $SacredUtils\\temp\\hotkeyreg.reg");
            regeditProcess?.WaitForExit();
            Log.Info("Register application in regedit for switching lang done!");
            File.Delete("$SacredUtils\\temp\\hotkeyreg.reg");
            Log.Info("Delete keyla switching language data application done!");
            CreateApplication();
        }

        private static void CheckAvailabilityProcess()
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, AppSettings.ApplicationSettings.DelayCheckingSacredProcess)
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
            Log.Info("Creating keyla switching language application archive done!");
            Directory.CreateDirectory("$SacredUtils\\temp\\keyla\\data");
            Log.Info("Creating keyla switching language application data folder done!");

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
                        Log.Error(exception.ToString);
                    }
                }
            }

            Log.Info("Creating keyla switching language application done!");
            File.Delete("$SacredUtils\\temp\\keyla.zip");
            Log.Info("Remove keyla switching language application archive done!");
            Log.Info("Runing keyla switching language application ...");
            Process.Start("$SacredUtils\\temp\\keyla\\data\\keyla.exe");
            CheckAvailabilityProcess();
        }

        private static void RemoveApplication()
        {
            foreach (Process process in Process.GetProcessesByName("keyla")) { process.Kill(); }

            Log.Info("Shutting down keyla switching language application done!");

            try { Directory.Delete("$SacredUtils\\temp", true); }
            catch (Exception e) { Log.Error(e.ToString); }
        }
    }
}
