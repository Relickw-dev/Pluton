namespace Pluton.Constants
{
    class PToolsConstants
    {
        internal const string SHUTDOWN_PROCESS = "shutdown.exe";
        internal const string SHUTDOWN_ARGS = "/s /f /t 0";
        internal const string RESTART_ARGS = "-r -t 0";
        internal const string ADVANCED_STARTUP_ARGS = "-r -t 0";
        internal const string PNG_IMAGE_FORMAT = ".png";
        internal const string TEMP_ENVIRONMENT_VARIABLE = "TEMP";
        internal const string SYSTEM_ROOT_ENVIRONMENT_VARIABLE = "%SYSTEMROOT%";
        internal const string PREFETCH_FOLDER = @"\Prefetch";
        internal const string TOGGLE_CAPS_VBS_FILE_NAME = @"\caps.vbs";
        internal static readonly string[] TOGGLE_CAPS_VBS_LINES = { "Set wshShell = wscript.CreateObject(\"WScript.Shell\")", "wshshell.sendkeys \"{CAPSLOCK}\"" };
    }
}
