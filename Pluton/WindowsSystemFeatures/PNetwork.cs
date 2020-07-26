using System;
using System.Diagnostics;
using System.Net;

namespace Pluton.WindowsSystemFeatures
{
    public static class PNetwork
    {
        // GET PUBLIC IP.
        public static void GetPublicIP()
        {
            string externalip = new WebClient().DownloadString("http://icanhazip.com");
            Console.WriteLine(externalip);
        }

        // DOWNLOAD THE FILE AND EXECUTE IT.
        public static void DownloadAndExecute(string url, string filePath)
        {
            WebClient wbb = new WebClient();
            wbb.DownloadFile(url, filePath);
            Process.Start(filePath);
        }

        // JUST DOWNLOAD A FILE.
        public static void Download(string url, string filePath)
        {
            WebClient wbb = new WebClient();
            wbb.DownloadFile(url, filePath);
        }

        // ENABLE AND DISABLE INTERNET CONNECTION.
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
