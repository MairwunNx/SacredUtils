using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static SacredUtils.Resources.bin.AncillaryConstsStrings;
using static SacredUtils.Resources.bin.LanguageConstsStrings;

namespace SacredUtils.Resources.bin
{
    public class LoadStrings
    {
        public async Task GetStringsAsync()
        {
            StreamReader streamReader = new StreamReader(AppLngDataFile, Encoding.Default);
            string[] stringss = streamReader.ReadToEnd().Split('\n');

            for (var i = 0; i < stringss.Length; i++)
            {
                var tempdata0 = stringss[i].Substring(stringss[i].IndexOf("\"", StringComparison.Ordinal) + 1);

                if (tempdata0 == stringss[i].Substring(stringss[i].IndexOf("\"", StringComparison.Ordinal) + 1))
                {
                    var tempdata1 = tempdata0.Remove(tempdata0.LastIndexOf("\"", StringComparison.Ordinal));

                    stringss[i] = tempdata1;
                }
            }

            try
            {
                String0001 = stringss[0];
                String0002 = stringss[1];
                String0003 = stringss[2];
                String0004 = stringss[3];
                String0005 = stringss[4];
                String0006 = stringss[5];
                String0007 = stringss[6];
                String0008 = stringss[7];
                String0009 = stringss[8];
                String0010 = stringss[9];
                String0011 = stringss[10];
                String0012 = stringss[11];
                String0013 = stringss[12];
                String0014 = stringss[13];
                String0015 = stringss[14];
                String0016 = stringss[15];
                String0017 = stringss[16];
                String0018 = stringss[17];
                String0019 = stringss[18];
                String0020 = stringss[19];
                String0021 = stringss[20];
                String0022 = stringss[21];
                String0023 = stringss[22];
                String0024 = stringss[23];
                String0025 = stringss[24];
                String0026 = stringss[25];
                String0027 = stringss[26];
                String0028 = stringss[27];
                String0029 = stringss[28];
                String0030 = stringss[29];
                String0031 = stringss[30];
                String0032 = stringss[31];
                String0033 = stringss[32];
                String0034 = stringss[33];
                String0035 = stringss[34];
                String0036 = stringss[35];
                String0037 = stringss[36];
                String0038 = stringss[37];
                String0039 = stringss[38];
                String0040 = stringss[39];
                String0041 = stringss[40];
                String0042 = stringss[41];
                String0043 = stringss[42];
                String0044 = stringss[43];
                String0045 = stringss[44];
                String0046 = stringss[45];
                String0047 = stringss[46];
                String0048 = stringss[47];
                String0049 = stringss[48];
                String0050 = stringss[49];
                String0051 = stringss[50];
                String0052 = stringss[51];
                String0053 = stringss[52];
                String0054 = stringss[53];
                String0055 = stringss[54];
                String0056 = stringss[55];
                String0057 = stringss[56];
                String0058 = stringss[57];
                String0059 = stringss[58];
                String0060 = stringss[59];
                String0061 = stringss[60];
                String0062 = stringss[61];
                String0063 = stringss[62];
                String0064 = stringss[63];
                String0065 = stringss[64];
                String0066 = stringss[65];
                String0067 = stringss[66];
                String0068 = stringss[67];
                String0069 = stringss[68];
                String0070 = stringss[69];
                String0071 = stringss[70];
                String0072 = stringss[71];
                String0073 = stringss[72];
                String0074 = stringss[73];
                String0075 = stringss[74];
                String0076 = stringss[75];
                String0077 = stringss[76];
                String0078 = stringss[77];
                String0079 = stringss[78];
                String0080 = stringss[79];
                String0081 = stringss[80];
                String0082 = stringss[81];
                String0083 = stringss[82];
                String0084 = stringss[83];
                String0085 = stringss[84];
                String0086 = stringss[85];
                String0087 = stringss[86];
                String0088 = stringss[87];
                String0089 = stringss[88];
                String0090 = stringss[89];
                String0091 = stringss[90];
                String0092 = stringss[91];
                String0093 = stringss[92];
                String0094 = stringss[93];
                String0095 = stringss[94];
                String0096 = stringss[95];
                String0097 = stringss[96];
                String0098 = stringss[97];
                String0099 = stringss[98];
                String0100 = stringss[99];
                String0101 = stringss[100];
                String0103 = stringss[101];
                String0104 = stringss[102];
                String0105 = stringss[103];
                String0106 = stringss[104];
                String0107 = stringss[105];
                String0108 = stringss[106];
                String0109 = stringss[107];
                String0110 = stringss[108];
                String0111 = stringss[109];
                String0112 = stringss[110];
                String0113 = stringss[111];
                String0114 = stringss[112];
                String0115 = stringss[113];
                String0116 = stringss[114];
                String0117 = stringss[115];
                String0118 = stringss[116];
                String0119 = stringss[117];
                String0120 = stringss[118];
                String0121 = stringss[119];
                String0122 = stringss[120];
                String0123 = stringss[121];
                String0124 = stringss[122];
                String0125 = stringss[123];
                String0126 = stringss[124];
                String0127 = stringss[125];
                String0128 = stringss[126];
                String0129 = stringss[127];
                String0130 = stringss[128];
                String0131 = stringss[129];
                String0132 = stringss[130];
                String0133 = stringss[131];
                String0134 = stringss[132];
                String0135 = stringss[133];
                String0136 = stringss[134];
                String0137 = stringss[135];
                String0138 = stringss[136];
                String0139 = stringss[137];
                String0140 = stringss[138];
                String0141 = stringss[139];
                String0142 = stringss[140];
                String0143 = stringss[141];
                String0144 = stringss[142];
                String0145 = stringss[143];
                String0146 = stringss[144];
                String0147 = stringss[145];
                String0148 = stringss[146];
            }
            catch
            {
                if (String0001 == "Вы обновитесь до версии")
                {
                    System.Random rnd = new System.Random();
                    
                    int rndInt = rnd.Next(210618, 1498640135);

                    Directory.CreateDirectory(AppLngBackupFolder);

                    await Task.Run(() => File.Copy(AppLngDataFile, $"{AppLngBackupFolder}\\language_ru_id_{rndInt}.dat"));

                    await Task.Run(() => File.WriteAllBytes(AppLngDataFile, Properties.Resources.languageru));

                    await CreateTempInfoFile(AppLngDataFile, $"{AppLngBackupFolder}\\language_ru_id_{rndInt}.dat");

                    Process.Start(AppnameFile); Environment.Exit(0);
                }

                if (String0001 == "You updating to version")
                {
                    System.Random rnd = new System.Random();

                    int rndInt = rnd.Next(210618, 1498640135);

                    Directory.CreateDirectory(AppLngBackupFolder);

                    await Task.Run(() => File.Copy(AppLngDataFile, $"{AppLngBackupFolder}\\language_en_id_{rndInt}.dat"));

                    await Task.Run(() => File.WriteAllBytes(AppLngDataFile, Properties.Resources.languageen));

                    await CreateTempInfoFile(AppLngDataFile, $"{AppLngBackupFolder}\\language_en_id_{rndInt}.dat");

                    Process.Start(AppnameFile); Environment.Exit(0);
                }

                if (String0001 == "Sie aktualisieren auf Version")
                {
                    System.Random rnd = new System.Random();

                    int rndInt = rnd.Next(210618, 1498640135);

                    Directory.CreateDirectory(AppLngBackupFolder);

                    await Task.Run(() => File.Copy(AppLngDataFile, $"{AppLngBackupFolder}\\language_de_id_{rndInt}.dat"));

                    await Task.Run(() => File.WriteAllBytes(AppLngDataFile, Properties.Resources.languagede));

                    await CreateTempInfoFile(AppLngDataFile, $"{AppLngBackupFolder}\\language_de_id_{rndInt}.dat");

                    Process.Start(AppnameFile); Environment.Exit(0);
                }

                if (String0001 == "")
                {
                    System.Random rnd = new System.Random();

                    int rndInt = rnd.Next(210618, 1498640135);

                    Directory.CreateDirectory(AppLngBackupFolder);

                    await Task.Run(() => File.Copy(AppLngDataFile, $"{AppLngBackupFolder}\\language_any_id_{rndInt}.dat"));

                    await Task.Run(() => File.Delete(AppLngDataFile));

                    await CreateTempInfoFile(AppLngDataFile, $"{AppLngBackupFolder}\\language_any_id_{rndInt}.dat");

                    Process.Start(AppnameFile); Environment.Exit(0);
                }
            }
        }

        public async Task CreateTempInfoFile(string file, string pathToBackupFile)
        {
            try
            {
                await Task.Run(() => Directory.CreateDirectory(AppTempLngFolder));

                StreamWriter textFile = new StreamWriter(AppLngErrorFile);
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
