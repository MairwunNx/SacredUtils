using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using SacredUtils.SourceFiles.settings;

namespace SacredUtils.SourceFiles.bin
{
    public static class GetApplicationGlobalizerLibrary
    {
        public static void Get()
        {
            if (!ApplicationSettingsManager.Settings.EnableCheckGlobLibrary) return;

            if (!File.Exists("WPFSharp.Globalizer.dll"))
            {
                if (File.Exists("update.cmd")) { File.Delete("update.cmd"); }
                Logger.Log.Warn("WPFSharp.Globalizer.dll library file not found!");
                Create();
            }
            else
            {
                Logger.Log.Info("WPFSharp.Globalizer.dll library file was found!");

                string md5FinallyHash;

                using (MD5 md5 = MD5.Create())
                {
                    using (FileStream stream = File.OpenRead("WPFSharp.Globalizer.dll"))
                    {
                        byte[] hash = md5.ComputeHash(stream);

                        md5FinallyHash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                    }
                }

                if (md5FinallyHash == "d0bb73987001ea1207393f8e1061630f") return;

                File.WriteAllBytes("update.cmd", Properties.Resources.update);

                ProcessStartInfo info = new ProcessStartInfo
                {
                    Arguments = $"/C {ApplicationInfo.CurrentPath}\\update.cmd",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = false,
                    FileName = "update.cmd"
                };

                Process.Start(info); Environment.Exit(0);
            }
        }

        private static void Create()
        {
            try
            {
                Logger.Log.Info("Creating WPFSharp.Globalizer.dll lirary file ...");
                File.WriteAllBytes("WPFSharp.Globalizer.dll", Properties.Resources.WPFSharp_Globalizer);
                Logger.Log.Info("Creating WPFSharp.Globalizer.dll library file done!");
                Logger.Log.Info("Reloading SacredUtils configurator ...");
                Process.Start(ApplicationInfo.AppPath); Environment.Exit(0);
            }
            catch (Exception exception)
            {
                Logger.Log.Fatal("Creating WPFSharp.Globalizer.dll library done with fatal level error!");
                Logger.Log.Fatal(exception.ToString);
                Logger.Log.Info("Shutting down SacredUtils configurator ...");
                Environment.Exit(0);
            }
        }
    }
}
