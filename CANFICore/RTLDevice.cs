using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.IO.Ports;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace CANFICore
{
    // class for RTL tuner gains
    public class RTLTunerGains
    {
        private SortedList<int, int[]> Gains = new SortedList<int,int[]>();

        public int Count
        {
            get
            {
                return Gains.Count;
            }

        }

        public int this[int i]
        {
            get
            {
                return Gains.Keys[i];
            }
        }

        public void AddGains(int tunergain, int[] gains)
        {
            Gains.Add(tunergain, gains);
        }

        public int[] GetGains(int tunergain)
        {
            return Gains[tunergain];
        }

    }

    // class for RTL tuner gain stages
    public class RTLGainStages
    {
        private Dictionary<string, int[]> Stages = new Dictionary<string, int[]>();

        public int Count
        {
            get
            {
                return Stages.Count;
            }
        }

        public void AddGains(string stage, int[] gains)
        {
            Stages.Add(stage, gains);
        }

        public string this[int i]
        {
            get
            {
                return Stages.Keys.ElementAt(i);
            }
        }

        public int[] GetGains(string stage)
        {
            return Stages[stage];
        }

        public int GetGain(string stage, int index)
        {
            return Stages[stage][index];
        }

        public int GainSumE4000(int[] gains)
        {
            // sum up and correct gain values for E4000
            // 2015-11-15: do not modify gain settings table while summarizing
            int _sum = 0;
            int g = 0;
            for (int i = 0; i < gains.Length; i++)
            {
                // get gain by default
                g = gains[i];
                // correct LNA gain 30 >> 25dB
                if ((i == 0) && (g == 300))
                    g = 250;
                // correct Mixer gain 4 >> 5dB
                if ((i == 1) && (g == 40))
                    g = 50;
                _sum += g;
            }
            _sum -= 420;
            return _sum;
        }

        public int GainSumR820T(int[] gains)
        {
            // sum up and correct gain values for R820T
            int _sum = 0;
            for (int i = 0; i < gains.Length; i++)
            {
                _sum += gains[i];
            }
            _sum -= 163;
            return _sum;
        }

        public int GainSumDefault(int[] gains)
        {
            // sum up and correct gain values for Default
            int _sum = 0;
            for (int i = 0; i < gains.Length; i++)
            {
                _sum += gains[i];
            }
            return _sum;
        }
        public bool ValidateGain(string stage, int gain)
        {
            // validate gain setting
            int[] gains;
            // return false if stage not found
            if (!Stages.TryGetValue(stage, out gains))
                return false;
            // try to find gain value in gains
            foreach (int g in gains)
                if (g == gain)
                    return true;
            return false;
        }
    }

    // class for RTL device descriptor
    public class RTLDevice
    {
        public uint Index { get; private set; }
        public RtlSdrTunerType TunerType { get; private set; }
        public string Name { get; set; }
        public string Manufacturer { get; private set; }
        public string Product { get; private set; }
        public string Serial { get; private set; }
        public RtlSdrGainMode GainMode { get; private set; }
        public RTLGainStages GainStages { get; private set; }
        public RTLTunerGains TunerGains { get; private set; }
        public double MaxPower { get; private set; }

        public static RTLDevice[] GetActiveDevices()
        {
            uint _devicecount = NativeMethods.rtlsdr_get_device_count();
            var _result = new RTLDevice[_devicecount];

            for (var i = 0u; i < _devicecount; i++)
            {
                // get device name
                string _name = NativeMethods.rtlsdr_get_device_name(i);
                // get device pointer
                System.IntPtr _dev;
                if (NativeMethods.rtlsdr_open(out _dev, i) > 0)
                    throw new InvalidOperationException("Cannot open RTL device. Is the device locked somewhere?");
                try
                {
                    // get tuner type
                    RtlSdrTunerType _tunertype;
                    _tunertype = NativeMethods.rtlsdr_get_tuner_type(_dev);
                    // get descriptor strings
                    StringBuilder _manufact = new StringBuilder(256);
                    StringBuilder _product = new StringBuilder(256);
                    StringBuilder _serial = new StringBuilder(256);
                    NativeMethods.rtlsdr_get_usb_strings(_dev, _manufact, _product, _serial);
                    RTLGainStages _gainstages = new RTLGainStages();
                    RTLTunerGains _tunergains = new RTLTunerGains();
                    RtlSdrGainMode _gainmode = RtlSdrGainMode.GAIN_MODE_MANUAL;
                    double _maxpower = 0;
                    // try to get all possible gain settings for all stages
                    // requires special version of rtlsdr.dll
                    try
                    {
                        // iterate through 256 possible stages
                        for (byte stage = 0; stage < 255; stage++)
                        {
                            // get number of gains per stage
                            int _count = NativeMethods.rtlsdr_get_tuner_stage_gains(_dev, stage, null, null);
                            // stopop iteration at first stage with no entries or error
                            if (_count <= 0)
                                break;
                            var _gains = new int[_count];
                            StringBuilder _desc = new StringBuilder(256);
                            // get gains
                            NativeMethods.rtlsdr_get_tuner_stage_gains(_dev, stage, _gains, _desc);
                            // add new entry to array
                            _gainstages.AddGains(_desc.ToString(), _gains);
                        }

                    }
                    catch
                    {
                        // no gain settings found or wrong version of rtlsdr.dll
                    }
                    if (_gainstages.Count > 0)
                    {
                        // gain settings per stage were found --> assuming that special version of rtlsdr is loaded
                        // we can set special settings per stage by ourselves
                        // save default gain settings to file to ensure that we have at least default settings on a file
                        SaveDefaultGainSettings(_tunertype,_gainstages);
                        // try to read gain settings per stage from file
                        // set gain mode to gain per stage
                        _gainmode = RtlSdrGainMode.GAIN_MODE_PERSTAGE;
                        // calculate file name according to tuner type
                        string filename = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + _tunertype.ToString() + ".tun";
                        try
                        {
                            using (StreamReader sr = new StreamReader(filename))
                            {
                                while (!sr.EndOfStream)
                                {
                                    // read a line
                                    string s = sr.ReadLine().Trim();
                                    if (!String.IsNullOrEmpty(s) && !s.StartsWith("//"))
                                    {
                                        // not comment, try to split into single values
                                        try
                                        {
                                            string[] a = s.Split(';');
                                            // check array for length --> must be equal to stages count
                                            if (a.Length != _gainstages.Count)
                                                throw (new InvalidOperationException("Tuner type: " + _tunertype + "\n" + "Filename: " + filename + "\n" + "Number of entries does not match number of stages" + " [" + _gainstages.Count.ToString() + "] in line: " + s));
                                            // initialize gain arry
                                            int[] gains = new int[_gainstages.Count];
                                            // set gain values
                                            for (int index = 0; index < a.Length; index++)
                                            {
                                                // convert string to int
                                                try
                                                {
                                                    gains[index] = System.Convert.ToInt32(a[index].Trim());
                                                }
                                                catch
                                                {
                                                    throw (new InvalidOperationException("Tuner type: " + _tunertype + "\n" + "Filename: " + filename + "\n" + "Invalid gain entry in line: " + s));
                                                }
                                                // validate entry with gain stages
                                                if (!_gainstages.ValidateGain(_gainstages[index], gains[index]))
                                                    throw (new InvalidOperationException("Tuner type: " + _tunertype + "\n" + "Filename: " + filename + "\n" + "Gain entry is not valid for this stage[ " + _gainstages[index] + "] in line: " + s));
                                            }
                                            // sum up and correct tuner gains
                                            int _gainsum = 0;
                                            switch (_tunertype)
                                            {
                                                case RtlSdrTunerType.E4000:
                                                    _gainsum = _gainstages.GainSumE4000(gains);
                                                    break;
                                                case RtlSdrTunerType.R820T:
                                                    _gainsum = _gainstages.GainSumR820T(gains);
                                                    break;
                                                default:
                                                    _gainsum = _gainstages.GainSumDefault(gains);
                                                    break;
                                            }
                                            // add them to TunerGains object
                                            _tunergains.AddGains(_gainsum, gains);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message, "Error Reading Tuner Gains from File" + filename);
                                        }
                                    }
                                }
                            }
                        }
                        catch
                        {
                            // do nothing if file not found
                        }
                    }
                    if (_tunergains.Count <= 0)
                    {
                        // file read was not successful or old version of rtlsdr.dll is loaded
                        // try to get per stage settings from DLL
                        // try to set gain mode to manual
                        if (NativeMethods.rtlsdr_set_tuner_gain_mode(_dev, RtlSdrGainMode.GAIN_MODE_MANUAL) != 0)
                            throw new InvalidOperationException("Cannot set tuner gain mode: " + RtlSdrGainMode.GAIN_MODE_MANUAL.ToString());
                        if (_tunertype == RtlSdrTunerType.E4000)
                        {
                            // OK, we have a E4000 tuner and we will emulate a sensitivity mode
                            // set emulated gains according to SM5BSZ
                            int[] _gains = { -250, -200, -150, -100, -50, 0, 50, 100, 150, 200, 250 };
                            // add each tuner gain to tuner gains, gain settings per stage set to 0 entries (not used)
                            foreach (int gain in _gains)
                            {
                                int[] _dummy = new int[0];
                                _tunergains.AddGains(gain, _dummy);
                            }
                            // store gain mode, we will use it later
                            _gainmode = RtlSdrGainMode.GAIN_MODE_SENSITIVITY;
                        }
                        else
                        {
                            // very old or very official version of rtlsdr.dll
                            // try to get standard stages from DLL
                            // get size of tuner gain table first
                            int _count = NativeMethods.rtlsdr_get_tuner_gains(_dev, null);
                            if (_count < 0)
                            {
                                // set count to 0 if fails
                                _count = 0;
                            }
                            // get tuner gain table if count > 0
                            int[] _gains = new int[_count];
                            if (_count >= 0)
                            {
                                // get tuner gains from dll
                                if (NativeMethods.rtlsdr_get_tuner_gains(_dev, _gains) < 0)
                                    throw new InvalidOperationException("Cannot get tuner gains.");
                                // add each tuner gain to tuner gains, gain settings per stage set to 0 entries (not used)
                                foreach (int gain in _gains)
                                {
                                    int[] _dummy = new int[0];
                                    _tunergains.AddGains(gain, _dummy);
                                }
                            }
                            // store gain mode, we will use it later
                            _gainmode = RtlSdrGainMode.GAIN_MODE_MANUAL;
                        }
                    }
                    // set MaxGain according to tuner type
                    switch (_tunertype)
                    {
                        case RtlSdrTunerType.E4000:
                            _maxpower = SupportFunctions.ToLinear(50);
                            break;
                        case RtlSdrTunerType.R820T:
                            _maxpower = SupportFunctions.ToLinear(45);
                            break;
                        default:
                            _maxpower = SupportFunctions.ToLinear(50);
                            break;
                    }
                    // initialize new RTLDevice entry
                    _result[i] = new RTLDevice
                    {
                        Index = i,
                        TunerType = _tunertype,
                        Name = _name,
                        Manufacturer = _manufact.ToString(),
                        Product = _product.ToString(),
                        Serial = _serial.ToString(),
                        GainMode = _gainmode,
                        GainStages = _gainstages,
                        TunerGains = _tunergains,
                        MaxPower = _maxpower
                    };
                }
                finally
                {
                    // try to close the device anyway
                    NativeMethods.rtlsdr_close(_dev);
                }
            }
            return _result;
        }

        public static void SaveDefaultGainSettings(RtlSdrTunerType tunertype, RTLGainStages gainstages)
        {
            // save gain stages and default values if available
            try
            {
                using (StreamWriter sw = new StreamWriter(tunertype + ".tun.default"))
                {
                    // write file header with description
                    sw.WriteLine("// CANFI tuner gain settings file (c) 2015 by DL2ALF");
                    sw.WriteLine("// Tuner type: " + tunertype);
                    sw.WriteLine("// Tuner stages: " + gainstages.Count.ToString());
                    sw.WriteLine("// All stages and possible gains are listed below.");
                    sw.WriteLine("// Description of the following lines: // Stage name:  gain_0[1/10dB] ... gain_n[1/10dB]");
                    sw.WriteLine("//");
                    // get max gain values index
                    int _maxindex = 0;
                    sw.Write("// ");
                    sw.Write("Stage name / Index".PadRight(20));
                    for (int stage = 0; stage < gainstages.Count; stage++)
                    {
                        string _desc = gainstages[stage];
                        int[] gains = gainstages.GetGains(_desc);
                        if (gains.Length > _maxindex)
                            _maxindex = gains.Length;
                    }
                    for (int i = 0; i < _maxindex; i++)
                        sw.Write(i.ToString().PadLeft(5));
                    sw.WriteLine();
                    for (int stage = 0; stage < gainstages.Count; stage++)
                    {
                        sw.Write("// ");
                        string _desc = gainstages[stage];
                        int[] gains = gainstages.GetGains(_desc);
                        sw.Write((_desc + ": ").PadRight(20));
                        foreach (int gain in gains)
                        {
                            sw.Write(gain.ToString().PadLeft(5));
                        }
                        sw.WriteLine();
                    }
                    sw.WriteLine("//");
                    sw.WriteLine("// To define individual gain settings append one line per gain below.");
                    sw.WriteLine("// Syntax:  gain[0]; ...;gain[n-1] where n is the number of stages (listed above)");
                    sw.WriteLine("// Example (3 stages): xxx;xxx;xxx");
                    sw.WriteLine("// Each line must contain exactly one gain per stage, e.g. 3 gains for 3 stages.");
                    sw.WriteLine("// Each gain must be valid for the according stage.");
                    sw.WriteLine("//");
                    // append default values for known tuner types
                    switch (tunertype)
                    {
                        case RtlSdrTunerType.E4000:
                            sw.WriteLine("// CANFI defaults (from DF9IC)");
                            sw.WriteLine("//");
                            sw.WriteLine("300;120;60;60;30;0;120;120\n300;120;60;60;30;0;90;120\n300;120;60;60;30;0;90;90\n300;120;60;60;30;0;60;90\n300;120;60;60;30;0;60;60\n300;120;60;60;30;0;30;60\n300;120;60;60;30;0;30;30\n300;40;60;60;30;0;30;60\n300;40;60;60;30;0;30;30\n200;40;60;60;30;0;30;60\n200;40;60;60;30;0;30;30\n150;40;60;60;30;0;30;60\n150;40;60;60;30;0;30;30\n100;40;60;60;30;0;30;60\n100;40;60;60;30;0;30;30\n50;40;60;60;30;0;30;60\n50;40;60;60;30;0;30;30");
                            break;
                        case RtlSdrTunerType.R820T:
                            sw.WriteLine("// CANFI defaults (from SM5BSZ)");
                            sw.WriteLine("//");
                            sw.WriteLine("322;152;337\n322;152;300\n322;152;265\n322;152;231\n322;139;195\n322;123;163\n322;123;149\n322;115;136\n322;115;112\n287;105;112\n282;88;112\n282;44;112\n223;44;112\n223;44;77\n192;25;77\n166;15;77\n144;15;77\n113;5;77\n62;0;77\n22;0;77\n9;0;77\n0;0;77");
                            break;
                    }
                }
                // copy over default to tuner file if not exists
                if (!File.Exists(tunertype + ".tun"))
                    File.Copy(tunertype + ".tun.default", tunertype + ".tun");
            }
            catch
            {
                // do nothing if fails
            }
        }

        public static RTLDevice GetDeviceByName(string name)
        {
            var _devices = GetActiveDevices();
            foreach (RTLDevice d in _devices)
            {
                if (d.Name == name)
                    return d;
            }
            return null;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
