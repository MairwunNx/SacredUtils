using Config.Net;

namespace SacredUtils
{
    public interface IAppSettings
    {
        [Option(Alias = "ApplicationLicenseFileCreate", DefaultValue = "true")]
        bool ApplicationLicenseFileCreate { get; }

        [Option(Alias = "ApplicationLoggingMethodName", DefaultValue = "false")]
        bool ApplicationLoggingMethodName { get; }

        [Option(Alias = "ApplicationShowChangeLog", DefaultValue = "true")]
        bool ApplicationShowChangeLog { get; }

        [Option(Alias = "ApplicationShowUsedMemory", DefaultValue = "false")]
        bool ApplicationShowUsedMemory { get; }

        [Option(Alias = "ApplicationUiColorTheme", DefaultValue = "light")]
        string ApplicationUiColorTheme { get; set; }

        [Option(Alias = "ApplicationUiLanguage", DefaultValue = "based on system")]
        string ApplicationUiLanguage { get; set; }

        [Option(Alias = "ArchiveOldFileOnStartup", DefaultValue = "true")]
        bool ArchiveOldFileOnStartup { get; }

        [Option(Alias = "AutoRegisterHotKeyForWinKey", DefaultValue = "true")]
        bool AutoRegisterHotKeyForWinKey { get; }

        [Option(Alias = "CheckApplicationUpdates", DefaultValue = "true")]
        bool CheckApplicationUpdates { get; set; }

        [Option(Alias = "CheckAutoAlphaUpdate", DefaultValue = "false")]
        bool CheckAutoAlphaUpdate { get; set; }

        [Option(Alias = "CloseDonateDialogAfterSelect", DefaultValue = "true")]
        bool CloseDonateDialogAfterSelect { get; }

        [Option(Alias = "ClosePageDialogAfterSelect", DefaultValue = "true")]
        bool ClosePageDialogAfterSelect { get; } 

        [Option(Alias = "DefaultOpenLogFileProgram", DefaultValue = "notepad")]
        string DefaultOpenLogFileProgram { get; }

        [Option(Alias = "DelayCheckingSacredProcess", DefaultValue = "1")]
        int DelayCheckingSacredProcess { get; }

        [Option(Alias = "DesiredFrameRateProperty", DefaultValue = "60")]
        int DesiredFrameRateProperty { get; }

        [Option(Alias = "DisableApplicationLogging", DefaultValue = "false")]
        bool DisableApplicationLogging { get; }

        [Option(Alias = "DisableApplicationTabKeyButton", DefaultValue = "true")]
        bool DisableApplicationTabKeyButton { get; }

        [Option(Alias = "DisableApplicationTelemetry", DefaultValue = "false")]
        bool DisableApplicationTelemetry { get; }

        [Option(Alias = "DisableCachingGameComponents", DefaultValue = "false")]
        bool DisableCachingGameComponents { get; }

        [Option(Alias = "DisableCelebrationFunnyDay", DefaultValue = "false")]
        bool DisableCelebrationFunnyDay { get; }

        [Option(Alias = "DisableCheckingGlobLibrary", DefaultValue = "false")]
        bool DisableCheckingGlobLibrary { get; }

        [Option(Alias = "DisableCheckInternetConnection", DefaultValue = "false")]
        bool DisableCheckInternetConnection { get; }
        
        [Option(Alias = "DisableCreatingRequiredFiles", DefaultValue = "false")]
        bool DisableCreatingRequiredFiles { get; }

        [Option(Alias = "DisablePrintBaseInfoToLog", DefaultValue = "false")]
        bool DisablePrintBaseInfoToLog { get; }

        [Option(Alias = "DisableReCreatingLangFiles", DefaultValue = "false")]
        bool DisableReCreatingLangFiles { get; }
        
        [Option(Alias = "DisableReCreatingThemeFiles", DefaultValue = "false")]
        bool DisableReCreatingThemeFiles { get; }

        [Option(Alias = "EnableArchiveFileCompression", DefaultValue = "true")]
        bool EnableArchiveFileCompression { get; }

        [Option(Alias = "EnableGlobalExceptionCatching", DefaultValue = "true")]
        bool EnableGlobalExceptionCatching { get; }

        [Option(Alias = "EnableLoggingLoadedSettings", DefaultValue = "false")]
        bool EnableLoggingLoadedSettings { get; }

        [Option(Alias = "ForceEnableFullScreenMode", DefaultValue = "true")]
        bool ForceEnableFullScreenMode { get; }

        [Option(Alias = "HotKeyEventArgsGameHandled", DefaultValue = "true")]
        bool HotKeyEventArgsGameHandled { get; }

        [Option(Alias = "HotKeyRegisterGameDelay", DefaultValue = "1000")]
        int HotKeyRegisterGameDelay { get; }

        [Option(Alias = "HWndSacredWindowClassId", DefaultValue = "Sacred")]
        string HWndSacredWindowClassId { get; }

        [Option(Alias = "KeyApplicationGotoMainMenu", DefaultValue = "Escape")]
        string KeyApplicationGotoMainMenu { get; }

        [Option(Alias = "KeyDefaultReloadSacredUtils", DefaultValue = "F5")]
        string KeyDefaultReloadSacredUtils { get; }

        [Option(Alias = "KeyDefaultShutdownSacredUtils", DefaultValue = "F6")]
        string KeyDefaultShutdownSacredUtils { get; }

        [Option(Alias = "KeyOpenSacredGameSettingsFile", DefaultValue = "F3")]
        string KeyOpenSacredGameSettingsFile { get; }

        [Option(Alias = "KeyOpenSacredUtilsDirectory", DefaultValue = "F4")]
        string KeyOpenSacredUtilsDirectory { get; }

        [Option(Alias = "KeyOpenSacredUtilsLogFile", DefaultValue = "F1")]
        string KeyOpenSacredUtilsLogFile { get; }

        [Option(Alias = "KeyOpenSacredUtilsSettingFile", DefaultValue = "F2")]
        string KeyOpenSacredUtilsSettingFile { get; }

        [Option(Alias = "KeyReloadFastModeSacredUtils", DefaultValue = "F7")]
        string KeyReloadFastModeSacredUtils { get; }

        [Option(Alias = "MakeAutoBackupAppGameConfigs", DefaultValue = "true")]
        bool MakeAutoBackupAppGameConfigs { get; set; }

        [Option(Alias = "MaxApplicationArchiveFiles", DefaultValue = "10")]
        int MaxApplicationArchiveFiles { get; }

        [Option(Alias = "MaxApplicationBackupFiles", DefaultValue = "10")]
        int MaxApplicationBackupFiles { get; }

        [Option(Alias = "MaxSacredGameBackupFiles", DefaultValue = "10")]
        int MaxSacredGameBackupFiles { get; }

        [Option(Alias = "RefreshSettingsOnWindowFocus", DefaultValue = "false")]
        bool RefreshSettingsOnWindowFocus { get; }

        [Option(Alias = "RemoveApplicationTempContent", DefaultValue = "true")]
        bool RemoveApplicationTempContent { get; }

        [Option(Alias = "RemoveBackupFilesOnOverflow", DefaultValue = "true")]
        bool RemoveBackupFilesOnOverflow { get; }

        [Option(Alias = "SacredCheatsEnableArgument", DefaultValue = "CHEATS=1")]
        string SacredCheatsEnableArgument { get; }

        [Option(Alias = "SacredConfigurationFile", DefaultValue = "Settings.cfg")]
        string SacredConfigurationFile { get; }
        
        [Option(Alias = "SacredExecutableFileName", DefaultValue = "Sacred.exe")]
        string SacredExecutableFileName { get; }

        [Option(Alias = "SacredFontSizeArray", DefaultValue = "10|10|12|15|12|12|8")]
        string SacredFontSizeArray { get; set; }

        [Option(Alias = "SacredGameStartupArguments", DefaultValue = 1)]
        int SacredStartArgs { get; set; }

        [Option(Alias = "SacredUtilsApplicationGuiScale", DefaultValue = "1.0")]
        double SacredUtilsGuiScale { get; set; }

        [Option(Alias = "ScreenShotGameCreateKey", DefaultValue = "PrintScreen")]
        string ScreenShotCreateKey { get; }

        [Option(Alias = "ScreenShotRemoveTgaAndJpgFiles", DefaultValue = "true")]
        bool ScreenShotRemoveTgaAndJpgFiles { get; }

        [Option(Alias = "ScreenShotSaveDirectory", DefaultValue = "Capture")]
        string ScreenShotSaveDirectory { get; }

        [Option(Alias = "ScreenShotSaveFilePattern", DefaultValue = "ddMMyyyy-hh-mm-ss-fff")]
        string ScreenShotSaveFilePattern { get; }
        
        [Option(Alias = "ScreenShotSaveFilePrefix", DefaultValue = "screen-")]
        string ScreenShotSaveFilePrefix { get; }

        [Option(Alias = "ShowUsedMemoryUpdateInterval", DefaultValue = "2")]
        int ShowUsedMemoryUpdateInterval { get; }

        [Option(Alias = "UseAsyncCreatingScreenshots", DefaultValue = "false")]
        bool UseAsyncCreatingScreenshots { get; }

        [Option(Alias = "UseAsyncLoadFontCollection", DefaultValue = "false")]
        bool UseAsyncLoadFontCollection { get; }

        [Option(Alias = "UseCustomFontSizeValue", DefaultValue = "false")]
        bool UseCustomFontSizeValue { get; }

        [Option(Alias = "UseSimplifiedHotKeySettings", DefaultValue = "true")]
        bool UseSimplifiedHotKeySettings { get; }

        [Option(Alias = "VisibleNoConnectionImage", DefaultValue = "true")]
        bool VisibleNoConnectionImage { get; }
    }

    public static class AppSettings
    {
        public static readonly IAppSettings ApplicationSettings =
            new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();
    }
}