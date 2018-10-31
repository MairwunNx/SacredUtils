using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
    public static class GetStateGlobalExceptionCatching
    {
        public static void Get()
        {
            if (AppSettings.ApplicationSettings.EnableGlobalExceptionCatching) { Subscribe(); }
        }

        private static void Subscribe()
        {
            AppDomain.CurrentDomain.UnhandledException += Catch;
        }

        private static void Catch(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;

            Log.Fatal("\n\n    There was a critical error that provoked the forced termination of the program.\n    Crash-report-log was created in $SacredUtils\\crash-reports, send it crash-report-log to MairwunNx\n");

            DateTime now = DateTime.Now;

            Directory.CreateDirectory("$SacredUtils\\crash-reports");

            File.WriteAllText(
                $"$SacredUtils\\crash-reports\\crash-{now.ToString(AppSettings.ApplicationSettings.ScreenShotSaveFilePattern)}-su.txt",
                $"---- SacredUtils Crash Report Details ----\n\n    There was a critical error of the program, sorry please, if the program could not start \n    Please contact MairwunNx, MairwunNx@gmail.com. May be it our problem. Sorry. );\n\n    In extreme cases, write in the VK (rus) or telegram (eng) (telegram \\ vk (@MairwunNx))\n\nCrash Created Time: {now}\nDescription: There was a severe problem during SacredUtils loading that has caused the SacredUtils to fail\n\nSacredUtils Version: {AppSummary.Version} \\ {AppSummary.AVersion} {AppSummary.Type} \\ {AppSummary.Build}\n\nOperating System: {Environment.OSVersion.VersionString} {RuntimeInformation.OSArchitecture}\n\n{e}");

            try
            {
                if (CheckAvailabilityInternetConnection.Connect())
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        SmtpClient smtpServer = new SmtpClient("smtp.mail.ru");

                        mail.From = new MailAddress("crashviolator@mail.ru");
                        mail.To.Add("MairwunNx@gmail.com");
                        mail.Subject = "SacredUtils Crash-Report";
                        mail.Body = $"SacredUtils Crash-Report from user {Environment.UserName}.";

                        Attachment attachment = new Attachment($"$SacredUtils\\crash-reports\\crash-{now.ToString(AppSettings.ApplicationSettings.ScreenShotSaveFilePattern)}-su.txt");
                        mail.Attachments.Add(attachment);

                        smtpServer.Port = 587;
                        smtpServer.Credentials = new NetworkCredential("crashviolator@mail.ru", "trAVypLMf2DkCv2");
                        smtpServer.EnableSsl = true;

                        smtpServer.Send(mail);
                    }
                }
            }
            catch (Exception exc)
            {
                Log.Error(exc.ToString);
            }
            
            Environment.Exit(0);
        }
    }
}
