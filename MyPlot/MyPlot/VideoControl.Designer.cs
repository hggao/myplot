
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
            this.buttonPlay = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.checkBoxSpeaker = new System.Windows.Forms.CheckBox();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.trackBarPosition = new System.Windows.Forms.TrackBar();
            this.buttonFullScreen = new System.Windows.Forms.Button();
            this.buttonSpeed = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.labelPosition = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.timerVCPUpdate = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(14, 42);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(32, 32);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = ">";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(14, 42);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(32, 32);
            this.buttonPause.TabIndex = 1;
            this.buttonPause.Text = "II";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(46, 42);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(32, 32);
            this.buttonNext.TabIndex = 2;
            this.buttonNext.Text = ">I";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // checkBoxSpeaker
            // 
            this.checkBoxSpeaker.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxSpeaker.Location = new System.Drawing.Point(78, 42);
            this.checkBoxSpeaker.Name = "checkBoxSpeaker";
            this.checkBoxSpeaker.Size = new System.Drawing.Size(32, 32);
            this.checkBoxSpeaker.TabIndex = 3;
            this.checkBoxSpeaker.Text = ":<";
            this.checkBoxSpeaker.UseVisualStyleBackColor = true;
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.AutoSize = false;
            this.trackBarVolume.Location = new System.Drawing.Point(110, 48);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(100, 22);
            this.trackBarVolume.TabIndex = 4;
            this.trackBarVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            this.trackBarVolume.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarPosition_MouseDown);
            this.trackBarVolume.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarPosition_MouseUp);
            // 
            // trackBarPosition
            // 
            this.trackBarPosition.AutoSize = false;
            this.trackBarPosition.Location = new System.Drawing.Point(12, 12);
            this.trackBarPosition.Maximum = 5000;
            this.trackBarPosition.Name = "trackBarPosition";
            this.trackBarPosition.Size = new System.Drawing.Size(1000, 22);
            this.trackBarPosition.TabIndex = 5;
            this.trackBarPosition.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarPosition.Scroll += new System.EventHandler(this.trackBarPosition_Scroll);
            this.trackBarPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarPosition_MouseDown);
            this.trackBarPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarPosition_MouseUp);
            // 
            // buttonFullScreen
            // 
            this.buttonFullScreen.Location = new System.Drawing.Point(970, 42);
            this.buttonFullScreen.Name = "buttonFullScreen";
            this.buttonFullScreen.Size = new System.Drawing.Size(32, 32);
            this.buttonFullScreen.TabIndex = 7;
            this.buttonFullScreen.Text = "F";
            this.buttonFullScreen.UseVisualStyleBackColor = true;
            this.buttonFullScreen.Click += new System.EventHandler(this.buttonFullScreen_Click);
            // 
            // buttonSpeed
            // 
            this.buttonSpeed.Location = new System.Drawing.Point(934, 42);
            this.buttonSpeed.Name = "buttonSpeed";
            this.buttonSpeed.Size = new System.Drawing.Size(32, 32);
            this.buttonSpeed.TabIndex = 6;
            this.buttonSpeed.Text = "S";
            this.buttonSpeed.UseVisualStyleBackColor = true;
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(896, 42);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(32, 32);
            this.buttonSettings.TabIndex = 8;
            this.buttonSettings.Text = "*";
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
            this.labelTitle.Size = new System.Drawing.Size(556, 22);
            this.labelTitle.TabIndex = 10;
            this.labelTitle.Text = "Title";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerVCPUpdate
            // 
            this.timerVCPUpdate.Interval = 50;
            this.timerVCPUpdate.Tick += new System.EventHandler(this.timerVCPUpdate_Tick);
            // 
            // VideoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1024, 96);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonFullScreen);
            this.Controls.Add(this.buttonSpeed);
            this.Controls.Add(this.trackBarPosition);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.checkBoxSpeaker);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonPlay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VideoControl";
            this.Opacity = 0.5D;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.VideoControl_Load);
            this.VisibleChanged += new System.EventHandler(this.VideoControl_VisibleChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VideoControl_Paint);
            this.MouseEnter += new System.EventHandler(this.VideoControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.VideoControl_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPosition)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.CheckBox checkBoxSpeaker;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.TrackBar trackBarPosition;
        private System.Windows.Forms.Button buttonFullScreen;
        private System.Windows.Forms.Button buttonSpeed;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Timer timerVCPUpdate;
    }
}