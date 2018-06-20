using System;
using System.IO;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;

namespace SacredUtils.Resources.bin
{
    public class CheckAvailableConfigs
    {
        public void GetAvailableAppConfig()
        {
            if (!File.Exists(AppSettings))
            {
                try
                {
                    File.WriteAllBytes(AppSettings, Properties.Resources.AppSettings);
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception.ToString()); Environment.Exit(0);
                }
            }

            GetAvailableGameConfig();
        }

        public void GetAvailableGameConfig()
        {
            if (!File.Exists(SacredSettings))
            {
                try
                {
                    File.WriteAllBytes(SacredSettings, Properties.Resources.GameSettings);
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception.ToString()); Environment.Exit(0);
                }
            }

            GetGameConfigIntegrity();
        }

        public void GetGameConfigIntegrity()
        {
            if (File.Exists(SacredSettings) && File.Exists(AppSettings))
            {
                var fileText = File.ReadAllText(AppSettings);

                var fileTextSacred = File.ReadAllText(SacredSettings);

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
                                File.WriteAllBytes(SacredSettings, Properties.Resources.GameSettings);
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
