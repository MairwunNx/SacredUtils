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

                        Msg = "- Fixed lenght for font example textbox.\n\n- Changed primary color for dark theme.\n\n- Restricted Tab key.\n\n- Added link on SacredUtils site.\n\n- Rename Debug console to Debug menu.\n\n- Some windows converted to modal windows."; Caption = String0136;
                    }

                    if (File.Exists(AppVersionFile))
                    {
                        var strings = File.ReadAllLines(AppVersionFile, Encoding.ASCII);

                        if (!strings[3].Contains($"; Current SacredUtils version = {AppCurrentVersion}"))
                        {
                            try
                            {
                                Changes = true;

                                Msg = "- Fixed lenght for font example textbox.\n\n- Changed primary color for dark theme.\n\n- Restricted Tab key.\n\n- Added link on SacredUtils site.\n\n- Rename Debug console to Debug menu.\n\n- Some windows converted to modal windows."; Caption = String0136;

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
