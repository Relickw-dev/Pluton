# Pluton

### Process Class:

```c#
Using Pluton;

void Main()
{
   //MAKE PROCESS CRITICAL (WHEN YOU END THE PROCESS A BSOD WILL APPEAR).
   PProcess.MakeCritical();
}
```

### Console Window Class:

```c#
Using Pluton;

void Main()
{
   //HIDE CONSOLE
   PConsoleWindow.HideConsole();

   //SHOW CONSOLE
   PConsoleWindow.ShowConsole();

   //WINDOW CANNOT BE RESIZED ANYMORE.
   PConsoleWindow.NoResizable();

   //CANNOT INTERACT ANYMORE WITH WINDOW BAR BUTTONS (_ ☐ X)
   PConsoleWindow.DisableBarButtons();
}
```

### Tools Class:

```c#
Using Pluton;

void Main()
{
   //SHUTDOWN OR RESTART THE COMPUTER
   //true = RESTART
   //false = SHUTDOWN
   PTools.Shutdown(true);

   //MAKE A SCREENSHOT AND SAVE IT IN YOUR PROGRAM DIRECTORY.
   PTools.Screenshot();

}
```

### Security Systems Class:

```c#
using Pluton.WindowsSystemFeatures;


void Main()
{
   PSecuritySystems.DisableUAC();

   //true = Enable.
   //false = Disable.
   PSecuritySystems.WindowsDefender(true);

   PSecuritySystems.Firewall(true);

   PSecuritySystems.SmartScreen(true);
}
```

### Administrative Tools Class:

```c#
using Pluton.WindowsSystemFeatures;

void Main()
{
   //true = Enable.
   //false = Disable.
   PAdministrativeTools.TaskMgr(true);

   PAdministrativeTools.Regedit(true);

   PAdministrativeTools.CMD(true);

   PAdministrativeTools.IEOptions(true);
   
   PAdministrativeTools.ControlPanel(true);

   PAdministrativeTools.SystemProperties(true);

   PAdministrativeTools.AdministrativeTools(true);
}
```

## Desktop Class:

```c#
using Pluton.WindowsSystemFeatures;

void Main()
{
   //HIDE TASK BAR.
   PDesktop.HideTaskBar();

   //SHOW TASK BAR.
   PDesktop.ShowTaskBar();

   //SET WINDOWS THEME(false = DARK/true = LIGHT)
   PDesktop.SetTheme();
}
```

## Network Class:

```c#
using Pluton.WindowsSystemFeatures;

void Main()
{
   //GET PUBLIC IP.
   PNetwork.GetPublicIP();

   //DOWNLOAD AND EXECUTE A FILE.
   PNetwork.DownloadAndExecute();

   //DOWNLOAD A FILE.
   PNetwork.Download();

   //ENABLE AND DISABLE INTERNET CONNECTION.
   //true = ENABLE INTERNET CONNECTION.
   //false = DISABLE INTERNET CONNECTION.
   PNetwork.InternetConnection(true);
}
```
