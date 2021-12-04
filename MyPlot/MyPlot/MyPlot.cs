using System;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp;
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using Microsoft.Web.WebView2.Core;


namespace MyPlot
{
    public partial class MyPlot : Form
    {
        private string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "config\\default.myplot.json"); 
        public ConfigureMain playersConfig = null;
        private bool formLoaded = false;

        //LibVLCSharp instances
        public LibVLC _libVLC;
        public MediaPlayer _videoMP;
        public MediaPlayer _audioMP;
        public MediaPlayer _radioMP;

        private VideoControl videoCtrl = null;

        //Runtime flags
        private bool mouseButtonDown = false;

        public MyPlot()
        {
            //Load the configurations of all player controls.
            playersConfig = new ConfigureMain();
            playersConfig.LoadConfigure(configFile);

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

            _audioMP = new MediaPlayer(_libVLC);
            _audioMP.SetRole(MediaPlayerRole.Music);
            _audioMP.EndReached += AudioPlayer_EndReached;
            audioView.MediaPlayer = _audioMP;

            _radioMP = new MediaPlayer(_libVLC);
            _radioMP.SetRole(MediaPlayerRole.Music);
            _radioMP.EndReached += RadioPlayer_EndReached;
            radioView.MediaPlayer = _radioMP;
        }

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
            timerControlbar.Dispose();
            _videoMP.Stop();
            _videoMP.Dispose();
            _audioMP.Stop();
            _audioMP.Dispose();
            _radioMP.Stop();
            _radioMP.Dispose();
            _libVLC.Dispose();
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
        }

        private void MyPlot_Resize(object sender, EventArgs e)
        {
            SetPlayerControlAppearance();
            relocateVideoControl();
        }

        private void SetPlayerControlAppearance()
        {
            //In some windows, we found form resize was called before form loaded, if so we are not ready yet
            if (!formLoaded)
            {
                return;
            }

            SetVideoviewAppearance();
            SetAudioViewAppearance();
            SetWebViewAppearance();
            SetRadioviewAppearance();

            //===== Global control above all the four players.
            MayHideMenu();

            int pX = 0;
            int pY = 0;
            if (ClientSize.Width > playerControlbar.Width)
            {
                pX = (ClientSize.Width - playerControlbar.Width) / 2;
            }
            if (ClientSize.Height - playerControlbar.Height > 20)
            {
                pY = ClientSize.Height - playerControlbar.Height - 20;
            }
            playerControlbar.Location = new Point(pX, pY);
            playerControlbar.Visible = false;

            labelViewInfo.Visible = false;
        }

        private void SetVideoviewAppearance()
        {
            Size newSize = ClientSize;

            //Video player has the top priority, if it is enabled, it would occupy the whole client area
            if (playersConfig.configData.mainPlayerConfig.enabled)
            {
                videoView.Location = new Point(0, 0);
                videoView.Size = newSize;
                videoView.Visible = true;
                videoView.Focus();
                vPanel.Enabled = true;
            }
            else
            {
                videoView.Visible = false;
                vPanel.Enabled = false;
            }
        }

        private void SetAudioViewAppearance()
        {
            Size newSize = ClientSize;

            //Set Audio player at the bottom left if video/web enalbed, otherwise put it at center.
            if (playersConfig.configData.audioPlayerConfig.enabled)
            {
                if (playersConfig.configData.mainPlayerConfig.enabled || playersConfig.configData.webPlayerConfig.enabled)
                {
                    audioView.Location = new Point(64, 32);
                }
                else
                {
                    audioView.Location = new Point((ClientSize.Width - audioView.Width) / 2, (ClientSize.Height - audioView.Height) / 2);
                }
                audioPicBox.Location = audioView.Location;
                audioView.Visible = true;
                aPanel.Enabled = true;
                audioPicBox.Visible = true;
            }
            else
            {
                audioView.Visible = false;
                aPanel.Enabled = false;
                audioPicBox.Visible = false;
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
                    newSize.Height = ClientSize.Height - 24;
                    webView.Location = new Point(0, 24);
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
                if (playersConfig.configData.mainPlayerConfig.enabled || playersConfig.configData.webPlayerConfig.enabled)
                {
                    radioView.Location = new Point(ClientSize.Width - radioView.Width - 64, 32);

                }
                else
                {
                    radioView.Location = new Point((ClientSize.Width - audioView.Width) / 2, (ClientSize.Height - audioView.Height) / 2);
                }
                radioPicBox.Location = radioView.Location;
                radioView.Visible = true;
                rPanel.Enabled = true;
                radioPicBox.Visible = true;
            }
            else
            {
                radioView.Visible = false;
                rPanel.Enabled = false;
                radioPicBox.Visible = false;
            }
        }

        private void WebPlayerStart()
        {
            if (webView.Visible == false)
            {
                return;
            }

            webView.NavigateToString(System.IO.File.ReadAllText(playersConfig.configData.webPlayerConfig.web_urls[0]));
        }

        private void AudioPlayerStart()
        {
            if (audioView.Visible == false)
            {
                return;
            }

            AudioPlayerConfig config = playersConfig.configData.audioPlayerConfig;
            config.play_index = -1;
            config.play_position = 0.0f;
            config.play_speed = 1.0f;
            audioView.MediaPlayer.Volume = config.volume;
            AudioPlayerPlayNext();
        }

        public void AudioPlayerPlayNext()
        {
            AudioPlayerConfig config = playersConfig.configData.audioPlayerConfig;

            //TODO: add looping, reshuffle flags later. Now we loop it without reshuffle by default
            config.play_index = (config.play_index + 1) % config.audio_files.Count;
            var media = new Media(_libVLC, new Uri(config.audio_files[config.play_index]));
            audioView.MediaPlayer.Play(media);
            Debug.WriteLine("======Playing audio started");
            Debug.WriteLine(config.audio_files[config.play_index]);
            media.Dispose();
        }

        private void AudioPlayer_EndReached(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(AudioPlayerPlayNext));
            t.Start();
        }

        private void AudioPlayerStop()
        {
            if (audioView.Visible == false)
            {
                return;
            }
            if (audioView.MediaPlayer.IsPlaying)
            {
                audioView.MediaPlayer.Stop();
            }
        }

        private void RadioPlayerStart()
        {
            if (radioView.Visible == false)
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
            ofd.Filter = "MyPlot Config (*.myplot.json)|*.myplot.json";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                RestartPlayerWithNewConfig(ofd.FileName);
            }
            MayHideMenu();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsDialog settingDlg = new SettingsDialog();
            settingDlg.configFile = configFile;
            settingDlg.StartPosition = FormStartPosition.Manual;
            settingDlg.Location = this.PointToScreen(new Point(64, 36));
            if (settingDlg.ShowDialog() == DialogResult.OK)
            {
                RestartPlayerWithNewConfig(settingDlg.configFile);
            }
            MayHideMenu();
        }

        private void RestartPlayerWithNewConfig(string newConfigFile)
        {
            if (configFile != newConfigFile)
            {
                VideoPlayerStop();
                AudioPlayerStop();
                RadioPlayerStop();
                if (newConfigFile != null)
                {
                    configFile = newConfigFile;
                    playersConfig = new ConfigureMain();
                    playersConfig.LoadConfigure(configFile);
                }
                SetPlayerControlAppearance();
                VideoPlayerStart();
                WebPlayerStart();
                AudioPlayerStart();
                RadioPlayerStart();
            }
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
            MayHideMenu();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MyPlot Ver 0.11 build 20211115. Copyright Reserved!");
            MayHideMenu();
        }

        private void MyPlot_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27) // ESC
            {
                if (menuMain.Visible)
                {
                    MayHideMenu();
                }
                else
                {
                    menuMain.Visible = true;
                }
                e.Handled = true;
                return;
            }
            if (e.KeyChar == ' ')
            {
                if (playerControlbar.Visible)
                {
                    timerControlbar.Enabled = false;
                    playerControlbar.Visible = false;
                }
                else
                {
                    playerControlbar.Visible = true;
                    playerControlbar.Focus();
                    playerControlbar.BringToFront();
                    timerControlbar.Enabled = true;
                }
                e.Handled = true;
                return;
            }

            e.Handled = false;
        }

        private void MayHideMenu()
        {
            if (!playersConfig.configData.mainPlayerConfig.enabled && playersConfig.configData.webPlayerConfig.enabled)
            {
                return;
            }
            if (menuMain.Visible && playersConfig != null && 
                (playersConfig.configData.mainPlayerConfig.enabled || playersConfig.configData.webPlayerConfig.enabled))
            {
                menuMain.Visible = false;
            }
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormBorderStyle == FormBorderStyle.None)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
            } else
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
        }

        private void timerControlbar_Tick(object sender, EventArgs e)
        {
            if (!playerControlbar.Visible)
            {
                return;
            }
            UpdateControlbarValues();
        }

        private void UpdateControlbarValues()
        {
            if (playersConfig == null) return;

            if (vPanel.Enabled)
            {
                if (videoView.MediaPlayer.IsPlaying)
                {
                    vPlay.Text = "II";
                }
                else
                {
                    vPlay.Text = ">";
                }
                if (!vPos.ContainsFocus || !mouseButtonDown)
                {
                    int pos = (int)(videoView.MediaPlayer.Position * vPos.Maximum);
                    vPos.Value = pos >= 0 ? pos : 0;
                }
                if (!vVolume.ContainsFocus || !mouseButtonDown)
                {
                    int vol = videoView.MediaPlayer.Volume;
                    vVolume.Value = vol >= 0 ? vol : 0;
                }
            }

            if (aPanel.Enabled)
            {
                if (audioView.MediaPlayer.IsPlaying)
                {
                    aPlay.Text = "II";
                }
                else
                {
                    aPlay.Text = ">";
                }
                if (!aPos.ContainsFocus || !mouseButtonDown)
                {
                    int pos = (int)(audioView.MediaPlayer.Position * aPos.Maximum);
                    aPos.Value = pos >= 0 ? pos : 0;
                }
                if (!aVolume.ContainsFocus || !mouseButtonDown)
                {
                    int vol = audioView.MediaPlayer.Volume;
                    aVolume.Value = vol >=0 ? vol : 0;
                }
            }

            if (rPanel.Enabled)
            {
                if (radioView.MediaPlayer.IsPlaying)
                {
                    rPlay.Text = "II";
                }
                else
                {
                    rPlay.Text = ">";
                }
                if (!rPos.ContainsFocus || !mouseButtonDown)
                {
                    int pos = (int)(radioView.MediaPlayer.Position * rPos.Maximum);
                    rPos.Value = pos >= 0 ? pos : 0;
                }
                if (!rVolume.ContainsFocus || !mouseButtonDown)
                {
                    int vol = radioView.MediaPlayer.Volume;
                    rVolume.Value = vol >= 0 ? vol : 0;
                }
            }
        }

        private void vPos_MouseDown(object sender, MouseEventArgs e)
        {
            mouseButtonDown = true;
        }

        private void vPos_MouseUp(object sender, MouseEventArgs e)
        {
            mouseButtonDown = false;
        }

        private void vPos_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            float newPos = (float)tb.Value / (float)tb.Maximum;
            videoView.MediaPlayer.Position = newPos;
        }

        private void vVolume_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            playersConfig.configData.mainPlayerConfig.volume = tb.Value;
            videoView.MediaPlayer.Volume = tb.Value;
        }

        private void aPos_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            float newPos = (float)tb.Value / (float)tb.Maximum;
            audioView.MediaPlayer.Position = newPos;
        }

        private void aVolume_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            playersConfig.configData.audioPlayerConfig.volume = tb.Value;
            audioView.MediaPlayer.Volume = tb.Value;
        }

        private void rPos_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            float newPos = (float)tb.Value / (float)tb.Maximum;
            radioView.MediaPlayer.Position = newPos;
        }

        private void rVolume_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            playersConfig.configData.radioPlayerConfig.volume = tb.Value;
            radioView.MediaPlayer.Volume = tb.Value;
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
            }
            else
            {
                playersConfig.configData.mainPlayerConfig.enabled = true;
            }
            RestartPlayerWithNewConfig(null);
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
            if (webView.Visible)
            {
                webView.NavigateToString(System.IO.File.ReadAllText(playersConfig.configData.webPlayerConfig.web_urls[0]));
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
    }
}