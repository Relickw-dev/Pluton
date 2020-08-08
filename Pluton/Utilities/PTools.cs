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


        /// <summary> 
        /// Shutdown the computer. 
        /// </summary>
        public static void Shutdown()
        {
            Process.Start("shutdown.exe", "/s /f /t 0");
        }

        /// <summary> 
        /// Restart the computer. 
        /// </summary>
        public static void Restart()
        {
            Process.Start("shutdown.exe", "-r -t 0");
        }

        /// <summary> 
        /// Restart the computer in advanced mode. 
        /// </summary>
        public static void AdvancedStartup()
        {
            Process.Start("shutdown.exe", "/o /r /t 0");
        }

        /// <summary> 
        /// Make a screenshot. 
        /// </summary>
        /// <param name="screenshotName">
        /// Name of the output file.
        /// </param>
        public static void Screenshot(string screenshotName)
        {
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
                bmp.Save(screenshotName + ".png");  // saves the image
            }
        }

        /// <summary> 
        /// Clear system temp. 
        /// </summary>
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

        /// <summary> 
        /// Clear user temp. 
        /// </summary>
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

        /// <summary> 
        /// Clear recycle bin. 
        /// </summary>
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
