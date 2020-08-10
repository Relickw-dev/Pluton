using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
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
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent,
        IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        

        /// <summary>
        /// Hide task bar.
        /// </summary>
        public void HideTaskBar()
        {
            int hwnd = FindWindow(TASK_BAR_WINDOW, "");
            ShowWindow(hwnd, SW_HIDE);
        }
        /// <summary>
        /// Show task bar.
        /// </summary>
        public void ShowTaskBar()
        {
            int hwnd = FindWindow(TASK_BAR_WINDOW, "");
            ShowWindow(hwnd, SW_SHOW);
        }
        /// <summary>
        /// Switch between light and dark theme.
        /// </summary>
        /// <param name="light">true = light theme; false = dark theme</param>
        public void SetTheme(bool light)
        {
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
        private RegistryKey GetPersonalizeKey() => Registry.CurrentUser.OpenSubKey(PERSONALIZE_REGISTRY_KEY, true);
    }
}
