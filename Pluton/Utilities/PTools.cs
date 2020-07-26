using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Pluton.Utilities
{
    public static class PTools
    {

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
    }
}
