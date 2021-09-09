using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace NoSleep
{
    public class NoSleepCore
    {
        enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001,
            INVALID = 0
        }
        static EXECUTION_STATE previousState;
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);
        
        public static void PreventSleep()
        {
            previousState = SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS);
        }
        public static void UndoPreventSleep()
        {
            if (previousState != EXECUTION_STATE.INVALID)
            {
                SetThreadExecutionState(previousState | EXECUTION_STATE.ES_CONTINUOUS);
            }
            
        }

       
    }
}
