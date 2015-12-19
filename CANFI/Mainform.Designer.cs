namespace CANFI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bw_Measure = new System.ComponentModel.BackgroundWorker();
            this.ss_main = new System.Windows.Forms.StatusStrip();
            this.ssl_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.ssl_Error = new System.Windows.Forms.ToolStripStatusLabel();
            this.tt_Main = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btn_Sweep_Measure = new System.Windows.Forms.Button();
            this.btn_Sweep_Settings = new System.Windows.Forms.Button();
            this.btn_Sweep_Calibrate = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btn_Measure = new System.Windows.Forms.Button();
            this.btn_Settings = new System.Windows.Forms.Button();
            this.btn_Calibrate = new System.Windows.Forms.Button();
            this.gb_FFT_Filter = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_FFT_Filter = new System.Windows.Forms.Label();
            this.tp_Info = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.rtb_Info = new System.Windows.Forms.RichTextBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.tb_Info_RTL_Library = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.tb_Info_RTL_Copyright = new System.Windows.Forms.TextBox();
            this.tb_Info_RTL_Version = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tb_Info_Copyright = new System.Windows.Forms.TextBox();
            this.tb_Info_AssemblyVersion = new System.Windows.Forms.TextBox();
            this.tb_Info_OS = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tp_Sweep = new System.Windows.Forms.TabPage();
            this.gb_Sweep = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lbl_Sweep_Gain = new System.Windows.Forms.Label();
            this.lbl_Sweep_NF = new System.Windows.Forms.Label();
            this.cbb_SMode = new System.Windows.Forms.ComboBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.gb_Sweep_RTL = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gb_Sweep_Chart = new System.Windows.Forms.GroupBox();
            this.ch_Sweep = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tp_Meter = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lbl_Noise = new System.Windows.Forms.Label();
            this.lbl_DUT = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ch_FFT = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_RTL_Status = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lbl_RTL_P_ON = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_RTL_P_OFF = new System.Windows.Forms.Label();
            this.lbl_RTL_Gain = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbb_MMode = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_DUT_Frequency = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_NF = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl_Gain = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label40 = new System.Windows.Forms.Label();
            this.lbl_RTL_Frequency = new System.Windows.Forms.Label();
            this.tc_Main = new System.Windows.Forms.TabControl();
            this.tb_FFT_Filter_NotchWidth = new System.Windows.Forms.TrackBar();
            this.tb_FFT_Filter_Threshold = new System.Windows.Forms.TrackBar();
            this.ud_Smoothing = new System.Windows.Forms.NumericUpDown();
            this.ud_DUT_P_ENR = new CANFI.CANFIUpDown();
            this.ud_DUT_Frequency = new CANFI.CANFIUpDown();
            this.ud_RTL_P_ENR = new CANFI.CANFIUpDown();
            this.ud_RTL_Frequency = new CANFI.CANFIUpDown();
            this.ud_DUT_Sweep_Step = new CANFI.CANFIUpDown();
            this.ud_DUT_Sweep_Stop = new CANFI.CANFIUpDown();
            this.ud_DUT_Sweep_Start = new CANFI.CANFIUpDown();
            this.ud_RTL_Sweep_Step = new CANFI.CANFIUpDown();
            this.ud_RTL_Sweep_Stop = new CANFI.CANFIUpDown();
            this.ud_RTL_Sweep_Start = new CANFI.CANFIUpDown();
            this.ss_main.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.gb_FFT_Filter.SuspendLayout();
            this.tp_Info.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tp_Sweep.SuspendLayout();
            this.gb_Sweep.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.gb_Sweep_RTL.SuspendLayout();
            this.gb_Sweep_Chart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch_Sweep)).BeginInit();
            this.tp_Meter.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ch_FFT)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tc_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_FFT_Filter_NotchWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_FFT_Filter_Threshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_Smoothing)).BeginInit();
            this.SuspendLayout();
            // 
            // bw_Measure
            // 
            this.bw_Measure.WorkerReportsProgress = true;
            this.bw_Measure.WorkerSupportsCancellation = true;
            // 
            // ss_main
            // 
            this.ss_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssl_Status,
            this.ssl_Error});
            this.ss_main.Location = new System.Drawing.Point(0, 350);
            this.ss_main.Name = "ss_main";
            this.ss_main.Size = new System.Drawing.Size(794, 22);
            this.ss_main.TabIndex = 44;
            this.ss_main.Text = "statusStrip1";
            // 
            // ssl_Status
            // 
            this.ssl_Status.ActiveLinkColor = System.Drawing.Color.Red;
            this.ssl_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ssl_Status.Name = "ssl_Status";
            this.ssl_Status.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.ssl_Status.Size = new System.Drawing.Size(779, 17);
            this.ssl_Status.Spring = true;
            this.ssl_Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ssl_Error
            // 
            this.ssl_Error.BackColor = System.Drawing.Color.Red;
            this.ssl_Error.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ssl_Error.ForeColor = System.Drawing.Color.White;
            this.ssl_Error.Name = "ssl_Error";
            this.ssl_Error.Size = new System.Drawing.Size(0, 17);
            // 
            // tt_Main
            // 
            this.tt_Main.ShowAlways = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.Controls.Add(this.btn_Sweep_Measure);
            this.groupBox10.Controls.Add(this.btn_Sweep_Settings);
            this.groupBox10.Controls.Add(this.btn_Sweep_Calibrate);
            this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.Location = new System.Drawing.Point(600, 207);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(181, 113);
            this.groupBox10.TabIndex = 69;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Measure";
            this.tt_Main.SetToolTip(this.groupBox10, "Measure Noise Figure without Calibration\r\nMeasure Noise Figure and Gain with Cali" +
        "bration");
            // 
            // btn_Sweep_Measure
            // 
            this.btn_Sweep_Measure.BackColor = System.Drawing.Color.PaleGreen;
            this.btn_Sweep_Measure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sweep_Measure.Location = new System.Drawing.Point(6, 64);
            this.btn_Sweep_Measure.Name = "btn_Sweep_Measure";
            this.btn_Sweep_Measure.Size = new System.Drawing.Size(92, 37);
            this.btn_Sweep_Measure.TabIndex = 52;
            this.btn_Sweep_Measure.Text = "Measure";
            this.btn_Sweep_Measure.UseVisualStyleBackColor = false;
            this.btn_Sweep_Measure.Click += new System.EventHandler(this.btn_Measure_Click);
            // 
            // btn_Sweep_Settings
            // 
            this.btn_Sweep_Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sweep_Settings.Location = new System.Drawing.Point(105, 15);
            this.btn_Sweep_Settings.Name = "btn_Sweep_Settings";
            this.btn_Sweep_Settings.Size = new System.Drawing.Size(69, 86);
            this.btn_Sweep_Settings.TabIndex = 53;
            this.btn_Sweep_Settings.Text = "Settings";
            this.btn_Sweep_Settings.UseVisualStyleBackColor = true;
            this.btn_Sweep_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // btn_Sweep_Calibrate
            // 
            this.btn_Sweep_Calibrate.BackColor = System.Drawing.Color.MistyRose;
            this.btn_Sweep_Calibrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sweep_Calibrate.Location = new System.Drawing.Point(6, 15);
            this.btn_Sweep_Calibrate.Name = "btn_Sweep_Calibrate";
            this.btn_Sweep_Calibrate.Size = new System.Drawing.Size(92, 38);
            this.btn_Sweep_Calibrate.TabIndex = 54;
            this.btn_Sweep_Calibrate.Text = "Calibrate";
            this.btn_Sweep_Calibrate.UseVisualStyleBackColor = false;
            this.btn_Sweep_Calibrate.Click += new System.EventHandler(this.btn_Calibrate_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btn_Measure);
            this.groupBox7.Controls.Add(this.btn_Settings);
            this.groupBox7.Controls.Add(this.btn_Calibrate);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(595, 107);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(181, 113);
            this.groupBox7.TabIndex = 68;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Measure";
            this.tt_Main.SetToolTip(this.groupBox7, "Measure Noise Figure without Calibration\r\nMeasure Noise Figure and Gain with Cali" +
        "bration");
            // 
            // btn_Measure
            // 
            this.btn_Measure.BackColor = System.Drawing.Color.PaleGreen;
            this.btn_Measure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Measure.Location = new System.Drawing.Point(6, 64);
            this.btn_Measure.Name = "btn_Measure";
            this.btn_Measure.Size = new System.Drawing.Size(92, 37);
            this.btn_Measure.TabIndex = 52;
            this.btn_Measure.Text = "Measure";
            this.btn_Measure.UseVisualStyleBackColor = false;
            this.btn_Measure.Click += new System.EventHandler(this.btn_Measure_Click);
            // 
            // btn_Settings
            // 
            this.btn_Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Settings.Location = new System.Drawing.Point(105, 15);
            this.btn_Settings.Name = "btn_Settings";
            this.btn_Settings.Size = new System.Drawing.Size(69, 86);
            this.btn_Settings.TabIndex = 53;
            this.btn_Settings.Text = "Settings";
            this.btn_Settings.UseVisualStyleBackColor = true;
            this.btn_Settings.Click += new System.EventHandler(this.btn_Settings_Click);
            // 
            // btn_Calibrate
            // 
            this.btn_Calibrate.BackColor = System.Drawing.Color.MistyRose;
            this.btn_Calibrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Calibrate.Location = new System.Drawing.Point(6, 15);
            this.btn_Calibrate.Name = "btn_Calibrate";
            this.btn_Calibrate.Size = new System.Drawing.Size(92, 38);
            this.btn_Calibrate.TabIndex = 54;
            this.btn_Calibrate.Text = "Calibrate";
            this.btn_Calibrate.UseVisualStyleBackColor = false;
            this.btn_Calibrate.Click += new System.EventHandler(this.btn_Calibrate_Click);
            // 
            // gb_FFT_Filter
            // 
            this.gb_FFT_Filter.Controls.Add(this.label4);
            this.gb_FFT_Filter.Controls.Add(this.label1);
            this.gb_FFT_Filter.Controls.Add(this.tb_FFT_Filter_NotchWidth);
            this.gb_FFT_Filter.Controls.Add(this.tb_FFT_Filter_Threshold);
            this.gb_FFT_Filter.Controls.Add(this.lbl_FFT_Filter);
            this.gb_FFT_Filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_FFT_Filter.Location = new System.Drawing.Point(8, 222);
            this.gb_FFT_Filter.Name = "gb_FFT_Filter";
            this.gb_FFT_Filter.Size = new System.Drawing.Size(82, 103);
            this.gb_FFT_Filter.TabIndex = 69;
            this.gb_FFT_Filter.TabStop = false;
            this.gb_FFT_Filter.Text = "FFT-Filter";
            this.tt_Main.SetToolTip(this.gb_FFT_Filter, "Click on the LED to enable/disable FFT-Filter");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 9);
            this.label4.TabIndex = 71;
            this.label4.Text = "Width";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 9);
            this.label1.TabIndex = 68;
            this.label1.Text = "Threshold";
            // 
            // lbl_FFT_Filter
            // 
            this.lbl_FFT_Filter.BackColor = System.Drawing.Color.Chartreuse;
            this.lbl_FFT_Filter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_FFT_Filter.Location = new System.Drawing.Point(13, 19);
            this.lbl_FFT_Filter.Name = "lbl_FFT_Filter";
            this.lbl_FFT_Filter.Size = new System.Drawing.Size(60, 8);
            this.lbl_FFT_Filter.TabIndex = 55;
            this.tt_Main.SetToolTip(this.lbl_FFT_Filter, "Click on the LED to enable/disable FFT-Filter");
            this.lbl_FFT_Filter.Click += new System.EventHandler(this.lbl_FFT_Click);
            // 
            // tp_Info
            // 
            this.tp_Info.BackColor = System.Drawing.SystemColors.Control;
            this.tp_Info.Controls.Add(this.groupBox13);
            this.tp_Info.Controls.Add(this.groupBox12);
            this.tp_Info.Controls.Add(this.groupBox11);
            this.tp_Info.Location = new System.Drawing.Point(4, 22);
            this.tp_Info.Name = "tp_Info";
            this.tp_Info.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Info.Size = new System.Drawing.Size(786, 324);
            this.tp_Info.TabIndex = 2;
            this.tp_Info.Text = "Info";
            this.tp_Info.Enter += new System.EventHandler(this.tp_Info_Enter);
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.rtb_Info);
            this.groupBox13.Location = new System.Drawing.Point(8, 112);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(770, 206);
            this.groupBox13.TabIndex = 3;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "License Information";
            // 
            // rtb_Info
            // 
            this.rtb_Info.BackColor = System.Drawing.Color.White;
            this.rtb_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Info.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_Info.Location = new System.Drawing.Point(3, 16);
            this.rtb_Info.Name = "rtb_Info";
            this.rtb_Info.ReadOnly = true;
            this.rtb_Info.Size = new System.Drawing.Size(764, 187);
            this.rtb_Info.TabIndex = 1;
            this.rtb_Info.Text = "";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.tb_Info_RTL_Library);
            this.groupBox12.Controls.Add(this.label30);
            this.groupBox12.Controls.Add(this.label28);
            this.groupBox12.Controls.Add(this.tb_Info_RTL_Copyright);
            this.groupBox12.Controls.Add(this.tb_Info_RTL_Version);
            this.groupBox12.Controls.Add(this.label29);
            this.groupBox12.Location = new System.Drawing.Point(459, 6);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(319, 100);
            this.groupBox12.TabIndex = 2;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "rtlsdr Information";
            // 
            // tb_Info_RTL_Library
            // 
            this.tb_Info_RTL_Library.Location = new System.Drawing.Point(77, 16);
            this.tb_Info_RTL_Library.Name = "tb_Info_RTL_Library";
            this.tb_Info_RTL_Library.ReadOnly = true;
            this.tb_Info_RTL_Library.Size = new System.Drawing.Size(236, 20);
            this.tb_Info_RTL_Library.TabIndex = 11;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(12, 19);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(41, 13);
            this.label30.TabIndex = 10;
            this.label30.Text = "Library:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(12, 71);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(54, 13);
            this.label28.TabIndex = 9;
            this.label28.Text = "Copyright:";
            // 
            // tb_Info_RTL_Copyright
            // 
            this.tb_Info_RTL_Copyright.Location = new System.Drawing.Point(77, 68);
            this.tb_Info_RTL_Copyright.Name = "tb_Info_RTL_Copyright";
            this.tb_Info_RTL_Copyright.ReadOnly = true;
            this.tb_Info_RTL_Copyright.Size = new System.Drawing.Size(236, 20);
            this.tb_Info_RTL_Copyright.TabIndex = 8;
            // 
            // tb_Info_RTL_Version
            // 
            this.tb_Info_RTL_Version.Location = new System.Drawing.Point(77, 42);
            this.tb_Info_RTL_Version.Name = "tb_Info_RTL_Version";
            this.tb_Info_RTL_Version.ReadOnly = true;
            this.tb_Info_RTL_Version.Size = new System.Drawing.Size(236, 20);
            this.tb_Info_RTL_Version.TabIndex = 7;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(12, 45);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(45, 13);
            this.label29.TabIndex = 6;
            this.label29.Text = "Version:";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label27);
            this.groupBox11.Controls.Add(this.tb_Info_Copyright);
            this.groupBox11.Controls.Add(this.tb_Info_AssemblyVersion);
            this.groupBox11.Controls.Add(this.tb_Info_OS);
            this.groupBox11.Controls.Add(this.label19);
            this.groupBox11.Controls.Add(this.label18);
            this.groupBox11.Location = new System.Drawing.Point(8, 6);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(445, 100);
            this.groupBox11.TabIndex = 1;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Program Information";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(11, 71);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(54, 13);
            this.label27.TabIndex = 5;
            this.label27.Text = "Copyright:";
            // 
            // tb_Info_Copyright
            // 
            this.tb_Info_Copyright.Location = new System.Drawing.Point(76, 68);
            this.tb_Info_Copyright.Name = "tb_Info_Copyright";
            this.tb_Info_Copyright.ReadOnly = true;
            this.tb_Info_Copyright.Size = new System.Drawing.Size(363, 20);
            this.tb_Info_Copyright.TabIndex = 4;
            // 
            // tb_Info_AssemblyVersion
            // 
            this.tb_Info_AssemblyVersion.Location = new System.Drawing.Point(76, 42);
            this.tb_Info_AssemblyVersion.Name = "tb_Info_AssemblyVersion";
            this.tb_Info_AssemblyVersion.ReadOnly = true;
            this.tb_Info_AssemblyVersion.Size = new System.Drawing.Size(363, 20);
            this.tb_Info_AssemblyVersion.TabIndex = 3;
            // 
            // tb_Info_OS
            // 
            this.tb_Info_OS.Location = new System.Drawing.Point(76, 16);
            this.tb_Info_OS.Name = "tb_Info_OS";
            this.tb_Info_OS.ReadOnly = true;
            this.tb_Info_OS.Size = new System.Drawing.Size(363, 20);
            this.tb_Info_OS.TabIndex = 2;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 13);
            this.label19.TabIndex = 1;
            this.label19.Text = "OS Info:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 45);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Version:";
            // 
            // tp_Sweep
            // 
            this.tp_Sweep.BackColor = System.Drawing.SystemColors.Control;
            this.tp_Sweep.Controls.Add(this.gb_Sweep);
            this.tp_Sweep.Controls.Add(this.groupBox10);
            this.tp_Sweep.Controls.Add(this.groupBox9);
            this.tp_Sweep.Controls.Add(this.gb_Sweep_RTL);
            this.tp_Sweep.Controls.Add(this.gb_Sweep_Chart);
            this.tp_Sweep.Location = new System.Drawing.Point(4, 22);
            this.tp_Sweep.Name = "tp_Sweep";
            this.tp_Sweep.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Sweep.Size = new System.Drawing.Size(786, 324);
            this.tp_Sweep.TabIndex = 1;
            this.tp_Sweep.Text = "Sweep";
            this.tp_Sweep.SizeChanged += new System.EventHandler(this.tp_Sweep_SizeChanged);
            this.tp_Sweep.Enter += new System.EventHandler(this.tp_Sweep_Enter);
            // 
            // gb_Sweep
            // 
            this.gb_Sweep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Sweep.Controls.Add(this.label26);
            this.gb_Sweep.Controls.Add(this.label25);
            this.gb_Sweep.Controls.Add(this.label21);
            this.gb_Sweep.Controls.Add(this.lbl_Sweep_Gain);
            this.gb_Sweep.Controls.Add(this.lbl_Sweep_NF);
            this.gb_Sweep.Controls.Add(this.cbb_SMode);
            this.gb_Sweep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Sweep.Location = new System.Drawing.Point(408, 207);
            this.gb_Sweep.Name = "gb_Sweep";
            this.gb_Sweep.Size = new System.Drawing.Size(186, 113);
            this.gb_Sweep.TabIndex = 70;
            this.gb_Sweep.TabStop = false;
            this.gb_Sweep.Text = "Sweep";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(2, 84);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(60, 13);
            this.label26.TabIndex = 63;
            this.label26.Text = "Gain[dB]:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Blue;
            this.label25.Location = new System.Drawing.Point(2, 55);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(50, 13);
            this.label25.TabIndex = 62;
            this.label25.Text = "NF[dB]:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(2, 25);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 13);
            this.label21.TabIndex = 61;
            this.label21.Text = "Mode:";
            // 
            // lbl_Sweep_Gain
            // 
            this.lbl_Sweep_Gain.BackColor = System.Drawing.Color.Black;
            this.lbl_Sweep_Gain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Sweep_Gain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Sweep_Gain.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_Sweep_Gain.Location = new System.Drawing.Point(68, 76);
            this.lbl_Sweep_Gain.Name = "lbl_Sweep_Gain";
            this.lbl_Sweep_Gain.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lbl_Sweep_Gain.Size = new System.Drawing.Size(94, 27);
            this.lbl_Sweep_Gain.TabIndex = 60;
            this.lbl_Sweep_Gain.Text = "00000.000";
            this.lbl_Sweep_Gain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Sweep_NF
            // 
            this.lbl_Sweep_NF.BackColor = System.Drawing.Color.Black;
            this.lbl_Sweep_NF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Sweep_NF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Sweep_NF.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_Sweep_NF.Location = new System.Drawing.Point(68, 47);
            this.lbl_Sweep_NF.Name = "lbl_Sweep_NF";
            this.lbl_Sweep_NF.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lbl_Sweep_NF.Size = new System.Drawing.Size(94, 27);
            this.lbl_Sweep_NF.TabIndex = 59;
            this.lbl_Sweep_NF.Text = "00000.000";
            this.lbl_Sweep_NF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbb_SMode
            // 
            this.cbb_SMode.BackColor = System.Drawing.Color.Black;
            this.cbb_SMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_SMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbb_SMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_SMode.ForeColor = System.Drawing.Color.Gold;
            this.cbb_SMode.Location = new System.Drawing.Point(68, 20);
            this.cbb_SMode.Name = "cbb_SMode";
            this.cbb_SMode.Size = new System.Drawing.Size(113, 24);
            this.cbb_SMode.TabIndex = 51;
            this.cbb_SMode.SelectedIndexChanged += new System.EventHandler(this.cbb_SMode_SelectedIndexChanged);
            // 
            // groupBox9
            // 
            this.groupBox9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox9.Controls.Add(this.label11);
            this.groupBox9.Controls.Add(this.label15);
            this.groupBox9.Controls.Add(this.label16);
            this.groupBox9.Controls.Add(this.ud_DUT_Sweep_Step);
            this.groupBox9.Controls.Add(this.ud_DUT_Sweep_Stop);
            this.groupBox9.Controls.Add(this.ud_DUT_Sweep_Start);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(207, 207);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(195, 113);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Device Under Test";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(14, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 59;
            this.label11.Text = "Step [MHz]:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 13);
            this.label15.TabIndex = 58;
            this.label15.Text = "Stop [MHz]:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(12, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 57;
            this.label16.Text = "Start [MHz]:";
            // 
            // gb_Sweep_RTL
            // 
            this.gb_Sweep_RTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Sweep_RTL.Controls.Add(this.label8);
            this.gb_Sweep_RTL.Controls.Add(this.label7);
            this.gb_Sweep_RTL.Controls.Add(this.label6);
            this.gb_Sweep_RTL.Controls.Add(this.ud_RTL_Sweep_Step);
            this.gb_Sweep_RTL.Controls.Add(this.ud_RTL_Sweep_Stop);
            this.gb_Sweep_RTL.Controls.Add(this.ud_RTL_Sweep_Start);
            this.gb_Sweep_RTL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Sweep_RTL.Location = new System.Drawing.Point(6, 207);
            this.gb_Sweep_RTL.Name = "gb_Sweep_RTL";
            this.gb_Sweep_RTL.Size = new System.Drawing.Size(195, 113);
            this.gb_Sweep_RTL.TabIndex = 1;
            this.gb_Sweep_RTL.TabStop = false;
            this.gb_Sweep_RTL.Text = "Measure Device";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 59;
            this.label8.Text = "Step [MHz]:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 58;
            this.label7.Text = "Stop [MHz]:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 57;
            this.label6.Text = "Start [MHz]:";
            // 
            // gb_Sweep_Chart
            // 
            this.gb_Sweep_Chart.Controls.Add(this.ch_Sweep);
            this.gb_Sweep_Chart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Sweep_Chart.Location = new System.Drawing.Point(3, 3);
            this.gb_Sweep_Chart.Name = "gb_Sweep_Chart";
            this.gb_Sweep_Chart.Size = new System.Drawing.Size(780, 198);
            this.gb_Sweep_Chart.TabIndex = 0;
            this.gb_Sweep_Chart.TabStop = false;
            this.gb_Sweep_Chart.Text = "Diagram";
            // 
            // ch_Sweep
            // 
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisY.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.MinorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY2.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.Name = "Sweep";
            this.ch_Sweep.ChartAreas.Add(chartArea1);
            this.ch_Sweep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ch_Sweep.Location = new System.Drawing.Point(3, 16);
            this.ch_Sweep.Name = "ch_Sweep";
            series1.BorderWidth = 3;
            series1.ChartArea = "Sweep";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Blue;
            series1.Name = "NF";
            series2.BorderWidth = 3;
            series2.ChartArea = "Sweep";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.Name = "Gain";
            series2.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.ch_Sweep.Series.Add(series1);
            this.ch_Sweep.Series.Add(series2);
            this.ch_Sweep.Size = new System.Drawing.Size(774, 179);
            this.ch_Sweep.TabIndex = 0;
            this.ch_Sweep.Text = "Sweep";
            // 
            // tp_Meter
            // 
            this.tp_Meter.BackColor = System.Drawing.SystemColors.Control;
            this.tp_Meter.Controls.Add(this.groupBox8);
            this.tp_Meter.Controls.Add(this.gb_FFT_Filter);
            this.tp_Meter.Controls.Add(this.groupBox7);
            this.tp_Meter.Controls.Add(this.groupBox6);
            this.tp_Meter.Controls.Add(this.groupBox5);
            this.tp_Meter.Controls.Add(this.groupBox4);
            this.tp_Meter.Controls.Add(this.groupBox1);
            this.tp_Meter.Controls.Add(this.groupBox3);
            this.tp_Meter.Controls.Add(this.groupBox2);
            this.tp_Meter.Location = new System.Drawing.Point(4, 22);
            this.tp_Meter.Name = "tp_Meter";
            this.tp_Meter.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Meter.Size = new System.Drawing.Size(786, 324);
            this.tp_Meter.TabIndex = 0;
            this.tp_Meter.Text = "Meter";
            this.tp_Meter.Enter += new System.EventHandler(this.tp_Meter_Enter);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Controls.Add(this.label12);
            this.groupBox8.Controls.Add(this.lbl_Noise);
            this.groupBox8.Controls.Add(this.lbl_DUT);
            this.groupBox8.Controls.Add(this.label17);
            this.groupBox8.Location = new System.Drawing.Point(8, 2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(82, 105);
            this.groupBox8.TabIndex = 70;
            this.groupBox8.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 25);
            this.label5.TabIndex = 65;
            this.label5.Text = "Status";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 43);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 62;
            this.label12.Text = "ENR:";
            // 
            // lbl_Noise
            // 
            this.lbl_Noise.BackColor = System.Drawing.Color.Chartreuse;
            this.lbl_Noise.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Noise.Location = new System.Drawing.Point(49, 40);
            this.lbl_Noise.Name = "lbl_Noise";
            this.lbl_Noise.Size = new System.Drawing.Size(18, 19);
            this.lbl_Noise.TabIndex = 61;
            // 
            // lbl_DUT
            // 
            this.lbl_DUT.BackColor = System.Drawing.Color.Chartreuse;
            this.lbl_DUT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DUT.Location = new System.Drawing.Point(49, 74);
            this.lbl_DUT.Name = "lbl_DUT";
            this.lbl_DUT.Size = new System.Drawing.Size(18, 19);
            this.lbl_DUT.TabIndex = 64;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 77);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(37, 13);
            this.label17.TabIndex = 63;
            this.label17.Text = "DUT:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ud_Smoothing);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(8, 108);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(82, 56);
            this.groupBox6.TabIndex = 67;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Smooth";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ch_FFT);
            this.groupBox5.Controls.Add(this.panel1);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(95, 222);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(681, 103);
            this.groupBox5.TabIndex = 66;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "SDR Values";
            // 
            // ch_FFT
            // 
            chartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisY.LabelStyle.Enabled = false;
            chartArea2.AxisY.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea2.BackColor = System.Drawing.Color.Black;
            chartArea2.Name = "Main";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 100F;
            chartArea2.Position.Width = 100F;
            this.ch_FFT.ChartAreas.Add(chartArea2);
            this.ch_FFT.Location = new System.Drawing.Point(154, 19);
            this.ch_FFT.Name = "ch_FFT";
            series3.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            series3.BackImageTransparentColor = System.Drawing.Color.Transparent;
            series3.BackSecondaryColor = System.Drawing.Color.Transparent;
            series3.BorderColor = System.Drawing.Color.White;
            series3.BorderWidth = 3;
            series3.ChartArea = "Main";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series3.Color = System.Drawing.Color.Blue;
            series3.LabelForeColor = System.Drawing.Color.White;
            series3.Name = "FFT";
            this.ch_FFT.Series.Add(series3);
            this.ch_FFT.Size = new System.Drawing.Size(520, 78);
            this.ch_FFT.TabIndex = 70;
            this.ch_FFT.Text = "FFT";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl_RTL_Status);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.lbl_RTL_P_ON);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lbl_RTL_P_OFF);
            this.panel1.Controls.Add(this.lbl_RTL_Gain);
            this.panel1.Location = new System.Drawing.Point(8, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(140, 77);
            this.panel1.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(5, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 71;
            this.label2.Text = "Status:";
            // 
            // lbl_RTL_Status
            // 
            this.lbl_RTL_Status.AutoSize = true;
            this.lbl_RTL_Status.BackColor = System.Drawing.Color.Black;
            this.lbl_RTL_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RTL_Status.ForeColor = System.Drawing.Color.Red;
            this.lbl_RTL_Status.Location = new System.Drawing.Point(62, 57);
            this.lbl_RTL_Status.Name = "lbl_RTL_Status";
            this.lbl_RTL_Status.Size = new System.Drawing.Size(54, 16);
            this.lbl_RTL_Status.TabIndex = 70;
            this.lbl_RTL_Status.Text = "Invalid";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Gold;
            this.label9.Location = new System.Drawing.Point(110, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 16);
            this.label9.TabIndex = 67;
            this.label9.Text = "dB";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Black;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Gold;
            this.label22.Location = new System.Drawing.Point(110, 39);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(27, 16);
            this.label22.TabIndex = 69;
            this.label22.Text = "dB";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Black;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Gold;
            this.label24.Location = new System.Drawing.Point(110, 2);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(27, 16);
            this.label24.TabIndex = 68;
            this.label24.Text = "dB";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Black;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Gold;
            this.label23.Location = new System.Drawing.Point(6, 2);
            this.label23.Margin = new System.Windows.Forms.Padding(3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 16);
            this.label23.TabIndex = 63;
            this.label23.Text = "Gain:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Black;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Gold;
            this.label20.Location = new System.Drawing.Point(6, 20);
            this.label20.Margin = new System.Windows.Forms.Padding(3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 16);
            this.label20.TabIndex = 62;
            this.label20.Text = "P_ON:";
            // 
            // lbl_RTL_P_ON
            // 
            this.lbl_RTL_P_ON.AutoSize = true;
            this.lbl_RTL_P_ON.BackColor = System.Drawing.Color.Black;
            this.lbl_RTL_P_ON.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RTL_P_ON.ForeColor = System.Drawing.Color.Gold;
            this.lbl_RTL_P_ON.Location = new System.Drawing.Point(63, 20);
            this.lbl_RTL_P_ON.Name = "lbl_RTL_P_ON";
            this.lbl_RTL_P_ON.Size = new System.Drawing.Size(36, 16);
            this.lbl_RTL_P_ON.TabIndex = 61;
            this.lbl_RTL_P_ON.Text = "0.00";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Gold;
            this.label10.Location = new System.Drawing.Point(6, 39);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 16);
            this.label10.TabIndex = 66;
            this.label10.Text = "P_OFF:";
            // 
            // lbl_RTL_P_OFF
            // 
            this.lbl_RTL_P_OFF.AutoSize = true;
            this.lbl_RTL_P_OFF.BackColor = System.Drawing.Color.Black;
            this.lbl_RTL_P_OFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RTL_P_OFF.ForeColor = System.Drawing.Color.Gold;
            this.lbl_RTL_P_OFF.Location = new System.Drawing.Point(63, 39);
            this.lbl_RTL_P_OFF.Name = "lbl_RTL_P_OFF";
            this.lbl_RTL_P_OFF.Size = new System.Drawing.Size(36, 16);
            this.lbl_RTL_P_OFF.TabIndex = 65;
            this.lbl_RTL_P_OFF.Text = "0.00";
            // 
            // lbl_RTL_Gain
            // 
            this.lbl_RTL_Gain.AutoSize = true;
            this.lbl_RTL_Gain.BackColor = System.Drawing.Color.Black;
            this.lbl_RTL_Gain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RTL_Gain.ForeColor = System.Drawing.Color.Gold;
            this.lbl_RTL_Gain.Location = new System.Drawing.Point(63, 2);
            this.lbl_RTL_Gain.Name = "lbl_RTL_Gain";
            this.lbl_RTL_Gain.Size = new System.Drawing.Size(36, 16);
            this.lbl_RTL_Gain.TabIndex = 64;
            this.lbl_RTL_Gain.Text = "0.00";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ud_DUT_P_ENR);
            this.groupBox4.Controls.Add(this.ud_DUT_Frequency);
            this.groupBox4.Controls.Add(this.label41);
            this.groupBox4.Controls.Add(this.label34);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(357, 106);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(230, 114);
            this.groupBox4.TabIndex = 65;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Device Under Test";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.Location = new System.Drawing.Point(3, 77);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(81, 16);
            this.label41.TabIndex = 66;
            this.label41.Text = "P_ENR[dB]:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(4, 27);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(77, 16);
            this.label34.TabIndex = 28;
            this.label34.Text = "Freq [MHz]:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbb_MMode);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(82, 56);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // cbb_MMode
            // 
            this.cbb_MMode.BackColor = System.Drawing.Color.Black;
            this.cbb_MMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_MMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbb_MMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_MMode.ForeColor = System.Drawing.Color.Gold;
            this.cbb_MMode.Location = new System.Drawing.Point(8, 15);
            this.cbb_MMode.Name = "cbb_MMode";
            this.cbb_MMode.Size = new System.Drawing.Size(59, 28);
            this.cbb_MMode.TabIndex = 51;
            this.cbb_MMode.DropDown += new System.EventHandler(this.cbb_MMode_DropDown);
            this.cbb_MMode.SelectedIndexChanged += new System.EventHandler(this.cbb_MMode_SelectedIndexChanged);
            this.cbb_MMode.DropDownClosed += new System.EventHandler(this.cbb_MMode_DropDownClosed);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lbl_DUT_Frequency);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.lbl_NF);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.lbl_Gain);
            this.groupBox3.Location = new System.Drawing.Point(95, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(681, 105);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(244, 25);
            this.label3.TabIndex = 59;
            this.label3.Text = "Frequency DUT [MHz]";
            // 
            // lbl_DUT_Frequency
            // 
            this.lbl_DUT_Frequency.BackColor = System.Drawing.Color.Black;
            this.lbl_DUT_Frequency.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_DUT_Frequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DUT_Frequency.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_DUT_Frequency.Location = new System.Drawing.Point(8, 34);
            this.lbl_DUT_Frequency.Name = "lbl_DUT_Frequency";
            this.lbl_DUT_Frequency.Size = new System.Drawing.Size(295, 66);
            this.lbl_DUT_Frequency.TabIndex = 58;
            this.lbl_DUT_Frequency.Text = "00000.000";
            this.lbl_DUT_Frequency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(490, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(195, 25);
            this.label14.TabIndex = 50;
            this.label14.Text = "Noise Figure [dB]";
            // 
            // lbl_NF
            // 
            this.lbl_NF.BackColor = System.Drawing.Color.Black;
            this.lbl_NF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_NF.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NF.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_NF.Location = new System.Drawing.Point(495, 34);
            this.lbl_NF.Name = "lbl_NF";
            this.lbl_NF.Size = new System.Drawing.Size(180, 66);
            this.lbl_NF.TabIndex = 49;
            this.lbl_NF.Text = "00.00";
            this.lbl_NF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(307, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 25);
            this.label13.TabIndex = 48;
            this.label13.Text = "Gain [dB]";
            // 
            // lbl_Gain
            // 
            this.lbl_Gain.BackColor = System.Drawing.Color.Black;
            this.lbl_Gain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Gain.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Gain.ForeColor = System.Drawing.Color.Chartreuse;
            this.lbl_Gain.Location = new System.Drawing.Point(309, 34);
            this.lbl_Gain.Name = "lbl_Gain";
            this.lbl_Gain.Size = new System.Drawing.Size(180, 66);
            this.lbl_Gain.TabIndex = 47;
            this.lbl_Gain.Text = "00.00";
            this.lbl_Gain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ud_RTL_P_ENR);
            this.groupBox2.Controls.Add(this.ud_RTL_Frequency);
            this.groupBox2.Controls.Add(this.label40);
            this.groupBox2.Controls.Add(this.lbl_RTL_Frequency);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(96, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(230, 112);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Measure Device";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.Location = new System.Drawing.Point(2, 76);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(81, 16);
            this.label40.TabIndex = 64;
            this.label40.Text = "P_ENR[dB]:";
            // 
            // lbl_RTL_Frequency
            // 
            this.lbl_RTL_Frequency.AutoSize = true;
            this.lbl_RTL_Frequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RTL_Frequency.Location = new System.Drawing.Point(2, 25);
            this.lbl_RTL_Frequency.Name = "lbl_RTL_Frequency";
            this.lbl_RTL_Frequency.Size = new System.Drawing.Size(77, 16);
            this.lbl_RTL_Frequency.TabIndex = 28;
            this.lbl_RTL_Frequency.Text = "Freq [MHz]:";
            // 
            // tc_Main
            // 
            this.tc_Main.Controls.Add(this.tp_Meter);
            this.tc_Main.Controls.Add(this.tp_Sweep);
            this.tc_Main.Controls.Add(this.tp_Info);
            this.tc_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_Main.Location = new System.Drawing.Point(0, 0);
            this.tc_Main.Name = "tc_Main";
            this.tc_Main.SelectedIndex = 0;
            this.tc_Main.Size = new System.Drawing.Size(794, 350);
            this.tc_Main.TabIndex = 62;
            this.tc_Main.SizeChanged += new System.EventHandler(this.tc_Main_SizeChanged);
            // 
            // tb_FFT_Filter_NotchWidth
            // 
            this.tb_FFT_Filter_NotchWidth.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "FFT_Filter_NotchWidth", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tb_FFT_Filter_NotchWidth.Location = new System.Drawing.Point(43, 28);
            this.tb_FFT_Filter_NotchWidth.Maximum = 16384;
            this.tb_FFT_Filter_NotchWidth.Name = "tb_FFT_Filter_NotchWidth";
            this.tb_FFT_Filter_NotchWidth.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tb_FFT_Filter_NotchWidth.Size = new System.Drawing.Size(45, 60);
            this.tb_FFT_Filter_NotchWidth.TabIndex = 70;
            this.tb_FFT_Filter_NotchWidth.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tt_Main.SetToolTip(this.tb_FFT_Filter_NotchWidth, "Click on the LED to enable/disable FFT-Filter");
            this.tb_FFT_Filter_NotchWidth.Value = global::CANFI.Properties.Settings.Default.FFT_Filter_NotchWidth;
            this.tb_FFT_Filter_NotchWidth.Scroll += new System.EventHandler(this.tb_FFT_Filter_NotchWidth_Scroll);
            // 
            // tb_FFT_Filter_Threshold
            // 
            this.tb_FFT_Filter_Threshold.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "FFT_Filter_Threshold", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tb_FFT_Filter_Threshold.Location = new System.Drawing.Point(15, 30);
            this.tb_FFT_Filter_Threshold.Maximum = 100;
            this.tb_FFT_Filter_Threshold.Minimum = 1;
            this.tb_FFT_Filter_Threshold.Name = "tb_FFT_Filter_Threshold";
            this.tb_FFT_Filter_Threshold.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tb_FFT_Filter_Threshold.Size = new System.Drawing.Size(45, 60);
            this.tb_FFT_Filter_Threshold.TabIndex = 68;
            this.tb_FFT_Filter_Threshold.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tt_Main.SetToolTip(this.tb_FFT_Filter_Threshold, "Click on the LED to enable/disable FFT-Filter");
            this.tb_FFT_Filter_Threshold.Value = global::CANFI.Properties.Settings.Default.FFT_Filter_Threshold;
            this.tb_FFT_Filter_Threshold.Scroll += new System.EventHandler(this.tb_FFT_Filter_Threshold_Scroll);
            // 
            // ud_Smoothing
            // 
            this.ud_Smoothing.BackColor = System.Drawing.Color.Black;
            this.ud_Smoothing.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "Smoothing", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_Smoothing.DataBindings.Add(new System.Windows.Forms.Binding("Maximum", global::CANFI.Properties.Settings.Default, "Smoothing_Max", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_Smoothing.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_Smoothing.ForeColor = System.Drawing.Color.Chartreuse;
            this.ud_Smoothing.Location = new System.Drawing.Point(8, 21);
            this.ud_Smoothing.Maximum = global::CANFI.Properties.Settings.Default.Smoothing_Max;
            this.ud_Smoothing.Minimum = global::CANFI.Properties.Settings.Default.Smoothing_Min;
            this.ud_Smoothing.Name = "ud_Smoothing";
            this.ud_Smoothing.Size = new System.Drawing.Size(59, 29);
            this.ud_Smoothing.TabIndex = 60;
            this.tt_Main.SetToolTip(this.ud_Smoothing, "Select the Smoothing Level here.\r\nSmoothing is done by a Moving Avarage of 2^[Smo" +
        "othing Level] values.");
            this.ud_Smoothing.Value = global::CANFI.Properties.Settings.Default.Smoothing;
            this.ud_Smoothing.ValueChanged += new System.EventHandler(this.ud_Smoothing_ValueChanged);
            // 
            // ud_DUT_P_ENR
            // 
            this.ud_DUT_P_ENR.BackColor = System.Drawing.Color.Black;
            this.ud_DUT_P_ENR.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "DUT_P_ENR", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_DUT_P_ENR.DecimalPlaces = 2;
            this.ud_DUT_P_ENR.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_DUT_P_ENR.ForeColor = System.Drawing.Color.Chartreuse;
            this.ud_DUT_P_ENR.Location = new System.Drawing.Point(84, 67);
            this.ud_DUT_P_ENR.Multiline = false;
            this.ud_DUT_P_ENR.Name = "ud_DUT_P_ENR";
            this.ud_DUT_P_ENR.PredecimalPlaces = 2;
            this.ud_DUT_P_ENR.ReadOnly = true;
            this.ud_DUT_P_ENR.ShortcutsEnabled = false;
            this.ud_DUT_P_ENR.Size = new System.Drawing.Size(140, 37);
            this.ud_DUT_P_ENR.TabIndex = 67;
            this.ud_DUT_P_ENR.Text = "0.000 ";
            this.tt_Main.SetToolTip(this.ud_DUT_P_ENR, "Use Left+Right to select\r\nUse Up+Dn or Mouse Wheel to change value");
            this.ud_DUT_P_ENR.Value = global::CANFI.Properties.Settings.Default.DUT_P_ENR;
            // 
            // ud_DUT_Frequency
            // 
            this.ud_DUT_Frequency.BackColor = System.Drawing.Color.Black;
            this.ud_DUT_Frequency.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "DUT_Frequency", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_DUT_Frequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_DUT_Frequency.ForeColor = System.Drawing.Color.Chartreuse;
            this.ud_DUT_Frequency.Location = new System.Drawing.Point(84, 18);
            this.ud_DUT_Frequency.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            196608});
            this.ud_DUT_Frequency.Multiline = false;
            this.ud_DUT_Frequency.Name = "ud_DUT_Frequency";
            this.ud_DUT_Frequency.PredecimalPlaces = 5;
            this.ud_DUT_Frequency.ReadOnly = true;
            this.ud_DUT_Frequency.ShortcutsEnabled = false;
            this.ud_DUT_Frequency.Size = new System.Drawing.Size(140, 37);
            this.ud_DUT_Frequency.TabIndex = 65;
            this.ud_DUT_Frequency.Text = "00.000.000 ";
            this.tt_Main.SetToolTip(this.ud_DUT_Frequency, "Use Left+Right to select\r\nUse Up+Dn or Mouse Wheel to change value");
            this.ud_DUT_Frequency.Value = global::CANFI.Properties.Settings.Default.DUT_Frequency;
            this.ud_DUT_Frequency.ValueChanged += new System.EventHandler(this.ud_DUT_Frequency_ValueChanged);
            // 
            // ud_RTL_P_ENR
            // 
            this.ud_RTL_P_ENR.BackColor = System.Drawing.Color.Black;
            this.ud_RTL_P_ENR.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "RTL_P_ENR", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_RTL_P_ENR.DecimalPlaces = 2;
            this.ud_RTL_P_ENR.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_RTL_P_ENR.ForeColor = System.Drawing.Color.Chartreuse;
            this.ud_RTL_P_ENR.Location = new System.Drawing.Point(82, 64);
            this.ud_RTL_P_ENR.Multiline = false;
            this.ud_RTL_P_ENR.Name = "ud_RTL_P_ENR";
            this.ud_RTL_P_ENR.PredecimalPlaces = 2;
            this.ud_RTL_P_ENR.ReadOnly = true;
            this.ud_RTL_P_ENR.ShortcutsEnabled = false;
            this.ud_RTL_P_ENR.Size = new System.Drawing.Size(140, 37);
            this.ud_RTL_P_ENR.TabIndex = 65;
            this.ud_RTL_P_ENR.Text = "0.000 ";
            this.tt_Main.SetToolTip(this.ud_RTL_P_ENR, "Use Left+Right to select\r\nUse Up+Dn or Mouse Wheel to change value");
            this.ud_RTL_P_ENR.Value = global::CANFI.Properties.Settings.Default.RTL_P_ENR;
            // 
            // ud_RTL_Frequency
            // 
            this.ud_RTL_Frequency.BackColor = System.Drawing.Color.Black;
            this.ud_RTL_Frequency.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "RTL_Frequency", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_RTL_Frequency.DataBindings.Add(new System.Windows.Forms.Binding("Minimum", global::CANFI.Properties.Settings.Default, "RTL_Frequency_Min", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_RTL_Frequency.DataBindings.Add(new System.Windows.Forms.Binding("Maximum", global::CANFI.Properties.Settings.Default, "RTL_Frequency_Max", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_RTL_Frequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_RTL_Frequency.ForeColor = System.Drawing.Color.Chartreuse;
            this.ud_RTL_Frequency.Location = new System.Drawing.Point(82, 15);
            this.ud_RTL_Frequency.Maximum = global::CANFI.Properties.Settings.Default.RTL_Frequency_Max;
            this.ud_RTL_Frequency.Minimum = global::CANFI.Properties.Settings.Default.RTL_Frequency_Min;
            this.ud_RTL_Frequency.Multiline = false;
            this.ud_RTL_Frequency.Name = "ud_RTL_Frequency";
            this.ud_RTL_Frequency.PredecimalPlaces = 5;
            this.ud_RTL_Frequency.ReadOnly = true;
            this.ud_RTL_Frequency.ShortcutsEnabled = false;
            this.ud_RTL_Frequency.Size = new System.Drawing.Size(140, 37);
            this.ud_RTL_Frequency.TabIndex = 53;
            this.ud_RTL_Frequency.Text = "00.000.000 ";
            this.tt_Main.SetToolTip(this.ud_RTL_Frequency, "Use Left+Right to select\r\nUse Up+Dn or Mouse Wheel to change value");
            this.ud_RTL_Frequency.Value = global::CANFI.Properties.Settings.Default.RTL_Frequency;
            this.ud_RTL_Frequency.ValueChanged += new System.EventHandler(this.ud_RTL_Frequency_ValueChanged);
            // 
            // ud_DUT_Sweep_Step
            // 
            this.ud_DUT_Sweep_Step.BackColor = System.Drawing.Color.Black;
            this.ud_DUT_Sweep_Step.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "DUT_Frequency_Step", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_DUT_Sweep_Step.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_DUT_Sweep_Step.ForeColor = System.Drawing.Color.Chartreuse;
            this.ud_DUT_Sweep_Step.Location = new System.Drawing.Point(83, 75);
            this.ud_DUT_Sweep_Step.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ud_DUT_Sweep_Step.Multiline = false;
            this.ud_DUT_Sweep_Step.Name = "ud_DUT_Sweep_Step";
            this.ud_DUT_Sweep_Step.PredecimalPlaces = 5;
            this.ud_DUT_Sweep_Step.ReadOnly = true;
            this.ud_DUT_Sweep_Step.ShortcutsEnabled = false;
            this.ud_DUT_Sweep_Step.Size = new System.Drawing.Size(101, 27);
            this.ud_DUT_Sweep_Step.TabIndex = 56;
            this.ud_DUT_Sweep_Step.Text = "00.000.000 ";
            this.tt_Main.SetToolTip(this.ud_DUT_Sweep_Step, "Use Left+Right to select\r\nUse Up+Dn or Mouse Wheel to change value");
            this.ud_DUT_Sweep_Step.Value = global::CANFI.Properties.Settings.Default.DUT_Frequency_Step;
            // 
            // ud_DUT_Sweep_Stop
            // 
            this.ud_DUT_Sweep_Stop.BackColor = System.Drawing.Color.Black;
            this.ud_DUT_Sweep_Stop.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "DUT_Frequency_Stop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_DUT_Sweep_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_DUT_Sweep_Stop.ForeColor = System.Drawing.Color.Chartreuse;
            this.ud_DUT_Sweep_Stop.Location = new System.Drawing.Point(83, 47);
            this.ud_DUT_Sweep_Stop.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            196608});
            this.ud_DUT_Sweep_Stop.Multiline = false;
            this.ud_DUT_Sweep_Stop.Name = "ud_DUT_Sweep_Stop";
            this.ud_DUT_Sweep_Stop.PredecimalPlaces = 5;
            this.ud_DUT_Sweep_Stop.ReadOnly = true;
            this.ud_DUT_Sweep_Stop.ShortcutsEnabled = false;
            this.ud_DUT_Sweep_Stop.Size = new System.Drawing.Size(101, 27);
            this.ud_DUT_Sweep_Stop.TabIndex = 55;
            this.ud_DUT_Sweep_Stop.Text = "00.000.000 ";
            this.tt_Main.SetToolTip(this.ud_DUT_Sweep_Stop, "Use Left+Right to select\r\nUse Up+Dn or Mouse Wheel to change value");
            this.ud_DUT_Sweep_Stop.Value = global::CANFI.Properties.Settings.Default.DUT_Frequency_Stop;
            // 
            // ud_DUT_Sweep_Start
            // 
            this.ud_DUT_Sweep_Start.BackColor = System.Drawing.Color.Black;
            this.ud_DUT_Sweep_Start.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "DUT_Frequency_Start", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_DUT_Sweep_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_DUT_Sweep_Start.ForeColor = System.Drawing.Color.Chartreuse;
            this.ud_DUT_Sweep_Start.Location = new System.Drawing.Point(83, 19);
            this.ud_DUT_Sweep_Start.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            196608});
            this.ud_DUT_Sweep_Start.Multiline = false;
            this.ud_DUT_Sweep_Start.Name = "ud_DUT_Sweep_Start";
            this.ud_DUT_Sweep_Start.PredecimalPlaces = 5;
            this.ud_DUT_Sweep_Start.ReadOnly = true;
            this.ud_DUT_Sweep_Start.ShortcutsEnabled = false;
            this.ud_DUT_Sweep_Start.Size = new System.Drawing.Size(101, 27);
            this.ud_DUT_Sweep_Start.TabIndex = 54;
            this.ud_DUT_Sweep_Start.Text = "00.000.000 ";
            this.tt_Main.SetToolTip(this.ud_DUT_Sweep_Start, "Use Left+Right to select\r\nUse Up+Dn or Mouse Wheel to change value");
            this.ud_DUT_Sweep_Start.Value = global::CANFI.Properties.Settings.Default.DUT_Frequency_Start;
            // 
            // ud_RTL_Sweep_Step
            // 
            this.ud_RTL_Sweep_Step.BackColor = System.Drawing.Color.Black;
            this.ud_RTL_Sweep_Step.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "RTL_Frequency_Step", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_RTL_Sweep_Step.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_RTL_Sweep_Step.ForeColor = System.Drawing.Color.Chartreuse;
            this.ud_RTL_Sweep_Step.Location = new System.Drawing.Point(83, 75);
            this.ud_RTL_Sweep_Step.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ud_RTL_Sweep_Step.Multiline = false;
            this.ud_RTL_Sweep_Step.Name = "ud_RTL_Sweep_Step";
            this.ud_RTL_Sweep_Step.PredecimalPlaces = 5;
            this.ud_RTL_Sweep_Step.ReadOnly = true;
            this.ud_RTL_Sweep_Step.ShortcutsEnabled = false;
            this.ud_RTL_Sweep_Step.Size = new System.Drawing.Size(101, 27);
            this.ud_RTL_Sweep_Step.TabIndex = 56;
            this.ud_RTL_Sweep_Step.Text = "00.000.000 ";
            this.tt_Main.SetToolTip(this.ud_RTL_Sweep_Step, "Use Left+Right to select\r\nUse Up+Dn or Mouse Wheel to change value");
            this.ud_RTL_Sweep_Step.Value = global::CANFI.Properties.Settings.Default.RTL_Frequency_Step;
            this.ud_RTL_Sweep_Step.ValueChanged += new System.EventHandler(this.ud_RTL_Sweep_Step_ValueChanged);
            // 
            // ud_RTL_Sweep_Stop
            // 
            this.ud_RTL_Sweep_Stop.BackColor = System.Drawing.Color.Black;
            this.ud_RTL_Sweep_Stop.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "RTL_Frequency_Stop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_RTL_Sweep_Stop.DataBindings.Add(new System.Windows.Forms.Binding("Maximum", global::CANFI.Properties.Settings.Default, "RTL_Frequency_Max", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_RTL_Sweep_Stop.DataBindings.Add(new System.Windows.Forms.Binding("Minimum", global::CANFI.Properties.Settings.Default, "RTL_Frequency_Min", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_RTL_Sweep_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_RTL_Sweep_Stop.ForeColor = System.Drawing.Color.Chartreuse;
            this.ud_RTL_Sweep_Stop.Location = new System.Drawing.Point(83, 47);
            this.ud_RTL_Sweep_Stop.Maximum = global::CANFI.Properties.Settings.Default.RTL_Frequency_Max;
            this.ud_RTL_Sweep_Stop.Minimum = global::CANFI.Properties.Settings.Default.RTL_Frequency_Min;
            this.ud_RTL_Sweep_Stop.Multiline = false;
            this.ud_RTL_Sweep_Stop.Name = "ud_RTL_Sweep_Stop";
            this.ud_RTL_Sweep_Stop.PredecimalPlaces = 5;
            this.ud_RTL_Sweep_Stop.ReadOnly = true;
            this.ud_RTL_Sweep_Stop.ShortcutsEnabled = false;
            this.ud_RTL_Sweep_Stop.Size = new System.Drawing.Size(101, 27);
            this.ud_RTL_Sweep_Stop.TabIndex = 55;
            this.ud_RTL_Sweep_Stop.Text = "00.000.000 ";
            this.tt_Main.SetToolTip(this.ud_RTL_Sweep_Stop, "Use Left+Right to select\r\nUse Up+Dn or Mouse Wheel to change value");
            this.ud_RTL_Sweep_Stop.Value = global::CANFI.Properties.Settings.Default.RTL_Frequency_Stop;
            this.ud_RTL_Sweep_Stop.ValueChanged += new System.EventHandler(this.ud_RTL_Sweep_Stop_ValueChanged);
            // 
            // ud_RTL_Sweep_Start
            // 
            this.ud_RTL_Sweep_Start.BackColor = System.Drawing.Color.Black;
            this.ud_RTL_Sweep_Start.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "RTL_Frequency_Start", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_RTL_Sweep_Start.DataBindings.Add(new System.Windows.Forms.Binding("Minimum", global::CANFI.Properties.Settings.Default, "RTL_Frequency_Min", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_RTL_Sweep_Start.DataBindings.Add(new System.Windows.Forms.Binding("Maximum", global::CANFI.Properties.Settings.Default, "RTL_Frequency_Max", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_RTL_Sweep_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_RTL_Sweep_Start.ForeColor = System.Drawing.Color.Chartreuse;
            this.ud_RTL_Sweep_Start.Location = new System.Drawing.Point(83, 19);
            this.ud_RTL_Sweep_Start.Maximum = global::CANFI.Properties.Settings.Default.RTL_Frequency_Max;
            this.ud_RTL_Sweep_Start.Minimum = global::CANFI.Properties.Settings.Default.RTL_Frequency_Min;
            this.ud_RTL_Sweep_Start.Multiline = false;
            this.ud_RTL_Sweep_Start.Name = "ud_RTL_Sweep_Start";
            this.ud_RTL_Sweep_Start.PredecimalPlaces = 5;
            this.ud_RTL_Sweep_Start.ReadOnly = true;
            this.ud_RTL_Sweep_Start.ShortcutsEnabled = false;
            this.ud_RTL_Sweep_Start.Size = new System.Drawing.Size(101, 27);
            this.ud_RTL_Sweep_Start.TabIndex = 54;
            this.ud_RTL_Sweep_Start.Text = "00.000.000 ";
            this.tt_Main.SetToolTip(this.ud_RTL_Sweep_Start, "Use Left+Right to select\r\nUse Up+Dn or Mouse Wheel to change value");
            this.ud_RTL_Sweep_Start.Value = global::CANFI.Properties.Settings.Default.RTL_Frequency_Start;
            this.ud_RTL_Sweep_Start.ValueChanged += new System.EventHandler(this.ud_RTL_Sweep_Start_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 372);
            this.Controls.Add(this.tc_Main);
            this.Controls.Add(this.ss_main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CANFI#";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ss_main.ResumeLayout(false);
            this.ss_main.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.gb_FFT_Filter.ResumeLayout(false);
            this.gb_FFT_Filter.PerformLayout();
            this.tp_Info.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tp_Sweep.ResumeLayout(false);
            this.gb_Sweep.ResumeLayout(false);
            this.gb_Sweep.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.gb_Sweep_RTL.ResumeLayout(false);
            this.gb_Sweep_RTL.PerformLayout();
            this.gb_Sweep_Chart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ch_Sweep)).EndInit();
            this.tp_Meter.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ch_FFT)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tc_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tb_FFT_Filter_NotchWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_FFT_Filter_Threshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_Smoothing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bw_Measure;
        private System.Windows.Forms.StatusStrip ss_main;
        private System.Windows.Forms.ToolStripStatusLabel ssl_Status;
        private System.Windows.Forms.ToolStripStatusLabel ssl_Error;
        private System.Windows.Forms.ToolTip tt_Main;
        private System.Windows.Forms.TabPage tp_Info;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.RichTextBox rtb_Info;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.TextBox tb_Info_RTL_Library;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox tb_Info_RTL_Copyright;
        private System.Windows.Forms.TextBox tb_Info_RTL_Version;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox tb_Info_Copyright;
        private System.Windows.Forms.TextBox tb_Info_AssemblyVersion;
        private System.Windows.Forms.TextBox tb_Info_OS;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabPage tp_Sweep;
        private System.Windows.Forms.GroupBox gb_Sweep;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lbl_Sweep_Gain;
        private System.Windows.Forms.Label lbl_Sweep_NF;
        private System.Windows.Forms.ComboBox cbb_SMode;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button btn_Sweep_Measure;
        private System.Windows.Forms.Button btn_Sweep_Settings;
        private System.Windows.Forms.Button btn_Sweep_Calibrate;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private CANFIUpDown ud_DUT_Sweep_Step;
        private CANFIUpDown ud_DUT_Sweep_Stop;
        private CANFIUpDown ud_DUT_Sweep_Start;
        private System.Windows.Forms.GroupBox gb_Sweep_RTL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private CANFIUpDown ud_RTL_Sweep_Step;
        private CANFIUpDown ud_RTL_Sweep_Stop;
        private CANFIUpDown ud_RTL_Sweep_Start;
        private System.Windows.Forms.GroupBox gb_Sweep_Chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart ch_Sweep;
        private System.Windows.Forms.TabPage tp_Meter;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbl_Noise;
        private System.Windows.Forms.Label lbl_DUT;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox gb_FFT_Filter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tb_FFT_Filter_NotchWidth;
        private System.Windows.Forms.TrackBar tb_FFT_Filter_Threshold;
        private System.Windows.Forms.Label lbl_FFT_Filter;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btn_Measure;
        private System.Windows.Forms.Button btn_Settings;
        private System.Windows.Forms.Button btn_Calibrate;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.NumericUpDown ud_Smoothing;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataVisualization.Charting.Chart ch_FFT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_RTL_Status;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lbl_RTL_P_ON;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_RTL_P_OFF;
        private System.Windows.Forms.Label lbl_RTL_Gain;
        private System.Windows.Forms.GroupBox groupBox4;
        private CANFIUpDown ud_DUT_P_ENR;
        private CANFIUpDown ud_DUT_Frequency;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbb_MMode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_DUT_Frequency;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_NF;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbl_Gain;
        private System.Windows.Forms.GroupBox groupBox2;
        private CANFIUpDown ud_RTL_P_ENR;
        private CANFIUpDown ud_RTL_Frequency;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label lbl_RTL_Frequency;
        private System.Windows.Forms.TabControl tc_Main;
    }
}

