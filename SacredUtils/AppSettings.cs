using Config.Net;

namespace SacredUtils
{
    public interface IAppSettings
    {
        [Option(Alias = "AcceptLicense", DefaultValue = "false")]
        bool AcceptLicense { get; set; }

        [Option(Alias = "AllowExperimentalScale", DefaultValue = "false")]
        bool AllowExperimentalScale { get; set; }

        [Option(Alias = "AppUiLanguage", DefaultValue = "based on system")]
        string AppUiLanguage { get; set; }

        [Option(Alias = "ArchiveOldFileOnStartup", DefaultValue = "true")]
        bool ArchiveOldFileOnStartup { get; set; }

        [Option(Alias = "CheckAutoAlphaUpdate", DefaultValue = "false")]
        bool CheckAutoAlphaUpdate { get; set; }

        [Option(Alias = "CheckAutoUpdate", DefaultValue = "true")]
        bool CheckAutoUpdate { get; set; }

        [Option(Alias = "CloseDonateDialogAfterSelect", DefaultValue = "true")]
        bool CloseDonateDialogAfterSelect { get; set; }

        [Option(Alias = "ClosePageDialogAfterSelect", DefaultValue = "true")]
        bool ClosePageDialogAfterSelect { get; set; } 

        [Option(Alias = "ColorTheme", DefaultValue = "light")]
        string ColorTheme { get; set; }

        [Option(Alias = "ConfigFileCreate", DefaultValue = "false")]
        bool ConfigFileCreate { get; set; }

        [Option(Alias = "DebugFileCreate", DefaultValue = "false")]
        bool DebugFileCreate { get; set; }

        [Option(Alias = "DisableCachingGameComponents", DefaultValue = "false")]
        bool DisableCachingGameComponents { get; set; }

        [Option(Alias = "DisableFootSteps", DefaultValue = "false")]
        bool DisableFootSteps { get; set; }

        [Option(Alias = "DisableLogging", DefaultValue = "false")]
        bool DisableLogging { get; set; }

        [Option(Alias = "DisableTelemetry", DefaultValue = "false")]
        bool DisableTelemetry { get; set; }

        [Option(Alias = "EnableArchiveFileCompression", DefaultValue = "true")]
        bool EnableArchiveFileCompression { get; set; }

        [Option(Alias = "EnableHealthCircles", DefaultValue = "true")]
        bool EnableHealthCircles { get; set; }

        [Option(Alias = "GameVoiceover", DefaultValue = "based on language")]
        string GameVoiceover { get; set; }

        [Option(Alias = "KeyGotoMainMenu", DefaultValue = "Escape")]
        string KeyGotoMainMenu { get; set; }

        [Option(Alias = "KeyOpenSacredUtilsDirectory", DefaultValue = "F3")]
        string KeyOpenSacredUtilsDirectory { get; set; }

        [Option(Alias = "KeyOpenSacredUtilsLogs", DefaultValue = "F1")]
        string KeyOpenSacredUtilsLogs { get; set; }

        [Option(Alias = "KeyOpenSacredUtilsSettings", DefaultValue = "F2")]
        string KeyOpenSacredUtilsSettings { get; set; }

        [Option(Alias = "KeyReloadFastSacredUtils", DefaultValue = "F6")]
        string KeyReloadFastSacredUtils { get; set; }

        [Option(Alias = "KeyReloadSacredUtils", DefaultValue = "F4")]
        string KeyReloadSacredUtils { get; set; }

        [Option(Alias = "KeyShutdownSacredUtils", DefaultValue = "F5")]
        string KeyShutdownSacredUtils { get; set; }

        [Option(Alias = "LicenseFileCreate", DefaultValue = "true")]
        bool LicenseFileCreate { get; set; }

        [Option(Alias = "LoggingMethodName", DefaultValue = "false")]
        bool LoggingMethodName { get; set; }

        [Option(Alias = "MakeAutoBackupConfigs", DefaultValue = "true")]
        bool MakeAutoBackupConfigs { get; set; }

        [Option(Alias = "MaxApplicationBackupFiles", DefaultValue = "10")]
        int MaxApplicationBackupFiles { get; set; }

        [Option(Alias = "MaxArchiveFiles", DefaultValue = "10")]
        int MaxArchiveFiles { get; set; }

        [Option(Alias = "MaxGameBackupFiles", DefaultValue = "10")]
        int MaxGameBackupFiles { get; set; }

        [Option(Alias = "NLogConfigFileCreate", DefaultValue = "false")]
        bool NLogConfigFileCreate { get; set; }

        [Option(Alias = "RemoveTempContent", DefaultValue = "true")]
        bool RemoveTempContent { get; set; }

        [Option(Alias = "SacredStartArgs", DefaultValue = 1)]
        int SacredStartArgs { get; set; }

        [Option(Alias = "SacredUtilsGuiScale", DefaultValue = "1.0")]
        double SacredUtilsGuiScale { get; set; }

        [Option(Alias = "ShowChangeLog", DefaultValue = "true")]
        bool ShowChangeLog { get; set; }

        [Option(Alias = "ShowUsedMemory", DefaultValue = "false")]
        bool ShowUsedMemory { get; set; }

        [Option(Alias = "ShowUsedMemoryUpdateInterval", DefaultValue = "2")]
        int ShowUsedMemoryUpdateInterval { get; set; }

        [Option(Alias = "UseOldSacredTextures", DefaultValue = "false")]
        bool UseOldSacredTextures { get; set; }

        [Option(Alias = "UseStaticBog", DefaultValue = "false")]
        bool UseStaticBog { get; set; }

        [Option(Alias = "UseStaticLava", DefaultValue = "false")]
        bool UseStaticLava { get; set; }

        [Option(Alias = "UseStaticWater", DefaultValue = "false")]
        bool UseStaticWater { get; set; }

        [Option(Alias = "WhatIsThisDoingHere", DefaultValue = "true")]
        bool WhatIsThisDoingHere { get; set; }
    }

    public static class AppSettings
    {
        public static readonly IAppSettings ApplicationSettings =
            new ConfigurationBuilder<IAppSettings>()
                .UseJsonFile("$SacredUtils\\conf\\settings.json").Build();
    }
}