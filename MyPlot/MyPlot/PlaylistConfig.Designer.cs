
namespace MyPlot
{
    partial class PlaylistSetup
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
            this.textBoxConfigFile = new System.Windows.Forms.TextBox();
            this.ButtonSaveAs = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.tabControlPlaylist = new System.Windows.Forms.TabControl();
            this.tabPageVideo = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabelDownload = new System.Windows.Forms.LinkLabel();
            this.trackBarVideoVol = new System.Windows.Forms.TrackBar();
            this.checkBoxVideoEnable = new System.Windows.Forms.CheckBox();
            this.ListBoxVideoList = new System.Windows.Forms.ListBox();
            this.LabelVideoVolText = new System.Windows.Forms.Label();
            this.CheckBoxMainLoop = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CheckBoxMainReshuffle = new System.Windows.Forms.CheckBox();
            this.tabPageAudio = new System.Windows.Forms.TabPage();
            this.tabPageWeb = new System.Windows.Forms.TabPage();
            this.tabPageRadio = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabControlPlaylist.SuspendLayout();
            this.tabPageVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVideoVol)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxConfigFile
            // 
            this.textBoxConfigFile.Location = new System.Drawing.Point(89, 8);
            this.textBoxConfigFile.Name = "textBoxConfigFile";
            this.textBoxConfigFile.ReadOnly = true;
            this.textBoxConfigFile.Size = new System.Drawing.Size(509, 20);
            this.textBoxConfigFile.TabIndex = 16;
            this.textBoxConfigFile.TextChanged += new System.EventHandler(this.textBoxConfigFile_TextChanged);
            // 
            // ButtonSaveAs
            // 
            this.ButtonSaveAs.Location = new System.Drawing.Point(728, 6);
            this.ButtonSaveAs.Name = "ButtonSaveAs";
            this.ButtonSaveAs.Size = new System.Drawing.Size(60, 24);
            this.ButtonSaveAs.TabIndex = 20;
            this.ButtonSaveAs.Text = "Save As";
            this.ButtonSaveAs.UseVisualStyleBackColor = true;
            this.ButtonSaveAs.Click += new System.EventHandler(this.ButtonSaveAs_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(670, 6);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(53, 24);
            this.ButtonSave.TabIndex = 19;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.Location = new System.Drawing.Point(604, 6);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(60, 24);
            this.ButtonOpen.TabIndex = 18;
            this.ButtonOpen.Text = "Open";
            this.ButtonOpen.UseVisualStyleBackColor = true;
            this.ButtonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "Configure File";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ButtonOK
            // 
            this.ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonOK.Location = new System.Drawing.Point(700, 484);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(87, 24);
            this.ButtonOK.TabIndex = 14;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            // 
            // tabControlPlaylist
            // 
            this.tabControlPlaylist.Controls.Add(this.tabPageVideo);
            this.tabControlPlaylist.Controls.Add(this.tabPageAudio);
            this.tabControlPlaylist.Controls.Add(this.tabPageWeb);
            this.tabControlPlaylist.Controls.Add(this.tabPageRadio);
            this.tabControlPlaylist.Location = new System.Drawing.Point(19, 49);
            this.tabControlPlaylist.Name = "tabControlPlaylist";
            this.tabControlPlaylist.SelectedIndex = 0;
            this.tabControlPlaylist.Size = new System.Drawing.Size(772, 429);
            this.tabControlPlaylist.TabIndex = 22;
            // 
            // tabPageVideo
            // 
            this.tabPageVideo.Controls.Add(this.label4);
            this.tabPageVideo.Controls.Add(this.label3);
            this.tabPageVideo.Controls.Add(this.linkLabelDownload);
            this.tabPageVideo.Controls.Add(this.trackBarVideoVol);
            this.tabPageVideo.Controls.Add(this.checkBoxVideoEnable);
            this.tabPageVideo.Controls.Add(this.ListBoxVideoList);
            this.tabPageVideo.Controls.Add(this.LabelVideoVolText);
            this.tabPageVideo.Controls.Add(this.CheckBoxMainLoop);
            this.tabPageVideo.Controls.Add(this.label2);
            this.tabPageVideo.Controls.Add(this.CheckBoxMainReshuffle);
            this.tabPageVideo.Location = new System.Drawing.Point(4, 22);
            this.tabPageVideo.Name = "tabPageVideo";
            this.tabPageVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVideo.Size = new System.Drawing.Size(764, 403);
            this.tabPageVideo.TabIndex = 0;
            this.tabPageVideo.Text = "Video";
            this.tabPageVideo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(407, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(257, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "to your PC, then drag and drop here.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-2, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(326, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Download your wanted scenery video from our";
            // 
            // linkLabelDownload
            // 
            this.linkLabelDownload.AutoSize = true;
            this.linkLabelDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelDownload.Location = new System.Drawing.Point(325, 42);
            this.linkLabelDownload.Name = "linkLabelDownload";
            this.linkLabelDownload.Size = new System.Drawing.Size(85, 16);
            this.linkLabelDownload.TabIndex = 8;
            this.linkLabelDownload.TabStop = true;
            this.linkLabelDownload.Text = "Server Site";
            this.linkLabelDownload.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDownload_LinkClicked);
            // 
            // trackBarVideoVol
            // 
            this.trackBarVideoVol.AutoSize = false;
            this.trackBarVideoVol.Location = new System.Drawing.Point(127, 12);
            this.trackBarVideoVol.Maximum = 100;
            this.trackBarVideoVol.Name = "trackBarVideoVol";
            this.trackBarVideoVol.Size = new System.Drawing.Size(103, 18);
            this.trackBarVideoVol.TabIndex = 7;
            this.trackBarVideoVol.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarVideoVol.Scroll += new System.EventHandler(this.trackBarVideoVol_Scroll);
            // 
            // checkBoxVideoEnable
            // 
            this.checkBoxVideoEnable.AutoSize = true;
            this.checkBoxVideoEnable.Location = new System.Drawing.Point(1, 12);
            this.checkBoxVideoEnable.Name = "checkBoxVideoEnable";
            this.checkBoxVideoEnable.Size = new System.Drawing.Size(59, 17);
            this.checkBoxVideoEnable.TabIndex = 6;
            this.checkBoxVideoEnable.Text = "Enable";
            this.checkBoxVideoEnable.UseVisualStyleBackColor = true;
            // 
            // ListBoxVideoList
            // 
            this.ListBoxVideoList.AllowDrop = true;
            this.ListBoxVideoList.FormattingEnabled = true;
            this.ListBoxVideoList.HorizontalScrollbar = true;
            this.ListBoxVideoList.Location = new System.Drawing.Point(2, 61);
            this.ListBoxVideoList.Name = "ListBoxVideoList";
            this.ListBoxVideoList.Size = new System.Drawing.Size(762, 342);
            this.ListBoxVideoList.TabIndex = 5;
            this.ListBoxVideoList.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBoxVideoList_DragDrop);
            this.ListBoxVideoList.DragOver += new System.Windows.Forms.DragEventHandler(this.ListBoxVideoList_DragOver);
            this.ListBoxVideoList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBoxVideoList_KeyDown);
            // 
            // LabelVideoVolText
            // 
            this.LabelVideoVolText.AutoSize = true;
            this.LabelVideoVolText.Location = new System.Drawing.Point(235, 14);
            this.LabelVideoVolText.Name = "LabelVideoVolText";
            this.LabelVideoVolText.Size = new System.Drawing.Size(13, 13);
            this.LabelVideoVolText.TabIndex = 4;
            this.LabelVideoVolText.Text = "0";
            this.LabelVideoVolText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CheckBoxMainLoop
            // 
            this.CheckBoxMainLoop.AutoSize = true;
            this.CheckBoxMainLoop.Location = new System.Drawing.Point(289, 12);
            this.CheckBoxMainLoop.Name = "CheckBoxMainLoop";
            this.CheckBoxMainLoop.Size = new System.Drawing.Size(50, 17);
            this.CheckBoxMainLoop.TabIndex = 0;
            this.CheckBoxMainLoop.Text = "Loop";
            this.CheckBoxMainLoop.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Volume";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckBoxMainReshuffle
            // 
            this.CheckBoxMainReshuffle.AutoSize = true;
            this.CheckBoxMainReshuffle.Location = new System.Drawing.Point(364, 12);
            this.CheckBoxMainReshuffle.Name = "CheckBoxMainReshuffle";
            this.CheckBoxMainReshuffle.Size = new System.Drawing.Size(71, 17);
            this.CheckBoxMainReshuffle.TabIndex = 1;
            this.CheckBoxMainReshuffle.Text = "Reshuffle";
            this.CheckBoxMainReshuffle.UseVisualStyleBackColor = true;
            // 
            // tabPageAudio
            // 
            this.tabPageAudio.Location = new System.Drawing.Point(4, 22);
            this.tabPageAudio.Name = "tabPageAudio";
            this.tabPageAudio.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAudio.Size = new System.Drawing.Size(764, 403);
            this.tabPageAudio.TabIndex = 1;
            this.tabPageAudio.Text = "Audio";
            this.tabPageAudio.UseVisualStyleBackColor = true;
            // 
            // tabPageWeb
            // 
            this.tabPageWeb.Location = new System.Drawing.Point(4, 22);
            this.tabPageWeb.Name = "tabPageWeb";
            this.tabPageWeb.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWeb.Size = new System.Drawing.Size(764, 403);
            this.tabPageWeb.TabIndex = 2;
            this.tabPageWeb.Text = "Web";
            this.tabPageWeb.UseVisualStyleBackColor = true;
            // 
            // tabPageRadio
            // 
            this.tabPageRadio.Location = new System.Drawing.Point(4, 22);
            this.tabPageRadio.Name = "tabPageRadio";
            this.tabPageRadio.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRadio.Size = new System.Drawing.Size(764, 403);
            this.tabPageRadio.TabIndex = 3;
            this.tabPageRadio.Text = "Radio";
            this.tabPageRadio.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 481);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(449, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Note: Drag files(.mp4, .mov, .wmv, .flv, .avi, .mkv) in to add. Del key or right " +
    "mouse to remove.";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(600, 484);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(87, 24);
            this.buttonCancel.TabIndex = 24;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // PlaylistSetup
            // 
            this.AcceptButton = this.ButtonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(807, 520);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabControlPlaylist);
            this.Controls.Add(this.textBoxConfigFile);
            this.Controls.Add(this.ButtonSaveAs);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ButtonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlaylistSetup";
            this.Text = "Playlist Setup";
            this.Load += new System.EventHandler(this.PlaylistSetup_Load);
            this.tabControlPlaylist.ResumeLayout(false);
            this.tabPageVideo.ResumeLayout(false);
            this.tabPageVideo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVideoVol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxConfigFile;
        private System.Windows.Forms.Button ButtonSaveAs;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.TabControl tabControlPlaylist;
        private System.Windows.Forms.TabPage tabPageVideo;
        private System.Windows.Forms.TrackBar trackBarVideoVol;
        private System.Windows.Forms.CheckBox checkBoxVideoEnable;
        private System.Windows.Forms.ListBox ListBoxVideoList;
        private System.Windows.Forms.Label LabelVideoVolText;
        private System.Windows.Forms.CheckBox CheckBoxMainLoop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CheckBoxMainReshuffle;
        private System.Windows.Forms.TabPage tabPageAudio;
        private System.Windows.Forms.TabPage tabPageWeb;
        private System.Windows.Forms.TabPage tabPageRadio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabelDownload;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCancel;
    }
}