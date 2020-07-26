using System;
using System.Runtime.InteropServices;


namespace Pluton.Utilities
{
    public static class PConsoleWindow
    {

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        private const int MF_BYCOMMAND = 0x00000000;
        private const int SC_CLOSE = 0xF060;
        private const int SC_MINIMIZE = 0xF020;
        private const int SC_MAXIMIZE = 0xF030;
        private const int SC_SIZE = 0xF000;

        // HIDE CONSOLE.
        public static void HideConsole()
        {
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
        }

        // SHOW CONSOLE.
        public static void ShowConsole()
        {
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_SHOW);
        }

        // WINDOW CANNOT BE RESIZED ANYMORE.
        public static void NoResizable()
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);


            DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
        }

        // CANNOT INTERACT ANYMORE WITH WINDOW BAR BUTTONS (_ ☐ X)
        public static void DisableBarButtons()
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            DeleteMenu(sysMenu, SC_CLOSE, MF_BYCOMMAND);
            DeleteMenu(sysMenu, SC_MINIMIZE, MF_BYCOMMAND);
            DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
        }
    }
}
