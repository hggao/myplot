
namespace MyPlot
{
    partial class AudioControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AudioControl));
            this.trackBarAudioPos = new System.Windows.Forms.TrackBar();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.trackBarAudioVol = new System.Windows.Forms.TrackBar();
            this.timerACPUpdate = new System.Windows.Forms.Timer(this.components);
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.checkBoxSpeaker = new System.Windows.Forms.CheckBox();
            this.buttonPlayPause = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAudioPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAudioVol)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarAudioPos
            // 
            this.trackBarAudioPos.AutoSize = false;
            this.trackBarAudioPos.Location = new System.Drawing.Point(12, 11);
            this.trackBarAudioPos.Maximum = 1000;
            this.trackBarAudioPos.Name = "trackBarAudioPos";
            this.trackBarAudioPos.Size = new System.Drawing.Size(576, 18);
            this.trackBarAudioPos.TabIndex = 6;
            this.trackBarAudioPos.TabStop = false;
            this.trackBarAudioPos.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarAudioPos.Scroll += new System.EventHandler(this.trackBarAudioPos_Scroll);
            this.trackBarAudioPos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarAudioPos_MouseDown);
            this.trackBarAudioPos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarAudioPos_MouseUp);
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelTitle.Location = new System.Drawing.Point(294, 36);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(294, 18);
            this.labelTitle.TabIndex = 22;
            this.labelTitle.Text = "Title";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPosition
            // 
            this.labelPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosition.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelPosition.Location = new System.Drawing.Point(207, 36);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(81, 18);
            this.labelPosition.TabIndex = 21;
            this.labelPosition.Text = "label1";
            this.labelPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // trackBarAudioVol
            // 
            this.trackBarAudioVol.AutoSize = false;
            this.trackBarAudioVol.Location = new System.Drawing.Point(104, 38);
            this.trackBarAudioVol.Maximum = 100;
            this.trackBarAudioVol.Name = "trackBarAudioVol";
            this.trackBarAudioVol.Size = new System.Drawing.Size(100, 18);
            this.trackBarAudioVol.TabIndex = 17;
            this.trackBarAudioVol.TabStop = false;
            this.trackBarAudioVol.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarAudioVol.Scroll += new System.EventHandler(this.trackBarAudioVol_Scroll);
            this.trackBarAudioVol.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarAudioPos_MouseDown);
            this.trackBarAudioVol.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarAudioPos_MouseUp);
            // 
            // timerACPUpdate
            // 
            this.timerACPUpdate.Interval = 50;
            this.timerACPUpdate.Tick += new System.EventHandler(this.timerACPUpdate_Tick);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(598, 61);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(1, 1);
            this.buttonCancel.TabIndex = 24;
            this.buttonCancel.TabStop = false;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.FlatAppearance.BorderSize = 0;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNext.Image = ((System.Drawing.Image)(resources.GetObject("buttonNext.Image")));
            this.buttonNext.Location = new System.Drawing.Point(44, 34);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(24, 24);
            this.buttonNext.TabIndex = 15;
            this.buttonNext.TabStop = false;
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // checkBoxSpeaker
            // 
            this.checkBoxSpeaker.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxSpeaker.FlatAppearance.BorderSize = 0;
            this.checkBoxSpeaker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxSpeaker.Image = ((System.Drawing.Image)(resources.GetObject("checkBoxSpeaker.Image")));
            this.checkBoxSpeaker.Location = new System.Drawing.Point(74, 33);
            this.checkBoxSpeaker.Name = "checkBoxSpeaker";
            this.checkBoxSpeaker.Size = new System.Drawing.Size(24, 24);
            this.checkBoxSpeaker.TabIndex = 16;
            this.checkBoxSpeaker.TabStop = false;
            this.checkBoxSpeaker.UseVisualStyleBackColor = true;
            this.checkBoxSpeaker.CheckedChanged += new System.EventHandler(this.checkBoxSpeaker_CheckedChanged);
            // 
            // buttonPlayPause
            // 
            this.buttonPlayPause.FlatAppearance.BorderSize = 0;
            this.buttonPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayPause.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonPlayPause.Image = ((System.Drawing.Image)(resources.GetObject("buttonPlayPause.Image")));
            this.buttonPlayPause.Location = new System.Drawing.Point(14, 34);
            this.buttonPlayPause.Name = "buttonPlayPause";
            this.buttonPlayPause.Size = new System.Drawing.Size(24, 24);
            this.buttonPlayPause.TabIndex = 14;
            this.buttonPlayPause.TabStop = false;
            this.buttonPlayPause.UseVisualStyleBackColor = true;
            this.buttonPlayPause.Click += new System.EventHandler(this.buttonPlayPause_Click);
            // 
            // AudioControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(600, 64);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.trackBarAudioVol);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.checkBoxSpeaker);
            this.Controls.Add(this.buttonPlayPause);
            this.Controls.Add(this.trackBarAudioPos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AudioControl";
            this.Opacity = 0.5D;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AudioControl_Load);
            this.VisibleChanged += new System.EventHandler(this.AudioControl_VisibleChanged);
            this.MouseEnter += new System.EventHandler(this.AudioControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.AudioControl_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAudioPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAudioVol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarAudioPos;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.TrackBar trackBarAudioVol;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Timer timerACPUpdate;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxSpeaker;
        private System.Windows.Forms.Button buttonPlayPause;
    }
}