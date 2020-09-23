using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using static Pluton.Constants.PDesktopConstants;

namespace Pluton.WindowsSystemFeatures
{
    public class PDesktop
    {
        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent,
        IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        internal static extern int SystemParametersInfo(UAction uAction, int uParam, StringBuilder lpvParam, int fuWinIni);
        internal enum UAction
        {
            SPI_SETDESKWALLPAPER = 0x0014,
        }
        /// <summary>
        /// Hide task bar.
        /// </summary>
        public static void HideTaskBar()
        {
            int hwnd = FindWindow(TASK_BAR_WINDOW, "");
            ShowWindow(hwnd, SW_HIDE);
        }
        /// <summary>
        /// Show task bar.
        /// </summary>
        public static void ShowTaskBar()
        {
            int hwnd = FindWindow(TASK_BAR_WINDOW, "");
            ShowWindow(hwnd, SW_SHOW);
        }
        /// <summary>
        /// Switch between light and dark theme.
        /// </summary>
        /// <param name="light">true = light theme; false = dark theme</param>
        public static void SetTheme(bool light)
        {
            RegistryKey GetPersonalizeKey() => Registry.CurrentUser.OpenSubKey(PERSONALIZE_REGISTRY_KEY, true);
            try
            {
                GetPersonalizeKey().SetValue(APPS_USE_LIGHT_THEME_REGISTRY_VALUE, light ? 1 : 0, RegistryValueKind.DWord);
                GetPersonalizeKey().SetValue(SYSTEM_USE_LIGHT_THEME_REGISTRY_VALUE, light ? 1 : 0, RegistryValueKind.DWord);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// Set desktop background.
        /// </summary>
        /// <param name="imagePath">Image path.</param>
        public static void SetDesktopBackground(string imagePath)
        {
            if (File.Exists(imagePath))
            {
                StringBuilder s = new StringBuilder(imagePath);
                SystemParametersInfo(UAction.SPI_SETDESKWALLPAPER, 0, s, 0x2);
            }
        }
    }
}
