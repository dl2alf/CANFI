//
// CANFI (C)heap (A)utomatic (N)oise (F)igure (I)ndicator 
// Copyright (C) 2015 DL2ALF
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.

// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
//

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

    // enum for CAMFI's tone output
    public enum TONEOUTPUT
    {
        NONE = 0,
        NF = 1,
        GAIN = 2
    }
}
