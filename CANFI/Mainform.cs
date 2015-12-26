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
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.IO;
using System.Globalization;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Diagnostics;
using Clifton.Tools.Data;
using CANFICore;

namespace CANFI
{


    public unsafe partial class MainForm : Form
    {

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
        private SimpleMovingAverage Av_G;
        private SimpleMovingAverage Av_F;

        // dictonary for noise source calibration values
        private Dictionary<double, double> NoiseCal = new Dictionary<double, double>();

        // dictionary for mode descriptor strings
        private Dictionary<string, string> ModeDesc = new Dictionary<string, string>();

        // calibration table
        private CalEntries Calibration = new CalEntries((int)Properties.Settings.Default.CAL_SampleCount_Max);

        // temp variable for local culture
        private CultureInfo LocalCulture;

        private string rtlsdr_dir;

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

            // set rtlsdr directory
             rtlsdr_dir = Application.StartupPath + Path.DirectorySeparatorChar + Properties.Settings.Default.RTL_DLL_DirName;

            // reset sweep mode to NONE and save settings
            Properties.Settings.Default.SweepMode = SMODE.NONE;
            Properties.Settings.Default.Save();

            // set initial mode and state
            State = STATE.NONE;
            CalState = CALSTATE.NONE;

            // initialize Properties.Settings.Default.Mode combobox
            cbb_MMode.Items.Add(MMODE.A);
            cbb_MMode.Items.Add(MMODE.B);
            cbb_MMode.Items.Add(MMODE.C);
            cbb_MMode.SelectedItem = Properties.Settings.Default.Mode;

            // initialize Properties.Settings.Default.SweepMode combobox
            cbb_SMode.Items.Add(SMODE.NONE);
            cbb_SMode.Items.Add(SMODE.SINGLE);
            cbb_SMode.Items.Add(SMODE.CONTINUOS);
            cbb_SMode.SelectedItem = Properties.Settings.Default.SweepMode;

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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // set initial display

            lbl_DUT_Frequency.Text = "-----.---";
            lbl_Gain.Text = "--.--";
            lbl_NF.Text = "--.--";

            lbl_RTL_Gain.Text = "--.--";
            lbl_RTL_P_ON.Text = "--.--";
            lbl_RTL_P_OFF.Text = "--.--";

            // append DLL search path
            Environment.SetEnvironmentVariable("PATH", Environment.GetEnvironmentVariable("PATH") + ";" + rtlsdr_dir);
            // set State to INIT
            State = STATE.INIT;
            // startup application
            Start();
            Status("Ready.");
        }

        private void Application_Idle(Object sender, EventArgs e)
        {
            // start RTLWorker according to state if necessary
            if ((State != STATE.NONE) && (State != STATE.SETTING) && !RTLWorker.IsBusy)
            {
                Application.DoEvents();
                Start();
            }
            // update GUI controls according to state
            // set window text according to mode
            try
            {
                Text = "CANFI v" + Assembly.GetExecutingAssembly().GetName().Version + " - " + ModeDesc[Enum.GetName(typeof(MMODE), Properties.Settings.Default.Mode)];
            }
            catch
            {
                // set default text if failed
                Text = "CANFI v" + Assembly.GetExecutingAssembly().GetName().Version;
            }

            // update frequency and ENR up/downs
            switch (Properties.Settings.Default.Mode)
            {
                case MMODE.A:
                    if (ud_DUT_Frequency.Value != ud_RTL_Frequency.Value)
                        ud_DUT_Frequency.Value = ud_RTL_Frequency.Value;
                    if (ud_DUT_Sweep_Start.Value != ud_RTL_Sweep_Start.Value)
                        ud_DUT_Sweep_Start.Value = ud_RTL_Sweep_Start.Value;
                    if (ud_DUT_P_ENR.Value != ud_RTL_P_ENR.Value)
                        ud_DUT_P_ENR.Value = ud_RTL_P_ENR.Value;
                    break;
                case MMODE.B:
                case MMODE.C:
                    break;
            }
            
            // calculate new DUT frequency
            ud_DUT_Sweep_Start.Value = ud_RTL_Sweep_Start.Value + Properties.Settings.Default.DUT_Frequency - Properties.Settings.Default.RTL_Frequency;
            ud_DUT_Sweep_Stop.Value = ud_RTL_Sweep_Stop.Value + Properties.Settings.Default.DUT_Frequency - Properties.Settings.Default.RTL_Frequency;
            ud_DUT_Sweep_Step.Value = ud_RTL_Sweep_Step.Value;

            // enable noise and frequency up/downs
            if ((RTLWorker.IsBusy) && (State != STATE.IDLE))
            {
                // disable controls if not idling
                {
                    // main display
                    ud_RTL_P_ENR.Enabled = false;
                    ud_DUT_P_ENR.Enabled = false;
                    ud_RTL_Frequency.Enabled = false;
                    ud_DUT_Frequency.Enabled = false;
                    // sweep display
                    ud_RTL_Sweep_Start.Enabled = false;
                    ud_RTL_Sweep_Stop.Enabled = false;
                    ud_RTL_Sweep_Step.Enabled = false;
                    ud_DUT_Sweep_Start.Enabled = false;
                    ud_DUT_Sweep_Stop.Enabled = false;
                    ud_DUT_Sweep_Step.Enabled = false;
                }
            }
            else
            {
                try
                {
                    switch (Properties.Settings.Default.Mode)
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
                switch (Properties.Settings.Default.Mode)
                {
                    case MMODE.A:
                        ud_RTL_Frequency.Enabled = true;
                        ud_DUT_Frequency.Enabled = false;
                        ud_RTL_Sweep_Start.Enabled = true;
                        ud_RTL_Sweep_Stop.Enabled = true;
                        ud_RTL_Sweep_Step.Enabled = true;
                        ud_DUT_Sweep_Start.Enabled = false;
                        ud_DUT_Sweep_Stop.Enabled = false;
                        ud_DUT_Sweep_Step.Enabled = false;
                        break;
                    case MMODE.B:
                    case MMODE.C:
                        ud_RTL_Frequency.Enabled = true;
                        ud_DUT_Frequency.Enabled = true;
                        ud_RTL_Sweep_Start.Enabled = true;
                        ud_RTL_Sweep_Stop.Enabled = true;
                        ud_RTL_Sweep_Step.Enabled = true;
                        ud_DUT_Sweep_Start.Enabled = false;
                        ud_DUT_Sweep_Stop.Enabled = false;
                        ud_DUT_Sweep_Step.Enabled = false;
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
                    btn_Sweep_Settings.Enabled = false;
                    btn_Calibrate.Text = "Calibrate";
                    btn_Calibrate.Enabled = false;
                    if (btn_Calibrate.BackColor != SystemColors.Control)
                        btn_Calibrate.BackColor = SystemColors.Control;
                    btn_Measure.Text = "Measure";
                    btn_Measure.Enabled = false;
                    if (btn_Measure.BackColor != SystemColors.Control)
                        btn_Measure.BackColor = SystemColors.Control;
                    lbl_Gain.Text = "--.--";
                    lbl_NF.Text = "--.--";
                    cbb_SMode.Enabled = true;
                    btn_Sweep_Calibrate.Text = "Calibrate";
                    btn_Sweep_Calibrate.Enabled = false;
                    if (btn_Sweep_Calibrate.BackColor != SystemColors.Control)
                        btn_Sweep_Calibrate.BackColor = SystemColors.Control;
                    btn_Sweep_Measure.Text = "Measure";
                    btn_Sweep_Measure.Enabled = false;
                    if (btn_Sweep_Measure.BackColor != SystemColors.Control)
                        btn_Sweep_Measure.BackColor = SystemColors.Control;
                    lbl_Sweep_Gain.Text = "--.--";
                    lbl_Sweep_NF.Text = "--.--";
                    break;
                case STATE.IDLE:
                    cbb_MMode.Enabled = true;
                    btn_Settings.Enabled = true;
                    btn_Measure.Text = "Measure";
                    btn_Measure.Enabled = true;
                    if (btn_Measure.BackColor != Color.PaleGreen)
                        btn_Measure.BackColor = Color.PaleGreen;
                    cbb_SMode.Enabled = true;
                    btn_Sweep_Settings.Enabled = true;
                    btn_Sweep_Measure.Text = "Measure";
                    btn_Sweep_Measure.Enabled = true;
                    if (btn_Sweep_Measure.BackColor != Color.PaleGreen)
                        btn_Sweep_Measure.BackColor = Color.PaleGreen;
                    // set Calibrate button according to CALSTATE
                    switch (CalState)
                    {
                        case CALSTATE.NONE:
                            btn_Calibrate.Text = "Calibrate";
                            btn_Calibrate.Enabled = true;
                            if (btn_Calibrate.BackColor != Color.MistyRose)
                                btn_Calibrate.BackColor = Color.MistyRose;
                            lbl_Gain.Text = "--.--";
                            btn_Sweep_Calibrate.Text = "Calibrate";
                            btn_Sweep_Calibrate.Enabled = true;
                            if (btn_Sweep_Calibrate.BackColor != Color.MistyRose)
                                btn_Sweep_Calibrate.BackColor = Color.MistyRose;
                            lbl_Sweep_Gain.Text = "--.--";
                            break;
                        case CALSTATE.CALIBRATED:
                            btn_Calibrate.Text = "Calibrated";
                            btn_Calibrate.Enabled = true;
                            if (btn_Calibrate.BackColor != Color.Coral)
                                btn_Calibrate.BackColor = Color.Coral;
                            lbl_Gain.Text = "00.00";
                            btn_Sweep_Calibrate.Text = "Calibrated";
                            btn_Sweep_Calibrate.Enabled = true;
                            if (btn_Sweep_Calibrate.BackColor != Color.Coral)
                                btn_Sweep_Calibrate.BackColor = Color.Coral;
                            lbl_Sweep_Gain.Text = "00.00";
                            break;
                    }
                    lbl_Sweep_Gain.Text = "--.--";
                    lbl_Sweep_NF.Text = "--.--";
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
                    cbb_SMode.Enabled = false;
                    btn_Sweep_Settings.Enabled = false;
                    btn_Sweep_Calibrate.Text = "Stop";
                    btn_Sweep_Calibrate.Enabled = true;
                    if (btn_Sweep_Calibrate.BackColor != Color.Coral)
                        btn_Sweep_Calibrate.BackColor = Color.Coral;
                    btn_Sweep_Measure.Text = "Measure";
                    btn_Sweep_Measure.Enabled = false;
                    if (btn_Sweep_Measure.BackColor != SystemColors.Control)
                        btn_Sweep_Measure.BackColor = SystemColors.Control;
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
                    cbb_SMode.Enabled = false;
                    btn_Sweep_Settings.Enabled = false;
                    btn_Sweep_Calibrate.Text = "Calibrate";
                    btn_Sweep_Calibrate.Enabled = false;
                    if (btn_Sweep_Calibrate.BackColor != SystemColors.Control)
                        btn_Sweep_Calibrate.BackColor = SystemColors.Control;
                    btn_Sweep_Measure.Text = "Stop";
                    btn_Sweep_Measure.Enabled = true;
                    if (btn_Sweep_Measure.BackColor != Color.PaleGreen)
                        btn_Sweep_Measure.BackColor = Color.PaleGreen;
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
            ud_RTL_Sweep_Start.ForeColor = ud_RTL_Sweep_Start.Enabled ? Color.Chartreuse : Color.DarkGray;
            ud_RTL_Sweep_Stop.ForeColor = ud_RTL_Sweep_Stop.Enabled ? Color.Chartreuse : Color.DarkGray;
            ud_RTL_Sweep_Step.ForeColor = ud_RTL_Sweep_Step.Enabled ? Color.Chartreuse : Color.DarkGray;
            ud_DUT_Sweep_Start.ForeColor = ud_DUT_Sweep_Start.Enabled ? Color.Chartreuse : Color.DarkGray;
            ud_DUT_Sweep_Stop.ForeColor = ud_DUT_Sweep_Stop.Enabled ? Color.Chartreuse : Color.DarkGray;
            ud_DUT_Sweep_Step.ForeColor = ud_DUT_Sweep_Step.Enabled ? Color.Chartreuse : Color.DarkGray;

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
                _rtlParams.SweepMode = Properties.Settings.Default.SweepMode;

                if (Properties.Settings.Default.SweepMode == SMODE.NONE)
                {
                    _rtlParams.Frequency_Start = Properties.Settings.Default.RTL_Frequency;
                    _rtlParams.Frequency_Stop = Properties.Settings.Default.RTL_Frequency;
                    _rtlParams.Frequency_Step = 0;
                }
                else
                {
                    _rtlParams.Frequency_Start = Properties.Settings.Default.RTL_Frequency_Start;
                    _rtlParams.Frequency_Stop = Properties.Settings.Default.RTL_Frequency_Stop;
                    _rtlParams.Frequency_Step = Properties.Settings.Default.RTL_Frequency_Step;
                }
                _rtlParams.Cycles = Properties.Settings.Default.Smoothing;
                _rtlParams.UseRTLAGC = Properties.Settings.Default.RTL_RTLAGC;
                _rtlParams.UseTunerAGC = Properties.Settings.Default.RTL_TunerAGC;
                _rtlParams.TunerGain = Properties.Settings.Default.RTL_TunerGain;
                _rtlParams.GainMode = Properties.Settings.Default.RTL_GainMode;
                _rtlParams.AGC = Properties.Settings.Default.RTL_AGC_Auto;

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
                _rtlParams.FFT_Algorithm = Properties.Settings.Default.FFT_Algorithm;
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
            // stop tone output
            ti_Tone.Stop();
            // stop measure thread and wait for IDLE state
            try
            {
                RTLWorker.CancelAsync();
                Status("Waiting for measure thread to close...");
                while (RTLWorker.IsBusy)
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

        public void Setting()
        {
            // stop measure thread
            try
            {
                RTLWorker.CancelAsync();
                Status("Waiting for measure thread to close...");
                while (RTLWorker.IsBusy)
                    Application.DoEvents();
            }
            catch
            {
                // do nothing
            }
            State = STATE.SETTING;
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
            Av_G = new SimpleMovingAverage((int)Math.Pow(2, (double)Properties.Settings.Default.Smoothing));
            Av_F = new SimpleMovingAverage((int)Math.Pow(2, (double)Properties.Settings.Default.Smoothing));
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
                InitAverages();
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
            // try to get an existing calibration entry
            // if not found --> add a new one
            CalEntry entry = Calibration[r.Frequency,r.TunerGain];
            if (entry == null)
            {
                // generate new calibration entry and fill in initial values
                entry = new CalEntry((int)Properties.Settings.Default.CAL_SampleCount_Max);
                entry.Invalid = false;
                entry.Frequency = r.Frequency;
                entry.TunerGain = r.TunerGain;
            }
            // add power values
            entry.P_OFF.AddSample(P_OFF);
            entry.P_ON.AddSample(P_ON);
            // get proper ENR values according to Properties.Settings.Default.Mode
            switch (Properties.Settings.Default.Mode)
            {
                case MMODE.A:
                case MMODE.B:
                    entry.ENR = SupportFunctions.ToLinear(System.Convert.ToDouble(ud_RTL_P_ENR.Value));
                    break;
                case MMODE.C:
                    entry.ENR = SupportFunctions.ToLinear(System.Convert.ToDouble(ud_DUT_P_ENR.Value));
                    break;
            }

            // try to calculate rest of values
            try
            {
                entry.Y = entry.P_ON.Average / entry.P_OFF.Average;
                entry.F = entry.ENR / (entry.Y - 1);
            }
            catch
            {
                entry.Y = 1;
                entry.F = 1;
            }

            // store calibration entry
            Calibration[entry.Frequency, entry.TunerGain] = entry;

            // update main display
            switch (Properties.Settings.Default.Mode)
            {
                case MMODE.A:
                case MMODE.B:
                    lbl_DUT_Frequency.Text = r.Frequency.ToString("00000.000", Application.CurrentCulture);
                    break;
                case MMODE.C:
                    lbl_DUT_Frequency.Text = (r.Frequency + Properties.Settings.Default.DUT_Frequency-Properties.Settings.Default.RTL_Frequency).ToString("00000.000", Application.CurrentCulture);
                    break;
            }
            if (!double.IsNaN(entry.F))
                lbl_NF.Text = SupportFunctions.TodB(entry.F).ToString("F2", CultureInfo.InvariantCulture);
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
                InitAverages();
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
            lbl_RTL_P_ON.Text = SupportFunctions.TodB(P_ON).ToString("F2", CultureInfo.InvariantCulture);
            lbl_RTL_P_OFF.Text = SupportFunctions.TodB(P_OFF).ToString("F2", CultureInfo.InvariantCulture);
            lbl_RTL_Status.ForeColor = Color.Chartreuse;
            lbl_RTL_Status.Text = "Valid";
            // get proper ENR values according to Properties.Settings.Default.Mode
            // this should always be the ENR at DUT frequency
            double P_ENR = SupportFunctions.ToLinear(System.Convert.ToDouble(ud_DUT_P_ENR.Value));
            try
            {
                // calculte and display gain and NF
                // temperature correction included 2014-09-01
                double T_amb = (double)Properties.Settings.Default.Tamb;
                double T_0 = (double)Properties.Settings.Default.T0;
                double Y = 1;
                double F = 1;
                double G = 0;
                double CAL_ON = 0;
                double CAL_OFF = 0;
                double CAL_Y = 0;
                double CAL_F = 0;
                double CAL_ENR = 0;
                // calculate Y-factor
                Y = P_ON / P_OFF;
                // calculate F (including temperature correction)
                F = P_ENR / (Y - 1) + 1 - T_amb / T_0;
                // reset F to 1 if fails
                if ((double.IsNaN(F)) || double.IsInfinity(F))
                    F = 1;
                // check calibration state and do corrections
                if (CalState == CALSTATE.CALIBRATED)
                {
                    // try to get calibration values
                    CalEntry entry = Calibration[r.Frequency, r.TunerGain];
                    if (entry != null)
                    {
                        CAL_ON = entry.P_ON.Average;
                        CAL_OFF = entry.P_OFF.Average;
                        CAL_Y = entry.Y;
                        CAL_F = entry.F;
                        CAL_ENR = entry.ENR;
                    }
                    else
                    {
                        // set to default if failed
                        CAL_ON = 0;
                        CAL_OFF = 0;
                        CAL_Y = 1;
                        CAL_F = 1;
                    }
                    // calibrated mode --> calculate gain value too
                    G = (P_ON - P_OFF) / (CAL_ON - CAL_OFF) * P_ENR / CAL_ENR;
                    // add samples for average
                    if ((double.IsNaN(G)) || (double.IsInfinity(G)))
                        G = 1;
                    // add gain to average
                    Av_G.AddSample(G);
                    // correct F according to CAL_F and calculated G
                    F = F - (CAL_F - T_amb / T_0) / G;
                    if ((double.IsNaN(F)) || double.IsInfinity(F))
                        F = 1;
                }
                // add F to floating average
                Av_F.AddSample(F);
                // do other calibration state specific stuff
                switch (CalState)
                {
                    case CALSTATE.NONE:
                        lbl_Gain.Text = "--.--";
                        // update sweep tab only when in sweep mode and NOISE_ON and last measurement cycle
                        if ((Properties.Settings.Default.SweepMode != SMODE.NONE) && r.Noise_ON && (r.Cycle == (int)Properties.Settings.Default.Smoothing - 1))
                        {
                            lbl_Sweep_Gain.Text = "--.--";
                            double yf = SupportFunctions.TodB(Av_F.Average);
                            if (!Double.IsNaN(yf))
                            {
                                // try to find and update a point with the same X-value
                                // add a new one if not found
                                try
                                {
                                    System.Windows.Forms.DataVisualization.Charting.DataPoint p = ch_Sweep.Series["NF"].Points.FindByValue(System.Convert.ToDouble(r.Frequency), "X", 0);
                                    p.SetValueY(yf);
                                }
                                catch
                                {
                                    ch_Sweep.Series["NF"].Points.AddXY(r.Frequency, yf);
                                }
                                // set X-axis span and update chart
                                ch_Sweep.ChartAreas["Sweep"].AxisX.Minimum = System.Convert.ToDouble(Properties.Settings.Default.RTL_Frequency_Start);
                                ch_Sweep.ChartAreas["Sweep"].AxisX.Maximum = System.Convert.ToDouble(Properties.Settings.Default.RTL_Frequency_Stop);
                            }
                        }
                        break;
                    case CALSTATE.CALIBRATED:
                        lbl_Gain.Text = SupportFunctions.TodB(Av_G.Average).ToString("F2", CultureInfo.InvariantCulture);
                        // update sweep tab only when in sweep mode and NOISE_ON and last measurement cycle
                        if ((Properties.Settings.Default.SweepMode != SMODE.NONE) && r.Noise_ON && (r.Cycle == (int)Properties.Settings.Default.Smoothing - 1))
                        {
                            lbl_Sweep_Gain.Text = SupportFunctions.TodB(Av_G.Average).ToString("F2", CultureInfo.InvariantCulture);
                            double yf = SupportFunctions.TodB(Av_F.Average);
                            double yg = SupportFunctions.TodB(Av_G.Average);
                            // add or update values to sweep chart
                            if (!Double.IsNaN(yf))
                            {
                                // try to find and update a point with the same X-value
                                // add a new one if not found
                                try
                                {
                                    System.Windows.Forms.DataVisualization.Charting.DataPoint p = ch_Sweep.Series["NF"].Points.FindByValue(System.Convert.ToDouble(r.Frequency), "X", 0);
                                    p.SetValueY(yf);
                                }
                                catch
                                {
                                    ch_Sweep.Series["NF"].Points.AddXY(r.Frequency, yf);
                                }
                            }
                            if (!Double.IsNaN(yg))
                            {
                                // try to find and update a point with the same X-value
                                // add a new one if not found
                                try
                                {
                                    System.Windows.Forms.DataVisualization.Charting.DataPoint p = ch_Sweep.Series["Gain"].Points.FindByValue(System.Convert.ToDouble(r.Frequency), "X", 0);
                                    p.SetValueY(yg);
                                }
                                catch
                                {
                                    ch_Sweep.Series["Gain"].Points.AddXY(r.Frequency, yg);
                                }
                            }
                            // set X-axis span and update chart
                            ch_Sweep.ChartAreas["Sweep"].AxisX.Minimum = System.Convert.ToDouble(Properties.Settings.Default.RTL_Frequency_Start);
                            ch_Sweep.ChartAreas["Sweep"].AxisX.Maximum = System.Convert.ToDouble(Properties.Settings.Default.RTL_Frequency_Stop);
                        }
                        break;
                    default:
                        // show nothing if an invalid calibration state is detected
                        lbl_Gain.Text = "--.--";
                        lbl_NF.Text = "--.--";
                        break;

                }
                // update rest of main display
                switch (Properties.Settings.Default.Mode)
                {
                    case MMODE.A:
                        lbl_DUT_Frequency.Text = r.Frequency.ToString("00000.000", Application.CurrentCulture);
                        break;
                    case MMODE.B:
                    case MMODE.C:
                        lbl_DUT_Frequency.Text = (r.Frequency + Properties.Settings.Default.DUT_Frequency - Properties.Settings.Default.RTL_Frequency).ToString("00000.000", Application.CurrentCulture);
                        break;
                }
                lbl_NF.Text = SupportFunctions.TodB(Av_F.Average).ToString("F2", CultureInfo.InvariantCulture);
                lbl_Sweep_NF.Text = SupportFunctions.TodB(Av_F.Average).ToString("F2", CultureInfo.InvariantCulture);

                // write values to file if enabled
                if (Properties.Settings.Default.RTL_Logging)
                {
                    // get measure frequency
                    double f = 0;
                    switch (Properties.Settings.Default.Mode)
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
                        (Properties.Settings.Default.RTL_TunerGain / 10).ToString("F2", LocalCulture) + ";" +
                        f.ToString("F3", LocalCulture) + ";" +
                        SupportFunctions.TodB(P_ENR).ToString("F2", LocalCulture));
                    Values.Flush();
                }
            }
            catch
            {
                // do nothing if failed
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
                // set display value range
                int disp_min = 0;
                int disp_max = 60;
                // set basic appearance of display
                ch_FFT.ChartAreas["Main"].AxisY.Minimum = disp_min;
                ch_FFT.ChartAreas["Main"].AxisY.Maximum = disp_max;
                ch_FFT.ChartAreas["Main"].AxisX.MajorGrid.Interval = c.Length / 2;
                // clear the FFT series
                ch_FFT.Series["FFT"].Points.Clear();
                // add new points
                for (int i = 0; i < c.Length; i++)
                {
                    // clip FFT values to avoid display exceptions
                    c[i] = Math.Min(disp_max,c[i]);
                    c[i] = Math.Max(disp_min, c[i]);
                    ch_FFT.Series["FFT"].Points.Add(c[i]);

                }
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
                // check if previously selected RTLDevice is empty (on 1st run) or does not match by name --> select first one available from the list
                try
                {
                    if (Devices[Properties.Settings.Default.RTL_DeviceIndex].Name != Properties.Settings.Default.RTL_Device)
                    {
                        Properties.Settings.Default.RTL_Device = Devices[0].Name;
                    }
                }
                catch
                {
                    if (Devices.Length > 0)
                    {
                        Properties.Settings.Default.RTL_Device = Devices[0].Name;
                    }
                }
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
                    // use local culture info 
                    if (Properties.Settings.Default.CAL_Logging)
                    {
                        try
                        {
                            using (StreamWriter sw = new StreamWriter(Properties.Settings.Default.CAL_Logging_FileName))
                            {
                                sw.WriteLine("Invalid[Bool];Frequency[MHz];TunerGain[dB];P_ON[dB];P_OFF[dB];Y[Units];NF[dB];ENR[dB]");
                                foreach (KeyValuePair<decimal, CalGains> gains in Calibration.GetAllEntries())
                                {
                                    foreach (KeyValuePair<int, CalEntry> c in gains.Value)
                                    {
                                        sw.WriteLine(
                                            c.Value.Invalid.ToString(LocalCulture) + ";" +
                                            c.Value.Frequency.ToString("F3", LocalCulture) + ";" +
                                            (c.Value.TunerGain / 10.0).ToString("F2", LocalCulture) + ";" +
                                            SupportFunctions.TodB(c.Value.P_ON.Average).ToString(LocalCulture) + ";" +
                                            SupportFunctions.TodB(c.Value.P_OFF.Average).ToString(LocalCulture) + ";" +
                                            c.Value.Y.ToString(LocalCulture) + ";" +
                                            SupportFunctions.TodB(c.Value.F).ToString(LocalCulture) + ";" +
                                            SupportFunctions.TodB(c.Value.ENR).ToString(LocalCulture));
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error while writing calibration file");
                        }

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
                InitAverages();
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

        public void btn_Measure_Click(object sender, EventArgs e)
        {
            if (State != STATE.MEASURING)
            {
                // stop any running measurement
                Stop();
                InitAverages();
                // clear sweep chart
                ch_Sweep.Series["NF"].Points.Clear();
                ch_Sweep.Series["Gain"].Points.Clear();
                // start timer for tone output
                ti_Tone.Start();
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
            // stop any running measurement and change to Setting state
            Setting();
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
                    State = STATE.INIT;
                    Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SettingsDlg");
            }
        }

        private void cbb_MMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Mode = (MMODE) cbb_MMode.SelectedItem;
            Properties.Settings.Default.Mode = Properties.Settings.Default.Mode;
            // set Mode Tooltip according to Properties.Settings.Default.Mode
            try
            {
                tt_Main.SetToolTip(cbb_MMode, ModeDesc[Enum.GetName(typeof(MMODE), Properties.Settings.Default.Mode)]);
            }
            catch
            {
                // no Tooltip availabe
                tt_Main.SetToolTip(cbb_MMode, "Not available.");
            }
        }

        private void cbb_MMode_DropDown(object sender, EventArgs e)
        {
            // set Mode Tooltip according to Properties.Settings.Default.Mode
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
            // set Mode Tooltip according to Properties.Settings.Default.Mode
            try
            {
                tt_Main.SetToolTip(cbb_MMode, ModeDesc[Enum.GetName(typeof(MMODE), Properties.Settings.Default.Mode)]);
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
            // reset sweep mode and frequencies if any
            cbb_SMode.SelectedItem = SMODE.NONE;
            // allow continious manual frequency change of RTL frequency if in Idle state --> kind of SDR radio!
            if (State == STATE.IDLE)
            {
                // change RTLWorkers' parameters online
                // CAUTION: Do not forget to lock the variables first!
                lock (RTLWorker.Params)
                {
                    RTLWorker.Params.Frequency_Start = ud_RTL_Frequency.Value;
                    RTLWorker.Params.Frequency_Stop = ud_RTL_Frequency.Value;
                    RTLWorker.Params.Frequency_Step = 0;
                }
            }
        }

        private void ud_DUT_Frequency_ValueChanged(object sender, EventArgs e)
        {
            // reset state uncalibrated when frequency has changed
            Calibration.Clear();
            CalState = CALSTATE.NONE;
            // reset sweep mode and frequencies if any
            cbb_SMode.SelectedItem = SMODE.NONE;
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

        private void cbb_SMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_SMode.SelectedItem != null)
            {
                // reset calibration state if 
                if (Properties.Settings.Default.SweepMode == SMODE.NONE)
                {
                    Calibration.Clear();
                    CalState = CALSTATE.NONE;
                }
                Properties.Settings.Default.SweepMode = (SMODE)cbb_SMode.SelectedItem;
            }
        }

        private void tc_Main_SizeChanged(object sender, EventArgs e)
        {
        }

        private void tp_Sweep_SizeChanged(object sender, EventArgs e)
        {
            // adjust chart area
            gb_Sweep_Chart.Width = tp_Sweep.Width;
            gb_Sweep_Chart.Height = tp_Sweep.Height - gb_Sweep.Height - 10;
            if (this.WindowState == FormWindowState.Maximized)
                ch_Sweep.ChartAreas["Sweep"].AxisY.MinorGrid.Enabled = true;
            else
                ch_Sweep.ChartAreas["Sweep"].AxisY.MinorGrid.Enabled = false;
        }

        private void ud_RTL_Sweep_Start_ValueChanged(object sender, EventArgs e)
        {
            // reset state uncalibrated when frequency has changed
            Calibration.Clear();
            CalState = CALSTATE.NONE;
        }

        private void ud_RTL_Sweep_Stop_ValueChanged(object sender, EventArgs e)
        {
            // reset state uncalibrated when frequency has changed
            Calibration.Clear();
            CalState = CALSTATE.NONE;
        }

        private void ud_RTL_Sweep_Step_ValueChanged(object sender, EventArgs e)
        {
        }

        private void tp_Meter_Enter(object sender, EventArgs e)
        {
            // reset window state to normal size 
            WindowState = FormWindowState.Normal;
            // disable maximize box
            MaximizeBox = false;
        }

        private void tp_Sweep_Enter(object sender, EventArgs e)
        {
            // enable maximize box
            MaximizeBox = true;
        }

        private void tp_Info_Enter(object sender, EventArgs e)
        {
            // reset window state to normal size 
            WindowState = FormWindowState.Normal;
            // disable maximize box
            MaximizeBox = false;
            // get basic CANFI version information
            try
            {
                tb_Info_OS.Text = Environment.OSVersion.VersionString;
                FileVersionInfo info = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetEntryAssembly().Location);
                tb_Info_AssemblyVersion.Text = info.ProductVersion;
                tb_Info_Copyright.Text = info.CompanyName + ", " + info.LegalCopyright;
            }
            catch (Exception ex)
            {
            }
            // get basic rtlsdr.dll information
            try
            {
                FileVersionInfo info = FileVersionInfo.GetVersionInfo(Application.StartupPath + Path.DirectorySeparatorChar + Properties.Settings.Default.RTL_DLL_DirName + Path.DirectorySeparatorChar + Properties.Settings.Default.RTL_DLL_Win_FileName);
                tb_Info_RTL_Library.Text = info.FileName;
                tb_Info_RTL_Version.Text = info.ProductVersion;
                tb_Info_RTL_Copyright.Text = info.CompanyName + ", " + info.LegalCopyright;
            }
            catch (Exception ex)
            {
            }
            // get license information from file
            try
            {
                rtb_Info.LoadFile(Application.StartupPath + Path.DirectorySeparatorChar + Properties.Settings.Default.Info_FileName, RichTextBoxStreamType.PlainText);
            }
            catch (Exception ex)
            {
                // do nothing if failed
            }
        }

        private void ti_Tone_Tick(object sender, EventArgs e)
        {
            // output tone if activated
            try
            {
                int tone_frequency = 0;
                int tone_duration = System.Convert.ToInt32(Properties.Settings.Default.Tone_Duration);
                switch (Properties.Settings.Default.Tone_Output)
                {
                    case TONEOUTPUT.NF:
                        double nf_min = System.Convert.ToDouble(Properties.Settings.Default.Tone_NF_0kHz);
                        double nf_max = System.Convert.ToDouble(Properties.Settings.Default.Tone_NF_10kHz);
                        double nf = SupportFunctions.TodB(Av_F.Average);
                        // calculate tone frequency according to NF
                        tone_frequency = (int)((nf - nf_min) / (nf_max - nf_min) * 10000.0);
                        // output a non-blocking system beep
                        if ((tone_frequency > 32) && (tone_frequency < 32767))
                        {
                            Action beep = () => Console.Beep(tone_frequency, tone_duration);
                            beep.BeginInvoke(null, null);
                        }
                        break;
                    case TONEOUTPUT.GAIN:
                        double g_min = System.Convert.ToDouble(Properties.Settings.Default.Tone_G_0kHz);
                        double g_max = System.Convert.ToDouble(Properties.Settings.Default.Tone_G_10kHz);
                        double g = SupportFunctions.TodB(Av_G.Average);
                        // calculate tone frequency according to NF
                        tone_frequency = (int)((g - g_min) / (g_max - g_min) * 10000.0);
                        // output a non-blocking system beep
                        if ((tone_frequency > 32) && (tone_frequency < 32767))
                        {
                            Action beep = () => Console.Beep(tone_frequency, tone_duration);
                            beep.BeginInvoke(null, null);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                // do nothing
            }
            // set timer interval
            ti_Tone.Interval = System.Convert.ToInt32(Properties.Settings.Default.Tone_Interval);
        }

    }

    #endregion

}
