using System.Diagnostics;
using System.Net;

namespace Pluton.WindowsSystemFeatures
{
    public static class PNetwork
    {
        /// <summary>
        /// Get public IP.
        /// </summary>
        public static string GetPublicIP
        {
            get
            {
                return new WebClient().DownloadString("http://icanhazip.com");
            }
        }

        /// <summary>
        /// Download a file and execute it.
        /// </summary>
        /// <param name="url">File url.</param>
        /// <param name="filePath">File path.</param>
        public static void DownloadAndExecute(string url, string filePath)
        {
            WebClient wbb = new WebClient();
            wbb.DownloadFile(url, filePath);
            Process.Start(filePath);
        }

        /// <summary>
        /// Download a file.
        /// </summary>
        /// <param name="url">File url.</param>
        /// <param name="filePath">File path.</param>
        public static void Download(string url, string filePath)
        {
            WebClient wbb = new WebClient();
            wbb.DownloadFile(url, filePath);
        }

        /// <summary>
        /// Enable or disable the internet connection.
        /// </summary>
        /// <param name="enable">true = enable; false = disable</param>
        public static void InternetConnection(bool enable)
        {
            string args = enable ? "/C ipconfig /renew" : "/C ipconfig /release";

            ProcessStartInfo internet = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                Arguments = args,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(internet);
        }
    }
}
