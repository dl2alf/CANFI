using System;
using System.Reflection;
using System.Threading;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.IO;
using System.Globalization;
using System.Collections;
using System.Configuration;

namespace CANFICore
{
    // enum for CANFI's measurement mode
    public enum MMODE
    {
        A = 1,  // Measuring of Amplifiers in Direct Mode
        B = 2,  // Measuring of Converters in Coverter Mode
        C = 3   // Measuring of Amplifiers with Converter Mode
    }

    // enum for CANFI's sweep mode
    public enum SMODE
    {
        NONE= 0,        // no sweep
        SINGLE = 1,     // single shot
        CONTINUOS =2    // continuos mode
    }

    // enum for CANFI's current state
    public enum STATE
    {
        NONE = 0,           // invalid
        INIT = 1,           // initialization
        IDLE = 2,           // idling
        CALIBRATING = 3,    // calibrating
        MEASURING = 5,      // measuring
        SETTING = 255       // changing settings      
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

    // enum for CANFI's FFT filter algorithm
    public enum FFTALGORITHM
    {
        NONE = 0,
        LOMONT = 1,
        FFTW = 2
    }
}
