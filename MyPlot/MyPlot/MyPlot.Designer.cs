
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
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.videoView = new LibVLCSharp.WinForms.VideoView();
            this.audioView = new LibVLCSharp.WinForms.VideoView();
            this.radioView = new LibVLCSharp.WinForms.VideoView();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioView)).BeginInit();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // webView21
            // 
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(660, 367);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(480, 270);
            this.webView21.TabIndex = 3;
            this.webView21.ZoomFactor = 1D;
            // 
            // videoView
            // 
            this.videoView.BackColor = System.Drawing.Color.CornflowerBlue;
            this.videoView.Location = new System.Drawing.Point(0, 0);
            this.videoView.MediaPlayer = null;
            this.videoView.Name = "videoView";
            this.videoView.Size = new System.Drawing.Size(1152, 648);
            this.videoView.TabIndex = 5;
            this.videoView.Text = "videoView";
            this.videoView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.videoView_KeyPress);
            // 
            // audioView
            // 
            this.audioView.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.audioView.Location = new System.Drawing.Point(67, 37);
            this.audioView.MediaPlayer = null;
            this.audioView.Name = "audioView";
            this.audioView.Size = new System.Drawing.Size(96, 54);
            this.audioView.TabIndex = 6;
            this.audioView.Text = "audioView";
            // 
            // radioView
            // 
            this.radioView.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.radioView.Location = new System.Drawing.Point(182, 37);
            this.radioView.MediaPlayer = null;
            this.radioView.Name = "radioView";
            this.radioView.Size = new System.Drawing.Size(96, 54);
            this.radioView.TabIndex = 6;
            this.radioView.Text = "radioView";
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
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
            this.userGuideToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.userGuideToolStripMenuItem.Text = "&User Guide";
            this.userGuideToolStripMenuItem.Click += new System.EventHandler(this.userGuideToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MyPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 648);
            this.Controls.Add(this.menuMain);
            this.Controls.Add(this.radioView);
            this.Controls.Add(this.audioView);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.videoView);
            this.MainMenuStrip = this.menuMain;
            this.Name = "MyPlot";
            this.Text = "MyPlot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MyPlot_FormClosed);
            this.Load += new System.EventHandler(this.MyPlot_Load);
            this.Resize += new System.EventHandler(this.MyPlot_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioView)).EndInit();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
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
    }
}

