using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using SacredUtils.SourceFiles.extensions;
using SacredUtils.SourceFiles.utils;
using static SacredUtils.SourceFiles.Logger;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;

namespace SacredUtils.SourceFiles
{
    [SecurityPermission(
        SecurityAction.Demand,
        Flags = SecurityPermissionFlag.ControlAppDomain
    )]
    public static class ExceptionCatching
    {
        private static readonly NetworkCredential Creds =
            new NetworkCredential("crashviolator@mail.ru", "trAVypLMf2DkCv2");

        public static void Init()
        {
            if (Settings.EnableGlobalExceptionCatching)
            {
                Subscribe();
            }
        }

        private static void Subscribe() => AppDomain.CurrentDomain.UnhandledException += Catch;

        private static void Catch(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception) args.ExceptionObject;
            DateTime now = DateTime.Now;
            string crashFilePath =
                $"{Path.Combine(ApplicationInfo.CrashFolder, $"crash-{now.ToString(Settings.ScreenShotSaveFilePattern)}-su.txt")}";
            string latestLogFile = Path.Combine(ApplicationInfo.Root, "logs", "latest.log");
            Directory.CreateDirectory(ApplicationInfo.CrashFolder);

            Log.Fatal(
                $"\n\n    There was a critical error that provoked the forced termination of the program.\n    Crash-report-log was created in {crashFilePath}, send it crash-report-log to MairwunNx\n"
            );

            File.WriteAllText(
                crashFilePath,
                $"---- SacredUtils Crash Report Details ----\n\n    There was a critical error of the program, sorry please, if the program could not start \n    Please contact MairwunNx, MairwunNx@gmail.com. May be it our problem. Sorry. );\n\n    In extreme cases, write in the VK (rus) or telegram (eng) (telegram \\ vk (@MairwunNx))\n\nCrash Created Time: {now}\nDescription: There was a severe problem during SacredUtils loading that has caused the SacredUtils to fail\nException Message: {e.Message}\n\nSacredUtils Version: {ApplicationInfo.Version} \\ {ApplicationInfo.AlphaVersion} {ApplicationInfo.Type} \\ {ApplicationInfo.Build}\nSacredUtils Path: {ApplicationInfo.CurrentPath}\nSacredUtils Startup Args: {ApplicationInfo.AppArguments.ToNormalString()}\n\nOperating System: {Environment.OSVersion.VersionString} {RuntimeInformation.OSArchitecture}\nFramework Runtime: {RuntimeInformation.FrameworkDescription}\n\n{e}"
            );

            try
            {
                if (NetworkUtils.IsConnected.Value && Settings.AutomaticallySendCrashReports)
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        SmtpClient smtpServer = new SmtpClient("smtp.mail.ru")
                        {
                            Port = 587, Credentials = Creds, EnableSsl = true
                        };

                        mail.From = new MailAddress("crashviolator@mail.ru");
                        mail.To.Add("MairwunNx@gmail.com");
                        mail.Subject = "SacredUtils Crash-Report";
                        mail.Body = $"SacredUtils Crash-Report from user {Environment.UserName}.";

                        Attachment reportAttachment = new Attachment(crashFilePath);
                        Attachment latestLogAttachment = new Attachment(latestLogFile);
                        mail.Attachments.Add(reportAttachment);
                        if (File.Exists(latestLogFile))
                        {
                            mail.Attachments.Add(latestLogAttachment);
                        }

                        smtpServer.Send(mail);
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Fatal("// I bet MairwunNx wouldn't have this problem.");
                Log.Fatal(exception.ToString);
            }

            SaveSettings();
            Environment.Exit(0);
        }
    }
}
