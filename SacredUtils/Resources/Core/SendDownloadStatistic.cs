using System;
using log4net;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static SacredUtils.Resources.Core.AppConstStrings;

namespace SacredUtils.Resources.Core
{
    class SendDownloadStatistic
    {
        private static readonly ILog Log = LogManager.GetLogger("LOGGER");

        public async Task CheckFirstInstallAsync()
        {
            try
            {
                Log.Info("[FTPSTAT] Открываем реестр HKEY_CURRENT_USER, SacredUtils .Statistic, downloads.");

                var currentUser = Registry.CurrentUser;
                var subKey = currentUser.OpenSubKey("SacredUtils .Statistic");

                Log.Info("[FTPSTAT] Получаем значение ключа downloads в SacredUtils .Statistic.");

                var first = subKey?.GetValue("downloads").ToString(); subKey?.Close();

                Log.Info("[FTPSTAT] Значение ключа downloads в SacredUtils .Statistic завершено без ошибок.");

                Log.Info("[FTPSTAT] Проверяем параметр 'Скачана ли программа первый раз.'.");

                if (first == "true")
                {
                    subKey.SetValue("downloads", "false");

                    subKey.Close();

                    await GetFileDownloadStatisticAsync();

                    Log.Info("[FTPSTAT] Программа скачана первый раз, мы занесем это к нам в базу :) .");
                }
                else if (first == "false")
                {
                    Log.Info("[FTPSTAT] Программа скачана не первый раз, мы не занесем это к нам в базу :) .");
                }
            }
            catch (Exception exception)
            {
                Log.Warn(exception.ToString());

                Log.Info("[FTPSTAT] Программа скачана первый раз, мы занесем это к нам в базу :) .");

                var currentUser = Registry.CurrentUser;
                var subKey = currentUser.CreateSubKey("SacredUtils .Statistic");

                Log.Info("[FTPSTAT] Создаем ключ downloads в SacredUtils .Statistic с параметром false.");

                subKey?.SetValue("downloads", "false"); subKey?.Close(); await GetFileDownloadStatisticAsync();
            }
        }

        public async Task GetFileDownloadStatisticAsync()
        {
            try
            {
                Log.Info("[FTPSTAT] Создаем фтп-веб запрос на хостинг с данными о скачиваниях.");

                FtpWebRequest request = await Task.Run(() => (FtpWebRequest)WebRequest.Create("ftp://mairwunnxstatistic@files.000webhost.com/SacredUtils%20Statistic/downloads.txt"));

                await Task.Run(() => request.Method = WebRequestMethods.Ftp.DownloadFile);

                Log.Info("[FTPSTAT] Проходим авторизацию на фтп-веб хостинге с mairwunnxstatistic и **********************.");

                request.Credentials = await Task.Run(() => new NetworkCredential("mairwunnxstatistic", "11317151PleaseNotChange"));

                Log.Info("[FTPSTAT] Авторизация на фтп-веб хостинг пройдена успешно.");

                FtpWebResponse response = await Task.Run(() => (FtpWebResponse)request.GetResponse());

                Stream responseStream = await Task.Run(() => response.GetResponseStream());
                StreamReader reader = new StreamReader(responseStream ?? throw new InvalidOperationException());

                Log.Info("[FTPSTAT] Создаем директорию .SacredUtils Data если ее нет.");

                Directory.CreateDirectory(AppDataFolder);

                Log.Info("[FTPSTAT] Директория .SacredUtils Data была создана без ошибок.");

                Log.Info("[FTPSTAT] Создаем файл downloadstat.dat в директории .SacredUtils Data.");

                using (Stream fileStream = File.Create(AppDataFolder + "/" + "downloadstat.dat"))
                {
                    responseStream.CopyTo(fileStream);

                    Log.Info("[FTPSTAT] Файл downloadstat.dat был создан с полученным содержимым без ошибок.");
                }

                Log.Info("[FTPSTAT] Завершаем процессы и закрываем веб-запросы и запускаем счетчик установок.");

                reader.Close(); response.Close(); await SetValueFileStatisticAsync();
            }
            catch (Exception exception)
            {
                Log.Error("[FTPSTAT] Во время работы с FTP сервером произошла ошибка, программа работу продолжит.");

                Log.Error(exception.ToString());
            }
        }

        public async Task SetValueFileStatisticAsync()
        {
            try
            {
                Log.Info("[FTPSTAT] Открываем файл downloadstat.dat в директории .SacredUtils Data для чтения.");

                var text = File.ReadAllText(AppDataFolder + "/" + "downloadstat.dat");

                Log.Info("[FTPSTAT] Файл downloadstat.dat был открыт для чтения без ошибок.");

                Log.Info("[FTPSTAT] Ищем число по регулярному выражению \\d+ в файле downloadstat.dat.");

                var numberOfStartups = Regex.Match(text, @"\d+").Value;

                Log.Info("[FTPSTAT] Поиск числа по регулярному выражению \\d+ завершен без ошибок.");

                Log.Info("[FTPSTAT] Добавляем +1 к найденному числу по регулярке в файле.");

                var newNumberOfStartups = Convert.ToInt32(numberOfStartups) + 1;

                var fileAllText = File.ReadAllLines(AppDataFolder + "/" + "downloadstat.dat");
                fileAllText[0] = "; The program is downloaded " + newNumberOfStartups + " time(s)";
                File.WriteAllLines(AppDataFolder + "/" + "downloadstat.dat", fileAllText, Encoding.UTF8);

                Log.Info("[FTPSTAT] Изменение количества скачиваний программы завершено без ошибок.");

                Log.Info("[FTPSTAT] Данные о запуске SacredUtils были сохранены в downloadstat.dat.");

                Log.Info("[FTPSTAT] Подготавливаемся к созданию фтп-веб запросу на хостинг с загрузкой файлов.");

                await SendFileDownloadStatisticAsync();
            }
            catch (Exception exception)
            {
                Log.Error("[FTPSTAT] Операция по счету скачиваний SacredUtils завершилась с ошибкой.");

                Log.Error(exception.ToString());
            }
        }

        public async Task SendFileDownloadStatisticAsync()
        {
            try
            {
                Log.Info("[FTPSTAT] Создаем фтп-веб запрос на хостинг с загрузкой файлов.");

                FtpWebRequest request = await Task.Run(() => (FtpWebRequest)WebRequest.Create("ftp://mairwunnxstatistic@files.000webhost.com/SacredUtils%20Statistic/downloads.txt"));

                await Task.Run(() => request.Method = WebRequestMethods.Ftp.UploadFile);

                Log.Info("[FTPSTAT] Проходим авторизацию на фтп-веб хостинге с mairwunnxstatistic и **********************.");

                await Task.Run(() => request.Credentials = new NetworkCredential("mairwunnxstatistic", "11317151PleaseNotChange"));

                Log.Info("[FTPSTAT] Авторизация на фтп-веб хостинг пройдена успешно.");

                Log.Info("[FTPSTAT] Подготавливаем файл к загрузке на FTP сервер.");

                StreamReader sourceStream = await Task.Run(() => new StreamReader(AppDataFolder + "/" + "downloadstat.dat"));
                byte[] fileContents = await Task.Run(() => Encoding.UTF8.GetBytes(sourceStream.ReadToEnd()));
                sourceStream.Close(); request.ContentLength = fileContents.Length;

                Log.Info("[FTPSTAT] Отправляем файл на FTP downloadstat.dat сервер.");

                Stream requestStream = await Task.Run(() => request.GetRequestStream());
                await Task.Run(() => requestStream.Write(fileContents, 0, fileContents.Length));
                requestStream.Close();

                Log.Info("[FTPSTAT] Отправка данных файла downloadstat.dat завершена без ошибок.");

                Log.Info("[FTPSTAT] Завершаем процессы и закрываем веб-запросы. Операция завершена.");

                FtpWebResponse response = await Task.Run(() => (FtpWebResponse)request.GetResponse());

                response.Close();
            }
            catch (Exception exception)
            {
                Log.Error("[FTPSTAT] Во время работы с FTP сервером произошла ошибка, программа работу продолжит.");

                Log.Error(exception.ToString());
            }
        }
    }
}
