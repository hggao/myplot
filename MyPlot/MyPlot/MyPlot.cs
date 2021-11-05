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

namespace MyPlot
{
    public partial class MyPlot : Form
    {
        private string configFile = @"C:\Users\hongg\Documents\GitHub\myplot\MyPlot\MyPlot\bin\Debug\config\video_only.myplot.json";
        private ConfigureMain playersConfig = null;

        //LibVLCSharp instances
        public LibVLC _libVLC;
        public MediaPlayer _videoMP;
        public MediaPlayer _audioMP;
        public MediaPlayer _radioMP;

        public MyPlot()
        {
            if (!DesignMode)
            {
                Core.Initialize();
            }

            InitializeComponent();

            _libVLC = new LibVLC();

            _videoMP = new MediaPlayer(_libVLC);
            _videoMP.SetRole(MediaPlayerRole.Video);
            _videoMP.EndReached += VideoPlayer_EndReached;
            videoView.MediaPlayer = _videoMP;

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
            //Load the configurations of all player controls.
            playersConfig = new ConfigureMain();
            playersConfig.LoadConfigure(configFile);

            //Special waiting for webView2 control done its initialization
            webView21.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted;
            Debug.WriteLine("before InitializeAsync");
            await InitializeAsync();
            Debug.WriteLine("after InitializeAsync");
            if ((webView21 == null) || (webView21.CoreWebView2 == null))
            {
                Debug.WriteLine("not ready");
            }

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
        }

        private async Task InitializeAsync()
        {
            Debug.WriteLine("InitializeAsync");
            await webView21.EnsureCoreWebView2Async(null);
            Debug.WriteLine("WebView2 Runtime version: " + webView21.CoreWebView2.Environment.BrowserVersionString);
        }

        private void WebView_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
        {
            Debug.WriteLine("WebView_CoreWebView2InitializationCompleted");
        }

        private void MyPlot_Resize(object sender, EventArgs e)
        {
            SetPlayerControlAppearance();
        }

        private void SetPlayerControlAppearance()
        {
            Size newSize = ClientSize;

            //Set Video player to occupy the whole client area.
            if (playersConfig.configData.mainPlayerConfig.enabled)
            {
                videoView.Location = new Point(0, 0);
                videoView.Size = newSize;
                videoView.Visible = true;
            } else
            {
                videoView.Visible = false;
            }

            //Set Web player at the bottom right corner
            if (playersConfig.configData.pipPlayerConfig.enabled)
            {
                newSize.Width = ClientSize.Width / 3;
                newSize.Height = ClientSize.Height / 3;
                webView21.Location = new Point(ClientSize.Width - newSize.Width, ClientSize.Height - newSize.Height);
                webView21.Size = newSize;
                webView21.Visible = true;
            }
            else
            {
                webView21.Visible = false;
            }
            //webView21.NavigateToString(System.IO.File.ReadAllText("browse_index.html"));

            //Set Audio player at the bottom left
            if (playersConfig.configData.audioPlayerConfig.enabled)
            {
                audioView.Location = new Point(68, 12);
                //newSize.Width = 96;
                //newSize.Height = 54;
                //audioView.Size = newSize;

                audioView.Visible = true;
            }
            else
            {
                audioView.Visible = false;
            }

            //Set Radio player at the right up
            if (playersConfig.configData.radioPlayerConfig.enabled)
            {
                //newSize.Width = 96;
                //newSize.Height = 54;
                //radioView.Size = newSize;
                radioView.Location = new Point(180, 12);
                radioView.Visible = true;
            }
            else
            {
                radioView.Visible = false;
            }

            //===== Global control above all the four players.
            menuMain.Visible = false;

        }

        private void VideoPlayerStart()
        {
            if (videoView.Visible == false)
            {
                return;
            }

            MainPlayerConfig config = playersConfig.configData.mainPlayerConfig;
            config.play_index = -1;
            config.play_position = 0.0f;
            config.play_speed = 1.0f;
            videoView.MediaPlayer.Volume = config.volume;
            VideoPlayerPlayNext();
        }

        public void VideoPlayerPlayNext()
        {
            MainPlayerConfig config = playersConfig.configData.mainPlayerConfig;

            //TODO: add looping, reshuffle flags later. Now we loop it without reshuffle by default
            config.play_index = (config.play_index + 1) % config.media_files.Count;
            var media = new Media(_libVLC, new Uri(config.media_files[config.play_index]));
            videoView.MediaPlayer.Play(media);
            videoView.MediaPlayer.UpdateViewpoint(0, 0, 0, 115);
            media.Dispose();
        }

        private void VideoPlayer_EndReached(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(VideoPlayerPlayNext));
            t.Start();
        }

        private void VideoPlayerStop()
        {
            if (videoView.Visible == false)
            {
                return;
            }
            if (videoView.MediaPlayer.IsPlaying)
            {
                videoView.MediaPlayer.Stop();
            }
        }

        private void WebPlayerStart()
        {
            if (webView21.Visible == false)
            {
                return;
            }

            webView21.NavigateToString(System.IO.File.ReadAllText("browse_index.html"));
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

            string firstRadio = playersConfig.configData.radioPlayerConfig.radio_urls[0];
            radioView.MediaPlayer.Volume = playersConfig.configData.radioPlayerConfig.volume;
            var media = new Media(_libVLC, new Uri(firstRadio));
            radioView.MediaPlayer.Play(media);
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

        private void videoView_KeyPress(object sender, KeyPressEventArgs e)
        {
            string controlKeys = "aAdDsSwWqQeEfFrR ";
            if (videoView.MediaPlayer.Media.Tracks[0].Data.Video.Projection == VideoProjection.Equirectangular &&
                controlKeys.Contains(e.KeyChar.ToString()))
            {
                VideoUpdateViewPoint(e.KeyChar);
                return;
            }

            if (e.KeyChar == 27) // ESC
            {
                if (menuMain.Visible)
                {
                    menuMain.Visible = false;
                }
                else
                {
                    menuMain.Visible = true;
                }
            }
        }

        private void VideoUpdateViewPoint(char keyChar)
        { 
            float delta = 1.0f;
            VideoViewpoint vp = videoView.MediaPlayer.Viewpoint;
            float yaw = vp.Yaw;
            float pitch = vp.Pitch;
            float roll = vp.Roll;
            float fov = vp.Fov;

            switch (keyChar) {
                case 'a':
                case 'A':
                    yaw -= delta;
                    break;
                case 'd':
                case 'D':
                    yaw += delta;
                    break;
                case 'w':
                case 'W':
                    pitch -= delta;
                    break;
                case 's':
                case 'S':
                    pitch += delta;
                    break;
                case 'q':
                case 'Q':
                    roll -= delta;
                    break;
                case 'e':
                case 'E':
                    roll += delta;
                    break;
                case 'f':
                case 'F':
                    fov -= delta;
                    break;
                case 'r':
                case 'R':
                    fov += delta;
                    break;
                case ' ':
                    yaw = 0; pitch = 0; fov = 0; fov = 115;
                    break;
            }
            videoView.MediaPlayer.UpdateViewpoint(yaw, pitch, roll, fov);
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
        }

        private void RestartPlayerWithNewConfig(string newConfigFile)
        {
            if (configFile != newConfigFile)
            {
                VideoPlayerStop();
                AudioPlayerStop();
                RadioPlayerStop();
                configFile = newConfigFile;
                playersConfig = new ConfigureMain();
                playersConfig.LoadConfigure(configFile);
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
            MessageBox.Show("User Guide is on its way.");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MyPlot Ver 0.1 Copyright Reserved!");
        }
    }
}
