using Microsoft.Win32;
using System;
using static Pluton.Constants.PAdministrativeToolsConstants;

namespace Pluton.WindowsSystemFeatures
{
    public class PAdministrativeTools
    {
        /// <summary>
        /// Enable or disable task manager.
        /// </summary>
        /// <param name="enable">true = enable; false = disable</param>
        public static void TaskMgr(bool enable)
        {
            try
            {
                RegistryKey disableTaskMgr = Registry.CurrentUser.CreateSubKey(SYSTEM_REGISTRY_KEY);
                disableTaskMgr.SetValue(DISABLE_TASK_MANAGER_REGISTRY_VALUE, enable ? ENABLE : DISABLE);
                disableTaskMgr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// Enable or disable registry editor.
        /// </summary>
        /// <param name="enable">true = enable; false = disable</param>
        public static void Regedit(bool enable)
        {
            try
            {
                RegistryKey disableRegedit = Registry.CurrentUser.CreateSubKey(SYSTEM_REGISTRY_KEY);
                if (!enable)
                    disableRegedit.SetValue(DISABLE_REGISTRY_TOOLS_REGISTRY_VALUE, DISABLE, RegistryValueKind.DWord);
                else
                    disableRegedit.DeleteValue(DISABLE_REGISTRY_TOOLS_REGISTRY_VALUE);
                disableRegedit.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// Enable or disable command line.
        /// </summary>
        /// <param name="enable">true = enable; false = disable</param>
        public static void CMD(bool enable)
        {
            try
            {
                RegistryKey disableCMD = Registry.CurrentUser.CreateSubKey(SYSTEM_REGISTRY_KEY_2);
                if (!enable)
                    disableCMD.SetValue(DISABLE_CMD_REGISTRY_VALUE, DISABLE, RegistryValueKind.DWord);
                else
                    disableCMD.DeleteValue(DISABLE_CMD_REGISTRY_VALUE);
                disableCMD.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// Enable or disable internet explorer options.
        /// </summary>
        /// <param name="enable">true = enable; false = disable</param>
        public static void IEOptions(bool enable)
        {
            try
            {
                RegistryKey disableIEOptions = Registry.CurrentUser.CreateSubKey(RESTRICTIONS_REGISTRY_KEY);
                if (!enable)
                    disableIEOptions.SetValue(DISABLE_IE_REGISTRY_VALUE, DISABLE, RegistryValueKind.DWord);
                else
                    disableIEOptions.DeleteValue(DISABLE_IE_REGISTRY_VALUE);
                disableIEOptions.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// Enable or disable control panel and windows settings.
        /// </summary>
        /// <param name="enable">true = enable; false = disable</param>
        public static void ControlPanel(bool enable)
        {
            try
            {
                RegistryKey disabeControlPanel = Registry.CurrentUser.CreateSubKey(EXPLORER_REGISTRY_KEY);
                if (!enable)
                    disabeControlPanel.SetValue(DISABLE_CONTROL_PANEL_REGISTRY_VALUE, DISABLE, RegistryValueKind.DWord);
                else
                    disabeControlPanel.DeleteValue(DISABLE_CONTROL_PANEL_REGISTRY_VALUE);
                disabeControlPanel.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        /// <summary>
        /// Enable or disable system properties.
        /// </summary>
        /// <param name="enable">true = enable; false = disable</param>
        public static void SystemProperties(bool enable)
        {
            try
            {
                RegistryKey disableSystemProperties = Registry.CurrentUser.CreateSubKey(EXPLORER_REGISTRY_KEY);
                if (!enable)
                    disableSystemProperties.SetValue(DISABLE_SYSTEM_PROPERTIES_REGISTRY_VALUE, DISABLE, RegistryValueKind.DWord);
                else
                    disableSystemProperties.DeleteValue(DISABLE_SYSTEM_PROPERTIES_REGISTRY_VALUE);
                disableSystemProperties.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
