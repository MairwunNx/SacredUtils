using System;
using System.IO;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;

namespace SacredUtils.Resources.bin
{
    public class CheckAvailableConfigs
    {
        public void GetAvailableAppConfig()
        {
            System.Random rnds = new System.Random();

            int rndIntf = rnds.Next(240618, 1498640135);
            
            string pathf = $"{AppBackupFolder}\\config_bck_id_{rndIntf}";

            if (!File.Exists(AppSettingsFile))
            {
                try
                {
                    File.WriteAllBytes(AppSettingsFile, Properties.Resources.AppSettings);
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception.ToString()); Environment.Exit(0);
                }
            }
            else
            {
                System.Random rnd = new System.Random();

                int rndInt = rnd.Next(240618, 1498640135);

                Directory.CreateDirectory(pathf);

                File.Copy(AppSettingsFile, $"{pathf}\\config_app_id_{rndInt}.dat");
            }

            GetAvailableGameConfig(pathf);
        }

        public void GetAvailableGameConfig(string pathf)
        {
            if (!File.Exists(SacredSettingsFile))
            {
                try
                {
                    File.WriteAllBytes(SacredSettingsFile, Properties.Resources.GameSettings);
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception.ToString()); Environment.Exit(0);
                }
            }
            else
            {
                System.Random rnd = new System.Random();

                int rndInt = rnd.Next(240618, 1498640135);

                Directory.CreateDirectory(pathf);

                File.Copy(SacredSettingsFile, $"{pathf}\\config_game_id_{rndInt}.dat");
            }

            GetGameConfigIntegrity();
        }

        public void GetGameConfigIntegrity()
        {
            if (File.Exists(SacredSettingsFile) && File.Exists(AppSettingsFile))
            {
                var fileText = File.ReadAllText(AppSettingsFile);

                var fileTextSacred = File.ReadAllText(SacredSettingsFile);

                try
                {
                    if (fileText.Contains("Restore Settings.cfg if it is corrupted = true"))
                    {
                        if (!fileTextSacred.Contains("AUTOSAVE") || !fileTextSacred.Contains("AUTOTRACKENEMY") ||
                            !fileTextSacred.Contains("CHAT_ALPHA") || !fileTextSacred.Contains("FSAA_FILTER") ||
                            !fileTextSacred.Contains("FULLSCREEN") || !fileTextSacred.Contains("GFX32") ||
                            !fileTextSacred.Contains("SHOWMOVIE") || !fileTextSacred.Contains("SOUND"))
                        {
                            try
                            {
                                File.WriteAllBytes(SacredSettingsFile, Properties.Resources.GameSettings);
                            }
                            catch (Exception exception)
                            {
                                Log.Error(exception.ToString());
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    Log.Error(exception.ToString());
                }
            }
        }
    }
}
