using System;
using System.Runtime.InteropServices;
using static Pluton.Constants.PConsoleWindowConstants;

namespace Pluton.Utilities
{
    public class PConsoleWindow
    {

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);
        [DllImport("kernel32.dll")]
        static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);
        [DllImport("kernel32.dll")]
        static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        /// <summary> 
        /// Hide console window. 
        /// </summary>
        public static void HideConsole()
        {
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
        }
        /// <summary>
        /// Show console window. 
        /// </summary>
        public static void ShowConsole()
        {
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_SHOW);
        }
        /// <summary>
        /// You can no longer resize the window
        /// </summary>
        public static void NoResizable()
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);
            DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
        }
        /// <summary>
        /// You can no longer interact with window bar buttons(_ ☐ X).
        /// </summary>
        public static void DisableBarButtons()
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);
            DeleteMenu(sysMenu, SC_CLOSE, MF_BYCOMMAND);
            DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);
            DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
        }
        /// <summary>
        /// Disable quick edit mode.
        /// </summary>
        /// <returns>Returns false if the operation failed.</returns>
        public static bool DisableQuickEditMode()
        {
            IntPtr consoleHandle = GetStdHandle(STD_INPUT_HANDLE);
            uint consoleMode;
            if (!GetConsoleMode(consoleHandle, out consoleMode))
                return false;
            consoleMode &= ~ENABLE_QUICK_EDIT;
            if (!SetConsoleMode(consoleHandle, consoleMode))
                return false;
            return true;
        }
    }
}
