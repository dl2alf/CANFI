using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.IO;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;

namespace CANFICore
{
    public static class SupportFunctions
    {
        public static double TodB(double value)
        {
            // calulate dB from linear value
            return 10.0f * Math.Log10(value);
        }

        public static double ToLinear(double value)
        {
            // calculate linear value from dB
            return Math.Pow(10, value / 10.0f);
        }

        public static bool IsLinux
        {
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                return (p == 4) || (p == 6) || (p == 128);
            }
        }
    }
}
