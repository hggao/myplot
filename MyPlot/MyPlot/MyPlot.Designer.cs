﻿
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
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerControlbar = new System.Windows.Forms.GroupBox();
            this.vPanel = new System.Windows.Forms.GroupBox();
            this.aPanel = new System.Windows.Forms.GroupBox();
            this.rPanel = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.vPos = new System.Windows.Forms.TrackBar();
            this.vVolume = new System.Windows.Forms.TrackBar();
            this.aVolume = new System.Windows.Forms.TrackBar();
            this.aPos = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.rVolume = new System.Windows.Forms.TrackBar();
            this.rPos = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.vPrev = new System.Windows.Forms.Button();
            this.vPlay = new System.Windows.Forms.Button();
            this.vNext = new System.Windows.Forms.Button();
            this.aVolIcon = new System.Windows.Forms.PictureBox();
            this.rVolIcon = new System.Windows.Forms.PictureBox();
            this.vVolIcon = new System.Windows.Forms.PictureBox();
            this.aPrev = new System.Windows.Forms.Button();
            this.aPlay = new System.Windows.Forms.Button();
            this.aNext = new System.Windows.Forms.Button();
            this.rPrev = new System.Windows.Forms.Button();
            this.rPlay = new System.Windows.Forms.Button();
            this.rNext = new System.Windows.Forms.Button();
            this.timerControlbar = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioView)).BeginInit();
            this.menuMain.SuspendLayout();
            this.playerControlbar.SuspendLayout();
            this.vPanel.SuspendLayout();
            this.aPanel.SuspendLayout();
            this.rPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aVolIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rVolIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vVolIcon)).BeginInit();
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
            this.viewToolStripMenuItem,
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
            // playerControlbar
            // 
            this.playerControlbar.BackColor = System.Drawing.SystemColors.Control;
            this.playerControlbar.Controls.Add(this.aPanel);
            this.playerControlbar.Controls.Add(this.rPanel);
            this.playerControlbar.Controls.Add(this.vPanel);
            this.playerControlbar.Location = new System.Drawing.Point(111, 111);
            this.playerControlbar.Name = "playerControlbar";
            this.playerControlbar.Size = new System.Drawing.Size(880, 240);
            this.playerControlbar.TabIndex = 8;
            this.playerControlbar.TabStop = false;
            // 
            // vPanel
            // 
            this.vPanel.Controls.Add(this.vNext);
            this.vPanel.Controls.Add(this.vPlay);
            this.vPanel.Controls.Add(this.vPrev);
            this.vPanel.Controls.Add(this.vVolume);
            this.vPanel.Controls.Add(this.vPos);
            this.vPanel.Controls.Add(this.vVolIcon);
            this.vPanel.Controls.Add(this.label1);
            this.vPanel.Location = new System.Drawing.Point(0, 10);
            this.vPanel.Name = "vPanel";
            this.vPanel.Size = new System.Drawing.Size(880, 68);
            this.vPanel.TabIndex = 0;
            this.vPanel.TabStop = false;
            // 
            // aPanel
            // 
            this.aPanel.Controls.Add(this.aNext);
            this.aPanel.Controls.Add(this.aVolume);
            this.aPanel.Controls.Add(this.aPlay);
            this.aPanel.Controls.Add(this.aPrev);
            this.aPanel.Controls.Add(this.aPos);
            this.aPanel.Controls.Add(this.label2);
            this.aPanel.Controls.Add(this.aVolIcon);
            this.aPanel.Location = new System.Drawing.Point(0, 84);
            this.aPanel.Name = "aPanel";
            this.aPanel.Size = new System.Drawing.Size(880, 68);
            this.aPanel.TabIndex = 1;
            this.aPanel.TabStop = false;
            // 
            // rPanel
            // 
            this.rPanel.Controls.Add(this.rNext);
            this.rPanel.Controls.Add(this.rVolume);
            this.rPanel.Controls.Add(this.rPos);
            this.rPanel.Controls.Add(this.rPlay);
            this.rPanel.Controls.Add(this.rPrev);
            this.rPanel.Controls.Add(this.label3);
            this.rPanel.Controls.Add(this.rVolIcon);
            this.rPanel.Location = new System.Drawing.Point(0, 158);
            this.rPanel.Name = "rPanel";
            this.rPanel.Size = new System.Drawing.Size(880, 68);
            this.rPanel.TabIndex = 1;
            this.rPanel.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Video";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vPos
            // 
            this.vPos.Location = new System.Drawing.Point(180, 20);
            this.vPos.Maximum = 1000;
            this.vPos.Name = "vPos";
            this.vPos.Size = new System.Drawing.Size(551, 45);
            this.vPos.TabIndex = 4;
            this.vPos.TickStyle = System.Windows.Forms.TickStyle.None;
            this.vPos.Scroll += new System.EventHandler(this.vPos_Scroll);
            this.vPos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vPos_MouseDown);
            this.vPos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vPos_MouseUp);
            // 
            // vVolume
            // 
            this.vVolume.LargeChange = 1;
            this.vVolume.Location = new System.Drawing.Point(770, 20);
            this.vVolume.Maximum = 100;
            this.vVolume.Name = "vVolume";
            this.vVolume.Size = new System.Drawing.Size(104, 45);
            this.vVolume.TabIndex = 5;
            this.vVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.vVolume.Scroll += new System.EventHandler(this.vVolume_Scroll);
            this.vVolume.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vPos_MouseDown);
            this.vVolume.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vPos_MouseUp);
            // 
            // aVolume
            // 
            this.aVolume.Location = new System.Drawing.Point(770, 19);
            this.aVolume.Maximum = 100;
            this.aVolume.Name = "aVolume";
            this.aVolume.Size = new System.Drawing.Size(104, 45);
            this.aVolume.TabIndex = 10;
            this.aVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.aVolume.Scroll += new System.EventHandler(this.aVolume_Scroll);
            this.aVolume.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vPos_MouseDown);
            this.aVolume.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vPos_MouseUp);
            // 
            // aPos
            // 
            this.aPos.Location = new System.Drawing.Point(180, 20);
            this.aPos.Maximum = 1000;
            this.aPos.Name = "aPos";
            this.aPos.Size = new System.Drawing.Size(551, 45);
            this.aPos.TabIndex = 9;
            this.aPos.TickStyle = System.Windows.Forms.TickStyle.None;
            this.aPos.Scroll += new System.EventHandler(this.aPos_Scroll);
            this.aPos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vPos_MouseDown);
            this.aPos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vPos_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Audio";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rVolume
            // 
            this.rVolume.Location = new System.Drawing.Point(770, 19);
            this.rVolume.Maximum = 100;
            this.rVolume.Name = "rVolume";
            this.rVolume.Size = new System.Drawing.Size(104, 45);
            this.rVolume.TabIndex = 15;
            this.rVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.rVolume.Scroll += new System.EventHandler(this.rVolume_Scroll);
            this.rVolume.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vPos_MouseDown);
            this.rVolume.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vPos_MouseUp);
            // 
            // rPos
            // 
            this.rPos.Location = new System.Drawing.Point(180, 20);
            this.rPos.Maximum = 1000;
            this.rPos.Name = "rPos";
            this.rPos.Size = new System.Drawing.Size(551, 45);
            this.rPos.TabIndex = 14;
            this.rPos.TickStyle = System.Windows.Forms.TickStyle.None;
            this.rPos.Scroll += new System.EventHandler(this.rPos_Scroll);
            this.rPos.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vPos_MouseDown);
            this.rPos.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vPos_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Radio";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // vPrev
            // 
            this.vPrev.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vPrev.Location = new System.Drawing.Point(80, 18);
            this.vPrev.Name = "vPrev";
            this.vPrev.Size = new System.Drawing.Size(24, 24);
            this.vPrev.TabIndex = 1;
            this.vPrev.Text = "|<";
            this.vPrev.UseVisualStyleBackColor = true;
            // 
            // vPlay
            // 
            this.vPlay.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vPlay.Location = new System.Drawing.Point(110, 18);
            this.vPlay.Name = "vPlay";
            this.vPlay.Size = new System.Drawing.Size(24, 24);
            this.vPlay.TabIndex = 2;
            this.vPlay.Text = ">";
            this.vPlay.UseVisualStyleBackColor = true;
            // 
            // vNext
            // 
            this.vNext.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vNext.Location = new System.Drawing.Point(140, 18);
            this.vNext.Name = "vNext";
            this.vNext.Size = new System.Drawing.Size(24, 24);
            this.vNext.TabIndex = 3;
            this.vNext.Text = ">|";
            this.vNext.UseVisualStyleBackColor = true;
            // 
            // aVolIcon
            // 
            this.aVolIcon.Image = global::MyPlot.Properties.Resources.Bitmap1;
            this.aVolIcon.Location = new System.Drawing.Point(745, 20);
            this.aVolIcon.Name = "aVolIcon";
            this.aVolIcon.Size = new System.Drawing.Size(24, 24);
            this.aVolIcon.TabIndex = 7;
            this.aVolIcon.TabStop = false;
            // 
            // rVolIcon
            // 
            this.rVolIcon.Image = global::MyPlot.Properties.Resources.Bitmap1;
            this.rVolIcon.Location = new System.Drawing.Point(745, 20);
            this.rVolIcon.Name = "rVolIcon";
            this.rVolIcon.Size = new System.Drawing.Size(24, 24);
            this.rVolIcon.TabIndex = 14;
            this.rVolIcon.TabStop = false;
            // 
            // vVolIcon
            // 
            this.vVolIcon.Image = global::MyPlot.Properties.Resources.Bitmap1;
            this.vVolIcon.Location = new System.Drawing.Point(745, 20);
            this.vVolIcon.Name = "vVolIcon";
            this.vVolIcon.Size = new System.Drawing.Size(24, 24);
            this.vVolIcon.TabIndex = 2;
            this.vVolIcon.TabStop = false;
            // 
            // aPrev
            // 
            this.aPrev.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aPrev.Location = new System.Drawing.Point(80, 18);
            this.aPrev.Name = "aPrev";
            this.aPrev.Size = new System.Drawing.Size(24, 24);
            this.aPrev.TabIndex = 6;
            this.aPrev.Text = "|<";
            this.aPrev.UseVisualStyleBackColor = true;
            // 
            // aPlay
            // 
            this.aPlay.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aPlay.Location = new System.Drawing.Point(110, 18);
            this.aPlay.Name = "aPlay";
            this.aPlay.Size = new System.Drawing.Size(24, 24);
            this.aPlay.TabIndex = 7;
            this.aPlay.Text = ">";
            this.aPlay.UseVisualStyleBackColor = true;
            // 
            // aNext
            // 
            this.aNext.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aNext.Location = new System.Drawing.Point(140, 18);
            this.aNext.Name = "aNext";
            this.aNext.Size = new System.Drawing.Size(24, 24);
            this.aNext.TabIndex = 8;
            this.aNext.Text = ">|";
            this.aNext.UseVisualStyleBackColor = true;
            // 
            // rPrev
            // 
            this.rPrev.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rPrev.Location = new System.Drawing.Point(80, 18);
            this.rPrev.Name = "rPrev";
            this.rPrev.Size = new System.Drawing.Size(24, 24);
            this.rPrev.TabIndex = 11;
            this.rPrev.Text = "|<";
            this.rPrev.UseVisualStyleBackColor = true;
            // 
            // rPlay
            // 
            this.rPlay.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rPlay.Location = new System.Drawing.Point(110, 18);
            this.rPlay.Name = "rPlay";
            this.rPlay.Size = new System.Drawing.Size(24, 24);
            this.rPlay.TabIndex = 12;
            this.rPlay.Text = ">";
            this.rPlay.UseVisualStyleBackColor = true;
            // 
            // rNext
            // 
            this.rNext.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rNext.Location = new System.Drawing.Point(140, 18);
            this.rNext.Name = "rNext";
            this.rNext.Size = new System.Drawing.Size(24, 24);
            this.rNext.TabIndex = 13;
            this.rNext.Text = ">|";
            this.rNext.UseVisualStyleBackColor = true;
            // 
            // timerControlbar
            // 
            this.timerControlbar.Tick += new System.EventHandler(this.timerControlbar_Tick);
            // 
            // MyPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 648);
            this.Controls.Add(this.playerControlbar);
            this.Controls.Add(this.menuMain);
            this.Controls.Add(this.radioView);
            this.Controls.Add(this.audioView);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.videoView);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuMain;
            this.Name = "MyPlot";
            this.Text = "MyPlot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MyPlot_FormClosed);
            this.Load += new System.EventHandler(this.MyPlot_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MyPlot_KeyPress);
            this.Resize += new System.EventHandler(this.MyPlot_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioView)).EndInit();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.playerControlbar.ResumeLayout(false);
            this.vPanel.ResumeLayout(false);
            this.vPanel.PerformLayout();
            this.aPanel.ResumeLayout(false);
            this.aPanel.PerformLayout();
            this.rPanel.ResumeLayout(false);
            this.rPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rPos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aVolIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rVolIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vVolIcon)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.GroupBox playerControlbar;
        private System.Windows.Forms.GroupBox aPanel;
        private System.Windows.Forms.GroupBox rPanel;
        private System.Windows.Forms.GroupBox vPanel;
        private System.Windows.Forms.TrackBar vVolume;
        private System.Windows.Forms.TrackBar vPos;
        private System.Windows.Forms.PictureBox vVolIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar aVolume;
        private System.Windows.Forms.TrackBar aPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox aVolIcon;
        private System.Windows.Forms.TrackBar rVolume;
        private System.Windows.Forms.TrackBar rPos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox rVolIcon;
        private System.Windows.Forms.Button vNext;
        private System.Windows.Forms.Button vPlay;
        private System.Windows.Forms.Button vPrev;
        private System.Windows.Forms.Button aNext;
        private System.Windows.Forms.Button aPlay;
        private System.Windows.Forms.Button aPrev;
        private System.Windows.Forms.Button rNext;
        private System.Windows.Forms.Button rPlay;
        private System.Windows.Forms.Button rPrev;
        private System.Windows.Forms.Timer timerControlbar;
    }
}

