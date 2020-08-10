using System;
using System.Diagnostics;
using System.Net;
using static Pluton.Constants.PNetworkConstants;

namespace Pluton.WindowsSystemFeatures
{
    public class PNetwork
    {
        /// <summary>
        /// Get public IP.
        /// </summary>
        public string GetPublicIP
        {
            get
            {
                try
                {
                    return new WebClient().DownloadString(DEFAULT_IP_SOURCE_URL);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return DEFAULT_IP_ON_FAIL;
                }
            }
        }
        /// <summary>
        /// Download a file and execute it.
        /// </summary>
        /// <param name="url">File url.</param>
        /// <param name="filePath">File path.</param>
        public void DownloadAndExecute(string url, string filePath)
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
        public void Download(string url, string filePath)
        {
            WebClient wbb = new WebClient();
            wbb.DownloadFile(url, filePath);
        }
        /// <summary>
        /// Enable or disable the internet connection.
        /// </summary>
        /// <param name="enable">true = enable; false = disable</param>
        public void InternetConnection(bool enable)
        {
            string args = enable ? ENABLE_INTERNET_CONNECTION : DISABLE_INTERNET_CONNECTION;

            ProcessStartInfo internet = new ProcessStartInfo()
            {
                FileName = COMMAND_LINE_PROCESS,
                Arguments = args,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(internet);
        }
    }
}
