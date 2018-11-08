using Config.Net;
// ReSharper disable InconsistentNaming

namespace SacredUtils
{
    public interface IAppSettings
    {
        [Option(Alias = "AppUiLanguage", DefaultValue = "based on system")]
        string AppUiLanguage { get; set; }

        [Option(Alias = "ArchiveOldFileOnStartup", DefaultValue = "true")]
        bool ArchiveOldFileOnStartup { get; }

        [Option(Alias = "CheckAutoAlphaUpdate", DefaultValue = "false")]
        bool CheckAutoAlphaUpdate { get; set; }

        [Option(Alias = "CheckAutoUpdate", DefaultValue = "true")]
        bool CheckAutoUpdate { get; set; }

        [Option(Alias = "CloseDonateDialogAfterSelect", DefaultValue = "true")]
        bool CloseDonateDialogAfterSelect { get; }

        [Option(Alias = "ClosePageDialogAfterSelect", DefaultValue = "true")]
        bool ClosePageDialogAfterSelect { get; } 

        [Option(Alias = "ColorTheme", DefaultValue = "light")]
        string ColorTheme { get; set; }

        [Option(Alias = "DefaultOpenLogFileProgram", DefaultValue = "notepad")]
        string DefaultOpenLogFileProgram { get; }

        [Option(Alias = "DelayCheckingSacredProcess", DefaultValue = "1")]
        int DelayCheckingSacredProcess { get; }

        [Option(Alias = "DesiredFrameRateProperty", DefaultValue = "60")]
        int DesiredFrameRateProperty { get; }

        [Option(Alias = "DisableCachingGameComponents", DefaultValue = "false")]
        bool DisableCachingGameComponents { get; }

        [Option(Alias = "DisableCheckingGlobLibrary", DefaultValue = "false")]
        bool DisableCheckingGlobLibrary { get; }

        [Option(Alias = "DisableCheckInternetConnection", DefaultValue = "false")]
        bool DisableCheckInternetConnection { get; }
        
        [Option(Alias = "DisableCreatingRequiredFiles", DefaultValue = "false")]
        bool DisableCreatingRequiredFiles { get; }

        [Option(Alias = "DisableFoolFunnyDay", DefaultValue = "false")]
        bool DisableFoolFunnyDay { get; }

        [Option(Alias = "DisableFootSteps", DefaultValue = "false")]
        bool DisableFootSteps { get; set; }

        [Option(Alias = "DisableLogging", DefaultValue = "false")]
        bool DisableLogging { get; }

        [Option(Alias = "DisablePrintBaseInfoToLog", DefaultValue = "false")]
        bool DisablePrintBaseInfoToLog { get; }

        [Option(Alias = "DisableReCreatingLangFiles", DefaultValue = "false")]
        bool DisableReCreatingLangFiles { get; }
        
        [Option(Alias = "DisableReCreatingThemeFiles", DefaultValue = "false")]
        bool DisableReCreatingThemeFiles { get; }

        [Option(Alias = "DisableTelemetry", DefaultValue = "false")]
        bool DisableTelemetry { get; }

        [Option(Alias = "EnableArchiveFileCompression", DefaultValue = "true")]
        bool EnableArchiveFileCompression { get; }

        [Option(Alias = "EnableGlobalExceptionCatching", DefaultValue = "true")]
        bool EnableGlobalExceptionCatching { get; }

        [Option(Alias = "EnableLoggingLoadedSettings", DefaultValue = "false")]
        bool EnableLoggingLoadedSettings { get; }

        [Option(Alias = "ForceEnableFullScreenMode", DefaultValue = "true")]
        bool ForceEnableFullScreenMode { get; }

        [Option(Alias = "HotKeyEventArgsHandled", DefaultValue = "true")]
        bool HotKeyEventArgsHandled { get; }

        [Option(Alias = "HotKeyRegisterDelay", DefaultValue = "1000")]
        int HotKeyRegisterDelay { get; }

        [Option(Alias = "hWndSacred", DefaultValue = "Sacred")]
        string hWndSacred { get; }

        [Option(Alias = "KeyGotoMainMenu", DefaultValue = "Escape")]
        string KeyGotoMainMenu { get; }

        [Option(Alias = "KeyOpenSacredGameSettings", DefaultValue = "F3")]
        string KeyOpenSacredGameSettings { get; }

        [Option(Alias = "KeyOpenSacredUtilsDirectory", DefaultValue = "F4")]
        string KeyOpenSacredUtilsDirectory { get; }

        [Option(Alias = "KeyOpenSacredUtilsLogs", DefaultValue = "F1")]
        string KeyOpenSacredUtilsLogs { get; }

        [Option(Alias = "KeyOpenSacredUtilsSettings", DefaultValue = "F2")]
        string KeyOpenSacredUtilsSettings { get; }

        [Option(Alias = "KeyReloadFastSacredUtils", DefaultValue = "F7")]
        string KeyReloadFastSacredUtils { get; }

        [Option(Alias = "KeyReloadSacredUtils", DefaultValue = "F5")]
        string KeyReloadSacredUtils { get; }

        [Option(Alias = "KeyShutdownSacredUtils", DefaultValue = "F6")]
        string KeyShutdownSacredUtils { get; }

        [Option(Alias = "LicenseFileCreate", DefaultValue = "true")]
        bool LicenseFileCreate { get; }

        [Option(Alias = "LoggingMethodName", DefaultValue = "false")]
        bool LoggingMethodName { get; }

        [Option(Alias = "MakeAutoBackupConfigs", DefaultValue = "true")]
        bool MakeAutoBackupConfigs { get; set; }

        [Option(Alias = "MaxApplicationBackupFiles", DefaultValue = "10")]
        int MaxApplicationBackupFiles { get; }

        [Option(Alias = "MaxArchiveFiles", DefaultValue = "10")]
        int MaxArchiveFiles { get; }

        [Option(Alias = "MaxGameBackupFiles", DefaultValue = "10")]
        int MaxGameBackupFiles { get; }

        [Option(Alias = "RefreshSettingsOnWindowFocus", DefaultValue = "false")]
        bool RefreshSettingsOnWindowFocus { get; }

        [Option(Alias = "RemoveBackupFilesOnOverflow", DefaultValue = "true")]
        bool RemoveBackupFilesOnOverflow { get; }

        [Option(Alias = "RemoveTempContent", DefaultValue = "true")]
        bool RemoveTempContent { get; }

        [Option(Alias = "SacredCheatsEnableArgument", DefaultValue = "CHEATS=1")]
        string SacredCheatsEnableArgument { get; }

        [Option(Alias = "SacredConfigurationFile", DefaultValue = "Settings.cfg")]
        string SacredConfigurationFile { get; }

        [Option(Alias = "SacredFileName", DefaultValue = "Sacred.exe")]
        string SacredFileName { get; }

        [Option(Alias = "SacredFontSizeArray", DefaultValue = "10|10|12|15|12|12|8")]
        string SacredFontSizeArray { get; set; }

        [Option(Alias = "SacredStartArgs", DefaultValue = 1)]
        int SacredStartArgs { get; set; }

        [Option(Alias = "SacredUtilsGuiScale", DefaultValue = "1.0")]
        double SacredUtilsGuiScale { get; set; }

        [Option(Alias = "ScreenShotCreateKey", DefaultValue = "PrintScreen")]
        string ScreenShotCreateKey { get; }

        [Option(Alias = "ScreenShotRemoveTgaAndJpgFiles", DefaultValue = "true")]
        bool ScreenShotRemoveTgaAndJpgFiles { get; }

        [Option(Alias = "ScreenShotSaveDirectory", DefaultValue = "Capture")]
        string ScreenShotSaveDirectory { get; }

        [Option(Alias = "ScreenShotSaveFilePattern", DefaultValue = "ddMMyyyy-hh-mm-ss-fff")]
        string ScreenShotSaveFilePattern { get; }
        
        [Option(Alias = "ScreenShotSaveFilePrefix", DefaultValue = "screen-")]
        string ScreenShotSaveFilePrefix { get; }

        [Option(Alias = "ShowChangeLog", DefaultValue = "true")]
        bool ShowChangeLog { get; }
        
        [Option(Alias = "ShowNoConnectionIcon", DefaultValue = "true")]
        bool ShowNoConnectionIcon { get; }

        [Option(Alias = "ShowUsedMemory", DefaultValue = "false")]
        bool ShowUsedMemory { get; }

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
    }

    public static class AppSettings
    {
        public static readonly IAppSettings ApplicationSettings =
            new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();
    }
}