using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using Clifton.Tools.Data;
using CANFICore;

namespace CANFI
{


    public unsafe partial class MainForm : Form
    {
        // CANFI's mode
        public MMODE MMode;

        // CANFI's current state
        public STATE State;
        
        // CANFI's currenz calibration state
        public CALSTATE CalState;

        // parameter object for measure thread
        private RTLParams _rtlParams = new RTLParams();

        // background worker for measurement
        public RTLWorker RTLWorker = new RTLWorker();

        // stream for value logging
        private StreamWriter Values;

        // device info
        public RTLDevice[] Devices;

        // temp variables for measurement results
        private double P_ON;
        private double P_OFF;

        private int G_ON;
        private int G_OFF;

        private decimal F_ON;
        private decimal F_OFF;

        // averaging objects for display
        private SimpleMovingAverage Av_P_ON;
        private SimpleMovingAverage Av_P_OFF;
        private SimpleMovingAverage Av_G;
        private SimpleMovingAverage Av_NF;

        // dictonary for noise source calibration values
        private Dictionary<double, double> NoiseCal = new Dictionary<double, double>();

        // dictionary for mode descriptor strings
        private Dictionary<string, string> ModeDesc = new Dictionary<string, string>();

        // calibration table
        private CalEntries Calibration = new CalEntries((int)Properties.Settings.Default.CAL_SampleCount_Max);

        // temp variable for local culture
        private CultureInfo LocalCulture;

        public MainForm()
        {
            try
            {
                // save current local LocalCulture
                LocalCulture = Application.CurrentCulture;

                // force culture invariant language for GUI
                Application.CurrentCulture = CultureInfo.InvariantCulture;

                // uprade settings from previous versions on first run
                if (Properties.Settings.Default.FirstRun)
                {
                    Properties.Settings.Default.Upgrade();
                    Properties.Settings.Default.FirstRun = false;
                    Properties.Settings.Default.Save();
                }

                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message + "\nInner:" + ex.InnerException.Message, "Init");
            }

            
            // initialize MMode combobox
            cbb_MMode.Items.AddRange(Enum.GetNames(typeof(MMODE)));
            cbb_MMode.SelectedItem = Properties.Settings.Default.Mode;

            // initialize mode descriptors
            foreach (string item in Properties.Settings.Default.Modes)
            {
                try
                {
                    string mode = item.Split(';')[0];
                    string desc = item.Split(';')[1];
                    ModeDesc.Add(mode, desc);
                }
                catch
                {
                    // do nothing
                }
            }

            // set initial display

            lbl_DUT_Frequency.Text = "-----.---";
            lbl_Gain.Text = "--.--";
            lbl_NF.Text = "--.--";

            lbl_RTL_Gain.Text = "--.--";
            lbl_RTL_P_ON.Text = "--.--";
            lbl_RTL_P_OFF.Text = "--.--";

            // initialize Idle event handler
            Application.Idle += new EventHandler(Application_Idle);

            // initialize RTLWorker's event handlers
            // RTLWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.RTLWorker_DoWork);
            RTLWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.RTLWorker_ProgressChanged);
            RTLWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.RTLWorker_RunWorkerCompleted);

            // load calibration, if enabled
            NoiseCal_Init();

            // initialize value logging
            try
            {
                Values = new StreamWriter(Properties.Settings.Default.RTL_Logging_FileName, false);
                Values.WriteLine("UTC;P_ON[dB];P_OFF[dB];Gain[dB];NF[dB];TunerGain[dB];f[MHz];ENR[dB]");
            }
            catch
            {
                // do nothing if failed
            }
            // set initial mode and state
            MMode = (MMODE)Enum.Parse(typeof(MMODE), Properties.Settings.Default.Mode);
            State = STATE.INIT;
            CalState = CALSTATE.NONE;

            // get basic RTL-Stick information
            Start();
            Status("Ready.");

        }

        private void Application_Idle(Object sender, EventArgs e)
        {
            // start RTLWorker according to state if necessary
            if (!RTLWorker.IsBusy)
            {
                Application.DoEvents();
                Start();
            }
            // update GUI controls according to state
            // set window text according to mode
            try
            {
                Text = "CANFI v" + Assembly.GetExecutingAssembly().GetName().Version + " - " + ModeDesc[Enum.GetName(typeof(MMODE), MMode)];
            }
            catch
            {
                // set default text if failed
                Text = "CANFI v" + Assembly.GetExecutingAssembly().GetName().Version;
            }

            // update frequency display 
            lbl_DUT_Frequency.Text = ud_DUT_Frequency.Value.ToString("00000.000", Application.CurrentCulture);
            // update noise and frequency up/downs
            if ((RTLWorker.IsBusy) && (State != STATE.IDLE))
            {
                // disable controls if not idling
                {
                    ud_RTL_P_ENR.Enabled = false;
                    ud_DUT_P_ENR.Enabled = false;
                    ud_RTL_Frequency.Enabled = false;
                    ud_DUT_Frequency.Enabled = false;
                }
            }
            else
            {
                try
                {
                    switch (MMode)
                    {
                        case MMODE.A:
                            if (Properties.Settings.Default.Noise_File_Activate)
                            {
                                // disable ENR input controls (they are not needed, values are taken from file)
                                ud_RTL_P_ENR.Enabled = false;
                                ud_DUT_P_ENR.Enabled = false;
                                ud_RTL_P_ENR.Value = (decimal)NoiseCal_GetENR(System.Convert.ToDouble(Properties.Settings.Default.RTL_Frequency));
                                ud_DUT_P_ENR.Value = (decimal)NoiseCal_GetENR(System.Convert.ToDouble(Properties.Settings.Default.RTL_Frequency));
                            }
                            else
                            {
                                ud_RTL_P_ENR.Enabled = true;
                                ud_DUT_P_ENR.Enabled = false;
                            }
                            break;
                        case MMODE.B:
                            if (Properties.Settings.Default.Noise_File_Activate)
                            {
                                // disable ENR input controls (they are not needed, values are taken from file)
                                ud_RTL_P_ENR.Enabled = false;
                                ud_DUT_P_ENR.Enabled = false;
                                ud_RTL_P_ENR.Value = (decimal)NoiseCal_GetENR(System.Convert.ToDouble(Properties.Settings.Default.RTL_Frequency));
                                ud_DUT_P_ENR.Value = (decimal)NoiseCal_GetENR(System.Convert.ToDouble(Properties.Settings.Default.DUT_Frequency));
                            }
                            else
                            {
                                ud_RTL_P_ENR.Enabled = true;
                                ud_DUT_P_ENR.Enabled = true;
                            }
                            break;
                        case MMODE.C:
                            if (Properties.Settings.Default.Noise_File_Activate)
                            {
                                ud_RTL_P_ENR.Value = (decimal)NoiseCal_GetENR(System.Convert.ToDouble(Properties.Settings.Default.DUT_Frequency));
                                ud_DUT_P_ENR.Value = (decimal)NoiseCal_GetENR(System.Convert.ToDouble(Properties.Settings.Default.DUT_Frequency));
                            }
                            else
                            {
                                ud_RTL_P_ENR.Enabled = true;
                                ud_DUT_P_ENR.Enabled = true;
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // show error message if no noise source calibration values are available for the current frequencies
                    Error(ex.Message + ": " + Properties.Settings.Default.RTL_Frequency.ToString() + "," + Properties.Settings.Default.DUT_Frequency.ToString());
                }
                // update frequency up/down input controls according to mode
                switch (MMode)
                {
                    case MMODE.A:
                        ud_RTL_Frequency.Enabled = true;
                        ud_DUT_Frequency.Enabled = false;
                        // set DUT frequency synchronous to RTL frequency in mode A 
                        if (ud_DUT_Frequency.Value != ud_RTL_Frequency.Value)
                            ud_DUT_Frequency.Value = ud_RTL_Frequency.Value;
                        break;
                    case MMODE.B:
                        ud_RTL_Frequency.Enabled = true;
                        ud_DUT_Frequency.Enabled = true;
                        break;
                    case MMODE.C:
                        ud_RTL_Frequency.Enabled = true;
                        ud_DUT_Frequency.Enabled = true;
                        break;
                }
            }
            // set controls according to the current state
            // be careful while changing button colors here
            // always check current color for changes before setting it new
            // setting the same color in idle procedure without checking for changes will cause maximum CPU load
            switch (State)
            {
                case STATE.INIT:
                    cbb_MMode.Enabled = true;
                    btn_Settings.Enabled = false;
                    btn_Calibrate.Text = "Calibrate";
                    btn_Calibrate.Enabled = false;
                    if (btn_Calibrate.BackColor != SystemColors.Control)
                        btn_Calibrate.BackColor = SystemColors.Control;
                    btn_Measure.Text = "Measure";
                    btn_Measure.Enabled = false;
                    if (btn_Measure.BackColor != SystemColors.Control)
                        btn_Measure.BackColor = SystemColors.Control;
                    lbl_NF.Text = "--.--";
                    break;
                case STATE.IDLE:
                    cbb_MMode.Enabled = true;
                    btn_Settings.Enabled = true;
                    btn_Measure.Text = "Measure";
                    btn_Measure.Enabled = true;
                    if (btn_Measure.BackColor != Color.PaleGreen)
                        btn_Measure.BackColor = Color.PaleGreen;
                    // set Calibrate button according to CALSTATE
                    switch (CalState)
                    {
                        case CALSTATE.NONE:
                            btn_Calibrate.Text = "Calibrate";
                            btn_Calibrate.Enabled = true;
                            if (btn_Calibrate.BackColor != Color.MistyRose)
                                btn_Calibrate.BackColor = Color.MistyRose;
                            lbl_Gain.Text = "--.--";
                            break;
                        case CALSTATE.CALIBRATED:
                            btn_Calibrate.Text = "Calibrated";
                            btn_Calibrate.Enabled = true;
                            if (btn_Calibrate.BackColor != Color.Coral)
                                btn_Calibrate.BackColor = Color.Coral;
                            lbl_Gain.Text = "00.00";
                            break;
                    }
                    lbl_NF.Text = "00.00";
                    break;
                case STATE.CALIBRATING:
                    cbb_MMode.Enabled = false;
                    btn_Settings.Enabled = false;
                    btn_Calibrate.Text = "Stop";
                    btn_Calibrate.Enabled = true;
                    if (btn_Calibrate.BackColor != Color.Coral)
                        btn_Calibrate.BackColor = Color.Coral;
                    btn_Measure.Text = "Measure";
                    btn_Measure.Enabled = false;
                    if (btn_Measure.BackColor != SystemColors.Control)
                        btn_Measure.BackColor = SystemColors.Control;
//                    Status("Calibrating...");
                    break;
                case STATE.MEASURING:
                    cbb_MMode.Enabled = false;
                    btn_Settings.Enabled = false;
                    btn_Calibrate.Text = "Calibrate";
                    btn_Calibrate.Enabled = false;
                    if (btn_Calibrate.BackColor != SystemColors.Control)
                        btn_Calibrate.BackColor = SystemColors.Control;
                    btn_Measure.Text = "Stop";
                    btn_Measure.Enabled = true;
                    if (btn_Measure.BackColor != Color.PaleGreen)
                        btn_Measure.BackColor = Color.PaleGreen;
//                    Status("Measuring...");
                    break;
            }
            // set FFT status
            lbl_FFT_Filter.BackColor = Properties.Settings.Default.FFT_Filter ? Color.Red : Color.WhiteSmoke;
            if (Properties.Settings.Default.FFT_Filter)
            {
                tb_FFT_Filter_Threshold.Enabled = true;
                tb_FFT_Filter_NotchWidth.Enabled = true;
            }
            else
            {
                tb_FFT_Filter_Threshold.Enabled = false;
                tb_FFT_Filter_NotchWidth.Enabled = false;
            }
            // this is for Linux Mono compatibility only

            // setting control's fore color according to enabled/disabled state
            ud_RTL_Frequency.ForeColor = ud_RTL_Frequency.Enabled ? Color.Chartreuse : Color.DarkGray;
            ud_DUT_Frequency.ForeColor = ud_DUT_Frequency.Enabled ? Color.Chartreuse : Color.DarkGray;
            ud_RTL_P_ENR.ForeColor = ud_RTL_P_ENR.Enabled ? Color.Chartreuse : Color.DarkGray;
            ud_DUT_P_ENR.ForeColor = ud_DUT_P_ENR.Enabled ? Color.Chartreuse : Color.DarkGray;

            // end of Linux Mono compatibility
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // stop background thread immediately
            RTLWorker.CancelAsync();
            // save current settings
            Properties.Settings.Default.Save();
        }

        public void Start()
        {
            // start up background thread
            Status("Starting...");
            Error("");
            if (!RTLWorker.IsBusy)
            {
                // set all parameters
                _rtlParams.State = State;

                // set sweep to single frequency
                _rtlParams.Frequency_Start = Properties.Settings.Default.RTL_Frequency;
                _rtlParams.Frequency_Stop = Properties.Settings.Default.RTL_Frequency;
                _rtlParams.Frequency_Step = 0;

                _rtlParams.UseRTLAGC = Properties.Settings.Default.RTL_RTLAGC;
                _rtlParams.UseTunerAGC = Properties.Settings.Default.RTL_TunerAGC;
                _rtlParams.TunerGain = Properties.Settings.Default.RTL_TunerGain;
                _rtlParams.GainMode = Properties.Settings.Default.RTL_GainMode;
                _rtlParams.AGC = Properties.Settings.Default.RTL_AGC_Auto;
                _rtlParams.P_Max = Properties.Settings.Default.RTL_P_Max;

                _rtlParams.SampleRate = Decimal.ToUInt32(Properties.Settings.Default.RTL_SampleRate);
                _rtlParams.MaxSampleCount = Decimal.ToInt32(Properties.Settings.Default.RTL_SampleCount);

                _rtlParams.COMPort = Properties.Settings.Default.COM_Port;
                _rtlParams.COMPortUse = Properties.Settings.Default.COM_Port_Use;
                _rtlParams.COMNoise = Properties.Settings.Default.COM_Noise;
                _rtlParams.COMNoiseUse = Properties.Settings.Default.COM_Noise_Use;
                _rtlParams.COMNoiseInverse = Properties.Settings.Default.COM_Noise_Inverse;
                _rtlParams.COMDUT = Properties.Settings.Default.COM_DUT;
                _rtlParams.COMDUTUse = Properties.Settings.Default.COM_DUT_Use;
                _rtlParams.COMDUTInverse = Properties.Settings.Default.COM_DUT_Inverse;
                _rtlParams.COMDelay = (int)Properties.Settings.Default.COM_Delay;

                try
                {
                    _rtlParams.Device = ((RTLDevice[])Properties.Settings.Default.RTL_Devices)[Properties.Settings.Default.RTL_DeviceIndex];
                }
                catch
                {
                    _rtlParams.Device = null;
                }

                _rtlParams.Clip_MinValue = Decimal.ToInt32(Properties.Settings.Default.RTL_ClipValue_Min);
                _rtlParams.Clip_MaxValue = Decimal.ToInt32(Properties.Settings.Default.RTL_ClipValue_Max);
                _rtlParams.Clip_MaxClipAllowed = Decimal.ToInt32(Properties.Settings.Default.RTL_MaxClipAllowed);

                _rtlParams.Averaging_Min = Decimal.ToInt32(Properties.Settings.Default.CAL_SampleCount_Min);
                _rtlParams.Averaging_Max = Decimal.ToInt32(Properties.Settings.Default.CAL_SampleCount_Max);

                _rtlParams.FFT_RealtimeDisplay = Properties.Settings.Default.FFT_RealtimeDisplay;
                _rtlParams.FFT_Filter = Properties.Settings.Default.FFT_Filter;
                _rtlParams.FFT_Filter_Threshold = Properties.Settings.Default.FFT_Filter_Threshold;
                _rtlParams.FFT_Filter_NotchWidth = Properties.Settings.Default.FFT_Filter_NotchWidth;

                _rtlParams.Calibration = Calibration;
                
                // clear all values and averages
                P_ON = 0;
                P_OFF = 0;
                G_ON = 0;
                G_OFF = 0;
                InitAverages();

                // clear status and error messages
                Status("");
                if (State > STATE.IDLE)
                    Error("");

                // start measure thread
                RTLWorker.RunWorkerAsync(_rtlParams);

            }
        }

        public void Stop()
        {
            // stop measure thread and wait for IDLE state
            try
            {
                RTLWorker.CancelAsync();
                Status("Waiting for measure thread to close...");
                while (State != STATE.IDLE)
                    Application.DoEvents();
            }
            catch
            {
                // do nothing
            }
        }

        public void Idle()
        {
            // set state to IDLE
            State = STATE.IDLE;
        }

        public void Calibrate()
        {
            // set state to CALIBRATING
            State = STATE.CALIBRATING;
        }

        public void Measure()
        {
            // set state to MEASURING
            State = STATE.MEASURING;
        }


        # region Noise functions

        private void NoiseCal_Init()
        {
            // initialize the noise source calibration table
            // clear noise calibration            
            NoiseCal.Clear();
            int count = 0;
            // check if reading from calibration file is enabled and the file name is not empty
            if ((Properties.Settings.Default.Noise_File_Activate) && (!String.IsNullOrEmpty(Properties.Settings.Default.Noise_FileName)))
            {
                try
                {
                    // open the stream
                    using (StreamReader sr = new StreamReader(Properties.Settings.Default.Noise_FileName))
                    {
                        while (!sr.EndOfStream)
                        {
                            // read a line
                            string s = sr.ReadLine().Trim();
                            // check for valid data line
                            if (!String.IsNullOrEmpty(s) && 
                                (!s.StartsWith("/")) &&
                                (s.IndexOf(';') > 0))
                            {
                                // for Linux Mono compatibility
                                // Double.TryParse seems not to work or ignores regional provider settings under Mono
                                // try System.Convert.ToDouble instead
                                // detect current LocalCulture and change decimal point accordingly
//                                s = s.Replace(".", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
//                                if (s.IndexOf(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator) < 0)
//                                    MessageBox.Show(s + "--> does not match current decimal separator");
                                // end of Linux Mono compatibility
                                // split the line and try to convert the entries to frequency and ENR
                                string[] a = s.Split(';');
                                double f = 0;
                                double enr = 0;
                                try
                                {
                                    f = System.Convert.ToDouble(a[0].Trim(),CultureInfo.InvariantCulture);
                                    enr = System.Convert.ToDouble(a[1].Trim(),CultureInfo.InvariantCulture);
                                }
                                catch
                                {
                                    f = 0;
                                    enr = 0;
                                    MessageBox.Show(s + " ---> " + f.ToString("F2", CultureInfo.InvariantCulture) + " --- " + enr.ToString("F2", CultureInfo.InvariantCulture) + "\n\n" +
                                        "CurrentCulture: " + Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName + "\n" +
                                        "DecimalSeparator: " + Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator,
                                        "Error reading calibration entry");
                                }
                                // add an entry to NoiseCal list
                                // frequency is in Ghz!!!
                                // ENR is in dB
                                if ((f > 0) && (enr > 0))
                                {
                                    try
                                    {
                                        NoiseCal.Add(f, enr);
                                        count++;
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Error adding noise calibration entry");
                                    }
                                }
                            }
                        }
                    }
                    Status(Properties.Settings.Default.Noise_FileName + " loaded. " + count.ToString() + " entries.");
                }
                catch (Exception ex)
                {
                    // display error message if failed
                    MessageBox.Show(ex.Message, "Error reading noise calibration file");
                }
            }
        }

        public double NoiseCal_GetENR(double f)
        {
            // get ENR value from calibration file
            // Input: f in MHz
            // return: ENR in dB
            // if a frequency value is not found exactly --> try to interpolate between two next entries

            // check if calibration values are present, else return 0
            if (NoiseCal.Count <= 0)
                return 0;

            try
            {
                // found f in between keys
                KeyValuePair<double, double> lowerFoundKey = new KeyValuePair<double, double>(double.NaN, double.NaN);
                KeyValuePair<double, double> upperFoundKey = new KeyValuePair<double, double>(double.NaN, double.NaN);

                foreach (KeyValuePair<double, double> key in NoiseCal)
                {
                    if (key.Key > f / 1E03)
                    {
                        upperFoundKey = key;
                        break;
                    }
                    else
                        lowerFoundKey = key;
                }
                // check if both keys are found, else return 0
                if ((lowerFoundKey.Key == double.NaN) || (upperFoundKey.Key == double.NaN))
                    return 0;

                // interpolate value
                double fratio = (f / 1E03 - lowerFoundKey.Key) / (upperFoundKey.Key - lowerFoundKey.Key);
                double enr = SupportFunctions.TodB(SupportFunctions.ToLinear(lowerFoundKey.Value) + fratio * (SupportFunctions.ToLinear(upperFoundKey.Value) - SupportFunctions.ToLinear(lowerFoundKey.Value)));
                if (double.IsNaN(enr))
                    return 0;
                return enr;
            }
            catch
            {
                // return 0 if failed
                return 0;
            }
        }

        void NoiseCal_Save()
        {
        }

        #endregion

        #region Support functions

        public void InitAverages()
        {
            // initialize averages for display
            Av_P_ON = new SimpleMovingAverage((int)Math.Pow(2,(double) Properties.Settings.Default.Smoothing));
            Av_P_OFF = new SimpleMovingAverage((int)Math.Pow(2, (double)Properties.Settings.Default.Smoothing));
            Av_G = new SimpleMovingAverage((int)Math.Pow(2, (double)Properties.Settings.Default.Smoothing));
            Av_NF = new SimpleMovingAverage((int)Math.Pow(2, (double)Properties.Settings.Default.Smoothing));
        }

        public void Status(string msg)
        {
            // show a status message
            if (msg != ssl_Status.Text)
            {
                ssl_Status.Text = msg;
                ss_main.Update();
            }
        }

        public void Error(string err)
        {
            // show an error message
            if (err != ssl_Error.Text)
            {
                ssl_Error.Text = err;
                ss_main.Update();
            }
        }


        #endregion

        
        #region Callback Procedures

        public void ReportCalibrating(RTLMeasureResults r)
        {
            // callback for computing results from Calibration
            // return on invalid results
            if (r.Invalid)
            {
                lbl_RTL_Gain.Text = (r.TunerGain / 10.0).ToString("F2", CultureInfo.InvariantCulture);
                lbl_RTL_P_ON.Text = "--.--";
                lbl_RTL_P_OFF.Text = "--.--";
                lbl_RTL_Status.ForeColor = Color.Red;
                lbl_RTL_Status.Text = "Invalid";
                return;
            }
            // get raw values for power and gain and frequency according to noise source state
            if (r.Noise_ON)
            {
                P_ON = r.Power;
                G_ON = r.TunerGain;
                F_ON = r.Frequency;
            }
            else
            {
                P_OFF = r.Power;
                G_OFF = r.TunerGain;
                F_OFF = r.Frequency;
            }
            // check for frequency mismatch
            if (F_ON != F_OFF)
            {
                return;
            }
            // return on P_OFF > P_ON (this is physically impossible)
            if (P_OFF > P_ON)
            {
                lbl_RTL_Gain.Text = (r.TunerGain / 10.0).ToString("F2", CultureInfo.InvariantCulture);
                lbl_RTL_P_ON.Text = "--.--";
                lbl_RTL_P_OFF.Text = "--.--";
                lbl_RTL_Status.ForeColor = Color.Red;
                lbl_RTL_Status.Text = "Invalid";
                return;
            }
            // check for gain mismatch --> reset all averages
            if (G_ON != G_OFF)
            {
                InitAverages();
                return;
            }
            // update tuner gain display
            lbl_RTL_Gain.Text = (r.TunerGain / 10.0).ToString("F2",CultureInfo.InvariantCulture);
            // update display
            lbl_RTL_P_ON.Text = SupportFunctions.TodB(P_ON).ToString("F2", CultureInfo.InvariantCulture);
            lbl_RTL_P_OFF.Text = SupportFunctions.TodB(P_OFF).ToString("F2", CultureInfo.InvariantCulture);
            lbl_RTL_Status.ForeColor = Color.Chartreuse;
            lbl_RTL_Status.Text = "Valid";

            // update calibration
            CalEntry entry = new CalEntry((int)Properties.Settings.Default.CAL_SampleCount_Max);
            entry.Invalid = false;
            entry.Frequency = r.Frequency;
            entry.TunerGain = r.TunerGain;
            entry.P_OFF.AddSample(P_OFF);
            entry.P_ON.AddSample(P_ON);
            // get proper ENR values according to MMode
            double CAL_ENR = SupportFunctions.ToLinear(System.Convert.ToDouble(ud_RTL_P_ENR.Value));
            entry.ENR = CAL_ENR;
            // try to calculate rest of values
            try
            {
                entry.Y = entry.P_ON.Average / entry.P_OFF.Average;
                entry.F = SupportFunctions.ToLinear(entry.ENR) / (entry.Y - 1);
                entry.NF = SupportFunctions.TodB(entry.F);
            }
            catch
            {
                entry.Y = 1;
                entry.F = 1;
                entry.NF = 0;
            }
            Calibration[entry.Frequency, entry.TunerGain] = entry;
            if (!double.IsNaN(entry.NF))
                lbl_NF.Text = entry.NF.ToString("F2", CultureInfo.InvariantCulture);
        }

        public void ReportMeasuring(RTLMeasureResults r)
        {
            // callback for computing results from Measuring
            // return on invalid results
            if (r.Invalid)
            {
                lbl_RTL_Gain.Text = (r.TunerGain / 10.0).ToString("F2", CultureInfo.InvariantCulture);
                lbl_RTL_P_ON.Text = "--.--";
                lbl_RTL_P_OFF.Text = "--.--";
                lbl_RTL_Status.ForeColor = Color.Red;
                lbl_RTL_Status.Text = "Invalid";
                return;
            }
            // get raw values for power and gain and frequency according to noise source state
            if (r.Noise_ON)
            {
                P_ON = r.Power;
                G_ON = r.TunerGain;
                F_ON = r.Frequency;
            }
            else
            {
                P_OFF = r.Power;
                G_OFF = r.TunerGain;
                F_OFF = r.Frequency;
            }
            // check for frequency mismatch
            if (F_ON != F_OFF)
            {
                return;
            }
            // return on P_OFF > P_ON (this is physically impossible)
            if (P_OFF > P_ON)
            {
                lbl_RTL_Gain.Text = (r.TunerGain / 10.0).ToString("F2", CultureInfo.InvariantCulture);
                lbl_RTL_P_ON.Text = "--.--";
                lbl_RTL_P_OFF.Text = "--.--";
                lbl_RTL_Status.ForeColor = Color.Red;
                lbl_RTL_Status.Text = "Invalid";
                return;
            }
            // check for gain mismatch --> reset all averages
            if (G_ON != G_OFF)
            {
                InitAverages();
                return;
            }
            // update tuner display
            lbl_RTL_Gain.Text = (r.TunerGain / 10.0).ToString("F2", CultureInfo.InvariantCulture);
            if (r.Noise_ON)
            {
                Av_P_ON.AddSample(r.Power);
                lbl_RTL_P_ON.Text = SupportFunctions.TodB(r.Power).ToString("F2", CultureInfo.InvariantCulture);
                lbl_RTL_Status.ForeColor = Color.Chartreuse;
                lbl_RTL_Status.Text = "Valid";
            }
            else
            {
                P_OFF = r.Power;
                G_OFF = r.TunerGain;
                Av_P_OFF.AddSample(r.Power);
                lbl_RTL_P_OFF.Text = SupportFunctions.TodB(r.Power).ToString("F2", CultureInfo.InvariantCulture);
            }

            // get proper ENR values according to MMode
            double P_ENR = SupportFunctions.ToLinear(System.Convert.ToDouble(ud_DUT_P_ENR.Value));
            double CAL_ENR = SupportFunctions.ToLinear(System.Convert.ToDouble(ud_RTL_P_ENR.Value));
            // calculte and display gain and NF
            // temperature correction included 2014-09-01
            double F = 0;
            double G = 0;
            double Y = 0;
            double T_amb = (double)Properties.Settings.Default.Tamb;
            double T_0 = (double)Properties.Settings.Default.T0;
            try
            {
                switch (CalState)
                {
                    case CALSTATE.NONE:
                        // calculate and show results if values available
                        // not calibrated --> gain value is not available 
                        F = 0;
                        G = 0;
                        Y = 0;
                        Y = P_ON / P_OFF;
//                        nf = CAL_ENR / (Y - 1);
                        F = P_ENR / (Y - 1) + 1 - T_amb / T_0;
                        if ((double.IsNaN(F)) || double.IsInfinity(F))
                            F = 1;
                        // add NF to floating average
                        Av_NF.AddSample(F);
                        lbl_Gain.Text = "--.--";
                        lbl_NF.Text = SupportFunctions.TodB(Av_NF.Average).ToString("F2", CultureInfo.InvariantCulture);
                        break;
                    case CALSTATE.CALIBRATED:
                        //  calculate and show results if values available
                        // calibrated mode --> calculate gain value too
                        double CAL_ON = 0;
                        double CAL_OFF = 0;
                        double CAL_Y = 0;
                        // try to get calibration values
                        CalEntry entry = Calibration[r.Frequency, r.TunerGain];
                        if (entry != null)
                        {
                            CAL_ON = entry.P_ON.Average;
                            CAL_OFF = entry.P_OFF.Average;
                            CAL_Y = entry.Y;
                        }
                        else
                        {
                            // set to default if failed
                            CAL_ON = 0;
                            CAL_OFF = 0;
                            CAL_Y = 1;
                        }
                        // calculate and show results if values available
                        F = 0;
                        G = 0;
                        Y = 0;
                        G = (P_ON - P_OFF) / (CAL_ON - CAL_OFF) * P_ENR / CAL_ENR;
                        // add samples for average
                        if ((double.IsNaN(G)) || (double.IsInfinity(G)))
                            G = 1;
                        // add gain to average
                        Av_G.AddSample(G);
                        Y = P_ON / P_OFF;
                        F = P_ENR / (Y - 1) - (CAL_ENR / (CAL_Y - 1) - T_amb/T_0) / G + 1 - T_amb/T_0;
                        if ((double.IsNaN(F)) || double.IsInfinity(F))
                            F = 1;
                        // add NF to average
                        Av_NF.AddSample(F);
                        lbl_Gain.Text = SupportFunctions.TodB(Av_G.Average).ToString("F2", CultureInfo.InvariantCulture);
                        lbl_NF.Text = SupportFunctions.TodB(Av_NF.Average).ToString("F2", CultureInfo.InvariantCulture);
                        break;
                    default:
                        // show nothing if an invalid calibration state is detected
                        lbl_Gain.Text = "--.--";
                        lbl_NF.Text = "--.--";
                        break;

                }
            }
            catch
            {
                // do nothing if failed
            }
            // write values to file if enabled
            if (Properties.Settings.Default.RTL_Logging)
            {
                // get measure frequency
                double f = 0;
                switch (MMode)
                {
                    case MMODE.A:
                        f = Decimal.ToDouble(r.Frequency);
                        break;
                    case MMODE.B:
                        f = Decimal.ToDouble(Properties.Settings.Default.DUT_Frequency);
                        break;
                    case MMODE.C:
                        f = Decimal.ToDouble(Properties.Settings.Default.DUT_Frequency);
                        break;
                }
                Values.WriteLine(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss,fff") + ";" +
                    SupportFunctions.TodB(P_ON).ToString("F2", LocalCulture) + ";" +
                    SupportFunctions.TodB(P_OFF).ToString("F2", LocalCulture) + ";" +
                    SupportFunctions.TodB(G).ToString("F2", LocalCulture) + ";" +
                    SupportFunctions.TodB(F).ToString("F2", LocalCulture) + ";" +
                    (Properties.Settings.Default.RTL_TunerGain/10).ToString("F2", LocalCulture) + ";" +
                    f.ToString("F3", LocalCulture) + ";" +
                    SupportFunctions.TodB(P_ENR).ToString("F2", LocalCulture));
                Values.Flush();
            }
        }

        public void ReportFFT(double[] e)
        {
            // callback for showing FFT results
            // get additional info from fft
            if (e == null)
                return;
            try
            {
                // get length of FFT array
                int len = e.Length;
                // displayed count of points, reduced to 512 to avoid performance issues
                int displen = 512;
                int step = len / displen;
                double[] c = new double[displen];
                // reduce the FFT results to fit the display
                for (int i = 0; i < displen; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < step; j++)
                    {
                        sum += e[i * step + j];
                    }
                    c[i] = sum / step;
                    // check if mean value is NaN --> set it to 0
                    if (double.IsNaN(c[i]))
                        c[i] = 0;
                }
                // clear the FFT series
                ch_FFT.Series["FFT"].Points.Clear();
                // add new points
                for (int i = 0; i < c.Length; i++)
                {
                    ch_FFT.Series["FFT"].Points.Add(c[i]);
                }
                // set basic appearance of display
//                ch_FFT.Series["FFT"].BorderWidth = 1;
                ch_FFT.ChartAreas["Main"].AxisY.Minimum = 0;
                ch_FFT.ChartAreas["Main"].AxisY.Maximum = 60;
                ch_FFT.ChartAreas["Main"].AxisX.MajorGrid.Interval = c.Length / 2;
            }
            catch
            {
                // do nothing if failed
            }
        }

        #endregion

        
        #region RTLWorker

        // background thread for measurement

        private void RTLWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // main background thread callback for reporting progress
            // always called if background thread has something to tell
            // use e.ProgressPercentage to switch between different conditions
            // extra data may have been stored in e.UserState
            if (e.ProgressPercentage == (int)PROGRESS.ERROR)
            {
                // an error occured --> show error message only
                if (e.UserState == null)
                    return;
                Error((string)e.UserState);
                // reset state
                // State = STATE.IDLE;
            }
            else if (e.ProgressPercentage == (int)PROGRESS.INIT)
            {
                // initialization progress message --> report active RTL devices 
                if (e.UserState == null)
                    return;
                Devices = (RTLDevice[])e.UserState;
                // store result in settings
                Properties.Settings.Default.RTL_Devices = Devices;
            }
            else if (e.ProgressPercentage == (int)PROGRESS.MESSAGE)
            {
                // simple text messages --> update display
                if (e.UserState == null)
                    return;
                string st = (string)e.UserState;
                if (!String.IsNullOrEmpty(st))
                    Status(st);
            }
            else if (e.ProgressPercentage == (int)PROGRESS.STATUS)
            {
                // initialization complete or other status messages --> update display
                if (e.UserState == null)
                    return;
                RTLStatus st = (RTLStatus)e.UserState;
                if (!String.IsNullOrEmpty(st.Message))
                    Status(st.Message);
                lbl_Noise.BackColor = st.Noise_ON ? Color.Red : Color.WhiteSmoke;
                lbl_DUT.BackColor = st.DUT_ON ? Color.Red : Color.WhiteSmoke;
            }
            else if (e.ProgressPercentage == (int)PROGRESS.FINISHED)
            {
                // measure cycle complete message
                if (e.UserState == null)
                    return;
                // switch to callback procedure according to state
                switch (State)
                {
                    case STATE.CALIBRATING:
                        ReportCalibrating((RTLMeasureResults)e.UserState);
                        break;
                    case STATE.MEASURING:
                        ReportMeasuring((RTLMeasureResults)e.UserState);
                        break;
                }
            }
            else if (e.ProgressPercentage == (int)PROGRESS.FFT)
            {
                // FFT complete message --> update FFT display 
                ReportFFT((double[]) e.UserState);
            }
            // not defined!
        }

        private void RTLWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // main background thread callback if thread is about to close
            RTLParams p = (RTLParams)e.Result;
            // do some after work procedures and cleanups
            switch (p.State)
            {
                case STATE.INIT:
                    // finishing initialization
                    // goto idle state
                    Idle();
                    break;
                case STATE.CALIBRATING:
                    // finishing calibration
                     // save calibration results to file if enabled
                    if (Properties.Settings.Default.CAL_Logging)
                    {
                        Calibration.ExportToCSV(Properties.Settings.Default.CAL_Logging_FileName);
                    }
                    // set CalState to calibrated
                    CalState = CALSTATE.CALIBRATED;
                    // goto idle state
                    Idle();
                    break;
                case STATE.MEASURING:
                    // finishing measuring
                    // goto idle state
                    Idle();
                    break;
            }
        }

        #endregion

        #region GUI Controls

        private void btn_Calibrate_Click(object sender, EventArgs e)
        {
            if (State != STATE.CALIBRATING)
            {
                // stop any running measurement
                Stop();
                // clear calibration values
                Calibration.Clear();
                CalState = CALSTATE.NONE;
                Calibrate();
            }
            else
            {
                // stop any running measurement
                Stop();
                // clear calibration values
                Calibration.Clear();
                CalState = CALSTATE.NONE;
            }

        }

        private void btn_Measure_Click(object sender, EventArgs e)
        {
            if (State != STATE.MEASURING)
            {
                // stop any running measurement
                Stop();
                P_ON = 0;
                P_OFF = 0;
                Av_P_OFF.ClearSamples();
                Av_P_ON.ClearSamples();
                Av_G.ClearSamples();
                Av_NF.ClearSamples();
                Measure();
            }
            else
            {
                // stop any running measurement
                Stop();
            }
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            // save all settings first
            Properties.Settings.Default.Save();
            // stop any running measurement
            Stop();
            // open settings dialog
            SettingsDlg Dlg = new SettingsDlg();
            try
            {
                if (Dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // save Settings
                    try
                    {
                        // plausibility check of settings
                        if (Dlg.cbb_Device.SelectedItem != null)
                            Properties.Settings.Default.RTL_Device = ((RTLDevice)Dlg.cbb_Device.SelectedItem).Name;
                        else
                            Properties.Settings.Default.RTL_Device = "";
                        if ((Dlg.rb_Noise_Cal_File.Checked == true) && String.IsNullOrEmpty(Dlg.tb_Noise_FileName.Text))
                        {
                            MessageBox.Show("No calibration file was seleceted. Option will be disabled.", "Load noise source calibration data from file");
                            Properties.Settings.Default.Noise_File_Activate = false;
                            Properties.Settings.Default.Noise_FileName = "";
                        }
                        if ((Dlg.cbb_COM.SelectedItem == null) || (Dlg.cbb_COM.SelectedItem.ToString() == "[none]"))
                        {
                            MessageBox.Show("You must select a COM port for noise source control to get CANFI working.", "Select COM Port");
                            Properties.Settings.Default.COM_Port_Use = false;
                            Properties.Settings.Default.COM_Port = "[none]";
                        }
                        else
                        {
                            Properties.Settings.Default.COM_Port_Use = true;
                            Properties.Settings.Default.COM_Port = Dlg.cbb_COM.SelectedItem.ToString();
                        }
                        Properties.Settings.Default.Save();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Problem while saving settings");
                    }
                    // load noise calibration if enabled
                    if (Properties.Settings.Default.Noise_File_Activate)
                        NoiseCal_Init();
                    else
                        NoiseCal.Clear();

                    // reset state to INIT and restart, if necessary
                    if (Dlg.InvalidateCalibration)
                    {
                        Stop();
                        Calibration.Clear();
                        CalState = CALSTATE.NONE;
                        State = STATE.INIT;
                        Start();
                    }
                }
                else
                {
                    // restore settings
                    Properties.Settings.Default.Reload();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SettingsDlg");
            }
        }

        private void cbb_MMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Mode = (string) cbb_MMode.SelectedItem;
            MMode = (MMODE)Enum.Parse(typeof(MMODE), Properties.Settings.Default.Mode);
            // set Mode Tooltip according to MMode
            try
            {
                tt_Main.SetToolTip(cbb_MMode, ModeDesc[Enum.GetName(typeof(MMODE), MMode)]);
            }
            catch
            {
                // no Tooltip availabe
                tt_Main.SetToolTip(cbb_MMode, "Not available.");
            }
        }

        private void cbb_MMode_DropDown(object sender, EventArgs e)
        {
            // set Mode Tooltip according to MMode
            try
            {
                string text = "Chose Measure mode:\n\n";
                foreach (KeyValuePair<string, string> item in ModeDesc)
                {
                    text += item.Key + ": " + item.Value + "\n";
                }
                tt_Main.SetToolTip(cbb_MMode, text);
            }
            catch
            {
                // no Tooltip availabe
                tt_Main.SetToolTip(cbb_MMode, "Not available.");
            }

        }

        private void cbb_MMode_DropDownClosed(object sender, EventArgs e)
        {
            // set Mode Tooltip according to MMode
            try
            {
                tt_Main.SetToolTip(cbb_MMode, ModeDesc[Enum.GetName(typeof(MMODE), MMode)]);
            }
            catch
            {
                // no Tooltip availabe
                tt_Main.SetToolTip(cbb_MMode, "Not available.");
            }
        }

        private void ud_RTL_Frequency_ValueChanged(object sender, EventArgs e)
        {
            // reset state uncalibrated when frequency has changed
            Calibration.Clear();
            CalState = CALSTATE.NONE;
        }

        private void ud_DUT_Frequency_ValueChanged(object sender, EventArgs e)
        {
            // reset state uncalibrated when frequency has changed
            Calibration.Clear();
            CalState = CALSTATE.NONE;
        }

        private void ud_RTL_Frequency_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                NumericUpDown numericUpDownsender = (sender as NumericUpDown);

                TextBoxBase txtBase = numericUpDownsender.Controls[1] as TextBoxBase;
                int currentCaretPosition = txtBase.SelectionStart;
                numericUpDownsender.DataBindings[0].WriteValue();
                txtBase.SelectionStart = currentCaretPosition;
            }
            catch
            {

            }
        }

        private void ud_Smoothing_ValueChanged(object sender, EventArgs e)
        {
            InitAverages();
        }

        private void lbl_RTL_Frequency_Click(object sender, EventArgs e)
        {
            SweepDlg Dlg = new SweepDlg();
            Dlg.ShowDialog();
        }

        private void lbl_FFT_Click(object sender, EventArgs e)
        {
            // toggle FFT Filter Activation
            Properties.Settings.Default.FFT_Filter = !Properties.Settings.Default.FFT_Filter;
            // change RTLWorkers' parameters online
            // CAUTION: Do not forget to lock the variables first!
            lock (RTLWorker.Params)
            {
                RTLWorker.Params.FFT_Filter = Properties.Settings.Default.FFT_Filter;
            }
        }

        private void tb_FFT_Filter_Threshold_Scroll(object sender, EventArgs e)
        {
            // change RTLWorkers' parameters online
            // CAUTION: Do not forget to lock the variables first!
            lock (RTLWorker.Params)
            {
                RTLWorker.Params.FFT_Filter_Threshold = Properties.Settings.Default.FFT_Filter_Threshold;
            }

        }

        private void tb_FFT_Filter_NotchWidth_Scroll(object sender, EventArgs e)
        {
            // change RTLWorkers' parameters online
            // CAUTION: Do not forget to lock the variables first!
            lock (RTLWorker.Params)
            {
                RTLWorker.Params.FFT_Filter_NotchWidth = Properties.Settings.Default.FFT_Filter_NotchWidth;
            }
        }

     }

    #endregion

}
