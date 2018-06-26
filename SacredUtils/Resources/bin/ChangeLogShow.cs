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

                        Msg = "- Added debug menu and console.\n\n- Fixed bug with update from 1 build to 9.\n\n- Updated Costura Fody and Fody libraries.\n\n- Added automatic copying configurations to backup folder.\n\n- Added auto deleting unnecessary files.\n\n- Renamed LangVersion.su file to langversion.dat.\n\n- Added saving info about voiceovers.\n\n- Added more random splashes!"; Caption = String0136;
                    }

                    if (File.Exists(AppVersionFile))
                    {
                        var strings = File.ReadAllLines(AppVersionFile, Encoding.ASCII);

                        if (!strings[3].Contains($"; Current SacredUtils version = {AppCurrentVersion}"))
                        {
                            try
                            {
                                Changes = true;

                                Msg = "- Added debug menu and console.\n\n- Fixed bug with update from 1 build to 9.\n\n- Updated Costura Fody and Fody libraries.\n\n- Added automatic copying configurations to backup folder.\n\n- Added auto deleting unnecessary files.\n\n- Renamed LangVersion.su file to langversion.dat.\n\n- Added saving info about voiceovers.\n\n- Added more random splashes!"; Caption = String0136;

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
