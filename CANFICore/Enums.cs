using System;
using System.Reflection;
using System.Threading;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.IO;
using System.Globalization;
using System.Collections;

namespace CANFICore
{
    // enum for CANFI's measurement mode
    public enum MMODE
    {
        A = 1,
        B = 2,
        C = 3
    }

    // enum for CANFI's current state
    public enum STATE
    {
        NONE = 0,
        INIT = 1,
        IDLE = 2,
        CALIBRATING = 3,
        MEASURING = 5
    }

    // enum for CANFI's calibration state
    public enum CALSTATE
    {
        NONE = 0,
        CALIBRATED = 1
    }

    // enum for CANFI's report progress
    public enum PROGRESS
    {
        ERROR = -1,
        INIT = 0,
        STATUS = 1,
        MESSAGE = 2,
        FINISHED = 100,
        FFT = 101
    }
}
