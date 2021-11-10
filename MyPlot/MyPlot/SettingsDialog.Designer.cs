
namespace MyPlot
{
    partial class SettingsDialog
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
            this.ButtonOK = new System.Windows.Forms.Button();
            this.GroupBoxMainPlayer = new System.Windows.Forms.GroupBox();
            this.ListBoxMainFiles = new System.Windows.Forms.ListBox();
            this.LabelMainVolumeText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TrackBarMainVolume = new System.Windows.Forms.TrackBar();
            this.CheckBoxMainReshuffle = new System.Windows.Forms.CheckBox();
            this.CheckBoxMainLoop = new System.Windows.Forms.CheckBox();
            this.TextBoxConfigFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonSaveAs = new System.Windows.Forms.Button();
            this.CheckBoxMainPlayer = new System.Windows.Forms.CheckBox();
            this.CheckBoxWebPlayer = new System.Windows.Forms.CheckBox();
            this.GroupBoxWebPlayer = new System.Windows.Forms.GroupBox();
            this.ListBoxWebUrls = new System.Windows.Forms.ListBox();
            this.LabelWebVolumeText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TrackBarWebVolume = new System.Windows.Forms.TrackBar();
            this.CheckBoxWebReshuffle = new System.Windows.Forms.CheckBox();
            this.CheckBoxWebLoop = new System.Windows.Forms.CheckBox();
            this.CheckBoxAudioPlayer = new System.Windows.Forms.CheckBox();
            this.GroupBoxAudioPlayer = new System.Windows.Forms.GroupBox();
            this.ListBoxAudioFiles = new System.Windows.Forms.ListBox();
            this.LabelAudioVolumeText = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TrackBarAudioVolume = new System.Windows.Forms.TrackBar();
            this.CheckBoxAudioReshuffle = new System.Windows.Forms.CheckBox();
            this.CheckBoxAudioLoop = new System.Windows.Forms.CheckBox();
            this.CheckBoxRadioPlayer = new System.Windows.Forms.CheckBox();
            this.GroupBoxRadioPlayer = new System.Windows.Forms.GroupBox();
            this.ListBoxRadioUrls = new System.Windows.Forms.ListBox();
            this.LabelRadioVolumeText = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TrackBarRadioVolume = new System.Windows.Forms.TrackBar();
            this.CheckBoxRadioReshuffle = new System.Windows.Forms.CheckBox();
            this.CheckBoxRadioLoop = new System.Windows.Forms.CheckBox();
            this.GroupBoxMainPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarMainVolume)).BeginInit();
            this.GroupBoxWebPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarWebVolume)).BeginInit();
            this.GroupBoxAudioPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarAudioVolume)).BeginInit();
            this.GroupBoxRadioPlayer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarRadioVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonOK
            // 
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.Location = new System.Drawing.Point(689, 16);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(58, 23);
            this.ButtonOK.TabIndex = 0;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            // 
            // GroupBoxMainPlayer
            // 
            this.GroupBoxMainPlayer.Controls.Add(this.ListBoxMainFiles);
            this.GroupBoxMainPlayer.Controls.Add(this.LabelMainVolumeText);
            this.GroupBoxMainPlayer.Controls.Add(this.label2);
            this.GroupBoxMainPlayer.Controls.Add(this.TrackBarMainVolume);
            this.GroupBoxMainPlayer.Controls.Add(this.CheckBoxMainReshuffle);
            this.GroupBoxMainPlayer.Controls.Add(this.CheckBoxMainLoop);
            this.GroupBoxMainPlayer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GroupBoxMainPlayer.Location = new System.Drawing.Point(24, 85);
            this.GroupBoxMainPlayer.Name = "GroupBoxMainPlayer";
            this.GroupBoxMainPlayer.Size = new System.Drawing.Size(343, 182);
            this.GroupBoxMainPlayer.TabIndex = 1;
            this.GroupBoxMainPlayer.TabStop = false;
            // 
            // ListBoxMainFiles
            // 
            this.ListBoxMainFiles.AllowDrop = true;
            this.ListBoxMainFiles.FormattingEnabled = true;
            this.ListBoxMainFiles.Location = new System.Drawing.Point(6, 42);
            this.ListBoxMainFiles.Name = "ListBoxMainFiles";
            this.ListBoxMainFiles.Size = new System.Drawing.Size(331, 134);
            this.ListBoxMainFiles.TabIndex = 5;
            // 
            // LabelMainVolumeText
            // 
            this.LabelMainVolumeText.AutoSize = true;
            this.LabelMainVolumeText.Location = new System.Drawing.Point(157, 23);
            this.LabelMainVolumeText.Name = "LabelMainVolumeText";
            this.LabelMainVolumeText.Size = new System.Drawing.Size(13, 13);
            this.LabelMainVolumeText.TabIndex = 4;
            this.LabelMainVolumeText.Text = "0";
            this.LabelMainVolumeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Volume";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TrackBarMainVolume
            // 
            this.TrackBarMainVolume.Location = new System.Drawing.Point(54, 19);
            this.TrackBarMainVolume.Maximum = 100;
            this.TrackBarMainVolume.Name = "TrackBarMainVolume";
            this.TrackBarMainVolume.Size = new System.Drawing.Size(116, 45);
            this.TrackBarMainVolume.TabIndex = 2;
            this.TrackBarMainVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // CheckBoxMainReshuffle
            // 
            this.CheckBoxMainReshuffle.AutoSize = true;
            this.CheckBoxMainReshuffle.Location = new System.Drawing.Point(266, 19);
            this.CheckBoxMainReshuffle.Name = "CheckBoxMainReshuffle";
            this.CheckBoxMainReshuffle.Size = new System.Drawing.Size(71, 17);
            this.CheckBoxMainReshuffle.TabIndex = 1;
            this.CheckBoxMainReshuffle.Text = "Reshuffle";
            this.CheckBoxMainReshuffle.UseVisualStyleBackColor = true;
            // 
            // CheckBoxMainLoop
            // 
            this.CheckBoxMainLoop.AutoSize = true;
            this.CheckBoxMainLoop.Location = new System.Drawing.Point(210, 19);
            this.CheckBoxMainLoop.Name = "CheckBoxMainLoop";
            this.CheckBoxMainLoop.Size = new System.Drawing.Size(50, 17);
            this.CheckBoxMainLoop.TabIndex = 0;
            this.CheckBoxMainLoop.Text = "Loop";
            this.CheckBoxMainLoop.UseVisualStyleBackColor = true;
            // 
            // TextBoxConfigFile
            // 
            this.TextBoxConfigFile.Location = new System.Drawing.Point(98, 18);
            this.TextBoxConfigFile.Name = "TextBoxConfigFile";
            this.TextBoxConfigFile.Size = new System.Drawing.Size(398, 20);
            this.TextBoxConfigFile.TabIndex = 2;
            this.TextBoxConfigFile.TextChanged += new System.EventHandler(this.TextBoxConfigFile_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Configure File";
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.Location = new System.Drawing.Point(500, 16);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(60, 23);
            this.ButtonOpen.TabIndex = 4;
            this.ButtonOpen.Text = "Open";
            this.ButtonOpen.UseVisualStyleBackColor = true;
            this.ButtonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(566, 15);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(53, 23);
            this.ButtonSave.TabIndex = 5;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            // 
            // ButtonSaveAs
            // 
            this.ButtonSaveAs.Location = new System.Drawing.Point(624, 16);
            this.ButtonSaveAs.Name = "ButtonSaveAs";
            this.ButtonSaveAs.Size = new System.Drawing.Size(59, 23);
            this.ButtonSaveAs.TabIndex = 6;
            this.ButtonSaveAs.Text = "Save As";
            this.ButtonSaveAs.UseVisualStyleBackColor = true;
            // 
            // CheckBoxMainPlayer
            // 
            this.CheckBoxMainPlayer.AutoSize = true;
            this.CheckBoxMainPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxMainPlayer.Location = new System.Drawing.Point(24, 71);
            this.CheckBoxMainPlayer.Name = "CheckBoxMainPlayer";
            this.CheckBoxMainPlayer.Size = new System.Drawing.Size(223, 17);
            this.CheckBoxMainPlayer.TabIndex = 7;
            this.CheckBoxMainPlayer.Text = "Main Player(360° or normal videos)";
            this.CheckBoxMainPlayer.UseVisualStyleBackColor = true;
            // 
            // CheckBoxWebPlayer
            // 
            this.CheckBoxWebPlayer.AutoSize = true;
            this.CheckBoxWebPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxWebPlayer.Location = new System.Drawing.Point(394, 71);
            this.CheckBoxWebPlayer.Name = "CheckBoxWebPlayer";
            this.CheckBoxWebPlayer.Size = new System.Drawing.Size(374, 17);
            this.CheckBoxWebPlayer.TabIndex = 9;
            this.CheckBoxWebPlayer.Text = "Web Player(Web based video/text News or special programs)";
            this.CheckBoxWebPlayer.UseVisualStyleBackColor = true;
            this.CheckBoxWebPlayer.CheckedChanged += new System.EventHandler(this.CheckBoxWebPlayer_CheckedChanged);
            // 
            // GroupBoxWebPlayer
            // 
            this.GroupBoxWebPlayer.Controls.Add(this.ListBoxWebUrls);
            this.GroupBoxWebPlayer.Controls.Add(this.LabelWebVolumeText);
            this.GroupBoxWebPlayer.Controls.Add(this.label4);
            this.GroupBoxWebPlayer.Controls.Add(this.TrackBarWebVolume);
            this.GroupBoxWebPlayer.Controls.Add(this.CheckBoxWebReshuffle);
            this.GroupBoxWebPlayer.Controls.Add(this.CheckBoxWebLoop);
            this.GroupBoxWebPlayer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GroupBoxWebPlayer.Location = new System.Drawing.Point(394, 85);
            this.GroupBoxWebPlayer.Name = "GroupBoxWebPlayer";
            this.GroupBoxWebPlayer.Size = new System.Drawing.Size(343, 182);
            this.GroupBoxWebPlayer.TabIndex = 8;
            this.GroupBoxWebPlayer.TabStop = false;
            // 
            // ListBoxWebUrls
            // 
            this.ListBoxWebUrls.AllowDrop = true;
            this.ListBoxWebUrls.FormattingEnabled = true;
            this.ListBoxWebUrls.Location = new System.Drawing.Point(6, 42);
            this.ListBoxWebUrls.Name = "ListBoxWebUrls";
            this.ListBoxWebUrls.Size = new System.Drawing.Size(331, 134);
            this.ListBoxWebUrls.TabIndex = 5;
            // 
            // LabelWebVolumeText
            // 
            this.LabelWebVolumeText.AutoSize = true;
            this.LabelWebVolumeText.Location = new System.Drawing.Point(174, 23);
            this.LabelWebVolumeText.Name = "LabelWebVolumeText";
            this.LabelWebVolumeText.Size = new System.Drawing.Size(13, 13);
            this.LabelWebVolumeText.TabIndex = 4;
            this.LabelWebVolumeText.Text = "0";
            this.LabelWebVolumeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Volume";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TrackBarWebVolume
            // 
            this.TrackBarWebVolume.Location = new System.Drawing.Point(62, 19);
            this.TrackBarWebVolume.Maximum = 100;
            this.TrackBarWebVolume.Name = "TrackBarWebVolume";
            this.TrackBarWebVolume.Size = new System.Drawing.Size(115, 45);
            this.TrackBarWebVolume.TabIndex = 2;
            this.TrackBarWebVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // CheckBoxWebReshuffle
            // 
            this.CheckBoxWebReshuffle.AutoSize = true;
            this.CheckBoxWebReshuffle.Location = new System.Drawing.Point(266, 19);
            this.CheckBoxWebReshuffle.Name = "CheckBoxWebReshuffle";
            this.CheckBoxWebReshuffle.Size = new System.Drawing.Size(71, 17);
            this.CheckBoxWebReshuffle.TabIndex = 1;
            this.CheckBoxWebReshuffle.Text = "Reshuffle";
            this.CheckBoxWebReshuffle.UseVisualStyleBackColor = true;
            // 
            // CheckBoxWebLoop
            // 
            this.CheckBoxWebLoop.AutoSize = true;
            this.CheckBoxWebLoop.Location = new System.Drawing.Point(205, 19);
            this.CheckBoxWebLoop.Name = "CheckBoxWebLoop";
            this.CheckBoxWebLoop.Size = new System.Drawing.Size(50, 17);
            this.CheckBoxWebLoop.TabIndex = 0;
            this.CheckBoxWebLoop.Text = "Loop";
            this.CheckBoxWebLoop.UseVisualStyleBackColor = true;
            // 
            // CheckBoxAudioPlayer
            // 
            this.CheckBoxAudioPlayer.AutoSize = true;
            this.CheckBoxAudioPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxAudioPlayer.Location = new System.Drawing.Point(24, 285);
            this.CheckBoxAudioPlayer.Name = "CheckBoxAudioPlayer";
            this.CheckBoxAudioPlayer.Size = new System.Drawing.Size(253, 17);
            this.CheckBoxAudioPlayer.TabIndex = 11;
            this.CheckBoxAudioPlayer.Text = "Audio Player(Standalone audio channel)";
            this.CheckBoxAudioPlayer.UseVisualStyleBackColor = true;
            this.CheckBoxAudioPlayer.CheckedChanged += new System.EventHandler(this.CheckBoxAudio_CheckedChanged);
            // 
            // GroupBoxAudioPlayer
            // 
            this.GroupBoxAudioPlayer.Controls.Add(this.ListBoxAudioFiles);
            this.GroupBoxAudioPlayer.Controls.Add(this.LabelAudioVolumeText);
            this.GroupBoxAudioPlayer.Controls.Add(this.label5);
            this.GroupBoxAudioPlayer.Controls.Add(this.TrackBarAudioVolume);
            this.GroupBoxAudioPlayer.Controls.Add(this.CheckBoxAudioReshuffle);
            this.GroupBoxAudioPlayer.Controls.Add(this.CheckBoxAudioLoop);
            this.GroupBoxAudioPlayer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GroupBoxAudioPlayer.Location = new System.Drawing.Point(24, 299);
            this.GroupBoxAudioPlayer.Name = "GroupBoxAudioPlayer";
            this.GroupBoxAudioPlayer.Size = new System.Drawing.Size(343, 182);
            this.GroupBoxAudioPlayer.TabIndex = 10;
            this.GroupBoxAudioPlayer.TabStop = false;
            // 
            // ListBoxAudioFiles
            // 
            this.ListBoxAudioFiles.AllowDrop = true;
            this.ListBoxAudioFiles.FormattingEnabled = true;
            this.ListBoxAudioFiles.Location = new System.Drawing.Point(6, 42);
            this.ListBoxAudioFiles.Name = "ListBoxAudioFiles";
            this.ListBoxAudioFiles.Size = new System.Drawing.Size(331, 134);
            this.ListBoxAudioFiles.TabIndex = 5;
            // 
            // LabelAudioVolumeText
            // 
            this.LabelAudioVolumeText.AutoSize = true;
            this.LabelAudioVolumeText.Location = new System.Drawing.Point(167, 23);
            this.LabelAudioVolumeText.Name = "LabelAudioVolumeText";
            this.LabelAudioVolumeText.Size = new System.Drawing.Size(13, 13);
            this.LabelAudioVolumeText.TabIndex = 4;
            this.LabelAudioVolumeText.Text = "0";
            this.LabelAudioVolumeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Volume";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TrackBarAudioVolume
            // 
            this.TrackBarAudioVolume.Location = new System.Drawing.Point(55, 19);
            this.TrackBarAudioVolume.Maximum = 100;
            this.TrackBarAudioVolume.Name = "TrackBarAudioVolume";
            this.TrackBarAudioVolume.Size = new System.Drawing.Size(115, 45);
            this.TrackBarAudioVolume.TabIndex = 2;
            this.TrackBarAudioVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // CheckBoxAudioReshuffle
            // 
            this.CheckBoxAudioReshuffle.AutoSize = true;
            this.CheckBoxAudioReshuffle.Location = new System.Drawing.Point(266, 19);
            this.CheckBoxAudioReshuffle.Name = "CheckBoxAudioReshuffle";
            this.CheckBoxAudioReshuffle.Size = new System.Drawing.Size(71, 17);
            this.CheckBoxAudioReshuffle.TabIndex = 1;
            this.CheckBoxAudioReshuffle.Text = "Reshuffle";
            this.CheckBoxAudioReshuffle.UseVisualStyleBackColor = true;
            // 
            // CheckBoxAudioLoop
            // 
            this.CheckBoxAudioLoop.AutoSize = true;
            this.CheckBoxAudioLoop.Location = new System.Drawing.Point(210, 19);
            this.CheckBoxAudioLoop.Name = "CheckBoxAudioLoop";
            this.CheckBoxAudioLoop.Size = new System.Drawing.Size(50, 17);
            this.CheckBoxAudioLoop.TabIndex = 0;
            this.CheckBoxAudioLoop.Text = "Loop";
            this.CheckBoxAudioLoop.UseVisualStyleBackColor = true;
            // 
            // CheckBoxRadioPlayer
            // 
            this.CheckBoxRadioPlayer.AutoSize = true;
            this.CheckBoxRadioPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxRadioPlayer.Location = new System.Drawing.Point(394, 285);
            this.CheckBoxRadioPlayer.Name = "CheckBoxRadioPlayer";
            this.CheckBoxRadioPlayer.Size = new System.Drawing.Size(303, 17);
            this.CheckBoxRadioPlayer.TabIndex = 13;
            this.CheckBoxRadioPlayer.Text = "Internet Radio (News or any other radio program)";
            this.CheckBoxRadioPlayer.UseVisualStyleBackColor = true;
            // 
            // GroupBoxRadioPlayer
            // 
            this.GroupBoxRadioPlayer.Controls.Add(this.ListBoxRadioUrls);
            this.GroupBoxRadioPlayer.Controls.Add(this.LabelRadioVolumeText);
            this.GroupBoxRadioPlayer.Controls.Add(this.label7);
            this.GroupBoxRadioPlayer.Controls.Add(this.TrackBarRadioVolume);
            this.GroupBoxRadioPlayer.Controls.Add(this.CheckBoxRadioReshuffle);
            this.GroupBoxRadioPlayer.Controls.Add(this.CheckBoxRadioLoop);
            this.GroupBoxRadioPlayer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GroupBoxRadioPlayer.Location = new System.Drawing.Point(394, 299);
            this.GroupBoxRadioPlayer.Name = "GroupBoxRadioPlayer";
            this.GroupBoxRadioPlayer.Size = new System.Drawing.Size(343, 182);
            this.GroupBoxRadioPlayer.TabIndex = 12;
            this.GroupBoxRadioPlayer.TabStop = false;
            // 
            // ListBoxRadioUrls
            // 
            this.ListBoxRadioUrls.AllowDrop = true;
            this.ListBoxRadioUrls.FormattingEnabled = true;
            this.ListBoxRadioUrls.Location = new System.Drawing.Point(6, 42);
            this.ListBoxRadioUrls.Name = "ListBoxRadioUrls";
            this.ListBoxRadioUrls.Size = new System.Drawing.Size(331, 134);
            this.ListBoxRadioUrls.TabIndex = 5;
            // 
            // LabelRadioVolumeText
            // 
            this.LabelRadioVolumeText.AutoSize = true;
            this.LabelRadioVolumeText.Location = new System.Drawing.Point(174, 23);
            this.LabelRadioVolumeText.Name = "LabelRadioVolumeText";
            this.LabelRadioVolumeText.Size = new System.Drawing.Size(13, 13);
            this.LabelRadioVolumeText.TabIndex = 4;
            this.LabelRadioVolumeText.Text = "0";
            this.LabelRadioVolumeText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Volume";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TrackBarRadioVolume
            // 
            this.TrackBarRadioVolume.Location = new System.Drawing.Point(62, 19);
            this.TrackBarRadioVolume.Maximum = 100;
            this.TrackBarRadioVolume.Name = "TrackBarRadioVolume";
            this.TrackBarRadioVolume.Size = new System.Drawing.Size(115, 45);
            this.TrackBarRadioVolume.TabIndex = 2;
            this.TrackBarRadioVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // CheckBoxRadioReshuffle
            // 
            this.CheckBoxRadioReshuffle.AutoSize = true;
            this.CheckBoxRadioReshuffle.Location = new System.Drawing.Point(266, 19);
            this.CheckBoxRadioReshuffle.Name = "CheckBoxRadioReshuffle";
            this.CheckBoxRadioReshuffle.Size = new System.Drawing.Size(71, 17);
            this.CheckBoxRadioReshuffle.TabIndex = 1;
            this.CheckBoxRadioReshuffle.Text = "Reshuffle";
            this.CheckBoxRadioReshuffle.UseVisualStyleBackColor = true;
            // 
            // CheckBoxRadioLoop
            // 
            this.CheckBoxRadioLoop.AutoSize = true;
            this.CheckBoxRadioLoop.Location = new System.Drawing.Point(210, 19);
            this.CheckBoxRadioLoop.Name = "CheckBoxRadioLoop";
            this.CheckBoxRadioLoop.Size = new System.Drawing.Size(50, 17);
            this.CheckBoxRadioLoop.TabIndex = 0;
            this.CheckBoxRadioLoop.Text = "Loop";
            this.CheckBoxRadioLoop.UseVisualStyleBackColor = true;
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 490);
            this.Controls.Add(this.CheckBoxRadioPlayer);
            this.Controls.Add(this.GroupBoxRadioPlayer);
            this.Controls.Add(this.CheckBoxAudioPlayer);
            this.Controls.Add(this.GroupBoxAudioPlayer);
            this.Controls.Add(this.CheckBoxWebPlayer);
            this.Controls.Add(this.GroupBoxWebPlayer);
            this.Controls.Add(this.CheckBoxMainPlayer);
            this.Controls.Add(this.ButtonSaveAs);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxConfigFile);
            this.Controls.Add(this.GroupBoxMainPlayer);
            this.Controls.Add(this.ButtonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsDialog_Load);
            this.GroupBoxMainPlayer.ResumeLayout(false);
            this.GroupBoxMainPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarMainVolume)).EndInit();
            this.GroupBoxWebPlayer.ResumeLayout(false);
            this.GroupBoxWebPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarWebVolume)).EndInit();
            this.GroupBoxAudioPlayer.ResumeLayout(false);
            this.GroupBoxAudioPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarAudioVolume)).EndInit();
            this.GroupBoxRadioPlayer.ResumeLayout(false);
            this.GroupBoxRadioPlayer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarRadioVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.GroupBox GroupBoxMainPlayer;
        private System.Windows.Forms.TextBox TextBoxConfigFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonOpen;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonSaveAs;
        private System.Windows.Forms.CheckBox CheckBoxMainPlayer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar TrackBarMainVolume;
        private System.Windows.Forms.CheckBox CheckBoxMainReshuffle;
        private System.Windows.Forms.CheckBox CheckBoxMainLoop;
        private System.Windows.Forms.ListBox ListBoxMainFiles;
        private System.Windows.Forms.Label LabelMainVolumeText;
        private System.Windows.Forms.CheckBox CheckBoxWebPlayer;
        private System.Windows.Forms.GroupBox GroupBoxWebPlayer;
        private System.Windows.Forms.ListBox ListBoxWebUrls;
        private System.Windows.Forms.Label LabelWebVolumeText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar TrackBarWebVolume;
        private System.Windows.Forms.CheckBox CheckBoxWebReshuffle;
        private System.Windows.Forms.CheckBox CheckBoxWebLoop;
        private System.Windows.Forms.CheckBox CheckBoxAudioPlayer;
        private System.Windows.Forms.GroupBox GroupBoxAudioPlayer;
        private System.Windows.Forms.ListBox ListBoxAudioFiles;
        private System.Windows.Forms.Label LabelAudioVolumeText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar TrackBarAudioVolume;
        private System.Windows.Forms.CheckBox CheckBoxAudioReshuffle;
        private System.Windows.Forms.CheckBox CheckBoxAudioLoop;
        private System.Windows.Forms.CheckBox CheckBoxRadioPlayer;
        private System.Windows.Forms.GroupBox GroupBoxRadioPlayer;
        private System.Windows.Forms.ListBox ListBoxRadioUrls;
        private System.Windows.Forms.Label LabelRadioVolumeText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar TrackBarRadioVolume;
        private System.Windows.Forms.CheckBox CheckBoxRadioReshuffle;
        private System.Windows.Forms.CheckBox CheckBoxRadioLoop;
    }
}