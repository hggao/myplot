﻿using System;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp;
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using Microsoft.Web.WebView2.Core;
using NAudio.CoreAudioApi;
using NAudio.Wave;


namespace MyPlot
{
    public partial class MyPlot : Form
    {
        private string configFile = null;
        public ConfigureMain playersConfig = null;
        private bool formLoaded = false;

        //LibVLCSharp instances
        public LibVLC _libVLC;
        public MediaPlayer _videoMP;
        public MediaPlayer _audioMP;
        public MediaPlayer _radioMP;

        private VideoControl videoCtrl = null;
        private AudioControl audioCtrl = null;
        private RadioControl radioCtrl = null;

        private WasapiLoopbackCapture capture = null;
        private WaveFormat waveFormat = null;

        //audio visualization
        private const int SAMPLE_LEN = 100;
        private readonly short[] samples;

        public MyPlot()
        {
            //Load the configurations of all player controls.
            playersConfig = new ConfigureMain(configFile);

            if (!DesignMode)
            {
                Core.Initialize();
            }

            InitializeComponent();

            _libVLC = new LibVLC();

            _videoMP = new MediaPlayer(_libVLC);
            _videoMP.SetRole(MediaPlayerRole.Video);
            _videoMP.EndReached += VideoPlayer_EndReached;
            _videoMP.Playing += VideoPlayer_Playing;
            videoView.MediaPlayer = _videoMP;
            videoView.MouseWheel += videoView_MouseWheel;
            videoCtrl = new VideoControl(this);
            playersConfig.configData.mainPlayerConfig.player_status = (int)PlayerStatus.Unknown;

            _audioMP = new MediaPlayer(_libVLC);
            _audioMP.SetRole(MediaPlayerRole.Music);
            _audioMP.EndReached += AudioPlayer_EndReached;
            _audioMP.Playing += AudioPlayer_Playing;
            audioView.MediaPlayer = _audioMP;
            audioCtrl = new AudioControl(this);
            playersConfig.configData.audioPlayerConfig.player_status = (int)PlayerStatus.Unknown;

            _radioMP = new MediaPlayer(_libVLC);
            _radioMP.SetRole(MediaPlayerRole.Music);
            _radioMP.EndReached += RadioPlayer_EndReached;
            radioView.MediaPlayer = _radioMP;
            radioCtrl = new RadioControl(this);
            playersConfig.configData.radioPlayerConfig.player_status = (int)PlayerStatus.Unknown;

            samples = new short[SAMPLE_LEN];
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        private async void MyPlot_Load(object sender, EventArgs e)
        {
            //Special waiting for webView2 control done its initialization
            webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
            Debug.WriteLine("before InitializeAsync");
            await InitializeAsync();
            Debug.WriteLine("after InitializeAsync");
            if ((webView == null) || (webView.CoreWebView2 == null))
            {
                Debug.WriteLine("!!!===Not Ready, shouldn't be.===");

            }
            webView.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;

            //Setup audio related: round region and capture for visualization
            audioView.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, audioView.Width, audioView.Height, 20, 20));
            capture = new WasapiLoopbackCapture();
            waveFormat = capture.WaveFormat;
            capture.DataAvailable += OnWaveInDataAvailable;

            //Radio round corner region
            radioView.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, radioView.Width, radioView.Height, 20, 20));
            radioPicBox.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, radioPicBox.Width, radioPicBox.Height, 20, 20));


            //In Chinese Windows, app would receive resize event much earlier before all controls are actually created
            //So that we use this flag to indicate would could only do resize after this flag set.
            formLoaded = true;

            //Based on configration to set all controls appearance
            SetPlayerControlAppearance();

            //Start the real works of each players
            VideoPlayerStart();
            WebPlayerStart();
            AudioPlayerStart();
            RadioPlayerStart();

        }

        private void MyPlot_FormClosed(object sender, FormClosedEventArgs e)
        {
            _videoMP.Stop();
            _videoMP.Dispose();
            _audioMP.Stop();
            _audioMP.Dispose();
            _radioMP.Stop();
            _radioMP.Dispose();
            _libVLC.Dispose();

            capture?.Dispose();
        }

        private async Task InitializeAsync()
        {
            Debug.WriteLine("InitializeAsync");
            await webView.EnsureCoreWebView2Async(null);
            Debug.WriteLine("WebView2 Runtime version: " + webView.CoreWebView2.Environment.BrowserVersionString);
        }

        private void WebView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            Debug.WriteLine("WebView_CoreWebView2InitializationCompleted");
        }

        private void CoreWebView2_NewWindowRequested(object sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            e.NewWindow = (CoreWebView2)sender;
        }

        private void MyPlot_Move(object sender, EventArgs e)
        {
            relocateVideoControl();
            relocateAudioControl();
            relocateRadioControl();
        }

        private void MyPlot_Resize(object sender, EventArgs e)
        {
            //In some windows, we found form resize was called before form loaded, if so we are not ready yet
            if (!formLoaded)
            {
                return;
            }
            SetPlayerControlAppearance();
            relocateVideoControl();
            relocateAudioControl();
            relocateRadioControl();
        }

        private void SetPlayerControlAppearance()
        {
            SetVideoviewAppearance();
            SetAudioViewAppearance();
            SetWebViewAppearance();
            SetRadioviewAppearance();
        }

        private void SetVideoviewAppearance()
        {
            //Video player has the top priority, if it is enabled, it would occupy the whole client area
            if (playersConfig.configData.mainPlayerConfig.enabled)
            {
                Size newSize = new Size(ClientSize.Width, ClientSize.Height - menuMain.Height);
                Point newLoc = new Point(0, menuMain.Height);
                if (this.FormBorderStyle == FormBorderStyle.None) //Expand to all when full screen mode
                {
                    newSize = ClientSize;
                    newLoc = new Point(0, 0);
                }
                videoView.Location = newLoc;
                videoView.Size = newSize;
                videoView.Visible = true;
                videoView.Focus();
            }
            else
            {
                videoView.Visible = false;
            }
        }

        private void SetAudioViewAppearance()
        {
            Size newSize = ClientSize;

            //Set Audio player at the bottom left if video/web enalbed, otherwise put it at center.
            if (playersConfig.configData.audioPlayerConfig.enabled)
            {
                audioView.Location = new Point(64, 32);
                audioView.Visible = true;
                timerAudio.Enabled = true;
                if (capture != null && capture.CaptureState == CaptureState.Stopped)
                {
                    capture.StartRecording();
                }
            }
            else
            {
                audioView.Visible = false;
                timerAudio.Enabled = false;
                if (capture != null && capture.CaptureState == CaptureState.Capturing)
                {
                    capture.StopRecording();
                }
            }
        }

        private void SetWebViewAppearance()
        {
            Size newSize = ClientSize;

            //Web player has the second priority, it video player isn't enabled, it would occupy the whole client area
            if (playersConfig.configData.webPlayerConfig.enabled)
            {
                newSize = ClientSize;
                if (playersConfig.configData.mainPlayerConfig.enabled)
                {
                    newSize.Width = ClientSize.Width * 4 / 10;
                    newSize.Height = ClientSize.Height * 4 / 10;
                    webView.Location = new Point(ClientSize.Width - newSize.Width - 12, ClientSize.Height - newSize.Height - 12);
                }
                else
                {
                    newSize.Height = ClientSize.Height - menuMain.Height;
                    webView.Location = new Point(0, menuMain.Height);
                }
                webView.Size = newSize;
                webView.Visible = true;
                webView.BringToFront();
            }
            else
            {
                webView.Visible = false;
            }
        }

        private void SetRadioviewAppearance()
        {
            Size newSize = ClientSize;

            //Set Radio player at the bottom left if video/web enalbed, otherwise put it at center.
            //NOTE: We assume Audio and Radio don't exist together
            if (playersConfig.configData.radioPlayerConfig.enabled)
            {
                radioView.Location = new Point(ClientSize.Width - radioView.Width - 64, 32);
                radioPicBox.Location = radioView.Location;
                radioView.Visible = true;
                radioPicBox.Visible = true;
            }
            else
            {
                radioView.Visible = false;
                radioPicBox.Visible = false;
            }
        }

        private string web_pageStart = "<html><head><meta http-equiv=\"refresh\" content=\"0; url=";
        private string web_pageMid = "\"><title>Initial Page</title></head><body><br><br><h1 align=\"center\" style=\"color:red\">Cannot navigate to [";
        private string web_pageEnd = "]! Check the URL you supplied in config!</h1></body></html>";
        private void WebPlayerStart()
        {
            if (webView.Visible == false)
            {
                return;
            }
            if (playersConfig.configData.webPlayerConfig.web_urls.Count < 1)
            {
                return;
            }
            string url = playersConfig.configData.webPlayerConfig.web_urls[0];
            webView.NavigateToString(web_pageStart + url + web_pageMid + url + web_pageEnd);
        }

        private void RadioPlayerStart()
        {
            if (radioView.Visible == false)
            {

                return;
            }
            if (playersConfig.configData.radioPlayerConfig.radio_urls.Count < 1)
            {
                return;
            }
            Debug.WriteLine("======Prepare to play the first radio URL");
            string firstRadio = playersConfig.configData.radioPlayerConfig.radio_urls[0];
            radioView.MediaPlayer.Volume = playersConfig.configData.radioPlayerConfig.volume;
            var media = new Media(_libVLC, new Uri(firstRadio));
            radioView.MediaPlayer.Play(media);
            Debug.WriteLine("======Radio start playing");
            Debug.WriteLine(firstRadio);
            media.Dispose();
        }

        private void RadioPlayer_EndReached(object sender, EventArgs e)
        {
            //Assume radio strem URL could be playing forever
        }

        private void RadioPlayerStop()
        {
            if (radioView.Visible == false)
            {
                return;
            }
            if (radioView.MediaPlayer.IsPlaying)
            {
                radioView.MediaPlayer.Stop();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "config");
            ofd.Filter = "MyPlot playlist(*.myplot.json)|*.myplot.json";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                RestartPlayerWithNewConfig(ofd.FileName, null);
            }
        }

        private void openAddMediaFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            string video_filter = String.Format("Video file({0})|{0}", GlobalDefs.GetVideoFilter());
            string photo_filter = String.Format("Photo file({0})|{0}", GlobalDefs.GetPhotoFilter());
            string audio_filter = String.Format("Audio file({0})|{0}", GlobalDefs.GetAudioFilter());
            string all_filter = String.Format("All files({0})|{0}", GlobalDefs.GetAllFilter());
            ofd.Filter = String.Format("{0}|{1}|{2}|{3}", video_filter, photo_filter, audio_filter, all_filter);
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                MediaType type = GlobalDefs.GetMediaType(ofd.FileName);
                int count = playersConfig.AddMediaToConfigure(ofd.FileName, type);
                if (count == 1)
                {
                    SetPlayerControlAppearance();
                }
                switch (type)
                {
                    case MediaType.Video:
                        if (!_videoMP.IsPlaying)
                        {
                            playersConfig.configData.mainPlayerConfig.play_index = count - 2;
                            VideoPlayerPlayNext();
                        }
                        break;
                    case MediaType.Audio:
                        if (!_audioMP.IsPlaying)
                        {
                            playersConfig.configData.audioPlayerConfig.play_index = count - 2;
                            AudioPlayerPlayNext();
                        }
                        break;
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlaylistSetup plSetup = new PlaylistSetup(this.playersConfig);
            plSetup.configFile = this.configFile;
            plSetup.StartPosition = FormStartPosition.Manual;
            plSetup.Location = this.PointToScreen(new Point(64, 36));
            if (plSetup.ShowDialog() == DialogResult.OK)
            {
                RestartPlayerWithNewConfig(plSetup.configFile, plSetup.config);
            }
        }

        private void RestartPlayerWithNewConfig(string newConfigFile, ConfigureMain newConfig)
        {
            //TODO: check if config didn't change, then return without doing anything

            VideoPlayerStop();
            AudioPlayerStop();
            RadioPlayerStop();

            configFile = newConfigFile;
            if (newConfig == null)
            {
                playersConfig = new ConfigureMain(configFile);
            }
            else
            {
                playersConfig = newConfig;
            }

            SetPlayerControlAppearance();
            VideoPlayerStart(); 
            WebPlayerStart();
            AudioPlayerStart();
            RadioPlayerStart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void userGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string helpStr = "";
            helpStr += "Keyboard controls:\n";
            helpStr += "    ESC: Show or hide menu\n";
            helpStr += "    Tab: Switch control input focus\n";
            helpStr += "    Space: Show or hide volume control\n";
            helpStr += "    a/A: Yaw 360° view point left\n";
            helpStr += "    d/D: Yaw 360° view point right\n";
            helpStr += "    w/W: Pitch 360° view point up\n";
            helpStr += "    s/S: Pitch 360° view point down\n";
            helpStr += "    q/Q: Roll 360° view point left\n";
            helpStr += "    e/E: Roll 360° view point right\n";
            helpStr += "    r/R: Increase 360° FOV (wider angel)\n";
            helpStr += "    f/F: Decrease 360° FOV (smaller angel of view)\n";
            helpStr += "    c/C: Reset(re-center) 360° view point to default\n\n";
            helpStr += "Mouse controls:\n";
            helpStr += "    In 360° view, hold down left mouse button to drag view point\n";
            helpStr += "    In 360° view, use mouse wheel to control FOV\n";
            MessageBox.Show(helpStr);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MyPlot Ver 0.11 build 20211115. Copyright Reserved!");
        }

        private void MyPlot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) // ESC
            {
                //QUit full screen if it is
                if (this.FormBorderStyle == FormBorderStyle.None)
                {
                    ToogleFullScreenMode();
                }
            }
        }

        public void ToogleFullScreenMode()
        {
            if (FormBorderStyle == FormBorderStyle.None)
            {
                //flip to normal mode
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                menuMain.Visible = true;
            }
            else
            {
                //flip to full screen mode
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                if (playersConfig.configData.mainPlayerConfig.enabled)
                    menuMain.Visible = false;
            }
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToogleFullScreenMode();
        }

        private void webView_KeyDown(object sender, KeyEventArgs e)
        {
            Focus();
        }

        private void enableDisableVideo_Click(object sender, EventArgs e)
        {
            if (playersConfig.configData.mainPlayerConfig.enabled)
            {
                playersConfig.configData.mainPlayerConfig.enabled = false;
                VideoPlayerStop();
                SetPlayerControlAppearance();
            }
            else
            {
                playersConfig.configData.mainPlayerConfig.enabled = true;
                SetPlayerControlAppearance();
                VideoPlayerStart();
            }
        }

        private void enableDisableAudio_Click(object sender, EventArgs e)
        {
            if (playersConfig.configData.audioPlayerConfig.enabled)
            {
                playersConfig.configData.audioPlayerConfig.enabled = false;
                AudioPlayerStop();
                SetAudioViewAppearance();
            }
            else
            {
                playersConfig.configData.audioPlayerConfig.enabled = true;
                SetAudioViewAppearance();
                AudioPlayerStart();
            }
        }

        private void enableDisableWeb_Click(object sender, EventArgs e)
        {
            if (playersConfig.configData.webPlayerConfig.enabled)
            {
                playersConfig.configData.webPlayerConfig.enabled = false;
                SetWebViewAppearance();
            }
            else
            {
                playersConfig.configData.webPlayerConfig.enabled = true;
                SetWebViewAppearance();
                WebPlayerStart();
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webView.Visible && playersConfig.configData.webPlayerConfig.web_urls.Count > 0)
            {
                string url = playersConfig.configData.webPlayerConfig.web_urls[0];
                webView.NavigateToString(web_pageStart + url + web_pageMid + url + web_pageEnd);
            }
        }

        private void forwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webView.Visible && webView.CanGoForward)
            {
                webView.GoForward();
            }
        }

        private void backwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (webView.Visible && webView.CanGoBack)
            {
                webView.GoBack();
            }
        }

        private void enableDisableRadio_Click(object sender, EventArgs e)
        {
            if (playersConfig.configData.radioPlayerConfig.enabled)
            {
                playersConfig.configData.radioPlayerConfig.enabled = false;
                RadioPlayerStop();
                SetRadioviewAppearance();
            }
            else
            {
                playersConfig.configData.radioPlayerConfig.enabled = true;
                SetRadioviewAppearance();
                RadioPlayerStart();
            }
        }

        private void relocateRadioControl()
        {
            if (radioCtrl.Visible)
            {
                radioCtrl.Location = PointToScreen(new Point(radioView.Location.X - radioCtrl.Width, radioView.Location.Y));
            }
        }

        private void ToogleRadioCtrlVisible()
        {
            if (radioCtrl.Visible)
            {
                radioCtrl.Hide();
            }
            else
            {
                radioCtrl.Show();
                relocateRadioControl();
            }
        }

        private void radioPicBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToogleRadioCtrlVisible();
            }
        }
    }
}