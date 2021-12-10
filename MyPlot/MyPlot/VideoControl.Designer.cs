
namespace MyPlot
{
    partial class VideoControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoControl));
            this.buttonPlayPause = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.trackBarVideoVol = new System.Windows.Forms.TrackBar();
            this.trackBarPosition = new System.Windows.Forms.TrackBar();
            this.buttonFullScreen = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.labelPosition = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.timerVCPUpdate = new System.Windows.Forms.Timer(this.components);
            this.comboBoxSpeed = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxSpeaker = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVideoVol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPlayPause
            // 
            this.buttonPlayPause.FlatAppearance.BorderSize = 0;
            this.buttonPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayPause.Image = ((System.Drawing.Image)(resources.GetObject("buttonPlayPause.Image")));
            this.buttonPlayPause.Location = new System.Drawing.Point(14, 42);
            this.buttonPlayPause.Name = "buttonPlayPause";
            this.buttonPlayPause.Size = new System.Drawing.Size(32, 32);
            this.buttonPlayPause.TabIndex = 0;
            this.buttonPlayPause.TabStop = false;
            this.buttonPlayPause.UseVisualStyleBackColor = true;
            this.buttonPlayPause.Click += new System.EventHandler(this.buttonPlayPause_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.FlatAppearance.BorderSize = 0;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Image = ((System.Drawing.Image)(resources.GetObject("buttonNext.Image")));
            this.buttonNext.Location = new System.Drawing.Point(46, 42);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(32, 32);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.TabStop = false;
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // trackBarVideoVol
            // 
            this.trackBarVideoVol.AutoSize = false;
            this.trackBarVideoVol.Location = new System.Drawing.Point(110, 48);
            this.trackBarVideoVol.Maximum = 100;
            this.trackBarVideoVol.Name = "trackBarVideoVol";
            this.trackBarVideoVol.Size = new System.Drawing.Size(100, 22);
            this.trackBarVideoVol.TabIndex = 4;
            this.trackBarVideoVol.TabStop = false;
            this.trackBarVideoVol.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarVideoVol.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            this.trackBarVideoVol.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarPosition_MouseDown);
            this.trackBarVideoVol.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarPosition_MouseUp);
            // 
            // trackBarPosition
            // 
            this.trackBarPosition.AutoSize = false;
            this.trackBarPosition.Location = new System.Drawing.Point(12, 12);
            this.trackBarPosition.Maximum = 5000;
            this.trackBarPosition.Name = "trackBarPosition";
            this.trackBarPosition.Size = new System.Drawing.Size(1000, 22);
            this.trackBarPosition.TabIndex = 5;
            this.trackBarPosition.TabStop = false;
            this.trackBarPosition.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarPosition.Scroll += new System.EventHandler(this.trackBarPosition_Scroll);
            this.trackBarPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarPosition_MouseDown);
            this.trackBarPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarPosition_MouseUp);
            // 
            // buttonFullScreen
            // 
            this.buttonFullScreen.FlatAppearance.BorderSize = 0;
            this.buttonFullScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFullScreen.Image = ((System.Drawing.Image)(resources.GetObject("buttonFullScreen.Image")));
            this.buttonFullScreen.Location = new System.Drawing.Point(970, 42);
            this.buttonFullScreen.Name = "buttonFullScreen";
            this.buttonFullScreen.Size = new System.Drawing.Size(32, 32);
            this.buttonFullScreen.TabIndex = 7;
            this.buttonFullScreen.TabStop = false;
            this.buttonFullScreen.UseVisualStyleBackColor = true;
            this.buttonFullScreen.Click += new System.EventHandler(this.buttonFullScreen_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Image = ((System.Drawing.Image)(resources.GetObject("buttonSettings.Image")));
            this.buttonSettings.Location = new System.Drawing.Point(880, 42);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(32, 32);
            this.buttonSettings.TabIndex = 8;
            this.buttonSettings.TabStop = false;
            this.buttonSettings.UseVisualStyleBackColor = true;
            // 
            // labelPosition
            // 
            this.labelPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosition.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelPosition.Location = new System.Drawing.Point(216, 48);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(112, 22);
            this.labelPosition.TabIndex = 9;
            this.labelPosition.Text = "label1";
            this.labelPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelTitle.Location = new System.Drawing.Point(334, 48);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(391, 22);
            this.labelTitle.TabIndex = 10;
            this.labelTitle.Text = "Title";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerVCPUpdate
            // 
            this.timerVCPUpdate.Interval = 50;
            this.timerVCPUpdate.Tick += new System.EventHandler(this.timerVCPUpdate_Tick);
            // 
            // comboBoxSpeed
            // 
            this.comboBoxSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBoxSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSpeed.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.comboBoxSpeed.FormattingEnabled = true;
            this.comboBoxSpeed.Items.AddRange(new object[] {
            "0.25",
            "0.50",
            "0.75",
            "1.00",
            "1.25",
            "1.50",
            "1.75",
            "2.00"});
            this.comboBoxSpeed.Location = new System.Drawing.Point(919, 48);
            this.comboBoxSpeed.Name = "comboBoxSpeed";
            this.comboBoxSpeed.Size = new System.Drawing.Size(45, 21);
            this.comboBoxSpeed.TabIndex = 11;
            this.comboBoxSpeed.TabStop = false;
            this.comboBoxSpeed.SelectedIndexChanged += new System.EventHandler(this.comboBoxSpeed_SelectedIndexChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(1023, 95);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(1, 1);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.TabStop = false;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBoxSpeaker
            // 
            this.checkBoxSpeaker.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxSpeaker.FlatAppearance.BorderSize = 0;
            this.checkBoxSpeaker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxSpeaker.Image = ((System.Drawing.Image)(resources.GetObject("checkBoxSpeaker.Image")));
            this.checkBoxSpeaker.Location = new System.Drawing.Point(78, 42);
            this.checkBoxSpeaker.Name = "checkBoxSpeaker";
            this.checkBoxSpeaker.Size = new System.Drawing.Size(32, 32);
            this.checkBoxSpeaker.TabIndex = 3;
            this.checkBoxSpeaker.TabStop = false;
            this.checkBoxSpeaker.UseVisualStyleBackColor = true;
            this.checkBoxSpeaker.CheckedChanged += new System.EventHandler(this.checkBoxSpeaker_CheckedChanged);
            // 
            // VideoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(1024, 96);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.comboBoxSpeed);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonFullScreen);
            this.Controls.Add(this.trackBarPosition);
            this.Controls.Add(this.trackBarVideoVol);
            this.Controls.Add(this.checkBoxSpeaker);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPlayPause);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VideoControl";
            this.Opacity = 0.5D;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.VideoControl_Load);
            this.VisibleChanged += new System.EventHandler(this.VideoControl_VisibleChanged);
            this.MouseEnter += new System.EventHandler(this.VideoControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.VideoControl_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVideoVol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPlayPause;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.CheckBox checkBoxSpeaker;
        private System.Windows.Forms.TrackBar trackBarVideoVol;
        private System.Windows.Forms.TrackBar trackBarPosition;
        private System.Windows.Forms.Button buttonFullScreen;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Timer timerVCPUpdate;
        private System.Windows.Forms.ComboBox comboBoxSpeed;
        private System.Windows.Forms.Button buttonCancel;
    }
}