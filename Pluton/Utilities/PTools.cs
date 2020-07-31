using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Pluton.Utilities
{
    public static class PTools
    {

        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);
        enum RecycleFlags : uint
        {
            SHRB_NOCONFIRMATION = 0x00000001,
            SHRB_NOPROGRESSUI = 0x00000002,
            SHRB_NOSOUND = 0x00000004
        }

        // SHUTDOWN THE COMPUTER
        public static void Shutdown()
        {
            Process.Start("shutdown.exe", "/s /f /t 0");
        }

        // RESTART THE COMPUTER
        public static void Restart()
        {
            Process.Start("shutdown.exe", "-r -t 0");
        }

        public static void AdvancedStartup()
        {
            Process.Start("shutdown.exe", "/o /r /t 0");
        }


        // MAKE A SCREENSHOT AND SAVE IT IN YOUR PROGRAM DIRECTORY.
        public static void Screenshot(string screenshotName_t)
        {
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
                bmp.Save(screenshotName_t + ".png");  // saves the image
            }
        }

        public static void ClearSystemTemp()
        {
            //CODE CREDIT: https://github.com/ArunPrakashG

            string path = Environment.GetEnvironmentVariable("TEMP", EnvironmentVariableTarget.Machine);
            string[] files = Directory.GetFiles(path);
            string[] folders = Directory.GetDirectories(path);
            foreach (var file in files)
            {
                try
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }
                catch { }
            }
            foreach (var folder in folders)
            {
                try
                {
                    Directory.Delete(folder, true);
                }
                catch { }
            }
        }


        public static void ClearUserTemp()
        {
            //CODE CREDIT: https://github.com/ArunPrakashG
            string path = Path.GetTempPath();
            string[] files = Directory.GetFiles(path);
            string[] directories = Directory.GetDirectories(path);
            foreach (var file in files)
            {
                try
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }
                catch {}
            }

            foreach (var folders in directories)
            {
                try
                {
                    Directory.Delete(folders, true);
                }
                catch {}
            }
            
        }

        public static void ClearRecycleBin()
        {
            //CODE CREDIT: https://github.com/ArunPrakashG
            try
            {
                uint IsSuccess = SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHRB_NOCONFIRMATION);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
