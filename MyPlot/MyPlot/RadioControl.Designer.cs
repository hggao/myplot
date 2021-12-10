
namespace MyPlot
{
    partial class RadioControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RadioControl));
            this.labelTitle = new System.Windows.Forms.Label();
            this.trackBarRadioVol = new System.Windows.Forms.TrackBar();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBoxSpeaker = new System.Windows.Forms.CheckBox();
            this.buttonPlayPause = new System.Windows.Forms.Button();
            this.timerRadioControl = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRadioVol)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelTitle.Location = new System.Drawing.Point(12, 38);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(376, 18);
            this.labelTitle.TabIndex = 31;
            this.labelTitle.Text = "Title";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // trackBarRadioVol
            // 
            this.trackBarRadioVol.AutoSize = false;
            this.trackBarRadioVol.Location = new System.Drawing.Point(87, 11);
            this.trackBarRadioVol.Maximum = 100;
            this.trackBarRadioVol.Name = "trackBarRadioVol";
            this.trackBarRadioVol.Size = new System.Drawing.Size(101, 18);
            this.trackBarRadioVol.TabIndex = 29;
            this.trackBarRadioVol.TabStop = false;
            this.trackBarRadioVol.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarRadioVol.Scroll += new System.EventHandler(this.trackBarRadioVol_Scroll);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(398, 1);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(1, 1);
            this.buttonCancel.TabIndex = 32;
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
            this.checkBoxSpeaker.Location = new System.Drawing.Point(57, 6);
            this.checkBoxSpeaker.Name = "checkBoxSpeaker";
            this.checkBoxSpeaker.Size = new System.Drawing.Size(24, 24);
            this.checkBoxSpeaker.TabIndex = 28;
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
            this.buttonPlayPause.Location = new System.Drawing.Point(15, 6);
            this.buttonPlayPause.Name = "buttonPlayPause";
            this.buttonPlayPause.Size = new System.Drawing.Size(24, 24);
            this.buttonPlayPause.TabIndex = 26;
            this.buttonPlayPause.TabStop = false;
            this.buttonPlayPause.UseVisualStyleBackColor = true;
            this.buttonPlayPause.Click += new System.EventHandler(this.buttonPlayPause_Click);
            // 
            // timerRadioControl
            // 
            this.timerRadioControl.Tick += new System.EventHandler(this.timerRadioControl_Tick);
            // 
            // RadioControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(400, 64);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.trackBarRadioVol);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.checkBoxSpeaker);
            this.Controls.Add(this.buttonPlayPause);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RadioControl";
            this.Opacity = 0.5D;
            this.Text = "RadioControl";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RadioControl_Load);
            this.VisibleChanged += new System.EventHandler(this.RadioControl_VisibleChanged);
            this.MouseEnter += new System.EventHandler(this.RadioControl_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.RadioControl_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRadioVol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TrackBar trackBarRadioVol;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxSpeaker;
        private System.Windows.Forms.Button buttonPlayPause;
        private System.Windows.Forms.Timer timerRadioControl;
    }
}