
namespace MyPlot
{
    partial class MyPlot
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
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.videoView = new LibVLCSharp.WinForms.VideoView();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableDisableVideo = new System.Windows.Forms.ToolStripMenuItem();
            this.audioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.webToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backwardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radioPicBox = new System.Windows.Forms.PictureBox();
            this.radioView = new LibVLCSharp.WinForms.VideoView();
            this.audioView = new LibVLCSharp.WinForms.VideoView();
            this.timerAudio = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoView)).BeginInit();
            this.menuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioView)).BeginInit();
            this.SuspendLayout();
            // 
            // webView
            // 
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Location = new System.Drawing.Point(660, 367);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(480, 270);
            this.webView.TabIndex = 3;
            this.webView.Visible = false;
            this.webView.ZoomFactor = 1D;
            this.webView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.webView_KeyDown);
            // 
            // videoView
            // 
            this.videoView.BackColor = System.Drawing.Color.CornflowerBlue;
            this.videoView.Location = new System.Drawing.Point(0, 24);
            this.videoView.MediaPlayer = null;
            this.videoView.Name = "videoView";
            this.videoView.Size = new System.Drawing.Size(1152, 621);
            this.videoView.TabIndex = 5;
            this.videoView.Text = " ";
            this.videoView.Visible = false;
            this.videoView.DoubleClick += new System.EventHandler(this.videoView_DoubleClick);
            this.videoView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.videoView_KeyPress);
            this.videoView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.videoView_MouseClick);
            this.videoView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.videoView_MouseDown);
            this.videoView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.videoView_MouseMove);
            this.videoView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.videoView_MouseUp);
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.videoToolStripMenuItem,
            this.audioToolStripMenuItem,
            this.webToolStripMenuItem,
            this.radioToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1152, 24);
            this.menuMain.TabIndex = 7;
            this.menuMain.Text = "menuStrip";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.testToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullScreenToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.fullScreenToolStripMenuItem.Text = "F&ull Screen";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableDisableVideo});
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.videoToolStripMenuItem.Text = "Video";
            // 
            // enableDisableVideo
            // 
            this.enableDisableVideo.Name = "enableDisableVideo";
            this.enableDisableVideo.Size = new System.Drawing.Size(152, 22);
            this.enableDisableVideo.Text = "Enable/Disable";
            this.enableDisableVideo.Click += new System.EventHandler(this.enableDisableVideo_Click);
            // 
            // audioToolStripMenuItem
            // 
            this.audioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableToolStripMenuItem1});
            this.audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            this.audioToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.audioToolStripMenuItem.Text = "Audio";
            // 
            // enableToolStripMenuItem1
            // 
            this.enableToolStripMenuItem1.Name = "enableToolStripMenuItem1";
            this.enableToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.enableToolStripMenuItem1.Text = "Enable/Disable";
            this.enableToolStripMenuItem1.Click += new System.EventHandler(this.enableDisableAudio_Click);
            // 
            // webToolStripMenuItem
            // 
            this.webToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableToolStripMenuItem2,
            this.homeToolStripMenuItem,
            this.forwardToolStripMenuItem,
            this.backwardToolStripMenuItem});
            this.webToolStripMenuItem.Name = "webToolStripMenuItem";
            this.webToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.webToolStripMenuItem.Text = "Web";
            // 
            // enableToolStripMenuItem2
            // 
            this.enableToolStripMenuItem2.Name = "enableToolStripMenuItem2";
            this.enableToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.enableToolStripMenuItem2.Text = "Enable/Disable";
            this.enableToolStripMenuItem2.Click += new System.EventHandler(this.enableDisableWeb_Click);
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // forwardToolStripMenuItem
            // 
            this.forwardToolStripMenuItem.Name = "forwardToolStripMenuItem";
            this.forwardToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.forwardToolStripMenuItem.Text = "Forward";
            this.forwardToolStripMenuItem.Click += new System.EventHandler(this.forwardToolStripMenuItem_Click);
            // 
            // backwardToolStripMenuItem
            // 
            this.backwardToolStripMenuItem.Name = "backwardToolStripMenuItem";
            this.backwardToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.backwardToolStripMenuItem.Text = "Backward";
            this.backwardToolStripMenuItem.Click += new System.EventHandler(this.backwardToolStripMenuItem_Click);
            // 
            // radioToolStripMenuItem
            // 
            this.radioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableToolStripMenuItem3});
            this.radioToolStripMenuItem.Name = "radioToolStripMenuItem";
            this.radioToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.radioToolStripMenuItem.Text = "Radio";
            // 
            // enableToolStripMenuItem3
            // 
            this.enableToolStripMenuItem3.Name = "enableToolStripMenuItem3";
            this.enableToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.enableToolStripMenuItem3.Text = "Enable/Disable";
            this.enableToolStripMenuItem3.Click += new System.EventHandler(this.enableDisableRadio_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userGuideToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // userGuideToolStripMenuItem
            // 
            this.userGuideToolStripMenuItem.Name = "userGuideToolStripMenuItem";
            this.userGuideToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.userGuideToolStripMenuItem.Text = "&User Guide";
            this.userGuideToolStripMenuItem.Click += new System.EventHandler(this.userGuideToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // radioPicBox
            // 
            this.radioPicBox.Image = global::MyPlot.Properties.Resources.radio_playing;
            this.radioPicBox.Location = new System.Drawing.Point(997, 37);
            this.radioPicBox.Name = "radioPicBox";
            this.radioPicBox.Size = new System.Drawing.Size(96, 54);
            this.radioPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.radioPicBox.TabIndex = 9;
            this.radioPicBox.TabStop = false;
            this.radioPicBox.Visible = false;
            // 
            // radioView
            // 
            this.radioView.BackColor = System.Drawing.SystemColors.Control;
            this.radioView.BackgroundImage = global::MyPlot.Properties.Resources.radio_playing;
            this.radioView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radioView.Location = new System.Drawing.Point(895, 37);
            this.radioView.MediaPlayer = null;
            this.radioView.Name = "radioView";
            this.radioView.Size = new System.Drawing.Size(96, 54);
            this.radioView.TabIndex = 6;
            this.radioView.Text = "radioView";
            this.radioView.Visible = false;
            // 
            // audioView
            // 
            this.audioView.BackColor = System.Drawing.Color.Black;
            this.audioView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.audioView.Location = new System.Drawing.Point(67, 37);
            this.audioView.MediaPlayer = null;
            this.audioView.Name = "audioView";
            this.audioView.Size = new System.Drawing.Size(112, 64);
            this.audioView.TabIndex = 6;
            this.audioView.Text = "audioView";
            this.audioView.Visible = false;
            this.audioView.Paint += new System.Windows.Forms.PaintEventHandler(this.audioView_Paint);
            this.audioView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.audioView_MouseClick);
            this.audioView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.audioView_MouseDown);
            this.audioView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.audioView_MouseMove);
            this.audioView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.audioView_MouseUp);
            // 
            // timerAudio
            // 
            this.timerAudio.Interval = 50;
            this.timerAudio.Tick += new System.EventHandler(this.timerAudio_Tick);
            // 
            // MyPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1152, 648);
            this.Controls.Add(this.radioPicBox);
            this.Controls.Add(this.menuMain);
            this.Controls.Add(this.radioView);
            this.Controls.Add(this.audioView);
            this.Controls.Add(this.webView);
            this.Controls.Add(this.videoView);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuMain;
            this.Name = "MyPlot";
            this.Text = "MyPlot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MyPlot_FormClosed);
            this.Load += new System.EventHandler(this.MyPlot_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MyPlot_KeyPress);
            this.Move += new System.EventHandler(this.MyPlot_Move);
            this.Resize += new System.EventHandler(this.MyPlot_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoView)).EndInit();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private LibVLCSharp.WinForms.VideoView videoView;
        private LibVLCSharp.WinForms.VideoView audioView;
        private LibVLCSharp.WinForms.VideoView radioView;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userGuideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.PictureBox radioPicBox;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableDisableVideo;
        private System.Windows.Forms.ToolStripMenuItem audioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem webToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backwardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem radioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem3;
        private System.Windows.Forms.Timer timerAudio;
    }
}

