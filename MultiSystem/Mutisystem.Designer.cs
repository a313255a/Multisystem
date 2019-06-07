namespace LungSound
{
    partial class Mutisystem
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mutisystem));
            this.recevide = new System.Windows.Forms.Label();
            this.Power = new System.Windows.Forms.PictureBox();
            this.save_progressBar = new System.Windows.Forms.ProgressBar();
            this.gbxRealTimeRecord = new System.Windows.Forms.GroupBox();
            this.Unlimitrecord = new System.Windows.Forms.Button();
            this.gbxFixedTimeRecord = new System.Windows.Forms.GroupBox();
            this.Recoder = new System.Windows.Forms.Button();
            this.gbxSettings = new System.Windows.Forms.GroupBox();
            this.ConnectRFID = new System.Windows.Forms.Button();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.BTIDName = new System.Windows.Forms.ComboBox();
            this.useBTID = new System.Windows.Forms.CheckBox();
            this.tbxFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.gbxrecord = new System.Windows.Forms.GroupBox();
            this.NIRPanel = new System.Windows.Forms.Panel();
            this.label55 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.PPGlabel = new System.Windows.Forms.Label();
            this.ECGPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ECGlabel = new System.Windows.Forms.Label();
            this.SoundPanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Soundlabel = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.avgSPO2 = new System.Windows.Forms.Label();
            this.minSPO2 = new System.Windows.Forms.Label();
            this.maxSPO2 = new System.Windows.Forms.Label();
            this.avgBR = new System.Windows.Forms.Label();
            this.minBR = new System.Windows.Forms.Label();
            this.maxBR = new System.Windows.Forms.Label();
            this.avgHR = new System.Windows.Forms.Label();
            this.minHR = new System.Windows.Forms.Label();
            this.maxHR = new System.Windows.Forms.Label();
            this.lab_RR = new System.Windows.Forms.Label();
            this.lab_HR = new System.Windows.Forms.Label();
            this.BreathRatelabel = new System.Windows.Forms.Label();
            this.HeartRatelabel = new System.Windows.Forms.Label();
            this.lab_SpO2 = new System.Windows.Forms.Label();
            this.SpO2Label = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MWT6 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.Avgacceleration = new System.Windows.Forms.TextBox();
            this.Avgspeed = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.Distance = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MWT = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Power)).BeginInit();
            this.gbxRealTimeRecord.SuspendLayout();
            this.gbxFixedTimeRecord.SuspendLayout();
            this.gbxSettings.SuspendLayout();
            this.gbxrecord.SuspendLayout();
            this.NIRPanel.SuspendLayout();
            this.ECGPanel.SuspendLayout();
            this.SoundPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // recevide
            // 
            this.recevide.AutoSize = true;
            this.recevide.Location = new System.Drawing.Point(75, 22);
            this.recevide.Name = "recevide";
            this.recevide.Size = new System.Drawing.Size(65, 12);
            this.recevide.TabIndex = 2;
            this.recevide.Text = "連線狀態：";
            // 
            // Power
            // 
            this.Power.Image = global::LungSound.Properties.Resources.off;
            this.Power.Location = new System.Drawing.Point(13, 12);
            this.Power.Name = "Power";
            this.Power.Size = new System.Drawing.Size(56, 53);
            this.Power.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Power.TabIndex = 3;
            this.Power.TabStop = false;
            this.Power.Click += new System.EventHandler(this.Power_Click);
            this.Power.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Power_first);
            this.Power.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Power_second);
            // 
            // save_progressBar
            // 
            this.save_progressBar.Location = new System.Drawing.Point(23, 53);
            this.save_progressBar.Name = "save_progressBar";
            this.save_progressBar.Size = new System.Drawing.Size(176, 23);
            this.save_progressBar.Step = 1;
            this.save_progressBar.TabIndex = 4;
            // 
            // gbxRealTimeRecord
            // 
            this.gbxRealTimeRecord.Controls.Add(this.Unlimitrecord);
            this.gbxRealTimeRecord.Location = new System.Drawing.Point(10, 37);
            this.gbxRealTimeRecord.Name = "gbxRealTimeRecord";
            this.gbxRealTimeRecord.Size = new System.Drawing.Size(205, 49);
            this.gbxRealTimeRecord.TabIndex = 5;
            this.gbxRealTimeRecord.TabStop = false;
            this.gbxRealTimeRecord.Text = "即時record";
            // 
            // Unlimitrecord
            // 
            this.Unlimitrecord.ForeColor = System.Drawing.Color.Black;
            this.Unlimitrecord.Location = new System.Drawing.Point(57, 21);
            this.Unlimitrecord.Name = "Unlimitrecord";
            this.Unlimitrecord.Size = new System.Drawing.Size(97, 22);
            this.Unlimitrecord.TabIndex = 0;
            this.Unlimitrecord.Text = "START";
            this.Unlimitrecord.UseVisualStyleBackColor = true;
            this.Unlimitrecord.Click += new System.EventHandler(this.Unlimitrecord_Click);
            // 
            // gbxFixedTimeRecord
            // 
            this.gbxFixedTimeRecord.Controls.Add(this.Recoder);
            this.gbxFixedTimeRecord.Controls.Add(this.save_progressBar);
            this.gbxFixedTimeRecord.Location = new System.Drawing.Point(10, 92);
            this.gbxFixedTimeRecord.Name = "gbxFixedTimeRecord";
            this.gbxFixedTimeRecord.Size = new System.Drawing.Size(205, 100);
            this.gbxFixedTimeRecord.TabIndex = 6;
            this.gbxFixedTimeRecord.TabStop = false;
            this.gbxFixedTimeRecord.Text = "定時record";
            // 
            // Recoder
            // 
            this.Recoder.ForeColor = System.Drawing.Color.Black;
            this.Recoder.Location = new System.Drawing.Point(56, 21);
            this.Recoder.Name = "Recoder";
            this.Recoder.Size = new System.Drawing.Size(107, 26);
            this.Recoder.TabIndex = 1;
            this.Recoder.Text = "Recoder";
            this.Recoder.UseVisualStyleBackColor = true;
            this.Recoder.Click += new System.EventHandler(this.Recoder_Click);
            // 
            // gbxSettings
            // 
            this.gbxSettings.Controls.Add(this.ConnectRFID);
            this.gbxSettings.Controls.Add(this.cmbPortName);
            this.gbxSettings.Controls.Add(this.BTIDName);
            this.gbxSettings.Controls.Add(this.useBTID);
            this.gbxSettings.Controls.Add(this.tbxFileName);
            this.gbxSettings.Controls.Add(this.lblFileName);
            this.gbxSettings.ForeColor = System.Drawing.Color.Gray;
            this.gbxSettings.Location = new System.Drawing.Point(2, 89);
            this.gbxSettings.Name = "gbxSettings";
            this.gbxSettings.Size = new System.Drawing.Size(221, 151);
            this.gbxSettings.TabIndex = 7;
            this.gbxSettings.TabStop = false;
            this.gbxSettings.Text = "Setting";
            // 
            // ConnectRFID
            // 
            this.ConnectRFID.ForeColor = System.Drawing.Color.Black;
            this.ConnectRFID.Location = new System.Drawing.Point(6, 106);
            this.ConnectRFID.Name = "ConnectRFID";
            this.ConnectRFID.Size = new System.Drawing.Size(93, 23);
            this.ConnectRFID.TabIndex = 151;
            this.ConnectRFID.Text = "Connect RFID";
            this.ConnectRFID.UseVisualStyleBackColor = true;
            this.ConnectRFID.Click += new System.EventHandler(this.ConnectRFID_Click);
            // 
            // cmbPortName
            // 
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6"});
            this.cmbPortName.Location = new System.Drawing.Point(107, 108);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(93, 20);
            this.cmbPortName.TabIndex = 150;
            // 
            // BTIDName
            // 
            this.BTIDName.FormattingEnabled = true;
            this.BTIDName.Items.AddRange(new object[] {
            "0008F40278E8",
            "0008F401DD76"});
            this.BTIDName.Location = new System.Drawing.Point(107, 21);
            this.BTIDName.Name = "BTIDName";
            this.BTIDName.Size = new System.Drawing.Size(103, 20);
            this.BTIDName.TabIndex = 149;
            this.BTIDName.Text = "0008F40278E8";
            // 
            // useBTID
            // 
            this.useBTID.AutoSize = true;
            this.useBTID.Checked = true;
            this.useBTID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useBTID.ForeColor = System.Drawing.Color.Black;
            this.useBTID.Location = new System.Drawing.Point(6, 25);
            this.useBTID.Name = "useBTID";
            this.useBTID.Size = new System.Drawing.Size(93, 16);
            this.useBTID.TabIndex = 8;
            this.useBTID.Text = "BTID Name：";
            this.useBTID.UseVisualStyleBackColor = true;
            // 
            // tbxFileName
            // 
            this.tbxFileName.Location = new System.Drawing.Point(107, 63);
            this.tbxFileName.Name = "tbxFileName";
            this.tbxFileName.Size = new System.Drawing.Size(93, 22);
            this.tbxFileName.TabIndex = 3;
            this.tbxFileName.Text = "rawdata_";
            this.tbxFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.ForeColor = System.Drawing.Color.Black;
            this.lblFileName.Location = new System.Drawing.Point(21, 66);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(64, 12);
            this.lblFileName.TabIndex = 2;
            this.lblFileName.Text = "File Name：";
            // 
            // gbxrecord
            // 
            this.gbxrecord.Controls.Add(this.gbxRealTimeRecord);
            this.gbxrecord.Controls.Add(this.gbxFixedTimeRecord);
            this.gbxrecord.ForeColor = System.Drawing.Color.Gray;
            this.gbxrecord.Location = new System.Drawing.Point(2, 242);
            this.gbxrecord.Name = "gbxrecord";
            this.gbxrecord.Size = new System.Drawing.Size(221, 201);
            this.gbxrecord.TabIndex = 8;
            this.gbxrecord.TabStop = false;
            this.gbxrecord.Text = "record";
            // 
            // NIRPanel
            // 
            this.NIRPanel.BackColor = System.Drawing.Color.Black;
            this.NIRPanel.Controls.Add(this.label55);
            this.NIRPanel.Controls.Add(this.label54);
            this.NIRPanel.Controls.Add(this.label53);
            this.NIRPanel.Controls.Add(this.label52);
            this.NIRPanel.Controls.Add(this.label51);
            this.NIRPanel.Controls.Add(this.label50);
            this.NIRPanel.Controls.Add(this.label49);
            this.NIRPanel.Controls.Add(this.PPGlabel);
            this.NIRPanel.Location = new System.Drawing.Point(239, 93);
            this.NIRPanel.Name = "NIRPanel";
            this.NIRPanel.Size = new System.Drawing.Size(782, 171);
            this.NIRPanel.TabIndex = 17;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.BackColor = System.Drawing.Color.Black;
            this.label55.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label55.Location = new System.Drawing.Point(-3, -1);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(22, 13);
            this.label55.TabIndex = 114;
            this.label55.Text = "3.0";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.BackColor = System.Drawing.Color.Black;
            this.label54.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label54.Location = new System.Drawing.Point(-3, 149);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(22, 13);
            this.label54.TabIndex = 113;
            this.label54.Text = "0.0";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.BackColor = System.Drawing.Color.Black;
            this.label53.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label53.Location = new System.Drawing.Point(-3, 124);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(22, 13);
            this.label53.TabIndex = 112;
            this.label53.Text = "0.5";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.BackColor = System.Drawing.Color.Black;
            this.label52.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label52.Location = new System.Drawing.Point(-3, 99);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(22, 13);
            this.label52.TabIndex = 111;
            this.label52.Text = "1.0";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.BackColor = System.Drawing.Color.Black;
            this.label51.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label51.Location = new System.Drawing.Point(-3, 24);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(22, 13);
            this.label51.TabIndex = 110;
            this.label51.Text = "2.5";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.BackColor = System.Drawing.Color.Black;
            this.label50.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label50.Location = new System.Drawing.Point(-3, 49);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(22, 13);
            this.label50.TabIndex = 109;
            this.label50.Text = "2.0";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.BackColor = System.Drawing.Color.Black;
            this.label49.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label49.Location = new System.Drawing.Point(-3, 74);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(22, 13);
            this.label49.TabIndex = 108;
            this.label49.Text = "1.5";
            // 
            // PPGlabel
            // 
            this.PPGlabel.AutoSize = true;
            this.PPGlabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PPGlabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.PPGlabel.Location = new System.Drawing.Point(13, -4);
            this.PPGlabel.Name = "PPGlabel";
            this.PPGlabel.Size = new System.Drawing.Size(42, 23);
            this.PPGlabel.TabIndex = 48;
            this.PPGlabel.Text = "PPG";
            // 
            // ECGPanel
            // 
            this.ECGPanel.BackColor = System.Drawing.Color.Black;
            this.ECGPanel.Controls.Add(this.label1);
            this.ECGPanel.Controls.Add(this.label2);
            this.ECGPanel.Controls.Add(this.label3);
            this.ECGPanel.Controls.Add(this.label4);
            this.ECGPanel.Controls.Add(this.label5);
            this.ECGPanel.Controls.Add(this.label6);
            this.ECGPanel.Controls.Add(this.label7);
            this.ECGPanel.Controls.Add(this.ECGlabel);
            this.ECGPanel.Location = new System.Drawing.Point(239, 269);
            this.ECGPanel.Name = "ECGPanel";
            this.ECGPanel.Size = new System.Drawing.Size(782, 174);
            this.ECGPanel.TabIndex = 115;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(-3, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 114;
            this.label1.Text = "3.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(-3, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 113;
            this.label2.Text = "0.0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(-3, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 112;
            this.label3.Text = "0.5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(-3, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 111;
            this.label4.Text = "1.0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label5.Location = new System.Drawing.Point(-3, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 110;
            this.label5.Text = "2.5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label6.Location = new System.Drawing.Point(-3, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 109;
            this.label6.Text = "2.0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label7.Location = new System.Drawing.Point(-3, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 108;
            this.label7.Text = "1.5";
            // 
            // ECGlabel
            // 
            this.ECGlabel.AutoSize = true;
            this.ECGlabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ECGlabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.ECGlabel.Location = new System.Drawing.Point(13, -4);
            this.ECGlabel.Name = "ECGlabel";
            this.ECGlabel.Size = new System.Drawing.Size(41, 23);
            this.ECGlabel.TabIndex = 48;
            this.ECGlabel.Text = "ECG";
            // 
            // SoundPanel
            // 
            this.SoundPanel.BackColor = System.Drawing.Color.Black;
            this.SoundPanel.Controls.Add(this.label8);
            this.SoundPanel.Controls.Add(this.label9);
            this.SoundPanel.Controls.Add(this.label10);
            this.SoundPanel.Controls.Add(this.label11);
            this.SoundPanel.Controls.Add(this.label12);
            this.SoundPanel.Controls.Add(this.label13);
            this.SoundPanel.Controls.Add(this.label14);
            this.SoundPanel.Controls.Add(this.Soundlabel);
            this.SoundPanel.Location = new System.Drawing.Point(239, 450);
            this.SoundPanel.Name = "SoundPanel";
            this.SoundPanel.Size = new System.Drawing.Size(782, 171);
            this.SoundPanel.TabIndex = 116;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label8.Location = new System.Drawing.Point(-3, -1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 13);
            this.label8.TabIndex = 114;
            this.label8.Text = "3.0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Location = new System.Drawing.Point(-3, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 13);
            this.label9.TabIndex = 113;
            this.label9.Text = "0.0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label10.Location = new System.Drawing.Point(-3, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 13);
            this.label10.TabIndex = 112;
            this.label10.Text = "0.5";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label11.Location = new System.Drawing.Point(-3, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 13);
            this.label11.TabIndex = 111;
            this.label11.Text = "1.0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label12.Location = new System.Drawing.Point(-3, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 13);
            this.label12.TabIndex = 110;
            this.label12.Text = "2.5";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label13.Location = new System.Drawing.Point(-3, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 13);
            this.label13.TabIndex = 109;
            this.label13.Text = "2.0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Black;
            this.label14.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label14.Location = new System.Drawing.Point(-3, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 13);
            this.label14.TabIndex = 108;
            this.label14.Text = "1.5";
            // 
            // Soundlabel
            // 
            this.Soundlabel.AutoSize = true;
            this.Soundlabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Soundlabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Soundlabel.Location = new System.Drawing.Point(13, -4);
            this.Soundlabel.Name = "Soundlabel";
            this.Soundlabel.Size = new System.Drawing.Size(54, 23);
            this.Soundlabel.TabIndex = 48;
            this.Soundlabel.Text = "LUNG";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(709, 63);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(51, 19);
            this.label20.TabIndex = 141;
            this.label20.Text = "AvgBR";
            this.label20.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.Control;
            this.label19.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(708, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 19);
            this.label19.TabIndex = 140;
            this.label19.Text = "MinBR";
            this.label19.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(705, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 19);
            this.label18.TabIndex = 139;
            this.label18.Text = "MaxBR";
            this.label18.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.Control;
            this.label17.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(516, 63);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 19);
            this.label17.TabIndex = 138;
            this.label17.Text = "AvgHR";
            this.label17.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(516, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 19);
            this.label16.TabIndex = 137;
            this.label16.Text = "MinHR";
            this.label16.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.Control;
            this.label15.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(512, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 19);
            this.label15.TabIndex = 136;
            this.label15.Text = "MaxHR";
            this.label15.Visible = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.SystemColors.Control;
            this.label21.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(303, 63);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 19);
            this.label21.TabIndex = 135;
            this.label21.Text = "AvgSPO2";
            this.label21.Visible = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.SystemColors.Control;
            this.label22.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(302, 39);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(68, 19);
            this.label22.TabIndex = 134;
            this.label22.Text = "MinSPO2";
            this.label22.Visible = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.SystemColors.Control;
            this.label23.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(300, 15);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(71, 19);
            this.label23.TabIndex = 133;
            this.label23.Text = "MaxSPO2";
            this.label23.Visible = false;
            // 
            // avgSPO2
            // 
            this.avgSPO2.AutoSize = true;
            this.avgSPO2.BackColor = System.Drawing.SystemColors.WindowText;
            this.avgSPO2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.avgSPO2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgSPO2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.avgSPO2.Location = new System.Drawing.Point(371, 61);
            this.avgSPO2.Name = "avgSPO2";
            this.avgSPO2.Size = new System.Drawing.Size(36, 25);
            this.avgSPO2.TabIndex = 132;
            this.avgSPO2.Text = "      ";
            this.avgSPO2.Visible = false;
            // 
            // minSPO2
            // 
            this.minSPO2.AutoSize = true;
            this.minSPO2.BackColor = System.Drawing.SystemColors.WindowText;
            this.minSPO2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.minSPO2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minSPO2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.minSPO2.Location = new System.Drawing.Point(371, 36);
            this.minSPO2.Name = "minSPO2";
            this.minSPO2.Size = new System.Drawing.Size(36, 25);
            this.minSPO2.TabIndex = 131;
            this.minSPO2.Text = "      ";
            this.minSPO2.Visible = false;
            // 
            // maxSPO2
            // 
            this.maxSPO2.AutoSize = true;
            this.maxSPO2.BackColor = System.Drawing.SystemColors.WindowText;
            this.maxSPO2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.maxSPO2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxSPO2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.maxSPO2.Location = new System.Drawing.Point(371, 11);
            this.maxSPO2.Name = "maxSPO2";
            this.maxSPO2.Size = new System.Drawing.Size(36, 25);
            this.maxSPO2.TabIndex = 130;
            this.maxSPO2.Text = "      ";
            this.maxSPO2.Visible = false;
            // 
            // avgBR
            // 
            this.avgBR.AutoSize = true;
            this.avgBR.BackColor = System.Drawing.SystemColors.WindowText;
            this.avgBR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.avgBR.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgBR.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.avgBR.Location = new System.Drawing.Point(760, 61);
            this.avgBR.Name = "avgBR";
            this.avgBR.Size = new System.Drawing.Size(36, 25);
            this.avgBR.TabIndex = 129;
            this.avgBR.Text = "      ";
            this.avgBR.Visible = false;
            // 
            // minBR
            // 
            this.minBR.AutoSize = true;
            this.minBR.BackColor = System.Drawing.SystemColors.WindowText;
            this.minBR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.minBR.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minBR.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.minBR.Location = new System.Drawing.Point(760, 36);
            this.minBR.Name = "minBR";
            this.minBR.Size = new System.Drawing.Size(36, 25);
            this.minBR.TabIndex = 128;
            this.minBR.Text = "      ";
            this.minBR.Visible = false;
            // 
            // maxBR
            // 
            this.maxBR.AutoSize = true;
            this.maxBR.BackColor = System.Drawing.SystemColors.WindowText;
            this.maxBR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.maxBR.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxBR.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.maxBR.Location = new System.Drawing.Point(760, 11);
            this.maxBR.Name = "maxBR";
            this.maxBR.Size = new System.Drawing.Size(36, 25);
            this.maxBR.TabIndex = 127;
            this.maxBR.Text = "      ";
            this.maxBR.Visible = false;
            // 
            // avgHR
            // 
            this.avgHR.AutoSize = true;
            this.avgHR.BackColor = System.Drawing.SystemColors.WindowText;
            this.avgHR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.avgHR.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgHR.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.avgHR.Location = new System.Drawing.Point(569, 61);
            this.avgHR.Name = "avgHR";
            this.avgHR.Size = new System.Drawing.Size(36, 25);
            this.avgHR.TabIndex = 126;
            this.avgHR.Text = "      ";
            this.avgHR.Visible = false;
            // 
            // minHR
            // 
            this.minHR.AutoSize = true;
            this.minHR.BackColor = System.Drawing.SystemColors.WindowText;
            this.minHR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.minHR.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minHR.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.minHR.Location = new System.Drawing.Point(569, 36);
            this.minHR.Name = "minHR";
            this.minHR.Size = new System.Drawing.Size(36, 25);
            this.minHR.TabIndex = 125;
            this.minHR.Text = "      ";
            this.minHR.Visible = false;
            // 
            // maxHR
            // 
            this.maxHR.AutoSize = true;
            this.maxHR.BackColor = System.Drawing.SystemColors.WindowText;
            this.maxHR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.maxHR.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxHR.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.maxHR.Location = new System.Drawing.Point(569, 11);
            this.maxHR.Name = "maxHR";
            this.maxHR.Size = new System.Drawing.Size(36, 25);
            this.maxHR.TabIndex = 124;
            this.maxHR.Text = "      ";
            this.maxHR.Visible = false;
            // 
            // lab_RR
            // 
            this.lab_RR.AutoSize = true;
            this.lab_RR.BackColor = System.Drawing.SystemColors.WindowText;
            this.lab_RR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lab_RR.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_RR.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lab_RR.Location = new System.Drawing.Point(645, 38);
            this.lab_RR.Name = "lab_RR";
            this.lab_RR.Size = new System.Drawing.Size(54, 47);
            this.lab_RR.TabIndex = 123;
            this.lab_RR.Text = "    ";
            // 
            // lab_HR
            // 
            this.lab_HR.AutoSize = true;
            this.lab_HR.BackColor = System.Drawing.SystemColors.WindowText;
            this.lab_HR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lab_HR.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_HR.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lab_HR.Location = new System.Drawing.Point(437, 34);
            this.lab_HR.Name = "lab_HR";
            this.lab_HR.Size = new System.Drawing.Size(70, 47);
            this.lab_HR.TabIndex = 122;
            this.lab_HR.Text = "      ";
            // 
            // BreathRatelabel
            // 
            this.BreathRatelabel.AutoSize = true;
            this.BreathRatelabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BreathRatelabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BreathRatelabel.Location = new System.Drawing.Point(418, 10);
            this.BreathRatelabel.Name = "BreathRatelabel";
            this.BreathRatelabel.Size = new System.Drawing.Size(36, 26);
            this.BreathRatelabel.TabIndex = 121;
            this.BreathRatelabel.Text = "BR";
            // 
            // HeartRatelabel
            // 
            this.HeartRatelabel.AutoSize = true;
            this.HeartRatelabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.HeartRatelabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeartRatelabel.Location = new System.Drawing.Point(217, 10);
            this.HeartRatelabel.Name = "HeartRatelabel";
            this.HeartRatelabel.Size = new System.Drawing.Size(37, 26);
            this.HeartRatelabel.TabIndex = 120;
            this.HeartRatelabel.Text = "HR";
            // 
            // lab_SpO2
            // 
            this.lab_SpO2.AutoSize = true;
            this.lab_SpO2.BackColor = System.Drawing.SystemColors.WindowText;
            this.lab_SpO2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lab_SpO2.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_SpO2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lab_SpO2.Location = new System.Drawing.Point(6, 35);
            this.lab_SpO2.Name = "lab_SpO2";
            this.lab_SpO2.Size = new System.Drawing.Size(54, 47);
            this.lab_SpO2.TabIndex = 118;
            this.lab_SpO2.Text = "    ";
            // 
            // SpO2Label
            // 
            this.SpO2Label.AutoSize = true;
            this.SpO2Label.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SpO2Label.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpO2Label.Location = new System.Drawing.Point(6, 10);
            this.SpO2Label.Name = "SpO2Label";
            this.SpO2Label.Size = new System.Drawing.Size(58, 26);
            this.SpO2Label.TabIndex = 119;
            this.SpO2Label.Text = "SPO2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BreathRatelabel);
            this.groupBox2.Controls.Add(this.HeartRatelabel);
            this.groupBox2.Controls.Add(this.SpO2Label);
            this.groupBox2.Controls.Add(this.lab_SpO2);
            this.groupBox2.Location = new System.Drawing.Point(232, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 88);
            this.groupBox2.TabIndex = 117;
            this.groupBox2.TabStop = false;
            // 
            // MWT6
            // 
            this.MWT6.BackColor = System.Drawing.SystemColors.WindowText;
            this.MWT6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MWT6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.MWT6.Location = new System.Drawing.Point(8, 461);
            this.MWT6.Multiline = true;
            this.MWT6.Name = "MWT6";
            this.MWT6.Size = new System.Drawing.Size(222, 160);
            this.MWT6.TabIndex = 142;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(807, 65);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(124, 26);
            this.label29.TabIndex = 148;
            this.label29.Text = "Avg. acceleration";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Avgacceleration
            // 
            this.Avgacceleration.BackColor = System.Drawing.SystemColors.WindowText;
            this.Avgacceleration.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Avgacceleration.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Avgacceleration.Location = new System.Drawing.Point(930, 65);
            this.Avgacceleration.Name = "Avgacceleration";
            this.Avgacceleration.Size = new System.Drawing.Size(93, 27);
            this.Avgacceleration.TabIndex = 147;
            // 
            // Avgspeed
            // 
            this.Avgspeed.BackColor = System.Drawing.SystemColors.WindowText;
            this.Avgspeed.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Avgspeed.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Avgspeed.Location = new System.Drawing.Point(930, 37);
            this.Avgspeed.Name = "Avgspeed";
            this.Avgspeed.Size = new System.Drawing.Size(93, 27);
            this.Avgspeed.TabIndex = 146;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(839, 39);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(84, 26);
            this.label28.TabIndex = 145;
            this.label28.Text = "Avg. speed";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Distance
            // 
            this.Distance.BackColor = System.Drawing.SystemColors.WindowText;
            this.Distance.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Distance.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Distance.Location = new System.Drawing.Point(930, 8);
            this.Distance.Name = "Distance";
            this.Distance.Size = new System.Drawing.Size(93, 27);
            this.Distance.TabIndex = 144;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(839, 8);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(75, 26);
            this.label27.TabIndex = 143;
            this.label27.Text = "Distance";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MWT
            // 
            this.MWT.Location = new System.Drawing.Point(2, 446);
            this.MWT.Name = "MWT";
            this.MWT.Size = new System.Drawing.Size(231, 184);
            this.MWT.TabIndex = 115;
            this.MWT.TabStop = false;
            this.MWT.Text = "6MWT";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(195, 9);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(17, 12);
            this.label24.TabIndex = 149;
            this.label24.Text = "：";
            this.label24.Visible = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(123, 49);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(17, 12);
            this.label25.TabIndex = 150;
            this.label25.Text = "：";
            this.label25.Visible = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(123, 74);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(17, 12);
            this.label26.TabIndex = 151;
            this.label26.Text = "：";
            this.label26.Visible = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(146, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(17, 12);
            this.label30.TabIndex = 152;
            this.label30.Text = "：";
            this.label30.Visible = false;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(146, 24);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(17, 12);
            this.label31.TabIndex = 153;
            this.label31.Text = "：";
            this.label31.Visible = false;
            // 
            // Mutisystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 627);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.Avgacceleration);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.Avgspeed);
            this.Controls.Add(this.avgSPO2);
            this.Controls.Add(this.minSPO2);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.maxSPO2);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.Distance);
            this.Controls.Add(this.avgBR);
            this.Controls.Add(this.minBR);
            this.Controls.Add(this.maxBR);
            this.Controls.Add(this.avgHR);
            this.Controls.Add(this.minHR);
            this.Controls.Add(this.maxHR);
            this.Controls.Add(this.lab_RR);
            this.Controls.Add(this.lab_HR);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SoundPanel);
            this.Controls.Add(this.NIRPanel);
            this.Controls.Add(this.gbxrecord);
            this.Controls.Add(this.recevide);
            this.Controls.Add(this.gbxSettings);
            this.Controls.Add(this.Power);
            this.Controls.Add(this.ECGPanel);
            this.Controls.Add(this.MWT6);
            this.Controls.Add(this.MWT);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mutisystem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mutisystem";
            this.Load += new System.EventHandler(this.LungSound_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Power)).EndInit();
            this.gbxRealTimeRecord.ResumeLayout(false);
            this.gbxFixedTimeRecord.ResumeLayout(false);
            this.gbxSettings.ResumeLayout(false);
            this.gbxSettings.PerformLayout();
            this.gbxrecord.ResumeLayout(false);
            this.NIRPanel.ResumeLayout(false);
            this.NIRPanel.PerformLayout();
            this.ECGPanel.ResumeLayout(false);
            this.ECGPanel.PerformLayout();
            this.SoundPanel.ResumeLayout(false);
            this.SoundPanel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label recevide;
        private System.Windows.Forms.PictureBox Power;
        private System.Windows.Forms.ProgressBar save_progressBar;
        private System.Windows.Forms.GroupBox gbxRealTimeRecord;
        private System.Windows.Forms.Button Unlimitrecord;
        private System.Windows.Forms.GroupBox gbxFixedTimeRecord;
        private System.Windows.Forms.Button Recoder;
        private System.Windows.Forms.GroupBox gbxSettings;
        private System.Windows.Forms.TextBox tbxFileName;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.CheckBox useBTID;
        private System.Windows.Forms.GroupBox gbxrecord;
        private System.Windows.Forms.Panel NIRPanel;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label PPGlabel;
        private System.Windows.Forms.Panel ECGPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label ECGlabel;
        private System.Windows.Forms.Panel SoundPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label Soundlabel;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label avgSPO2;
        private System.Windows.Forms.Label minSPO2;
        private System.Windows.Forms.Label maxSPO2;
        private System.Windows.Forms.Label avgBR;
        private System.Windows.Forms.Label minBR;
        private System.Windows.Forms.Label maxBR;
        private System.Windows.Forms.Label avgHR;
        private System.Windows.Forms.Label minHR;
        private System.Windows.Forms.Label maxHR;
        private System.Windows.Forms.Label lab_RR;
        private System.Windows.Forms.Label lab_HR;
        private System.Windows.Forms.Label BreathRatelabel;
        private System.Windows.Forms.Label HeartRatelabel;
        private System.Windows.Forms.Label lab_SpO2;
        private System.Windows.Forms.Label SpO2Label;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox MWT6;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox Avgacceleration;
        private System.Windows.Forms.TextBox Avgspeed;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox Distance;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox MWT;
        private System.Windows.Forms.ComboBox BTIDName;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.Button ConnectRFID;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
    }
}

