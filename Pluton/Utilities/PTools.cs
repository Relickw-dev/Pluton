using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Pluton.Constants.PToolsConstants;

namespace Pluton.Utilities
{
    public class PTools
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
            Process.Start(SHUTDOWN_PROCESS, SHUTDOWN_ARGS);
        }
        /// <summary> 
        /// Restart the computer. 
        /// </summary>
        public static void Restart()
        {
            Process.Start(SHUTDOWN_PROCESS, RESTART_ARGS);
        }
        /// <summary> 
        /// Restart the computer in advanced mode. 
        /// </summary>
        public static void AdvancedStartup()
        {
            Process.Start(SHUTDOWN_PROCESS, ADVANCED_STARTUP_ARGS);
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
                bmp.Save(screenshotName + PNG_IMAGE_FORMAT);  // saves the image
            }
        }
        /// <summary> 
        /// Clear system temp. 
        /// </summary>
        public static void ClearSystemTemp()
        {
            //CODE CREDIT: https://github.com/ArunPrakashG
            string path = Environment.GetEnvironmentVariable(TEMP_ENVIRONMENT_VARIABLE, EnvironmentVariableTarget.Machine);
            ClearAFolder(path);
        }
        /// <summary> 
        /// Clear user temp. 
        /// </summary>
        public static void ClearUserTemp()
        {
            //CODE CREDIT: https://github.com/ArunPrakashG

            string path = Path.GetTempPath();
            ClearAFolder(path);
        }
        /// <summary>
        /// Clear download folder.
        /// </summary>
        public static void ClearDownloadFolder()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
            ClearAFolder(path);
        }
        /// <summary>
        /// Clear prefetch.
        /// </summary>
        public static void ClearPrefetch()
        {

            string path = Environment.ExpandEnvironmentVariables(SYSTEM_ROOT_ENVIRONMENT_VARIABLE) + PREFETCH_FOLDER;
            ClearAFolder(path);
            
        }
        /// <summary> 
        /// Clear recycle bin. 
        /// </summary>
        public static void ClearRecycleBin()
        {
            //CODE CREDIT: https://github.com/ArunPrakashG
            uint IsSuccess = SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHRB_NOCONFIRMATION);
        }
        /// <summary>
        /// Clear a folder.
        /// </summary>
        /// <param name="path">Path of the folder.</param>
        public static void ClearAFolder(string path)
        {
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
        /// Toggle caps lock.
        /// </summary>
        public static void ToggleCaps()
        {
            string filepath = Path.GetTempPath() + TOGGLE_CAPS_VBS_FILE_NAME;
            if (!File.Exists(filepath))
                File.WriteAllLines(filepath, TOGGLE_CAPS_VBS_LINES);
            Process.Start(filepath);
        }
    }
}
