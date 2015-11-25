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

namespace CANFICore
{
    // used to set all measurement parameters from MainDlg to RTLWorker
    public class RTLParams
    {
        // CANFI's current state
        public STATE State;

        // CANFI's sweep mode
        public SMODE SweepMode;

        // RTL device
        public RTLDevice Device;

        // RTL frequency sweep parameters [MHz]
        public decimal Frequency_Start;
        public decimal Frequency_Stop;
        public decimal Frequency_Step;

        // number of cycles until frequency change is performed (relevant in sweep mode only)
        public decimal Cycles;

        // usage of RTL automatic gain control (legacy, should be OFF)
        public bool UseRTLAGC;
        // usage or tuner automatic gain control (legacy, should be OFF)
        public bool UseTunerAGC;

        // tuner gain value [10th of dB]
        public int TunerGain;
        // tuner gain mode settings
        public int GainMode;    
        // usage of soft AGC
        public bool AGC;

        // RTL sample rate [samples/sec]
        public uint SampleRate;
        // RTL sample count per measurement cycle [samples]
        public int MaxSampleCount;

        // selected COM port
        public string COMPort;
        // selected COM port status line for noise source control
        public string COMNoise;
        // selected COM port status line for DUT switch control
        public string COMDUT;
        // usage of COM port for noise source and DUT control (legacy, should be always ON)
        public bool COMPortUse;
        // usage of COM port for noise source control (legacy, should be always ON)
        public bool COMNoiseUse;
        // usage of COM port for DUT switch control
        public bool COMDUTUse;
        // inversion of status line for noise source control
        public bool COMNoiseInverse;
        // inversion of status line for DUT switch control
        public bool COMDUTInverse;
        // delay after changing COM port status lines [ms]
        public int COMDelay;

        // lower bound when RTL starts clipping
        public int Clip_MinValue;
        // upper bound when RTL starts clipping
        public int Clip_MaxValue;
        // maximum number of clippings allowed per cycle before setting the result to invalid
        public int Clip_MaxClipAllowed;

        // minimum count of cycles for averaging calibration result
        public int Averaging_Min;
        // maximum count of cycles for averaging calibration result
        public int Averaging_Max;

        // usage of FFT realtime display --> send FFT data in realtime to main thread
        public bool FFT_RealtimeDisplay;

        // usage of FFT filter
        public bool FFT_Filter;
        // FFT algorithm
        public FFTALGORITHM FFT_Algorithm;
        // threshold for FFT filter
        public double FFT_Filter_Threshold;
        // notch width in FFT-bins
        public int FFT_Filter_NotchWidth;

        // list of calibration values
        public CalEntries Calibration;

    }

    // used to report basic RTL device info from RTLWorker to MainDlg
    public class RTLInfo
    {
        public string DeviceName;
        public RtlSdrTunerType TunerType;
        public int[] TunerGains;
    }

    // class used to report measurement results from RTLWorker to MainDlg
    public class RTLMeasureResults
    {
        // current tuner center frequency [MHz]
        public decimal Frequency;

        // validation state of measurement result [valid/invalid]
        public bool Invalid;
        // clipping state of measurment results [non clipped/clipped]
        public bool Clipped;

        // time stamp of measurement (taken at the beginning of sampling)
        public DateTime Timestamp;

        // state of noise source [ON/OFF]
        public bool Noise_ON;
        // state of DUT switch control [ON/OFF]
        public bool DUT_ON;

        // number of collected samples
        public int SampleCount;
        // measured power [linear]
        public double Power;
        // current tuner gain
        public int TunerGain;

        // current measurement cycle
        public int Cycle;
    }

    // used to report status messages from RTLWorker to MainDlg
    public class RTLStatus
    {
        // state of noise source [ON/OFF]
        public bool Noise_ON;
        // state of DUT switch control [ON/OFF]
        public bool DUT_ON;
        // string message (optional)
        public string Message;

        public RTLStatus()
        {
            Noise_ON = false;
            DUT_ON = false;
            Message = "";
        }

        public RTLStatus(string message)
        {
            Noise_ON = false;
            DUT_ON = false;
            Message = message;
        }

        public RTLStatus(bool noise, string message)
        {
            Noise_ON = noise;
            Message = message;
        }

        public RTLStatus(bool noise, bool dut, string message)
        {
            Noise_ON = noise;
            DUT_ON = dut;
            Message = message;
        }
    }

    // basic measurement thread as BackgroundWorker
    public class RTLWorker : BackgroundWorker
    {
        // bytecount per sample (1 byte for I, 1byte for Q) 
        public int BytesperSample = 2;

        // set of parameters
        public RTLParams Params;

        // device pointer
        private IntPtr DevicePtr;

        // buffer for measurement results
        public RTLMeasureResults MeasureResults = new RTLMeasureResults();

        // private buffer for RTL readout and FFT
        // contains raw values as I/Q samples and Real/Imag values after in-place FFT
        // alignments are:
        // Raw values: I[0];Q[0];I[1];Q[1];.....I[n];Q[n]
        // FFT values: Real[0];Imag[0];Real[1];Imag[1];.....Real[n];Imag[n]
        private double[] Buf;
        // handles and pointer for FFTW
        GCHandle hin, hout;
		IntPtr fftplan;

        // Block out status of values
        // used to filter out carrieres with FFT and filter while Noise if OFF
        private bool[] BlockedOut;

        // serial port
        private SerialPort COMPort;

        // COM and DUT state for internal use
        private bool Noise = false;
        private bool DUT = false;

        // gain values for internal use
        private int MaxGain = int.MinValue;
        private int MinGain = int.MaxValue;
        private int ClipGain;

        // Tuner frequency
        private decimal Frequency;
        // keep the last frequency tuned
        private decimal Frequency_tuned = 0;

        // Tuner gain
        private int TunerGain;

        private bool SupportsOffsetTuning = false;

        // timestamps for runtime measurement
        private DateTime T_Start;
        private DateTime T_Stop;

        // current measurement cycle;
        private int Cycle;

        public RTLWorker()
            : base()
        {
            this.WorkerReportsProgress = true;
            this.WorkerSupportsCancellation = true;
            this.Buf = null;
            Cycle = 0;
        }

        #region RTL functions

        public void RTLOpenDevice()
        {
            // check for valid device selection first
            uint _deviceindex;
            try
            {
                _deviceindex = Params.Device.Index;
            }
            catch
            {
                throw new InvalidOperationException("Device not found or not allocated properly.");
            }
            // try to open the device and get some basic information
            if (NativeMethods.rtlsdr_open(out DevicePtr, Params.Device.Index) > 0)
                throw new InvalidOperationException("Cannot open RTL device. Is the device locked somewhere?");
            // check for offset tuning support of rtlsdr
            SupportsOffsetTuning = NativeMethods.rtlsdr_set_offset_tuning(DevicePtr, 0) != -2;
            // reset RTL buffer
            RTLResetBuffer();
            // find lower and upper bound of tuner gain from calibration values
            // --> use only tuner gains for which a calibration is available
            try
            {
                foreach (KeyValuePair<int, CalEntry> entry in Params.Calibration[Frequency])
                {
                    if ((entry.Equals(new KeyValuePair<int, CalEntry>())) && (!entry.Value.Invalid))
                    {
                        if (entry.Key > MaxGain)
                            MaxGain = entry.Key;
                        if (entry.Key < MinGain)
                            MinGain = entry.Key;
                    }
                    ClipGain = MaxGain;
                }
            }
            catch
            {
            }
            // reset frequency tuned
            Frequency_tuned = 0;
        }

        public void RTLConfigureDevice()
        {
            // set the required device configuration
            RtlSdrGainMode gainmode = Params.Device.GainMode;
            // try to set the gain mode except GAIN_MODE_PERSTAGE
            if (gainmode == RtlSdrGainMode.GAIN_MODE_PERSTAGE)
            {
                if (NativeMethods.rtlsdr_set_tuner_gain_mode(DevicePtr, RtlSdrGainMode.GAIN_MODE_SENSITIVITY) != (int)RtlSdrGainMode.GAIN_MODE_SENSITIVITY)
                    throw new InvalidOperationException("Cannot set tuner gain mode: " + RtlSdrGainMode.GAIN_MODE_SENSITIVITY.ToString());
            }
            else
            {
                if (NativeMethods.rtlsdr_set_tuner_gain_mode(DevicePtr, gainmode) != 0)
                    throw new InvalidOperationException("Cannot set tuner gain mode: " + gainmode.ToString());
            }
            // set tuner center frequency [Hz]
            uint freq = System.Convert.ToUInt32(Frequency * 1000000);
            RTLSetCenterFreq(freq);
            // set RTL sample rate
            if (NativeMethods.rtlsdr_set_sample_rate(DevicePtr, Params.SampleRate) != 0)
                throw new InvalidOperationException("Cannot set sample rate: " + Params.SampleRate.ToString());
            // set RTL AGC mode
            if (NativeMethods.rtlsdr_set_agc_mode(DevicePtr, Params.UseRTLAGC ? 1 : 0) != 0)
                throw new InvalidOperationException("Cannot set agc mode: " + Params.UseRTLAGC.ToString());
            // set tuner gain to inital value taken from the parameters
            RTLSetTunerGain(TunerGain);
            // reset frequency tuned
            Frequency_tuned = 0;
        }

        private void RTLResetBuffer()
        {
            // reset the RTL buffer
            if (NativeMethods.rtlsdr_reset_buffer(DevicePtr) != 0)
                throw new InvalidOperationException("Cannot reset buffer: ");
        }

        private void RTLSetCenterFreq(uint frequency)
        {
            // set tuner center frequency [Hz]
            // do not set the same frequency again --> save time!
            if (frequency != Frequency_tuned)
            {
                if (NativeMethods.rtlsdr_set_center_freq(DevicePtr, frequency) != 0)
                    throw new InvalidOperationException("Cannot set center frequency: " + (frequency).ToString());
                Frequency_tuned = frequency;
            }
        }

        private static void e4k_setLNA_MixerGain(IntPtr dev, int LNAGain, int MixerGain)
        {
            // e4k driver sets LNAGain and MixerGain together. 12dB MixerGain is only used for
            // total gain of 42dB (LNAGain=30dB), otherwise only 4dB MixerGain
            NativeMethods.rtlsdr_set_tuner_gain(dev, (LNAGain + MixerGain) * 10);
        }

        private static void e4k_setIFGain(IntPtr dev, int[] stage_gain)
        {
            // set the IF stages gain
            int stage;
            for (stage = 0; stage < 6; stage++)
                NativeMethods.rtlsdr_set_tuner_if_gain(dev, stage + 1, stage_gain[stage] * 10);
        }

        private void RTLSetTunerGain(int gain)
        {
            // set tuner gain
            TunerGain = gain;
            // set gains in manual mode per standard call
            switch (Params.Device.GainMode)
            {
                case  RtlSdrGainMode.GAIN_MODE_MANUAL:
                    if (NativeMethods.rtlsdr_set_tuner_gain(DevicePtr, gain) < 0)
                        throw new InvalidOperationException("Cannot set tuner gain: " + gain.ToString());
                    break;
                case RtlSdrGainMode.GAIN_MODE_PERSTAGE:
                    // set gains per stage if supported
                    int[] _gains = Params.Device.TunerGains.GetGains(gain);
                    for (byte i = 0; i < _gains.Length; i++)
                    {
                        // TODO: check return code!!
                        if (NativeMethods.rtlsdr_set_tuner_stage_gain(DevicePtr, i, _gains[i]) < 0)
                            throw new InvalidOperationException("Cannot set tuner stage gain[" + i + "]: " + _gains[i].ToString());
                    }
                    break;                                    
                case RtlSdrGainMode.GAIN_MODE_SENSITIVITY:
                    // emulate a sensitivity mode for E4000 tuner
                    switch (gain)
                    {
                        /* LNA Mixer IF  Total */
                        case -250:
                            e4k_setLNA_MixerGain(DevicePtr, 5, 4);
                            e4k_setIFGain(DevicePtr, new int[] { -3, 0, 0, 1, 6, 3 });   /*  5    5   7     17  */
                            break;
                        case -200:
                            e4k_setLNA_MixerGain(DevicePtr, 10, 4);
                            e4k_setIFGain(DevicePtr, new int[] { -3, 0, 0, 1, 6, 3 });   /* 10    5   7     22  */
                            break;
                        case -150:
                            e4k_setLNA_MixerGain(DevicePtr, 15, 4);
                            e4k_setIFGain(DevicePtr, new int[] { -3, 0, 0, 1, 6, 3 });   /* 15    5   7     27  */
                            break;
                        case -100:
                            e4k_setLNA_MixerGain(DevicePtr, 20, 4);
                            e4k_setIFGain(DevicePtr, new int[] { -3, 0, 0, 1, 6, 3 });   /* 20    5   7     32  */
                            break;
                        case -50:
                            e4k_setLNA_MixerGain(DevicePtr, 30, 4);
                            e4k_setIFGain(DevicePtr, new int[] { -3, 0, 0, 1, 6, 3 });   /* 25    5   7     37  */
                            break;
                        case 0:
                            e4k_setLNA_MixerGain(DevicePtr, 30, 12);
                            e4k_setIFGain(DevicePtr, new int[] { -3, 0, 0, 2, 3, 3 });   /* 25   12   5     42  */
                            break;
                        case 50:
                            e4k_setLNA_MixerGain(DevicePtr, 30, 12);
                            e4k_setIFGain(DevicePtr, new int[] { -3, 3, 0, 1, 6, 3 });   /* 25   12  10     47  */
                            break;
                        case 100:
                            e4k_setLNA_MixerGain(DevicePtr, 30, 12);
                            e4k_setIFGain(DevicePtr, new int[] { 6, 0, 0, 0, 6, 3 });   /* 25   12  15     52  */
                            break;
                        case 150:
                            e4k_setLNA_MixerGain(DevicePtr, 30, 12);
                            e4k_setIFGain(DevicePtr, new int[] { 6, 0, 0, 2, 9, 3 });   /* 25   12  20     57  */
                            break;
                        case 200:
                            e4k_setLNA_MixerGain(DevicePtr, 30, 12);
                            e4k_setIFGain(DevicePtr, new int[] { 6, 3, 0, 1, 9, 6 });   /* 25   12  25     62  */
                            break;
                        case 250:
                            e4k_setLNA_MixerGain(DevicePtr, 30, 12);
                            e4k_setIFGain(DevicePtr, new int[] { 6, 6, 0, 0, 9, 9 });   /* 25   12  30     67  */
                            break;
                        default:
                            // return failure if gain not found in table
                            throw new InvalidOperationException("Cannot set tuner gain: " + gain.ToString());
                    }
                break;
            }   

        }

        private void RTLReadSamples()
        {
            // read a number of samples
            // initailize and reset buffers
            RTLResetBuffer();
            // calculate length
            int _len = Params.MaxSampleCount * BytesperSample;
            // recalculate length, in order to get 2^n length for fast FFT
            _len = (int)Math.Pow(2, Math.Truncate(Math.Log(_len, 2)));
            // get new buffer for raw values ONLY when Noise = OFF
            if (!Noise)
            {
				if ((Buf == null) || (_len != Buf.Length)) 
                {
					if (Params.FFT_Algorithm == FFTALGORITHM.FFTW) 
                    {
						if (Buf != null) 
                        {
							FFTWSharp.fftw.destroy_plan (fftplan);
							hout.Free ();
							hin.Free ();
						}
					}
					Buf = new double[_len];
                    BlockedOut = new bool[_len];
                    if (Params.FFT_Algorithm == FFTALGORITHM.FFTW)
                    {
						hin = GCHandle.Alloc (Buf, GCHandleType.Pinned);
						hout = GCHandle.Alloc (Buf, GCHandleType.Pinned);
						fftplan = FFTWSharp.fftw.dft_1d (_len / 2, hin.AddrOfPinnedObject (), hout.AddrOfPinnedObject (), FFTWSharp.fftw_direction.Forward, FFTWSharp.fftw_flags.Estimate);
					}
				}
            }
            byte[] _buf = new byte[Buf.Length];
            // pin the array to get an IntPtr for an unmanaged call
            GCHandle pinnedArray = GCHandle.Alloc(_buf, GCHandleType.Pinned);
            IntPtr ptr = pinnedArray.AddrOfPinnedObject();
            // read samples the call does not return until the requested number of samples is read
            int _nRead = 0;
            int r = 0;
            r = NativeMethods.rtlsdr_read_sync(DevicePtr, ptr, Buf.Length, out _nRead);
            // check byte counts (should be equal to requested)
            if ((r < 0) || (_nRead < Buf.Length))
            {
                throw new InvalidOperationException("Unable to read from device: " + _nRead.ToString() + " Bytes.");
            }
            // copy over from raw buffer into Buf
            for (var i = 0; i < Buf.Length; i++)
            {
                // clear blocked out status only if Noise is OFF
                if (!Noise)
                    BlockedOut[i] = false;
                Buf[i] = _buf[i] * 10 - 1275;
            }
            // free pinned array
            pinnedArray.Free();
        }

        public RTLMeasureResults RTLMeasurePower()
        {
            // do the power measurement here

            // invalidate results
            MeasureResults.Invalid = true;
            
            // set frequency in the results
            MeasureResults.Frequency = Frequency;

            // set timestamp at the beginning of measurement
            MeasureResults.Timestamp = DateTime.UtcNow;

            // read samples into Buf
			DateTime tick, tock;
			tick = System.DateTime.Now;
            RTLReadSamples();
			tock = System.DateTime.Now;
			Console.WriteLine ("READ: "+tock.Subtract (tick).Milliseconds);

            // perform an in-place FFT
            FFT();
			tock = System.DateTime.Now;
			Console.WriteLine ("FFT: "+tock.Subtract (tick).Milliseconds);

            // perform FFT filter only when activated and Noise = OFF
            if (Params.FFT_Filter && !Noise)
                FFT_Filter();

			tock = System.DateTime.Now;
			Console.WriteLine ("FILT: "+tock.Subtract (tick).Milliseconds);

            // set number samples read
            MeasureResults.SampleCount = Buf.Length / 2;

            double _magsum = 0;
            double _meansum_real = 0;
            double _meansum_imag = 0;
			// define arrays
			double[] c = new double[Buf.Length / 2];

            int Clip_I_0 = 0;
            int Clip_I_255 = 0;
            int Clip_Q_0 = 0;
            int Clip_Q_255 = 0;

            int _samplecount = 0;
            // calculate sum values and detect clipping
            for (var i = 0; i < Buf.Length; i+=2)
            {
                // sort out blocked values from FFT filter
                if (BlockedOut[i] || BlockedOut[i + 1])
                {
                    // set values to NaN
                    Buf[i] = double.NaN;
                    Buf[i + 1] = double.NaN;
                    continue;
                }
                double real = Buf[i];
                double imag = Buf[i + 1];
                c[i / 2] = real * real + imag * imag;
				_magsum += c [i / 2];
                _meansum_real += real;
                _meansum_imag += imag;
                // detect clipping - see RtlDevice.cs: *buf++ * 10 - 1275
                if (real <= Params.Clip_MinValue)
                    Clip_I_0++;
                if (real >= Params.Clip_MaxValue)
                    Clip_I_255++;
                if (imag <= Params.Clip_MinValue)
                    Clip_Q_0++;
                if (imag >= Params.Clip_MaxValue)
                    Clip_Q_255++;
                _samplecount++;
            }
            
			tock = System.DateTime.Now;
			Console.WriteLine ("CLIP: "+tock.Subtract (tick).Milliseconds);

            // calculate DC values
            double DC_I = _meansum_real / ((double)_samplecount);
            double DC_Q = _meansum_imag / ((double)_samplecount);

            // calculate power
            _magsum = _magsum / ((double)_samplecount);
            // subtract DC offset
            _magsum = _magsum - DC_I * DC_I - DC_Q * DC_Q;

            // set Power
            MeasureResults.Power = _magsum;

            // set noise source status
            MeasureResults.Noise_ON = Noise;

            // set tuner gain
            MeasureResults.TunerGain = TunerGain;

            // set measurement cycle info
            MeasureResults.Cycle = Cycle;

            // check count of clipped values > allowed --> set status to clipped and invalidate measure results
            // also: if measured power > maxpower allowed for the device (without detected clipping)
            if ((Clip_I_0 > Params.Clip_MaxClipAllowed) ||
                (Clip_I_255 > Params.Clip_MaxClipAllowed) ||
                (Clip_Q_0 > Params.Clip_MaxClipAllowed) ||
                (Clip_Q_255 > Params.Clip_MaxClipAllowed) ||
                (MeasureResults.Power > Params.Device.MaxPower))
            {
                MeasureResults.Clipped = true;
                MeasureResults.Invalid = true;
                ClipGain = MeasureResults.TunerGain;
            }
            else
            {
                MeasureResults.Clipped = false;
                MeasureResults.Invalid = false;
            }

            // report measure results to main thread
            this.ReportProgress((int)PROGRESS.FINISHED, MeasureResults);

            // calculate spectrum and
            // report results to main thread if needed
            if (Params.FFT_RealtimeDisplay)
            {
                // calculate PSD
                for (int i = 0; i < c.Length; i++)
                {
                    c[i] = 10 * Math.Log10(c[i]);
                }
                // fold the results in-place to get a +/- center frequency display
                int _halflen = c.Length / 2;
                for (int i = 0; i < _halflen / 2; i++)
                {
                    double v = c[_halflen - i - 1];
                    c[_halflen - i - 1] = c[i];
                    c[i] = v;
                    v = c[_halflen * 2 - i - 1];
                    c[_halflen * 2 - i - 1] = c[_halflen + i];
                    c[_halflen + i] = v;
                }
                /*
                // save FFT spectrum for testing
                using (StreamWriter sw = new StreamWriter("FFT_unfiltered.csv"))
                {
                    sw.WriteLine("i;FFT-Value[lin];FFT-Value[dB]");
                    for (int i = 0; i < c.Length; i++)
                    {
                        sw.WriteLine(i.ToString() + ";" + SupportFunctions.ToLinear(c[i]) + ";" + c[i].ToString("F2"));
                    }
                    sw.Flush();
                }
                */
                // report only in Idle state or while noise source is ON
                if ((Params.State == STATE.IDLE) || (Noise))
                    ReportProgress((int)PROGRESS.FFT, c);
            }
			tock = System.DateTime.Now;
			Console.WriteLine ("DISP: "+tock.Subtract (tick).Milliseconds);

            // return measure results for local use
            return MeasureResults;
        }

        public void RTLCloseDevice()
        {
            // close the RTL device
            if (NativeMethods.rtlsdr_close(DevicePtr) != 0)
                throw new InvalidOperationException("Cannot close device.");
            DevicePtr = System.IntPtr.Zero;

        }

        #endregion

        #region COM functions

        public void COMOpenDevice()
        {
            // open the serial device
            COMPort = new SerialPort(Params.COMPort);
            // do some basic settings
            if (COMPort == null)
            {
                throw new InvalidOperationException("Cannot open COM: " + Params.COMPort);
            }
            try
            {
                COMPort.Handshake = Handshake.None;
                COMPort.Open();
            }
            catch
            {
                throw new InvalidOperationException("Unable to set status line: " + Params.COMPort);
            }
        }

        public bool COMSetStatusLine(string statusline, bool on, bool inverse)
        {
            // set a serial port status line
            try
            {
                if (statusline == "RTS")
                {
                    COMPort.RtsEnable = (inverse) ? !on : on;
                    return on;
                }
                if (statusline == "DTR")
                {
                    COMPort.DtrEnable = (inverse) ? !on : on;
                    return on;
                }
            }
            catch
            {
            }
            throw new InvalidOperationException("Unable to set status line: " + Params.COMPort + "-->" + statusline + ":" + ((on) ? "ON" : "OFF"));
        }

        public int COMNoiseON()
        {
            // check if Noise switch via COM is activated
            // return 0 if not
            if (!Params.COMNoiseUse)
                return 0;
            // set the status line
            Noise = COMSetStatusLine(Params.COMNoise, true, Params.COMNoiseInverse);
            // report status to main thread
            ReportProgress((int)PROGRESS.STATUS, new RTLStatus(Noise, DUT, ""));
            return 0;
        }

        public int COMNoiseOFF()
        {
            // check if Noise switch via COM is activated
            // return 0 if not
            if (!Params.COMNoiseUse)
                return 0;
            // set the status line
            Noise = COMSetStatusLine(Params.COMNoise, false, Params.COMNoiseInverse);
            // report status to main thread
            ReportProgress((int)PROGRESS.STATUS, new RTLStatus(Noise, DUT, ""));
            return 0;
        }

        public int COMDUTON()
        {
            // check if DUT switch via COM is activated
            // return 0 if not
            if (!Params.COMDUTUse)
                return 0;
            // set the status line
            DUT = COMSetStatusLine(Params.COMDUT, true, Params.COMDUTInverse);
            // report status to main thread
            ReportProgress((int)PROGRESS.STATUS, new RTLStatus(Noise, DUT, ""));
            return 0;
        }

        public int COMDUTOFF()
        {
            // check if DUT switch via COM is activated
            // return 0 if not
            if (!Params.COMDUTUse)
                return 0;
            // set status line
            DUT = COMSetStatusLine(Params.COMDUT, false, Params.COMDUTInverse);
            // report status to main thread
            ReportProgress((int)PROGRESS.STATUS, new RTLStatus(Noise, DUT, ""));
            return 0;
        }

        public int COMCloseDevice()
        {
            // close the serial device
            try
            {
                COMNoiseOFF();
                COMDUTOFF();
                COMPort.Close();
                COMPort.Dispose();
            }
            catch
            {
                throw new InvalidOperationException ("Unable to close COM: " + Params.COMPort);
            }
            return 0;
        }

        #endregion

        #region Measurement functions

        protected override void OnDoWork (DoWorkEventArgs e)
        {
            // main background thread procedure
            // individual thread procedures are started according to state
            // once started they are running in a loop until the whole thread is cancelled
            // get parameters
            Params = (RTLParams)e.Argument;
            // report start up
            ReportProgress((int)PROGRESS.STATUS, new RTLStatus("Start."));
            // run thread procedures according to state
            try
            {
                switch (Params.State)
                {
                    case STATE.INIT:
                        Init();
                        break;
                    case STATE.IDLE:
                        Idle();
                        break;
                    case STATE.CALIBRATING:
                        Calibrate();
                        break;
                    case STATE.MEASURING:
                        Measure();
                        break;
                }
            }
            catch (Exception ex)
            {
                // return with error message if failed
                ReportProgress((int)PROGRESS.ERROR, ex.Message);
            }
            finally
            {
                // try to close COM device anyway
                try
                {
                    COMCloseDevice();
                }
                catch
                {
                    // do nothing if failed
                }
                // try to close RTL device anyway
                try
                {

                    RTLCloseDevice();
                }
                catch
                {
                    // do nothing if failed
                }
            }
            // thread is about to exit
            ReportProgress((int)PROGRESS.STATUS, new RTLStatus("Stop."));
            // set return value
            e.Result = Params;

        }

        public void Init()
        {
            // do initialization
            // enumerate all devices
            RTLDevice[] devices = RTLDevice.GetActiveDevices();
            // report results to main thread
            ReportProgress((int)PROGRESS.INIT, devices);
        }

        public void Idle()
        {
            // do idle
            // CAUTION: always start measurement with Noise=OFF to initialize blocked out status!
            // open device
            RTLOpenDevice();
            // set initial frequeny and gain
            Frequency = Params.Frequency_Start;
            TunerGain = Params.TunerGain;

            // configure device
            RTLConfigureDevice();
            while (!CancellationPending)
            {
                try
                {
                    T_Start = DateTime.UtcNow;
                    // set tuner frequency
                    RTLSetCenterFreq(System.Convert.ToUInt32(Frequency * 1000000));
                    // measure power
                    RTLMeasurePower();
                    T_Stop = DateTime.UtcNow;
                    ReportProgress((int)PROGRESS.MESSAGE, "[" + Params.Device.Name + "] " + "Idling at: " + Frequency.ToString("F3") + " MHz and " + (TunerGain / 10).ToString() + " dB [" + (T_Stop - T_Start).Milliseconds.ToString() + "ms].");
                }
                catch (Exception ex)
                {
                    ReportProgress((int)PROGRESS.ERROR, "Error: " + ex.Message);
                }
                Thread.Sleep(1);
            }
            // close device
            RTLCloseDevice();
        }

        public void Calibrate()
        {
            // do calibrate
            // open device
            // CAUTION: always start measurement with Noise=OFF to initialize blocked out status!
            RTLOpenDevice();

            // open COMPort
            if (Params.COMPortUse)
            {
                COMOpenDevice();
                COMDUTOFF();
                COMNoiseOFF();
            }

            // set initial frequeny and gain
            Frequency = Params.Frequency_Start;
            TunerGain = Params.TunerGain;
            // configure device
            RTLConfigureDevice();
            do
            {
                // set tuner frequency
                RTLSetCenterFreq(System.Convert.ToUInt32(Frequency * 1000000));
                // set gain iterate boundaries
                int gmin = 0;
                int gmax = Params.Device.TunerGains.Count - 1;
                if (!Params.AGC)
                {
                    // if AGC is off --> reduce imin/imax to the only one manually selected gain index
                    for (int i = 0; i < Params.Device.TunerGains.Count; i++)
                    {
                        if (Params.Device.TunerGains[i] == TunerGain)
                        {
                            gmin = i;
                            gmax = i;
                        }
                    }
                }
                // iterate through tuner gains starting with lowest gain
                int g = gmin;
                do
                {
                    double p_on = 0;
                    double p_off = 0;
                    double y = 0;
                    int av = 0;
                    try
                    {
                        // take a dummy measurement to see the Y-Factor
                        // set tuner gain
                        RTLSetTunerGain(Params.Device.TunerGains[g]);
                        // set Noise on
                        COMNoiseOFF();
                        Thread.Sleep(Params.COMDelay);
                        // measure power
                        p_off = RTLMeasurePower().Power;
                        // set Noise off
                        COMNoiseON();
                        Thread.Sleep(Params.COMDelay);
                        // measure power
                        p_on = RTLMeasurePower().Power;
                        try
                        {
                            // calculate Y-factor
                            y = p_on / p_off;
                            // calculate needed measure cycles (as a rule of thumb!)
                            // the lower the Y factor the more cycles needed for a good calibration
                            av = (int)(1 / (y - 1) * 10.0);
                            // cut to max/min allowed cycles
                            if (av < Params.Averaging_Min)
                                av = Params.Averaging_Min;
                            if (av > Params.Averaging_Max)
                                av = Params.Averaging_Max;
                        }
                        catch
                        {
                            av = Params.Averaging_Min;
                        }
                        // set tuner gain
                        RTLSetTunerGain(Params.Device.TunerGains[g]);
                        for (int j = 0; j < av; j++)
                        {
                            // set Noise on
                            COMNoiseOFF();
                            Thread.Sleep(Params.COMDelay);
                            // measure power
                            RTLMeasurePower();
                            // set Noise off
                            COMNoiseON();
                            Thread.Sleep(Params.COMDelay);
                            // measure power
                            RTLMeasurePower();
                            // check for cancellation pending
                            if (CancellationPending)
                                return;
                            // report current cycle
                            ReportProgress((int)PROGRESS.MESSAGE, "[" + Params.Device.Name + "] " + "Calibrating at: " + Frequency.ToString("F3") + " MHz and " + (TunerGain / 10).ToString() + " dB [" + (T_Stop - T_Start).Milliseconds.ToString() + "ms].");
                        }
                    }
                    catch (Exception ex)
                    {
                        ReportProgress((int)PROGRESS.ERROR, "Error: " + ex.Message);
                    }
                    g++;
                }
                while ((g <= gmax) && !CancellationPending);
                Frequency = Frequency + Params.Frequency_Step;
            }
            while ((!CancellationPending) && (Frequency < Params.Frequency_Stop));
            // close device
            RTLCloseDevice();
            // close COM
            if (Params.COMPortUse)
            {
                COMDUTOFF();
                COMNoiseOFF();
                COMCloseDevice();
            }
        }

        public void AGC(RTLMeasureResults r)
        {
            // this is the software AGC
            // try to set the highest possible gain until the RTL device starts clipping
            // check if AGC is enabled
            if (!Params.AGC)
                return;
            // check clipping status
            if (r.Clipped || (r.Power > Params.Device.MaxPower))
            {
                int newgain = MeasureResults.TunerGain;
                // reduce tuner gain to next lower value
                // only one step is possible in one cycle
                if (Params.Calibration.Count > 0)
                {
                    // if calibrated: use next lower calibrated gain level
                    foreach (KeyValuePair<int, CalEntry> entry in Params.Calibration[Frequency])
                    {
                        if (!entry.Value.Invalid)
                        {
                            if (entry.Key < MeasureResults.TunerGain)
                                newgain = entry.Key;
                        }
                    }
                }
                else
                {
                    // if not calibrated: use next lower tuner gain level
                    for (int i = 0; i < Params.Device.TunerGains.Count; i++ )
                    {
                        if (Params.Device.TunerGains[i] < MeasureResults.TunerGain)
                            newgain = Params.Device.TunerGains[i];
                    }
                }
                // set new tuner gain
                TunerGain = newgain;
                RTLSetTunerGain(newgain);
            }
            else
            {
                // increase gain to a higher value
                // skip gain steps if possible to save reaction time
                int newgain = MeasureResults.TunerGain;
                // calculate the headroom space in 10th of dB (if any) and set the ClipGain as maximum allowed gain
                int headroom = 0;
                if (Params.Device.MaxPower > MeasureResults.Power)
                    headroom = (int)((SupportFunctions.TodB(Params.Device.MaxPower) - SupportFunctions.TodB(MeasureResults.Power)) * 10.0);
                ClipGain = TunerGain + headroom;
                // starting from ClipGain --> find next lower tuner gain level
                if (ClipGain - TunerGain > 30)
                {
                    // if calibrated: use highest possible calibrated gain level which is just below ClipGain
                    if (Params.Calibration.Count > 0)
                    {
                        foreach (KeyValuePair<int, CalEntry> entry in Params.Calibration[Frequency])
                        {
                            if (!entry.Value.Invalid)
                            {
                                if (entry.Key < ClipGain - 30)
                                {
                                    newgain = entry.Key;
                                }
                            }
                        }
                    }
                    else
                    {
                        // if not calibrated: use highest possible tuner gain level which is just below ClipGain
                        for (int i = 0; i < Params.Device.TunerGains.Count; i++ )
                        {
                            if (Params.Device.TunerGains[i] < ClipGain - 30)
                            {
                                newgain = Params.Device.TunerGains[i];
                            }
                        }
                    }
                    // set new tuner gain if changed
                    // check for changes first, otherwise slowering the measurement!
                    if (TunerGain != newgain)
                    {
                        TunerGain = newgain;
                        RTLSetTunerGain(newgain);
                    }
                }
            }

        }

        public void Measure()
        {
            // do measurement
            // CAUTION: always start measurement with Noise=OFF to initialize blocked out status!
            try
            {
                // open device
                RTLOpenDevice();
                // open COMPort
                if (Params.COMPortUse)
                {
                    COMOpenDevice();
                    COMDUTON();
                    COMNoiseOFF();
                }
                // set initial gain
                TunerGain = Params.TunerGain;
                // set tuner gain to minimum availble calibrated value, if AGC is on
                if (Params.AGC)
                {
                    if (Params.Calibration.Count > 0)
                    {
                        // find maxgain which is not invalid
                        int maxgain = int.MinValue;
                        int mingain = int.MaxValue;
                        foreach (KeyValuePair<int, CalEntry> entry in Params.Calibration[Frequency])
                        {
                            if ((!entry.Value.Invalid) && (entry.Key > maxgain))
                                maxgain = entry.Key;
                            if ((!entry.Value.Invalid) && (entry.Key < mingain))
                                mingain = entry.Key;
                        }
                        TunerGain = mingain;
                    }
                    else
                    {
                        TunerGain = Params.Device.TunerGains[0];
                    }
                }

                // configure device
                RTLConfigureDevice();
            }
            catch (Exception ex)
            {
                // report error to main thread
                ReportProgress((int)PROGRESS.ERROR, "Error: " + ex.Message);
            }
            do
            {
                // set initial frequency
                Frequency = Params.Frequency_Start;
                do
                {
                    // reset measurement cycle
                    Cycle = 0;
                    do
                    {
                        try
                        {
                            T_Start = DateTime.UtcNow;
                            // set tuner frequency
                            RTLSetCenterFreq(System.Convert.ToUInt32(Frequency * 1000000));
                            COMNoiseOFF();
                            Thread.Sleep(Params.COMDelay);
                            // measure power
                            RTLMeasurePower();
                            COMNoiseON();
                            Thread.Sleep(Params.COMDelay);
                            RTLMeasurePower();
                            // do AGC if necessary, but only if noise source is on
                            AGC(MeasureResults);
                            T_Stop = DateTime.UtcNow;
                            // report current cycle
                            ReportProgress((int)PROGRESS.MESSAGE, "[" + Params.Device.Name + "] " + "Measuring at: " + Frequency.ToString("F3") + " MHz and " + (TunerGain / 10).ToString() + " dB [" + (T_Stop - T_Start).Milliseconds.ToString() + "ms].");
                        }
                        catch (Exception ex)
                        {
                            // report error to main thread
                            ReportProgress((int)PROGRESS.ERROR, "Error: " + ex.Message);
                        }
                        Cycle++;
                    }
                    while (!CancellationPending && (Cycle < Params.Cycles));
                    Frequency += Params.Frequency_Step;
                }
                while (!CancellationPending && (Frequency < Params.Frequency_Stop));
            }
            while (!CancellationPending && (Params.SweepMode != SMODE.SINGLE));
            // close device
            RTLCloseDevice();
            // close COM
            if (Params.COMPortUse)
            {
                COMDUTOFF();
                COMNoiseOFF();
                COMCloseDevice();
            }
        }

        public void FFT()
        {
            // perform an in-place FFT with Buf
			if (Params.FFT_Algorithm == FFTALGORITHM.FFTW) {
				int i = 0;
				FFTWSharp.fftw.execute (fftplan);
				//Scale and revert order
                for (i = 0; i < Buf.Length / 2; i += 2)
                {
                    // keep value of Buf[i]
                    double d = Buf[i] / Math.Sqrt(Buf.Length / 2);
                    Buf[i] = Buf[(Buf.Length - i) % Buf.Length] / Math.Sqrt(Buf.Length / 2);
                    Buf[(Buf.Length - i) % Buf.Length] = d;
                    // keep value of Buf[i+1]
                    d = Buf[i + 1] / Math.Sqrt(Buf.Length / 2);
                    Buf[i + 1] = Buf[(Buf.Length - i + 1) % Buf.Length] / Math.Sqrt(Buf.Length / 2);
                    Buf[(Buf.Length - i + 1) % Buf.Length] = d;
                }
            }
            else
            {
				// perform an in-place FFT with Buf
	            Lomont.LomontFFT fft = new Lomont.LomontFFT();
				fft.FFT (Buf, true);
			}
        }

        public void FFT_Filter()
        {
            // perform an in-place FFT filter with Buf
            // CURRENTLY ONLY: block out values > magsum * xxx --> set BlockedOut[i] = true
            // calculate preliminary noise power
            double _magsum = 0;
            double _magmax = 0;
            int _maxi = 0;
            double _meanreal = 0;
            double _meanimag = 0;
            for (int i = 0; i < Buf.Length; i+=2)
            {
                double real = Buf[i];
                double imag = Buf[i + 1];
                _magsum += real * real + imag * imag;
                if (_magsum > _magmax)
                {
                    _magmax = _magsum;
                    _maxi = i;
                }
                _meanreal += real;
                _meanimag += imag;
            }
            _magsum = _magsum / (Buf.Length / 2);
            _meanreal = _meanreal / (Buf.Length / 2);
            _meanimag = _meanimag / (Buf.Length / 2);
            double _filterthreshold = _magsum * Params.FFT_Filter_Threshold;
            int _filterwidth = Params.FFT_Filter_NotchWidth;
            for (int i = 0; i < Buf.Length; i += 2)
            {
                double d = Buf[i] * Buf[i] + Buf[i + 1] * Buf[i + 1];
                if (d >_filterthreshold)
                {
                    // block out values +/- filterwidth
                    // blocked out status will be kept when Noise is ON
                    for (int j = -_filterwidth; j < _filterwidth / 2; j++)
                    {
                        if (((i + j) >= 0) && ((i + j) < Buf.Length - 1))
                        {
                            BlockedOut[i + j] = true;
                            BlockedOut[i + j + 1] = true;
                        }
                    }
//                    System.Console.WriteLine(i + ": " + d);
                }
            }
            /*
            using (StreamWriter sw = new StreamWriter("FFT_filtered.csv"))
            {
                sw.WriteLine("i;FFT-Value");
                for (int i = 0; i < Buf.Length; i += 2)
                {
                    double d = Buf[i] * Buf[i] + Buf[i + 1] * Buf[i + 1];
                    sw.WriteLine(i.ToString() + ";" + d.ToString("F2"));
                }
            }
             */
        }

        #endregion
    }

    // simple structure for saving I/Q values
    public struct Complex
    {
        public int Real;
        public int Imag;
    }



}
