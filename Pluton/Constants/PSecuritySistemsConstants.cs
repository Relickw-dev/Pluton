using System;

namespace Pluton.Constants
{
    class PSecuritySistemsConstants
    {
        internal const string STRING_1 = "1";
        internal const string STRING_0 = "0";
        internal const string SYSTEM_REGISTRY_KEY = @"Software\Policies\Microsoft\Windows\System";
        internal const string SYSTEM_REGISTRY_KEY_2 = @"Software\Microsoft\Windows\CurrentVersion\Policies\System";
        internal const string WINDOWS_DEFENDER_REGISTRY_KEY = @"Software\Policies\Microsoft\Windows Defender";
        internal const string REAL_TIME_PROTECTION_REGISTRY_KEY = @"Software\Policies\Microsoft\Windows Defender\Real-Time Protection";
        internal const string DISABLE_ANTI_SPYWARE_REGISTRY_VALUE = "DisableAntiSpyware";
        internal const string DISABLE_BEHAVIOR_MONITORING_REGISTRY_VALUE = "DisableBehaviorMonitoring";
        internal const string DISABLE_SCAN_ON_REALTIME_REGISTRY_VALUE = "DisableScanOnRealtimeEnable";
        internal const string DISABLE_ON_ACCES_PROTECTION_REGISTRY_VALUE = "DisableOnAccessProtection";
        internal const string ENABLE_FIREWALL = "advfirewall set allprofiles state on";
        internal const string DISABLE_FIREWALL = "advfirewall set allprofiles state off";
        internal const string NETSH_PROCESS = "netsh.exe";
        internal const string ENABLE_SMART_SCREEN_REGISTRY_VALUE = "EnableSmartScreen";
        internal const string CHECK_SETTING_REGISTRY_VALUE = "CheckSetting";
        internal const string CONSENT_PROMPT_BEHAVIOR_ADMIN_REGISTRY_VALUE = "ConsentPromptBehaviorAdmin";
        internal const string PROMPT_ON_SECURE_DESKTOP_REGISTRY_VALUE = "ConsentPromptBehaviorAdmin";
        internal const string ENAMBLE_LUA_REGISTRY_VALUE = "EnableLUA";
        internal const Int32 INT32_0 = 0;
    }
}
