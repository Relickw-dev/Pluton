using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pluton.WindowsSystemFeatures
{
    public static class PAdministrativeTools
    {
        public static void TaskMgr(bool enable)
        {
            try
            {
                RegistryKey disableTaskMgr = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                disableTaskMgr.SetValue("DisableTaskMgr", enable ? "1`" : "0");
                disableTaskMgr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void Regedit(bool enable)
        {
            try
            {
                RegistryKey disableRegedit = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
                if (!enable)
                {
                    disableRegedit.SetValue("DisableRegistryTools", "1", RegistryValueKind.DWord);
                    disableRegedit.Close();
                }
                else
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

        public static void CMD(bool enable)
        {
            try
            {
                RegistryKey disableCMD = Registry.CurrentUser.CreateSubKey(@"Software\Policies\Microsoft\Windows\System");
                if (!enable)
                {
                    disableCMD.SetValue("DisableCMD", "1", RegistryValueKind.DWord);
                    disableCMD.Close();
                }
                else
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

        public static void IEOptions(bool enable)
        {
            try
            {
                RegistryKey disableIEOptions = Registry.CurrentUser.CreateSubKey(@"Software\Policies\Microsoft\Internet Explore\Restrictions");
                if (!enable)
                {
                    disableIEOptions.SetValue("NoBrowserOptions", "1", RegistryValueKind.DWord);
                    disableIEOptions.Close();
                }
                else
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

        public static void ControlPanel(bool enable)
        {
            try
            {
                RegistryKey disabeControlPanel = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                if (!enable)
                {
                    disabeControlPanel.SetValue("NoControlPanel", "1", RegistryValueKind.DWord);
                    disabeControlPanel.Close();
                }
                else
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

        public static void SystemProperties(bool enable)
        {
            try
            {
                RegistryKey disableSystemProperties = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer");
                if (!enable)
                {
                    disableSystemProperties.SetValue("NoPropertiesMyComputer", "1", RegistryValueKind.DWord);
                    disableSystemProperties.Close();
                }
                else
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

        public static void AdministrativeTools(bool enable)
        {
            try
            {
                RegistryKey HideAdministrativeTools = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced");
                HideAdministrativeTools.SetValue("StartMenuAdminTools", enable ? "1" : "0", RegistryValueKind.DWord);
                HideAdministrativeTools.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
