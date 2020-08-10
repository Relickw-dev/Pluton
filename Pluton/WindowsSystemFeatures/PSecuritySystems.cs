using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Linq;
using static Pluton.Constants.PSecuritySistemsConstants;


namespace Pluton.WindowsSystemFeatures
{
    public class PSecuritySystems
    {
        /// <summary>
        /// Enable or disable windows defender.
        /// </summary>
        /// <param name="enable">true = enable; false = disable </param>
        public void WindowsDefender(bool enable)
        {
            try
            {
                RegistryKey disableAntiSpyware = Registry.LocalMachine.CreateSubKey(WINDOWS_DEFENDER_REGISTRY_KEY);
                RegistryKey disableAntivirus = Registry.LocalMachine.CreateSubKey(REAL_TIME_PROTECTION_REGISTRY_KEY);
                if (!enable)
                {
                    disableAntiSpyware.SetValue(DISABLE_ANTI_SPYWARE_REGISTRY_VALUE, STRING_1, RegistryValueKind.DWord);
                    disableAntivirus.SetValue(DISABLE_BEHAVIOR_MONITORING_REGISTRY_VALUE, STRING_1, RegistryValueKind.DWord);
                    disableAntivirus.SetValue(DISABLE_SCAN_ON_REALTIME_REGISTRY_VALUE, STRING_1, RegistryValueKind.DWord);
                    disableAntivirus.SetValue(DISABLE_ON_ACCES_PROTECTION_REGISTRY_VALUE, STRING_1, RegistryValueKind.DWord);
                }
                else
                {
                    disableAntiSpyware.DeleteValue(DISABLE_ANTI_SPYWARE_REGISTRY_VALUE);
                    disableAntivirus.DeleteValue(DISABLE_BEHAVIOR_MONITORING_REGISTRY_VALUE);
                    disableAntivirus.DeleteValue(DISABLE_SCAN_ON_REALTIME_REGISTRY_VALUE);
                    disableAntivirus.DeleteValue(DISABLE_ON_ACCES_PROTECTION_REGISTRY_VALUE);
                }
                disableAntivirus.Close();
                disableAntiSpyware.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        /// <summary>
        /// Enable or disable firewall.
        /// </summary>
        /// <param name="enable">true = enable; false = disable </param>
        public void Firewall(bool enable)
        {
            string args = enable ? ENABLE_FIREWALL : DISABLE_FIREWALL;
            Process proc = new Process();
            string top = NETSH_PROCESS;
            proc.StartInfo.Arguments = args;
            proc.StartInfo.FileName = top;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            proc.WaitForExit();
        }
        /// <summary>
        /// Enable or disable smart screen.
        /// </summary>
        /// <param name="enable">true = enable; false = disable </param>
        public void SmartScreen(bool enable)
        {
            try
            {
                RegistryKey disableSmartscreen = Registry.LocalMachine.CreateSubKey(SYSTEM_REGISTRY_KEY);
                disableSmartscreen.SetValue(ENABLE_SMART_SCREEN_REGISTRY_VALUE, enable ? STRING_1 : STRING_0, RegistryValueKind.DWord);
                disableSmartscreen.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// Disable user account control.
        /// </summary>
        public void DisableUAC()
        {
            try
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Action Center\Checks\{C8E6F269-B90A-4053-A3BE-499AFCEC98C4}.check.0", CHECK_SETTING_REGISTRY_VALUE, StringToByteArray("23004100430042006C006F00620000000000000000000000010000000000000000000000"), RegistryValueKind.Binary);
                RegistryKey uac = Registry.LocalMachine.OpenSubKey(SYSTEM_REGISTRY_KEY_2, true);
                uac = Registry.LocalMachine.CreateSubKey(SYSTEM_REGISTRY_KEY_2);
                uac.SetValue(CONSENT_PROMPT_BEHAVIOR_ADMIN_REGISTRY_VALUE, INT32_0);
                uac.SetValue(PROMPT_ON_SECURE_DESKTOP_REGISTRY_VALUE, INT32_0);
                uac.SetValue(ENAMBLE_LUA_REGISTRY_VALUE, INT32_0);
                uac.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
