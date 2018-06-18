using System;
using System.IO;
using System.Text;
using System.Windows;
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
                    if (!File.Exists($"{AppDataFolder}\\appversion.dat"))
                    {
                        File.WriteAllBytes($"{AppDataFolder}\\appversion.dat", Properties.Resources.AppVersion);

                        MessageBox.Show("Добавлено что-то там.", "Изменения.");
                    }

                    if (File.Exists($"{AppDataFolder}\\appversion.dat"))
                    {
                        var strings = File.ReadAllLines($"{AppDataFolder}\\appversion.dat", Encoding.ASCII);

                        if (!strings[3].Contains($"; Current SacredUtils version = {AppCurrentVersion}"))
                        {
                            try
                            {
                                Changes = true;
                                
                                Msg = "- Added changelog messagebox."; Caption = $"{String0136}";

                                var fileAllText = File.ReadAllLines($"{AppDataFolder}\\appversion.dat");
                                fileAllText[3] = $"; Current SacredUtils version = {AppCurrentVersion}";
                                File.WriteAllLines($"{AppDataFolder}\\appversion.dat", fileAllText);
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
