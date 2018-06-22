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

                        Msg = "- Added the ability to quickly change the language.\n\n- Removed .En, .De, .Ru projects, they are merged into one.\n\n- Some code optimization.\n\n- Added checking of the integrity of language files.\n\n- Added version checking of language files.\n\n- Added more random splashes!"; Caption = String0136;
                    }

                    if (File.Exists(AppVersionFile))
                    {
                        var strings = File.ReadAllLines(AppVersionFile, Encoding.ASCII);

                        if (!strings[3].Contains($"; Current SacredUtils version = {AppCurrentVersion}"))
                        {
                            try
                            {
                                Changes = true;

                                Msg = "- Added the ability to quickly change the language.\n\n- Removed .En, .De, .Ru projects, they are merged into one.\n\n- Some code optimization.\n\n- Added checking of the integrity of language files.\n\n- Added version checking of language files.\n\n- Added more random splashes!"; Caption = String0136;

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
