namespace CANFI
{
    partial class SweepDlg
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
            this.label1 = new System.Windows.Forms.Label();
            this.ud_RTL_Frequency_Start = new CANFI.CANFIUpDown();
            this.ud_RTL_Frequency_Stop = new CANFI.CANFIUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ud_RTL_Frequency_Step = new CANFI.CANFIUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Freq [MHz]:";
            // 
            // ud_RTL_Frequency_Start
            // 
            this.ud_RTL_Frequency_Start.BackColor = System.Drawing.Color.Black;
            this.ud_RTL_Frequency_Start.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "RTL_Frequency_Start", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_RTL_Frequency_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_RTL_Frequency_Start.ForeColor = System.Drawing.Color.Chartreuse;
            this.ud_RTL_Frequency_Start.Location = new System.Drawing.Point(136, 25);
            this.ud_RTL_Frequency_Start.Name = "ud_RTL_Frequency_Start";
            this.ud_RTL_Frequency_Start.PredecimalPlaces = 5;
            this.ud_RTL_Frequency_Start.ReadOnly = true;
            this.ud_RTL_Frequency_Start.Size = new System.Drawing.Size(173, 29);
            this.ud_RTL_Frequency_Start.TabIndex = 1;
            this.ud_RTL_Frequency_Start.Text = "00.000.100 ";
            this.ud_RTL_Frequency_Start.Value = global::CANFI.Properties.Settings.Default.RTL_Frequency_Start;
            // 
            // ud_RTL_Frequency_Stop
            // 
            this.ud_RTL_Frequency_Stop.BackColor = System.Drawing.Color.Black;
            this.ud_RTL_Frequency_Stop.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "RTL_Frequency_Stop", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_RTL_Frequency_Stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_RTL_Frequency_Stop.ForeColor = System.Drawing.Color.Chartreuse;
            this.ud_RTL_Frequency_Stop.Location = new System.Drawing.Point(139, 61);
            this.ud_RTL_Frequency_Stop.Name = "ud_RTL_Frequency_Stop";
            this.ud_RTL_Frequency_Stop.PredecimalPlaces = 5;
            this.ud_RTL_Frequency_Stop.ReadOnly = true;
            this.ud_RTL_Frequency_Stop.Size = new System.Drawing.Size(173, 29);
            this.ud_RTL_Frequency_Stop.TabIndex = 3;
            this.ud_RTL_Frequency_Stop.Text = "00.000.200 ";
            this.ud_RTL_Frequency_Stop.Value = global::CANFI.Properties.Settings.Default.RTL_Frequency_Stop;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Stop Freq [MHz]:";
            // 
            // ud_RTL_Frequency_Step
            // 
            this.ud_RTL_Frequency_Step.BackColor = System.Drawing.Color.Black;
            this.ud_RTL_Frequency_Step.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::CANFI.Properties.Settings.Default, "RTL_Frequency_Step", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ud_RTL_Frequency_Step.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_RTL_Frequency_Step.ForeColor = System.Drawing.Color.Chartreuse;
            this.ud_RTL_Frequency_Step.Location = new System.Drawing.Point(139, 98);
            this.ud_RTL_Frequency_Step.Name = "ud_RTL_Frequency_Step";
            this.ud_RTL_Frequency_Step.ReadOnly = true;
            this.ud_RTL_Frequency_Step.Size = new System.Drawing.Size(173, 29);
            this.ud_RTL_Frequency_Step.TabIndex = 5;
            this.ud_RTL_Frequency_Step.Text = "000.001 ";
            this.ud_RTL_Frequency_Step.Value = global::CANFI.Properties.Settings.Default.RTL_Frequency_Step;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Stepwidth [MHz]:";
            // 
            // SweepDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 154);
            this.Controls.Add(this.ud_RTL_Frequency_Step);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ud_RTL_Frequency_Stop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ud_RTL_Frequency_Start);
            this.Controls.Add(this.label1);
            this.Name = "SweepDlg";
            this.Text = "Set Sweep Mode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CANFIUpDown ud_RTL_Frequency_Start;
        private CANFIUpDown ud_RTL_Frequency_Stop;
        private System.Windows.Forms.Label label2;
        private CANFIUpDown ud_RTL_Frequency_Step;
        private System.Windows.Forms.Label label3;
    }
}