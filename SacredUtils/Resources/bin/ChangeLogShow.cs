using System;
using System.IO;
using System.Text;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;
using static SacredUtils.Resources.bin.LanguageConstsStrings;

namespace SacredUtils.Resources.bin
{
    public class ChangeLogShow
    {
        public void CheckLaunchedVersion()
        {
            while (true)
            {
                if (!UpdateProcess)
                {
                    if (!File.Exists(AppVersionFile))
                    {
                        File.WriteAllBytes(AppVersionFile, Properties.Resources.AppVersion);

                        Changes = true;

                        Msg = "- Added the ability to change voiceovers (Ru, En, De, Sp).\n\n- Added the ability to change interface lang (Ru, En, De, Sp, Fr).\n\n- Added error log file \"SacredUtils - errlog.log\".\n\n- Some app configurations corrections.\n\n- Added notise license apache 2.0 file.\n\n- Deleted all info and warning log.\n\n- Code optimizations, speedup working.\n\n- Added application loading screen.\n\n- Encoding fixed in log. (to UTF-8).\n\n- Added function disable logging.\n\n- SendDownloadStatistic code optimize.\n\n- Removed local modding resources.\n\n- Added install components for modding menu.\n\n- Added supported color theme in ComponentWindow.\n\n- Changed logo and icon, thx icons8 for icon and logo.\n\n- Added project SacredUtils.Ru, and some other.\n\n- Added class with consts gui strings for translate.\n\n- Directory cleaning and refractoring and sorted.\n\n- Fixed regedit working, sending stat now work!\n\n- Fixed invisible symbol in alpha version string.\n\n- Added silent update, and available notify.\n\n- Maybe i fixed download components func.\n\n- App config small fixed.\n\n- Debug file SacredUtils.pdb updated.\n\n- Code optimizations and added button \"Chat\".\n\n- Package Costura fody updated.\n\n- Added MahApps and Border and Glow window.\n\n- Added FlexibleMessageBox sources.\n\n- Added changelog messagebox.\n\n- Added random splashes in example label.\n\n- Added random splashes by shalinorus!"; Caption = String0136;
                    }

                    if (File.Exists(AppVersionFile))
                    {
                        var strings = File.ReadAllLines(AppVersionFile, Encoding.ASCII);

                        if (!strings[3].Contains($"; Current SacredUtils version = {AppCurrentVersion}"))
                        {
                            try
                            {
                                Changes = true;

                                Msg = "- Added the ability to change voiceovers (Ru, En, De, Sp).\n\n- Added the ability to change interface lang (Ru, En, De, Sp, Fr).\n\n- Added error log file \"SacredUtils - errlog.log\".\n\n- Some app configurations corrections.\n\n- Added notise license apache 2.0 file.\n\n- Deleted all info and warning log.\n\n- Code optimizations, speedup working.\n\n- Added application loading screen.\n\n- Encoding fixed in log. (to UTF-8).\n\n- Added function disable logging.\n\n- SendDownloadStatistic code optimize.\n\n- Removed local modding resources.\n\n- Added install components for modding menu.\n\n- Added supported color theme in ComponentWindow.\n\n- Changed logo and icon, thx icons8 for icon and logo.\n\n- Added project SacredUtils.Ru, and some other.\n\n- Added class with consts gui strings for translate.\n\n- Directory cleaning and refractoring and sorted.\n\n- Fixed regedit working, sending stat now work!\n\n- Fixed invisible symbol in alpha version string.\n\n- Added silent update, and available notify.\n\n- Maybe i fixed download components func.\n\n- App config small fixed.\n\n- Debug file SacredUtils.pdb updated.\n\n- Code optimizations and added button \"Chat\".\n\n- Package Costura fody updated.\n\n- Added MahApps and Border and Glow window.\n\n- Added FlexibleMessageBox sources.\n\n- Added changelog messagebox.\n\n- Added random splashes in example label.\n\n- Added random splashes by shalinorus!"; Caption = String0136;

                                var fileAllText = File.ReadAllLines(AppVersionFile);
                                fileAllText[3] = $"; Current SacredUtils version = {AppCurrentVersion}";
                                File.WriteAllLines(AppVersionFile, fileAllText);
                            }
                            catch (Exception exception)
                            {
                                Log.Error(exception.ToString());
                            }
                        }
                    }
                }
                else
                {
                    continue;
                }

                break;
            }
        }
    }
}
