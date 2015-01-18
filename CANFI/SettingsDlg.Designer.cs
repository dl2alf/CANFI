namespace CANFI
{
    partial class SettingsDlg
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDlg));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbb_Device = new System.Windows.Forms.ComboBox();
            this.lbl_TunerType = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ud_COM_Delay = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.cb_COM_DUT_Inverse = new System.Windows.Forms.CheckBox();
            this.cb_COM_Noise_Inverse = new System.Windows.Forms.CheckBox();
            this.cb_COM_DUT = new System.Windows.Forms.CheckBox();
            this.cb_COM_Noise = new System.Windows.Forms.CheckBox();
            this.cb_COM_Port = new System.Windows.Forms.CheckBox();
            this.cbb_COM_DUT = new System.Windows.Forms.ComboBox();
            this.cbb_COM_Noise = new System.Windows.Forms.ComboBox();
            this.cbb_COM = new System.Windows.Forms.ComboBox();
            this.btn_Settings_OK = new System.Windows.Forms.Button();
            this.btn_Settings_Cancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rb_Noise_Cal_File = new System.Windows.Forms.RadioButton();
            this.rb_Noise_Cal_Man = new System.Windows.Forms.RadioButton();
            this.tb_Noise_FileName = new System.Windows.Forms.TextBox();
            this.btn_Noise_File = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ud_RTL_SampleRate = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.cbb_RTL_TunerGain = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_RTL_AGC_Auto = new System.Windows.Forms.CheckBox();
            this.ud_Averaging = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ud_SampleCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.ud_CAL_SampleCount_Min = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.ud_RTL_CLipValue_Max = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.ud_ClipValue_Min = new System.Windows.Forms.NumericUpDown();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cb_RTL_Logging = new System.Windows.Forms.CheckBox();
            this.cb_CAL_Logging = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cb_FFT_Filter = new System.Windows.Forms.CheckBox();
            this.cb_FFT_Display_Realtime = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.ud_Tamb = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_COM_Delay)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_RTL_SampleRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_Averaging)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_SampleCount)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_CAL_SampleCount_Min)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_RTL_CLipValue_Max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_ClipValue_Min)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_Tamb)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbb_Device);
            this.groupBox1.Controls.Add(this.lbl_TunerType);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 82);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RTL-SDR Device";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Device";
            // 
            // cbb_Device
            // 
            this.cbb_Device.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_Device.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_Device.FormattingEnabled = true;
            this.cbb_Device.Location = new System.Drawing.Point(8, 33);
            this.cbb_Device.Name = "cbb_Device";
            this.cbb_Device.Size = new System.Drawing.Size(205, 21);
            this.cbb_Device.TabIndex = 0;
            this.cbb_Device.SelectedIndexChanged += new System.EventHandler(this.cbb_Device_SelectedIndexChanged);
            // 
            // lbl_TunerType
            // 
            this.lbl_TunerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TunerType.Location = new System.Drawing.Point(120, 16);
            this.lbl_TunerType.Name = "lbl_TunerType";
            this.lbl_TunerType.Size = new System.Drawing.Size(93, 13);
            this.lbl_TunerType.TabIndex = 29;
            this.lbl_TunerType.Text = "E4000";
            this.lbl_TunerType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ud_COM_Delay);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.cb_COM_DUT_Inverse);
            this.groupBox2.Controls.Add(this.cb_COM_Noise_Inverse);
            this.groupBox2.Controls.Add(this.cb_COM_DUT);
            this.groupBox2.Controls.Add(this.cb_COM_Noise);
            this.groupBox2.Controls.Add(this.cb_COM_Port);
            this.groupBox2.Controls.Add(this.cbb_COM_DUT);
            this.groupBox2.Controls.Add(this.cbb_COM_Noise);
            this.groupBox2.Controls.Add(this.cbb_COM);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(484, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 145);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "COM Control";
            // 
            // ud_COM_Delay
            // 
            this.ud_COM_Delay.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "COM_Delay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_COM_Delay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_COM_Delay.Location = new System.Drawing.Point(143, 116);
            this.ud_COM_Delay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ud_COM_Delay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ud_COM_Delay.Name = "ud_COM_Delay";
            this.ud_COM_Delay.Size = new System.Drawing.Size(78, 20);
            this.ud_COM_Delay.TabIndex = 56;
            this.ud_COM_Delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ud_COM_Delay.Value = global::CANFI.Properties.Settings.Default.COM_Delay;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(15, 118);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 13);
            this.label15.TabIndex = 55;
            this.label15.Text = "Switchover Delay [ms]:";
            // 
            // cb_COM_DUT_Inverse
            // 
            this.cb_COM_DUT_Inverse.AutoSize = true;
            this.cb_COM_DUT_Inverse.Checked = global::CANFI.Properties.Settings.Default.COM_DUT_Inverse;
            this.cb_COM_DUT_Inverse.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::CANFI.Properties.Settings.Default, "COM_DUT_Inverse", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_COM_DUT_Inverse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_COM_DUT_Inverse.Location = new System.Drawing.Point(239, 88);
            this.cb_COM_DUT_Inverse.Name = "cb_COM_DUT_Inverse";
            this.cb_COM_DUT_Inverse.Size = new System.Drawing.Size(41, 17);
            this.cb_COM_DUT_Inverse.TabIndex = 34;
            this.cb_COM_DUT_Inverse.Text = "Inv";
            this.cb_COM_DUT_Inverse.UseVisualStyleBackColor = true;
            // 
            // cb_COM_Noise_Inverse
            // 
            this.cb_COM_Noise_Inverse.AutoSize = true;
            this.cb_COM_Noise_Inverse.Checked = global::CANFI.Properties.Settings.Default.COM_Noise_Inverse;
            this.cb_COM_Noise_Inverse.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::CANFI.Properties.Settings.Default, "COM_Noise_Inverse", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_COM_Noise_Inverse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_COM_Noise_Inverse.Location = new System.Drawing.Point(239, 58);
            this.cb_COM_Noise_Inverse.Name = "cb_COM_Noise_Inverse";
            this.cb_COM_Noise_Inverse.Size = new System.Drawing.Size(41, 17);
            this.cb_COM_Noise_Inverse.TabIndex = 33;
            this.cb_COM_Noise_Inverse.Text = "Inv";
            this.cb_COM_Noise_Inverse.UseVisualStyleBackColor = true;
            // 
            // cb_COM_DUT
            // 
            this.cb_COM_DUT.AutoSize = true;
            this.cb_COM_DUT.Checked = global::CANFI.Properties.Settings.Default.COM_DUT_Use;
            this.cb_COM_DUT.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::CANFI.Properties.Settings.Default, "COM_DUT_Use", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_COM_DUT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_COM_DUT.Location = new System.Drawing.Point(18, 86);
            this.cb_COM_DUT.Name = "cb_COM_DUT";
            this.cb_COM_DUT.Size = new System.Drawing.Size(87, 17);
            this.cb_COM_DUT.TabIndex = 32;
            this.cb_COM_DUT.Text = "DUT Switch:";
            this.cb_COM_DUT.UseVisualStyleBackColor = true;
            // 
            // cb_COM_Noise
            // 
            this.cb_COM_Noise.AutoSize = true;
            this.cb_COM_Noise.Checked = global::CANFI.Properties.Settings.Default.COM_Noise_Use;
            this.cb_COM_Noise.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_COM_Noise.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::CANFI.Properties.Settings.Default, "COM_Noise_Use", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_COM_Noise.Enabled = false;
            this.cb_COM_Noise.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_COM_Noise.Location = new System.Drawing.Point(18, 56);
            this.cb_COM_Noise.Name = "cb_COM_Noise";
            this.cb_COM_Noise.Size = new System.Drawing.Size(93, 17);
            this.cb_COM_Noise.TabIndex = 31;
            this.cb_COM_Noise.Text = "Noise Source:";
            this.cb_COM_Noise.UseVisualStyleBackColor = true;
            // 
            // cb_COM_Port
            // 
            this.cb_COM_Port.AutoSize = true;
            this.cb_COM_Port.Checked = global::CANFI.Properties.Settings.Default.COM_Port_Use;
            this.cb_COM_Port.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_COM_Port.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::CANFI.Properties.Settings.Default, "COM_Port_Use", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_COM_Port.Enabled = false;
            this.cb_COM_Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_COM_Port.Location = new System.Drawing.Point(18, 24);
            this.cb_COM_Port.Name = "cb_COM_Port";
            this.cb_COM_Port.Size = new System.Drawing.Size(75, 17);
            this.cb_COM_Port.TabIndex = 30;
            this.cb_COM_Port.Text = "COM Port:";
            this.cb_COM_Port.UseVisualStyleBackColor = true;
            // 
            // cbb_COM_DUT
            // 
            this.cbb_COM_DUT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_COM_DUT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_COM_DUT.FormattingEnabled = true;
            this.cbb_COM_DUT.Location = new System.Drawing.Point(117, 84);
            this.cbb_COM_DUT.Name = "cbb_COM_DUT";
            this.cbb_COM_DUT.Size = new System.Drawing.Size(104, 21);
            this.cbb_COM_DUT.TabIndex = 5;
            this.cbb_COM_DUT.SelectedIndexChanged += new System.EventHandler(this.cbb_COM_DUT_SelectedIndexChanged);
            // 
            // cbb_COM_Noise
            // 
            this.cbb_COM_Noise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_COM_Noise.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_COM_Noise.FormattingEnabled = true;
            this.cbb_COM_Noise.Location = new System.Drawing.Point(117, 54);
            this.cbb_COM_Noise.Name = "cbb_COM_Noise";
            this.cbb_COM_Noise.Size = new System.Drawing.Size(104, 21);
            this.cbb_COM_Noise.TabIndex = 4;
            this.cbb_COM_Noise.SelectedIndexChanged += new System.EventHandler(this.cbb_COM_Noise_SelectedIndexChanged);
            // 
            // cbb_COM
            // 
            this.cbb_COM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_COM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_COM.FormattingEnabled = true;
            this.cbb_COM.Location = new System.Drawing.Point(117, 22);
            this.cbb_COM.Name = "cbb_COM";
            this.cbb_COM.Size = new System.Drawing.Size(104, 21);
            this.cbb_COM.TabIndex = 0;
            // 
            // btn_Settings_OK
            // 
            this.btn_Settings_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Settings_OK.Location = new System.Drawing.Point(697, 284);
            this.btn_Settings_OK.Name = "btn_Settings_OK";
            this.btn_Settings_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_Settings_OK.TabIndex = 33;
            this.btn_Settings_OK.Text = "&OK";
            this.btn_Settings_OK.UseVisualStyleBackColor = true;
            // 
            // btn_Settings_Cancel
            // 
            this.btn_Settings_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Settings_Cancel.Location = new System.Drawing.Point(697, 313);
            this.btn_Settings_Cancel.Name = "btn_Settings_Cancel";
            this.btn_Settings_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Settings_Cancel.TabIndex = 34;
            this.btn_Settings_Cancel.Text = "&Cancel";
            this.btn_Settings_Cancel.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rb_Noise_Cal_File);
            this.groupBox3.Controls.Add(this.rb_Noise_Cal_Man);
            this.groupBox3.Controls.Add(this.tb_Noise_FileName);
            this.groupBox3.Controls.Add(this.btn_Noise_File);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(484, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(288, 103);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Noise Source Calibration";
            // 
            // rb_Noise_Cal_File
            // 
            this.rb_Noise_Cal_File.AutoSize = true;
            this.rb_Noise_Cal_File.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Noise_Cal_File.Location = new System.Drawing.Point(20, 41);
            this.rb_Noise_Cal_File.Name = "rb_Noise_Cal_File";
            this.rb_Noise_Cal_File.Size = new System.Drawing.Size(173, 17);
            this.rb_Noise_Cal_File.TabIndex = 35;
            this.rb_Noise_Cal_File.TabStop = true;
            this.rb_Noise_Cal_File.Text = "Take Calibration Data From File";
            this.rb_Noise_Cal_File.UseVisualStyleBackColor = true;
            this.rb_Noise_Cal_File.CheckedChanged += new System.EventHandler(this.rb_Noise_Cal_File_CheckedChanged);
            // 
            // rb_Noise_Cal_Man
            // 
            this.rb_Noise_Cal_Man.AutoSize = true;
            this.rb_Noise_Cal_Man.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Noise_Cal_Man.Location = new System.Drawing.Point(20, 18);
            this.rb_Noise_Cal_Man.Name = "rb_Noise_Cal_Man";
            this.rb_Noise_Cal_Man.Size = new System.Drawing.Size(173, 17);
            this.rb_Noise_Cal_Man.TabIndex = 34;
            this.rb_Noise_Cal_Man.TabStop = true;
            this.rb_Noise_Cal_Man.Text = "Enter Calibration Data Manually";
            this.rb_Noise_Cal_Man.UseVisualStyleBackColor = true;
            this.rb_Noise_Cal_Man.CheckedChanged += new System.EventHandler(this.rb_Noise_Cal_Man_CheckedChanged);
            // 
            // tb_Noise_FileName
            // 
            this.tb_Noise_FileName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::CANFI.Properties.Settings.Default, "Noise_FileName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tb_Noise_FileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_Noise_FileName.Location = new System.Drawing.Point(20, 70);
            this.tb_Noise_FileName.Name = "tb_Noise_FileName";
            this.tb_Noise_FileName.ReadOnly = true;
            this.tb_Noise_FileName.Size = new System.Drawing.Size(254, 20);
            this.tb_Noise_FileName.TabIndex = 33;
            this.tb_Noise_FileName.Text = global::CANFI.Properties.Settings.Default.Noise_FileName;
            // 
            // btn_Noise_File
            // 
            this.btn_Noise_File.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Noise_File.Location = new System.Drawing.Point(199, 38);
            this.btn_Noise_File.Name = "btn_Noise_File";
            this.btn_Noise_File.Size = new System.Drawing.Size(75, 23);
            this.btn_Noise_File.TabIndex = 32;
            this.btn_Noise_File.Text = "Load";
            this.btn_Noise_File.UseVisualStyleBackColor = true;
            this.btn_Noise_File.Click += new System.EventHandler(this.btn_Noise_File_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ud_RTL_SampleRate);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.cbb_RTL_TunerGain);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.cb_RTL_AGC_Auto);
            this.groupBox4.Controls.Add(this.ud_Averaging);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.ud_SampleCount);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(12, 100);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(230, 160);
            this.groupBox4.TabIndex = 36;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "RTL Measure Settings";
            // 
            // ud_RTL_SampleRate
            // 
            this.ud_RTL_SampleRate.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "RTL_SampleRate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_RTL_SampleRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_RTL_SampleRate.Location = new System.Drawing.Point(132, 75);
            this.ud_RTL_SampleRate.Maximum = new decimal(new int[] {
            2500000,
            0,
            0,
            0});
            this.ud_RTL_SampleRate.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.ud_RTL_SampleRate.Name = "ud_RTL_SampleRate";
            this.ud_RTL_SampleRate.Size = new System.Drawing.Size(83, 20);
            this.ud_RTL_SampleRate.TabIndex = 50;
            this.ud_RTL_SampleRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ud_RTL_SampleRate.Value = global::CANFI.Properties.Settings.Default.RTL_SampleRate;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 49;
            this.label5.Text = "Sample Rate:";
            // 
            // cbb_RTL_TunerGain
            // 
            this.cbb_RTL_TunerGain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_RTL_TunerGain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_RTL_TunerGain.FormattingEnabled = true;
            this.cbb_RTL_TunerGain.Location = new System.Drawing.Point(96, 26);
            this.cbb_RTL_TunerGain.Name = "cbb_RTL_TunerGain";
            this.cbb_RTL_TunerGain.Size = new System.Drawing.Size(53, 21);
            this.cbb_RTL_TunerGain.TabIndex = 48;
            this.cbb_RTL_TunerGain.SelectedIndexChanged += new System.EventHandler(this.cbb_RTL_TunerGain_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Tuner Gain [dB]:";
            // 
            // cb_RTL_AGC_Auto
            // 
            this.cb_RTL_AGC_Auto.AutoSize = true;
            this.cb_RTL_AGC_Auto.Checked = global::CANFI.Properties.Settings.Default.RTL_AGC_Auto;
            this.cb_RTL_AGC_Auto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_RTL_AGC_Auto.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::CANFI.Properties.Settings.Default, "RTL_AGC_Auto", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_RTL_AGC_Auto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_RTL_AGC_Auto.Location = new System.Drawing.Point(167, 28);
            this.cb_RTL_AGC_Auto.Name = "cb_RTL_AGC_Auto";
            this.cb_RTL_AGC_Auto.Size = new System.Drawing.Size(48, 17);
            this.cb_RTL_AGC_Auto.TabIndex = 46;
            this.cb_RTL_AGC_Auto.Text = "Auto";
            this.cb_RTL_AGC_Auto.UseVisualStyleBackColor = true;
            this.cb_RTL_AGC_Auto.CheckedChanged += new System.EventHandler(this.cb_RTL_AGC_Auto_CheckedChanged);
            // 
            // ud_Averaging
            // 
            this.ud_Averaging.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "Smoothing", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_Averaging.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_Averaging.Location = new System.Drawing.Point(132, 131);
            this.ud_Averaging.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ud_Averaging.Name = "ud_Averaging";
            this.ud_Averaging.Size = new System.Drawing.Size(83, 20);
            this.ud_Averaging.TabIndex = 45;
            this.ud_Averaging.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ud_Averaging.Value = global::CANFI.Properties.Settings.Default.Smoothing;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Smoothing Level:";
            // 
            // ud_SampleCount
            // 
            this.ud_SampleCount.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "RTL_SampleCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_SampleCount.DataBindings.Add(new System.Windows.Forms.Binding("Maximum", global::CANFI.Properties.Settings.Default, "RTL_SampleCount_Max", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_SampleCount.DataBindings.Add(new System.Windows.Forms.Binding("Minimum", global::CANFI.Properties.Settings.Default, "RTL_SampleCount_Min", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_SampleCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_SampleCount.Location = new System.Drawing.Point(132, 103);
            this.ud_SampleCount.Maximum = global::CANFI.Properties.Settings.Default.RTL_SampleCount_Max;
            this.ud_SampleCount.Minimum = global::CANFI.Properties.Settings.Default.RTL_SampleCount_Min;
            this.ud_SampleCount.Name = "ud_SampleCount";
            this.ud_SampleCount.Size = new System.Drawing.Size(83, 20);
            this.ud_SampleCount.TabIndex = 43;
            this.ud_SampleCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ud_SampleCount.Value = global::CANFI.Properties.Settings.Default.RTL_SampleCount;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Sample Count:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.numericUpDown1);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.ud_CAL_SampleCount_Min);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(248, 68);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(230, 73);
            this.groupBox5.TabIndex = 37;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "RTL Calibration Settings";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "CAL_SampleCount_Max", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(135, 42);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(78, 20);
            this.numericUpDown1.TabIndex = 54;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = global::CANFI.Properties.Settings.Default.CAL_SampleCount_Max;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 13);
            this.label7.TabIndex = 53;
            this.label7.Text = "Calibration Cycles Max:";
            // 
            // ud_CAL_SampleCount_Min
            // 
            this.ud_CAL_SampleCount_Min.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "CAL_SampleCount_Min", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_CAL_SampleCount_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_CAL_SampleCount_Min.Location = new System.Drawing.Point(135, 18);
            this.ud_CAL_SampleCount_Min.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ud_CAL_SampleCount_Min.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ud_CAL_SampleCount_Min.Name = "ud_CAL_SampleCount_Min";
            this.ud_CAL_SampleCount_Min.Size = new System.Drawing.Size(78, 20);
            this.ud_CAL_SampleCount_Min.TabIndex = 52;
            this.ud_CAL_SampleCount_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ud_CAL_SampleCount_Min.Value = global::CANFI.Properties.Settings.Default.CAL_SampleCount_Min;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Calibration Cycles Min:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 51;
            this.label8.Text = "Clipping Value Min:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.numericUpDown2);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.ud_RTL_CLipValue_Max);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.ud_ClipValue_Min);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(248, 142);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(230, 118);
            this.groupBox6.TabIndex = 38;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "RTL Clippimg Settings";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "RTL_MaxClipAllowed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown2.Location = new System.Drawing.Point(135, 78);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            1275,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1275,
            0,
            0,
            -2147483648});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(78, 20);
            this.numericUpDown2.TabIndex = 56;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown2.Value = global::CANFI.Properties.Settings.Default.RTL_MaxClipAllowed;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 13);
            this.label10.TabIndex = 55;
            this.label10.Text = "Clip Count until Invalid:";
            // 
            // ud_RTL_CLipValue_Max
            // 
            this.ud_RTL_CLipValue_Max.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "RTL_ClipValue_Max", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_RTL_CLipValue_Max.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_RTL_CLipValue_Max.Location = new System.Drawing.Point(135, 49);
            this.ud_RTL_CLipValue_Max.Maximum = new decimal(new int[] {
            1275,
            0,
            0,
            0});
            this.ud_RTL_CLipValue_Max.Minimum = new decimal(new int[] {
            1275,
            0,
            0,
            -2147483648});
            this.ud_RTL_CLipValue_Max.Name = "ud_RTL_CLipValue_Max";
            this.ud_RTL_CLipValue_Max.Size = new System.Drawing.Size(78, 20);
            this.ud_RTL_CLipValue_Max.TabIndex = 54;
            this.ud_RTL_CLipValue_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ud_RTL_CLipValue_Max.Value = global::CANFI.Properties.Settings.Default.RTL_ClipValue_Max;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 13);
            this.label9.TabIndex = 53;
            this.label9.Text = "Clipping Value Max:";
            // 
            // ud_ClipValue_Min
            // 
            this.ud_ClipValue_Min.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "RTL_ClipValue_Min", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_ClipValue_Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_ClipValue_Min.Location = new System.Drawing.Point(135, 22);
            this.ud_ClipValue_Min.Maximum = new decimal(new int[] {
            1275,
            0,
            0,
            0});
            this.ud_ClipValue_Min.Minimum = new decimal(new int[] {
            1275,
            0,
            0,
            -2147483648});
            this.ud_ClipValue_Min.Name = "ud_ClipValue_Min";
            this.ud_ClipValue_Min.Size = new System.Drawing.Size(78, 20);
            this.ud_ClipValue_Min.TabIndex = 52;
            this.ud_ClipValue_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ud_ClipValue_Min.Value = global::CANFI.Properties.Settings.Default.RTL_ClipValue_Min;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cb_RTL_Logging);
            this.groupBox7.Controls.Add(this.cb_CAL_Logging);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(12, 284);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(230, 66);
            this.groupBox7.TabIndex = 39;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "RTL Logging Settings";
            // 
            // cb_RTL_Logging
            // 
            this.cb_RTL_Logging.AutoSize = true;
            this.cb_RTL_Logging.Checked = global::CANFI.Properties.Settings.Default.RTL_Logging;
            this.cb_RTL_Logging.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::CANFI.Properties.Settings.Default, "RTL_Logging", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_RTL_Logging.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_RTL_Logging.Location = new System.Drawing.Point(9, 40);
            this.cb_RTL_Logging.Name = "cb_RTL_Logging";
            this.cb_RTL_Logging.Size = new System.Drawing.Size(145, 17);
            this.cb_RTL_Logging.TabIndex = 41;
            this.cb_RTL_Logging.Text = "Log Measurement to File:";
            this.cb_RTL_Logging.UseVisualStyleBackColor = true;
            // 
            // cb_CAL_Logging
            // 
            this.cb_CAL_Logging.AutoSize = true;
            this.cb_CAL_Logging.Checked = global::CANFI.Properties.Settings.Default.CAL_Logging;
            this.cb_CAL_Logging.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::CANFI.Properties.Settings.Default, "CAL_Logging", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_CAL_Logging.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_CAL_Logging.Location = new System.Drawing.Point(9, 17);
            this.cb_CAL_Logging.Name = "cb_CAL_Logging";
            this.cb_CAL_Logging.Size = new System.Drawing.Size(130, 17);
            this.cb_CAL_Logging.TabIndex = 40;
            this.cb_CAL_Logging.Text = "Log Calibration to File:";
            this.cb_CAL_Logging.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cb_FFT_Filter);
            this.groupBox8.Controls.Add(this.cb_FFT_Display_Realtime);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(248, 284);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(230, 66);
            this.groupBox8.TabIndex = 42;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "FFT Settings";
            // 
            // cb_FFT_Filter
            // 
            this.cb_FFT_Filter.AutoSize = true;
            this.cb_FFT_Filter.Checked = global::CANFI.Properties.Settings.Default.FFT_Filter;
            this.cb_FFT_Filter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_FFT_Filter.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::CANFI.Properties.Settings.Default, "FFT_Filter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_FFT_Filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_FFT_Filter.Location = new System.Drawing.Point(9, 40);
            this.cb_FFT_Filter.Name = "cb_FFT_Filter";
            this.cb_FFT_Filter.Size = new System.Drawing.Size(138, 17);
            this.cb_FFT_Filter.TabIndex = 41;
            this.cb_FFT_Filter.Text = "Use FFT Filter Algorithm";
            this.cb_FFT_Filter.UseVisualStyleBackColor = true;
            // 
            // cb_FFT_Display_Realtime
            // 
            this.cb_FFT_Display_Realtime.AutoSize = true;
            this.cb_FFT_Display_Realtime.Checked = global::CANFI.Properties.Settings.Default.FFT_RealtimeDisplay;
            this.cb_FFT_Display_Realtime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_FFT_Display_Realtime.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::CANFI.Properties.Settings.Default, "FFT_RealtimeDisplay", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cb_FFT_Display_Realtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_FFT_Display_Realtime.Location = new System.Drawing.Point(9, 17);
            this.cb_FFT_Display_Realtime.Name = "cb_FFT_Display_Realtime";
            this.cb_FFT_Display_Realtime.Size = new System.Drawing.Size(163, 17);
            this.cb_FFT_Display_Realtime.TabIndex = 40;
            this.cb_FFT_Display_Realtime.Text = "Display Spectrum in Realtime";
            this.cb_FFT_Display_Realtime.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Chartreuse;
            this.label11.Location = new System.Drawing.Point(38, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 39);
            this.label11.TabIndex = 0;
            this.label11.Text = "CANFI";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Chartreuse;
            this.label12.Location = new System.Drawing.Point(16, 60);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(175, 16);
            this.label12.TabIndex = 1;
            this.label12.Text = "(c) DF9IC, DL8AAU, DL2ALF";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Chartreuse;
            this.label13.Location = new System.Drawing.Point(2, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(199, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "(C)heap (A)utomatic (N)oise (F)igure (I)ndicator";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(484, 266);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 84);
            this.panel1.TabIndex = 43;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.ud_Tamb);
            this.groupBox9.Controls.Add(this.label14);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(248, 12);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(230, 50);
            this.groupBox9.TabIndex = 44;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Temperature Correction";
            // 
            // ud_Tamb
            // 
            this.ud_Tamb.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "Tamb", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_Tamb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_Tamb.Location = new System.Drawing.Point(135, 20);
            this.ud_Tamb.Maximum = new decimal(new int[] {
            373,
            0,
            0,
            0});
            this.ud_Tamb.Minimum = new decimal(new int[] {
            173,
            0,
            0,
            0});
            this.ud_Tamb.Name = "ud_Tamb";
            this.ud_Tamb.Size = new System.Drawing.Size(78, 20);
            this.ud_Tamb.TabIndex = 54;
            this.ud_Tamb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ud_Tamb.Value = global::CANFI.Properties.Settings.Default.Tamb;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(127, 13);
            this.label14.TabIndex = 53;
            this.label14.Text = "Ambient Temperature [K]:";
            // 
            // SettingsDlg
            // 
            this.AcceptButton = this.btn_Settings_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Settings_Cancel;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btn_Settings_Cancel);
            this.Controls.Add(this.btn_Settings_OK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsDlg";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsDlg_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_COM_Delay)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_RTL_SampleRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_Averaging)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_SampleCount)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_CAL_SampleCount_Min)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_RTL_CLipValue_Max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_ClipValue_Min)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_Tamb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_TunerType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Settings_OK;
        private System.Windows.Forms.Button btn_Settings_Cancel;
        public System.Windows.Forms.ComboBox cbb_Device;
        public System.Windows.Forms.ComboBox cbb_COM;
        public System.Windows.Forms.ComboBox cbb_COM_DUT;
        public System.Windows.Forms.ComboBox cbb_COM_Noise;
        private System.Windows.Forms.CheckBox cb_COM_Port;
        private System.Windows.Forms.CheckBox cb_COM_DUT;
        private System.Windows.Forms.CheckBox cb_COM_Noise;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_Noise_File;
        public System.Windows.Forms.TextBox tb_Noise_FileName;
        private System.Windows.Forms.CheckBox cb_COM_DUT_Inverse;
        private System.Windows.Forms.CheckBox cb_COM_Noise_Inverse;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown ud_RTL_SampleRate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbb_RTL_TunerGain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_RTL_AGC_Auto;
        private System.Windows.Forms.NumericUpDown ud_Averaging;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ud_SampleCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown ud_CAL_SampleCount_Min;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown ud_ClipValue_Min;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown ud_RTL_CLipValue_Max;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox7;
        public System.Windows.Forms.RadioButton rb_Noise_Cal_File;
        public System.Windows.Forms.RadioButton rb_Noise_Cal_Man;
        private System.Windows.Forms.CheckBox cb_RTL_Logging;
        private System.Windows.Forms.CheckBox cb_CAL_Logging;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox cb_FFT_Display_Realtime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.NumericUpDown ud_Tamb;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown ud_COM_Delay;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox cb_FFT_Filter;
    }
}