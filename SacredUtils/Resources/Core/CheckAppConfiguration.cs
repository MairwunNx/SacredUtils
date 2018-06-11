using System;
using System.IO;
using static SacredUtils.Resources.Core.AppConstStrings;

namespace SacredUtils.Resources.Core
{
    public class CheckAppConfiguration
    {
        public void GetAvailableAppConfig()
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

            if (File.Exists(SacredSettings) && File.Exists(AppSettings))
            {
                var fileText = File.ReadAllText(AppSettings);
                
                var fileTextSacred = File.ReadAllText(SacredSettings);

                try
                {
                    if (fileText.Contains("Restore Settings.cfg if it is corrupted = true"))
                    {
                        if (!fileTextSacred.Contains("COMPAT_VIDEO") || !fileTextSacred.Contains("DEFAULT_SKILLS") ||
                            !fileTextSacred.Contains("DETAILLEVEL") || !fileTextSacred.Contains("FONTAA") ||
                            !fileTextSacred.Contains("FONTFILTER") || !fileTextSacred.Contains("FSAA_FILTER") ||
                            !fileTextSacred.Contains("FULLSCREEN") || !fileTextSacred.Contains("GFX32") ||
                            !fileTextSacred.Contains("LANGUAGE") || !fileTextSacred.Contains("MUSICVOLUME") ||
                            !fileTextSacred.Contains("PICKUPANIM") || !fileTextSacred.Contains("PICKUPAUTO") ||
                            !fileTextSacred.Contains("SFXVOLUME") || !fileTextSacred.Contains("SHOWMOVIE") ||
                            !fileTextSacred.Contains("SHOWPOTIONS") || !fileTextSacred.Contains("SHOW_ENEMYINFO") ||
                            !fileTextSacred.Contains("SOUND") || !fileTextSacred.Contains("SOUNDQUALITY") ||
                            !fileTextSacred.Contains("VOICEVOLUME") || !fileTextSacred.Contains("WARNING_LEVEL"))
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
        }
    }
}
