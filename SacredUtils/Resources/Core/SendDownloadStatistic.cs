using System;
using log4net;
using System.IO;
using System.Net;
using System.Text;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using static SacredUtils.Resources.Core.AppConstStrings;

namespace SacredUtils.Resources.Core
{
    class SendDownloadStatistic
    {
        private static readonly ILog Log = LogManager.GetLogger("LOGGER");

        public void CheckFirstInstallAsync()
        {
            try
            {
                Log.Info("Открываем реестр HKEY_CURRENT_USER, SacredUtils .Statistic, downloads.");

                var currentUser = Registry.CurrentUser;
                var subKey = currentUser.OpenSubKey("SacredUtils .Statistic");

                Log.Info("Получаем значение ключа downloads в SacredUtils .Statistic.");

                var first = subKey?.GetValue("downloads").ToString(); subKey?.Close();

                Log.Info("Значение ключа downloads в SacredUtils .Statistic завершено без ошибок.");

                Log.Info("Проверяем параметр 'Скачана ли программа первый раз.'.");

                if (first == "true")
                {
                    subKey.SetValue("downloads", "false"); subKey.Close(); GetFileDownloadStatistic();

                    Log.Info("Программа скачана первый раз, мы занесем это к нам в базу :) .");
                }
                else if (first == "false")
                {
                    Log.Info("Программа скачана не первый раз, мы не занесем это к нам в базу :) .");
                }
            }
            catch (Exception exception)
            {
                Log.Warn(exception.ToString());

                Log.Info("Программа скачана первый раз, мы занесем это к нам в базу :) .");

                var currentUser = Registry.CurrentUser;
                var subKey = currentUser.CreateSubKey("SacredUtils .Statistic");

                Log.Info("Создаем ключ downloads в SacredUtils .Statistic с параметром false.");

                subKey?.SetValue("downloads", "false"); subKey?.Close(); GetFileDownloadStatistic();
            }
        }

        public void GetFileDownloadStatistic()
        {
            try
            {
                Log.Info("Создаем фтп-веб запрос на хостинг с данными о скачиваниях.");

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://mairwunnxstatistic@files.000webhost.com/SacredUtils%20Statistic/downloads.txt");

                request.Method = WebRequestMethods.Ftp.DownloadFile;

                Log.Info("Проходим авторизацию на фтп-веб хостинге с mairwunnxstatistic и **********************.");

                request.Credentials = new NetworkCredential("mairwunnxstatistic", "11317151PleaseNotChange");

                Log.Info("Авторизация на фтп-веб хостинг пройдена успешно.");

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream ?? throw new InvalidOperationException());

                Log.Info("Создаем директорию .SacredUtils Data если ее нет.");

                Directory.CreateDirectory(AppDataFolder);

                Log.Info("Директория .SacredUtils Data была создана без ошибок.");

                Log.Info("Создаем файл downloadstat.dat в директории .SacredUtils Data.");

                using (Stream fileStream = File.Create(AppDataFolder + "/" + "downloadstat.dat"))
                {
                    responseStream.CopyTo(fileStream);

                    Log.Info("Файл downloadstat.dat был создан с полученным содержимым без ошибок.");
                }

                Log.Info("Завершаем процессы и закрываем веб-запросы и запускаем счетчик установок.");

                reader.Close(); response.Close(); SetValueFileStatistic();
            }
            catch (Exception exception)
            {
                Log.Error("Во время работы с FTP сервером произошла ошибка, программа работу продолжит.");

                Log.Error(exception.ToString());
            }
        }

        public void SetValueFileStatistic()
        {
            try
            {
                Log.Info("Открываем файл downloadstat.dat в директории .SacredUtils Data для чтения.");

                var text = File.ReadAllText(AppDataFolder + "/" + "downloadstat.dat");

                Log.Info("Файл downloadstat.dat был открыт для чтения без ошибок.");

                Log.Info("Ищем число по регулярному выражению \\d+ в файле downloadstat.dat.");

                var numberOfStartups = Regex.Match(text, @"\d+").Value;

                Log.Info("Поиск числа по регулярному выражению \\d+ завершен без ошибок.");

                Log.Info("Добавляем +1 к найденному числу по регулярке в файле.");

                var newNumberOfStartups = Convert.ToInt32(numberOfStartups) + 1;

                var fileAllText = File.ReadAllLines(AppDataFolder + "/" + "downloadstat.dat");
                fileAllText[0] = "; The program is downloaded " + newNumberOfStartups + " time(s)";
                File.WriteAllLines(AppDataFolder + "/" + "downloadstat.dat", fileAllText, Encoding.UTF8);

                Log.Info("Изменение количества скачиваний программы завершено без ошибок.");

                Log.Info("Данные о запуске SacredUtils были сохранены в downloadstat.dat.");

                Log.Info("Подготавливаемся к созданию фтп-веб запросу на хостинг с загрузкой файлов.");

                SendFileDownloadStatistic();
            }
            catch (Exception exception)
            {
                Log.Error("Операция по счету скачиваний SacredUtils завершилась с ошибкой.");

                Log.Error(exception.ToString());
            }
        }

        public void SendFileDownloadStatistic()
        {
            try
            {
                Log.Info("Создаем фтп-веб запрос на хостинг с загрузкой файлов.");

                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://mairwunnxstatistic@files.000webhost.com/SacredUtils%20Statistic/downloads.txt");
                request.Method = WebRequestMethods.Ftp.UploadFile;

                Log.Info("Проходим авторизацию на фтп-веб хостинге с mairwunnxstatistic и **********************.");

                request.Credentials = new NetworkCredential("mairwunnxstatistic", "11317151PleaseNotChange");

                Log.Info("Авторизация на фтп-веб хостинг пройдена успешно.");

                Log.Info("Подготавливаем файл к загрузке на FTP сервер.");

                StreamReader sourceStream = new StreamReader(AppDataFolder + "/" + "downloadstat.dat");
                byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
                sourceStream.Close(); request.ContentLength = fileContents.Length;

                Log.Info("Отправляем файл на FTP downloadstat.dat сервер.");

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                Log.Info("Отправка данных файла downloadstat.dat завершена без ошибок.");

                Log.Info("Завершаем процессы и закрываем веб-запросы и запускаем счетчик установок.");

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                response.Close();
            }
            catch (Exception exception)
            {
                Log.Error("Во время работы с FTP сервером произошла ошибка, программа работу продолжит.");

                Log.Error(exception.ToString());
            }
        }
    }
}
