using System.Diagnostics;
using System.Linq;
using SacredUtils.SourceFiles.settings;

namespace SacredUtils.SourceFiles.bin
{
    public static class ApplicationRunSacredGameWithArgs
    {
        public static void Run(string[] args)
        {
            if (args.Contains("-cheatsEnable"))
            {
                Process.Start(ApplicationSettingsManager.Settings.SacredExecutableFileName,
                    ApplicationSettingsManager.Settings.SacredCheatsEnableArgument
                );

                EnableSwitchingLanguage(args);
                EnableStretchingScreenshot(args);
                EnableEmulateHotKeys(args);
                EnableDisableWinKey(args);
            }
            else
            {
                Process.Start(ApplicationSettingsManager.Settings.SacredExecutableFileName);

                EnableSwitchingLanguage(args);
                EnableStretchingScreenshot(args);
                EnableEmulateHotKeys(args);
                EnableDisableWinKey(args);
            }
        }

        private static void EnableSwitchingLanguage(string[] args)
        {
            if (!args.Contains("-forceSwitchLanguage")) return;

            ForceSwitchKeyboardLanguageInGame.RegisterApplication();
        }

        private static void EnableStretchingScreenshot(string[] args)
        {
            if (!args.Contains("-fullScreenShot")) return;

            ForceStretchSacredGameScreenshot.RegisterKey(true);
        }

        private static void EnableEmulateHotKeys(string[] args)
        {
            if (!args.Contains("-emulateHotKeys")) return;

            ApplicationStartEmulateHotkeys.RegisterMainHotkeys();
        }

        private static void EnableDisableWinKey(string[] args)
        {
            if (!args.Contains("-disableWinKey")) return;

            ForceSacredGameDisableWinKey.RegisterKeys();
            ForceSacredGameDisableWinKey.Disable();
        }
    }
}
