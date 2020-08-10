namespace Pluton.Constants
{
    class PNetworkConstants
    {
        internal const string DEFAULT_IP_SOURCE_URL = "http://icanhazip.com";
        internal const string DEFAULT_IP_ON_FAIL = "0.0.0.0";
        internal const string ENABLE_INTERNET_CONNECTION = "/C ipconfig /renew";
        internal const string DISABLE_INTERNET_CONNECTION = "/C ipconfig /release";
        internal const string COMMAND_LINE_PROCESS = "cmd.exe";
    }
}
