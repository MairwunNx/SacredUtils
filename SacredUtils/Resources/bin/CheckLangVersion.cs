using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;
using static SacredUtils.Resources.bin.LanguageConstsStrings;

namespace SacredUtils.Resources.bin
{
    public class CheckLangVersion
    {
        public async Task GetLanguageVersionAsync()
        {
            if (File.Exists(".SacredUtilsData\\LangVersion.su"))
            {
                File.Move(".SacredUtilsData\\LangVersion.su", ".SacredUtilsData\\langversion.dat");
            }

            if (!File.Exists(".SacredUtilsData\\langversion.dat"))
            {
                File.WriteAllBytes(".SacredUtilsData\\langversion.dat", Properties.Resources.LangVersion);
            }

            var strings = File.ReadAllLines(".SacredUtilsData\\langversion.dat", Encoding.ASCII);

            if (!strings[3].Contains("; Current language version = 2"))
            {
                if (String0001 == "Вы обновитесь до версии")
                {
                    Random rnd = new Random();

                    int rndInt = rnd.Next(220618, 1498640135);

                    Directory.CreateDirectory(AppLngBackupFolder);

                    await Task.Run(() => File.Copy(AppLngDataFile, $"{AppLngBackupFolder}\\language_ru_id_{rndInt}.dat"));

                    await Task.Run(() => File.WriteAllBytes(AppLngDataFile, Properties.Resources.languageru));

                    await CreateTempInfoFile("Update", AppLngDataFile, $"{AppLngBackupFolder}\\language_ru_id_{rndInt}.dat");

                    await Task.Run(() => File.WriteAllBytes(".SacredUtilsData\\langversion.dat", Properties.Resources.LangVersion));

                    Process.Start(AppnameFile); Environment.Exit(0);
                }

                if (String0001 == "You updating to version")
                {
                    Random rnd = new Random();

                    int rndInt = rnd.Next(220618, 1498640135);

                    Directory.CreateDirectory(AppLngBackupFolder);

                    await Task.Run(() => File.Copy(AppLngDataFile, $"{AppLngBackupFolder}\\language_en_id_{rndInt}.dat"));

                    await Task.Run(() => File.WriteAllBytes(AppLngDataFile, Properties.Resources.languageen));

                    await CreateTempInfoFile("Update", AppLngDataFile, $"{AppLngBackupFolder}\\language_en_id_{rndInt}.dat");

                    await Task.Run(() => File.WriteAllBytes(".SacredUtilsData\\langversion.dat", Properties.Resources.LangVersion));

                    Process.Start(AppnameFile); Environment.Exit(0);
                }

                if (String0001 == "Sie aktualisieren auf Version")
                {
                    Random rnd = new Random();

                    int rndInt = rnd.Next(220618, 1498640135);

                    Directory.CreateDirectory(AppLngBackupFolder);

                    await Task.Run(() => File.Copy(AppLngDataFile, $"{AppLngBackupFolder}\\language_de_id_{rndInt}.dat"));

                    await Task.Run(() => File.WriteAllBytes(AppLngDataFile, Properties.Resources.languagede));

                    await CreateTempInfoFile("Update", AppLngDataFile, $"{AppLngBackupFolder}\\language_de_id_{rndInt}.dat");

                    await Task.Run(() => File.WriteAllBytes(".SacredUtilsData\\langversion.dat", Properties.Resources.LangVersion));

                    Process.Start(AppnameFile); Environment.Exit(0);
                }

                if (String0001 == "")
                {
                    Random rnd = new Random();

                    int rndInt = rnd.Next(220618, 1498640135);

                    Directory.CreateDirectory(AppLngBackupFolder);

                    await Task.Run(() => File.Copy(AppLngDataFile, $"{AppLngBackupFolder}\\language_any_id_{rndInt}.dat"));

                    await Task.Run(() => File.Delete(AppLngDataFile));

                    await CreateTempInfoFile("Update", AppLngDataFile, $"{AppLngBackupFolder}\\language_any_id_{rndInt}.dat");

                    await Task.Run(() => File.WriteAllBytes(".SacredUtilsData\\langversion.dat", Properties.Resources.LangVersion));

                    Process.Start(AppnameFile); Environment.Exit(0);
                }
            }
        }

        public async Task CreateTempInfoFile(string reason, string file, string pathToBackupFile)
        {
            try
            {
                if (File.Exists(AppLngErrorFile))
                {
                    await Task.Run(() => File.Delete(AppLngErrorFile));
                }

                await Task.Run(() => Directory.CreateDirectory(AppTempLngFolder));

                StreamWriter textFile = new StreamWriter(AppLngErrorFile);
                textFile.WriteLine(reason);
                textFile.WriteLine(file);
                textFile.WriteLine(pathToBackupFile);
                textFile.Close();
            }
            catch (Exception e)
            {
                FlexibleMessageBox.Show(e.ToString());
            }
        }
    }
}
