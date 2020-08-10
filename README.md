<div align="center">
<img width=15% src="/Art/Pluton.png">
<br />
<h1>Pluton</h1>
<br/>
<a href="https://github.com/Relickw-dev/Pluton/releases">
   <img src="https://img.shields.io/github/downloads/Relickw-dev/Pluton/total.svg">
</a>
<a>
	<img src="https://img.shields.io/github/forks/Relickw-dev/Pluton" />
	<img src="https://img.shields.io/github/stars/Relickw-dev/Pluton" />
</a>      
</div>

### Process Class:

```c#
using Pluton.Utilities;

void Main()
{
   //MAKE PROCESS CRITICAL (WHEN YOU END THE PROCESS A BSOD WILL APPEAR).
   PProcess.MakeCritical();
}
```

### Console Window Class:

```c#
using Pluton.Utilities;

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
using Pluton.Utilities;

void Main()
{
   //SHUTDOWN THE COMPUTER
   PTools.Shutdown();
   
   //RESTART THE COMPUTER
   PTools.Reboot();

   //MAKE A SCREENSHOT AND SAVE IT IN YOUR PROGRAM DIRECTORY.
   PTools.Screenshot();
   
   //CLEAR SYSTEM TEMP
   PTools.ClearSystemTemp();
   
   //CLEAR USER TEMP
   PTools.ClearUserTemp();
   
   //CLEAR RECYCLE BIN
   PTools.ClearRecycleBin();

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

### Desktop Class:

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

### Network Class:

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
