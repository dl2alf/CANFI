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
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;

namespace CANFICore
{
    public enum RtlSdrTunerType
    {
        Unknown = 0,
        E4000,
        FC0012,
        FC0013,
        FC2580,
        R820T
    }

    public enum RtlSdrGainMode
    {
        GAIN_MODE_AGC = 0,
        GAIN_MODE_MANUAL = 1,
        GAIN_MODE_LINEARITY = 2,
        GAIN_MODE_SENSITIVITY = 3,   // special gain mode for sensitivity supported by some special versions of rtlsdr.dll
        GAIN_MODE_PERSTAGE = 4     // special gain mode for setting gains per stage, do not use this value with rtlsdr_set_tuner_gain_mode !!
    }

    public class NativeMethods
    {
        private const string LibRtlSdr = "rtlsdr";

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_get_device_count", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rtlsdr_get_device_count();

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_get_device_name", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr rtlsdr_get_device_name_native(uint index);

        public static string rtlsdr_get_device_name(uint index)
        {
            var strptr = rtlsdr_get_device_name_native(index);
            return Marshal.PtrToStringAnsi(strptr);
        }

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_get_device_usb_strings", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_get_device_usb_strings(uint index, StringBuilder manufact, StringBuilder product, StringBuilder serial);

        // modified to manage special gain settings
        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_open", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_open(out IntPtr dev, uint index);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_close", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_close(IntPtr dev);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_set_xtal_freq", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_set_xtal_freq(IntPtr dev, uint rtlFreq, uint tunerFreq);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_get_xtal_freq", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_get_xtal_freq(IntPtr dev, out uint rtlFreq, out uint tunerFreq);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_get_usb_strings", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_get_usb_strings(IntPtr dev, StringBuilder manufact, StringBuilder product, StringBuilder serial);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_set_center_freq", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_set_center_freq(IntPtr dev, uint freq);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_get_center_freq", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rtlsdr_get_center_freq(IntPtr dev);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_set_freq_correction", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_set_freq_correction(IntPtr dev, int ppm);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_get_freq_correction", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_get_freq_correction(IntPtr dev);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_get_tuner_stage_gains", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_get_tuner_stage_gains(IntPtr dev, Byte stage, [In, Out] int[] gains, StringBuilder description);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_set_tuner_stage_gain", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_set_tuner_stage_gain(IntPtr dev, Byte stage, int gain);

        // modified to manage special gain settings
        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_get_tuner_gains", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_get_tuner_gains(IntPtr dev, [In, Out] int[] gains);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_get_tuner_type", CallingConvention = CallingConvention.Cdecl)]
        public static extern RtlSdrTunerType rtlsdr_get_tuner_type(IntPtr dev);

        // modified to manage special gain settings
        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_set_tuner_gain", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_set_tuner_gain(IntPtr dev, int gain);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_set_tuner_if_gain", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_set_tuner_if_gain(IntPtr dev, int stage, int gain);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_get_tuner_gain", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_get_tuner_gain(IntPtr dev);

        // modified to manage special gain settings
        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_set_tuner_gain_mode", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_set_tuner_gain_mode(IntPtr dev, RtlSdrGainMode mode);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_set_agc_mode", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_set_agc_mode(IntPtr dev, int on);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_set_direct_sampling", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_set_direct_sampling(IntPtr dev, int on);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_set_offset_tuning", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_set_offset_tuning(IntPtr dev, int on);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_set_sample_rate", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_set_sample_rate(IntPtr dev, uint rate);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_get_sample_rate", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint rtlsdr_get_sample_rate(IntPtr dev);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_set_testmode", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_set_testmode(IntPtr dev, int on);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_reset_buffer", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_reset_buffer(IntPtr dev);

        [DllImport(LibRtlSdr, EntryPoint = "rtlsdr_read_sync", CallingConvention = CallingConvention.Cdecl)]
        public static extern int rtlsdr_read_sync(IntPtr dev, IntPtr buf, int len, out int nRead);

    }
}
