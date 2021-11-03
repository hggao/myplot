
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyPlot));
            this.vlcCtrlMain = new Vlc.DotNet.Forms.VlcControl();
            this.vlcCtrlAudio = new Vlc.DotNet.Forms.VlcControl();
            this.vlcCtrlRadio = new Vlc.DotNet.Forms.VlcControl();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.vlcCtrlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcCtrlAudio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcCtrlRadio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // vlcCtrlMain
            // 
            this.vlcCtrlMain.BackColor = System.Drawing.Color.Black;
            this.vlcCtrlMain.Location = new System.Drawing.Point(0, 0);
            this.vlcCtrlMain.Name = "vlcCtrlMain";
            this.vlcCtrlMain.Size = new System.Drawing.Size(1092, 669);
            this.vlcCtrlMain.Spu = -1;
            this.vlcCtrlMain.TabIndex = 0;
            this.vlcCtrlMain.Text = "vlcCtrlMain";
            this.vlcCtrlMain.VlcLibDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("vlcCtrlMain.VlcLibDirectory")));
            this.vlcCtrlMain.VlcMediaplayerOptions = null;
            this.vlcCtrlMain.EndReached += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerEndReachedEventArgs>(this.vlcCtrlMain_EndReached);
            this.vlcCtrlMain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.vlcCtrlMain_KeyPress);
            // 
            // vlcCtrlAudio
            // 
            this.vlcCtrlAudio.BackColor = System.Drawing.Color.LawnGreen;
            this.vlcCtrlAudio.Location = new System.Drawing.Point(12, 462);
            this.vlcCtrlAudio.Name = "vlcCtrlAudio";
            this.vlcCtrlAudio.Size = new System.Drawing.Size(737, 196);
            this.vlcCtrlAudio.Spu = -1;
            this.vlcCtrlAudio.TabIndex = 1;
            this.vlcCtrlAudio.Text = "vlcCtrlAudio";
            this.vlcCtrlAudio.VlcLibDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("vlcCtrlAudio.VlcLibDirectory")));
            this.vlcCtrlAudio.VlcMediaplayerOptions = null;
            this.vlcCtrlAudio.EndReached += new System.EventHandler<Vlc.DotNet.Core.VlcMediaPlayerEndReachedEventArgs>(this.vlcCtrlAudio_EndReached);
            // 
            // vlcCtrlRadio
            // 
            this.vlcCtrlRadio.BackColor = System.Drawing.Color.Gold;
            this.vlcCtrlRadio.Location = new System.Drawing.Point(766, 12);
            this.vlcCtrlRadio.Name = "vlcCtrlRadio";
            this.vlcCtrlRadio.Size = new System.Drawing.Size(316, 444);
            this.vlcCtrlRadio.Spu = -1;
            this.vlcCtrlRadio.TabIndex = 2;
            this.vlcCtrlRadio.Text = "vlcCtrlRadio";
            this.vlcCtrlRadio.VlcLibDirectory = ((System.IO.DirectoryInfo)(resources.GetObject("vlcCtrlRadio.VlcLibDirectory")));
            this.vlcCtrlRadio.VlcMediaplayerOptions = null;
            // 
            // webView21
            // 
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(766, 462);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(316, 196);
            this.webView21.TabIndex = 3;
            this.webView21.ZoomFactor = 1D;
            // 
            // MyPlot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 823);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.vlcCtrlRadio);
            this.Controls.Add(this.vlcCtrlAudio);
            this.Controls.Add(this.vlcCtrlMain);
            this.Name = "MyPlot";
            this.Text = "MyPlot";
            this.Load += new System.EventHandler(this.MyPlot_Load);
            this.Resize += new System.EventHandler(this.MyPlot_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.vlcCtrlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcCtrlAudio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlcCtrlRadio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Vlc.DotNet.Forms.VlcControl vlcCtrlMain;
        private Vlc.DotNet.Forms.VlcControl vlcCtrlAudio;
        private Vlc.DotNet.Forms.VlcControl vlcCtrlRadio;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}

