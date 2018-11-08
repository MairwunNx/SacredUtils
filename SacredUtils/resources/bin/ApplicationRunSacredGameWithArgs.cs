using System.Diagnostics;
using System.Linq;

namespace SacredUtils.resources.bin
{
    public static class ApplicationRunSacredGameWithArgs
    {
        private static readonly string SacredFileName = AppSettings.ApplicationSettings.SacredExecutableFileName;
        private static readonly string SacredCheatArg = AppSettings.ApplicationSettings.SacredCheatsEnableArgument;
        
        public static void Run(string[] args)
        {
            if (args.Contains("-cheats"))
            {
                Process.Start(SacredFileName, SacredCheatArg);

                EnableSwitchingLanguage(args);
                EnableStretchingScreenshot(args);
                EnableEmulateHotkeys(args);
            }
            else
            {
                Process.Start(SacredFileName);

                EnableSwitchingLanguage(args);
                EnableStretchingScreenshot(args);
                EnableEmulateHotkeys(args);
            }
        }

        private static void EnableSwitchingLanguage(string[] args)
        {
            if (args.Contains("-forceSwitchLanguage"))
            {
                ForceSwitchKeyboardLanguageInGame.RegisterApplication();
            }
        }

        private static void EnableStretchingScreenshot(string[] args)
        {
            if (args.Contains("-fullScreenShot"))
            {
                ForceStretchSacredGameScreenshot.RegisterKey(true);
            }
        }

        private static void EnableEmulateHotkeys(string[] args)
        { 
            if (args.Contains("-emulateHotkeys"))
            {
                ApplicationStartEmulateHotkeys.RegisterMainHotkeys();
            }
        }
    }
}
