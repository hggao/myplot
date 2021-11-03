using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Core;

namespace MyPlot
{
    public partial class MyPlot : Form
    {
        private string configFile = "C:\\videodev360gps\\config_default.json";
        private ConfigureMain playersConfig = null;

        public MyPlot()
        {
            InitializeComponent();
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
            MainPlayerStart();
            PIPPlayerStart();
            AudioPlayerStart();
            RadioPlayerStart();
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

            //Set main player to occupy the whole client area.
            if (playersConfig.configData.mainPlayerConfig.enabled)
            {
                vlcCtrlMain.Location = new Point(0, 0);
                vlcCtrlMain.Size = newSize;
                vlcCtrlMain.Visible = true;
            } else
            {
                vlcCtrlMain.Visible = false;
            }

            //Set PIP web player at the bottom right corner
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
                newSize.Width = ClientSize.Width * 2 / 3;
                newSize.Height = ClientSize.Height / 6;
                vlcCtrlAudio.Location = new Point(0, ClientSize.Height - newSize.Height);
                vlcCtrlAudio.Size = newSize;
                vlcCtrlAudio.Visible = true;
            }
            else
            {
                vlcCtrlAudio.Visible = false;
            }

            //Set Radio player at the right up
            if (playersConfig.configData.radioPlayerConfig.enabled)
            {
                newSize.Width = ClientSize.Width / 6;
                newSize.Height = ClientSize.Height * 2 / 3;
                vlcCtrlRadio.Location = new Point(ClientSize.Width - newSize.Width, 0);
                vlcCtrlRadio.Size = newSize;
                vlcCtrlRadio.Visible = true;
            }
            else
            {
                vlcCtrlRadio.Visible = false;
            }
        }

        private void MainPlayerStart()
        {
            if (vlcCtrlMain.Visible == false)
            {
                return;
            }

            MainPlayerConfig config = playersConfig.configData.mainPlayerConfig;
            config.play_index = -1;
            config.play_position = 0.0f;
            config.play_speed = 1.0f;
            vlcCtrlMain.VlcMediaPlayer.Audio.Volume = config.volume;
            MainPlayerPlayNext();
        }

        private void MainPlayerStop()
        {
            if (vlcCtrlMain.Visible == false)
            {
                return;
            }
            if (vlcCtrlMain.IsPlaying)
            {
                vlcCtrlMain.Stop();
            }
        }

        private void PIPPlayerStart()
        {
            if (webView21.Visible == false)
            {
                return;
            }

            webView21.NavigateToString(System.IO.File.ReadAllText("browse_index.html"));
        }

        private void AudioPlayerStart()
        {
            if (vlcCtrlAudio.Visible == false)
            {
                return;
            }

            AudioPlayerConfig config = playersConfig.configData.audioPlayerConfig;
            config.play_index = -1;
            config.play_position = 0.0f;
            config.play_speed = 1.0f;
            vlcCtrlAudio.VlcMediaPlayer.Audio.Volume = config.volume;
            AudioPlayerPlayNext();
        }

        private void AudioPlayerStop()
        {
            if (vlcCtrlAudio.Visible == false)
            {
                return;
            }
            if (vlcCtrlAudio.IsPlaying)
            {
                vlcCtrlAudio.Stop();
            }
        }

        private void RadioPlayerStart()
        {
            if (vlcCtrlRadio.Visible == false)
            {
                return;
            }

            string firstRadio = playersConfig.configData.radioPlayerConfig.radio_urls[0];
            vlcCtrlRadio.VlcMediaPlayer.Audio.Volume = playersConfig.configData.radioPlayerConfig.volume;
            vlcCtrlRadio.Play(new Uri(firstRadio));
        }

        private void RadioPlayerStop()
        {
            if (vlcCtrlRadio.Visible == false)
            {
                return;
            }
            if (vlcCtrlRadio.IsPlaying)
            {
                vlcCtrlRadio.Stop();
            }
        }

        public void MainPlayerPlayNext()
        {
            MainPlayerConfig config = playersConfig.configData.mainPlayerConfig;

            //TODO: add looping, reshuffle flags later. Now we loop it without reshuffle by default
            config.play_index = (config.play_index + 1) % config.media_files.Count;
            vlcCtrlMain.Play(new Uri(config.media_files[config.play_index]));
        }
  
        private void vlcCtrlMain_EndReached(object sender, Vlc.DotNet.Core.VlcMediaPlayerEndReachedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(MainPlayerPlayNext));
            t.Start();
        }
        public void AudioPlayerPlayNext()
        {
            AudioPlayerConfig config = playersConfig.configData.audioPlayerConfig;

            //TODO: add looping, reshuffle flags later. Now we loop it without reshuffle by default
            config.play_index = (config.play_index + 1) % config.audio_files.Count;
            vlcCtrlAudio.Play(new Uri(config.audio_files[config.play_index]));
        }

        private void vlcCtrlAudio_EndReached(object sender, VlcMediaPlayerEndReachedEventArgs e)
        {
            Thread t = new Thread(new ThreadStart(AudioPlayerPlayNext));
            t.Start();
        }

        private void vlcCtrlMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {

                //===============================
                string mymsg = "Null";

                /* Options
                string[] playOptions = vlcCtrlMain.VlcMediaplayerOptions;
                if (playOptions == null)
                {
                     playOptions = new string[1] { "NULL" };
                }
                string msg = playOptions.ToString();
                */

                /* Position, Time, Rate, Length
                mymsg = "Position: ";
                mymsg += vlcCtrlMain.VlcMediaPlayer.Position.ToString();
                mymsg += "\n Time: ";
                mymsg += vlcCtrlMain.VlcMediaPlayer.Time.ToString();
                mymsg += "\n Rate: ";
                vlcCtrlMain.VlcMediaPlayer.Rate = 2.0f;
                mymsg += vlcCtrlMain.VlcMediaPlayer.Rate.ToString();
                mymsg += "\n Length: ";
                mymsg += vlcCtrlMain.VlcMediaPlayer.Length.ToString();
                */

                /* Media
                */
                VlcMedia md = vlcCtrlMain.VlcMediaPlayer.GetMedia();
                mymsg = "Title: ";
                mymsg += md.Title;
                mymsg += "\n AspectRatio: ";
                mymsg += vlcCtrlMain.VlcMediaPlayer.Video.AspectRatio;

                MessageBox.Show(mymsg);
                //===============================

            }
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            using (SettingsDialog settingDlg = new SettingsDialog())
            {
                settingDlg.configFile = configFile;
                settingDlg.StartPosition = FormStartPosition.Manual;
                settingDlg.Location = this.PointToScreen(new Point(64, 36));
                if (settingDlg.ShowDialog() == DialogResult.OK)
                {
                    if (configFile != settingDlg.configFile)
                    {
                        MainPlayerStop();
                        AudioPlayerStop();
                        RadioPlayerStop();
                        configFile = settingDlg.configFile;
                        playersConfig = new ConfigureMain();
                        playersConfig.LoadConfigure(configFile);
                        SetPlayerControlAppearance();
                        MainPlayerStart();
                        PIPPlayerStart();
                        AudioPlayerStart();
                        RadioPlayerStart();
                    }
                }
            }
        }
    }
}
