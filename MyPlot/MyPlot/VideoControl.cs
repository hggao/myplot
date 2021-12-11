using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;

namespace MyPlot
{
    public partial class VideoControl : Form
    {
        private MyPlot _myplot;
        private MediaPlayer _videoMP;
        private bool mouseLeftButtonDown = false;
        private bool mouseInside = false;
        private long mouseOutTimeMS = 0;
        private Image imagePlay = null;
        private Image imagePause = null;
        private Image imageReplay = null;
        private Image imageSpkr = null;
        private Image imageMuted = null;

        public VideoControl(MyPlot myplot)
        {
            InitializeComponent();

            _myplot = myplot;
            _videoMP = myplot._videoMP;

            imagePlay = Image.FromFile("play.png");
            imagePause = Image.FromFile("pause.png");
            imageReplay = Image.FromFile("replay.png");
            imageSpkr = Image.FromFile("spkr.png");
            imageMuted = Image.FromFile("muted.png");
        }

        public void LayoutControls()
        {
            trackBarPosition.Location = new Point(14, 12);
            trackBarPosition.Size = new Size(ClientSize.Width - 14 * 2, 22);

            int leftMargin = 334;  //left starting point of labelTitle
            int rightMargin = 146; //right size reservation for other controls
            labelTitle.Location = new Point(leftMargin, 48);
            labelTitle.Size = new Size(ClientSize.Width - leftMargin - rightMargin, 22);

            buttonFullScreen.Location = new Point(ClientSize.Width - 14 - 38, 48);
            comboBoxSpeed.Location = new Point(ClientSize.Width - 14 - 36 - 36 - 18, 52);
            buttonSettings.Location = new Point(ClientSize.Width - 14 - 36 - 36 - 36 - 18, 48);


        }

        private void VideoControl_Load(object sender, EventArgs e)
        {
            comboBoxSpeed.SelectedIndex = 3;
        }

        private void VideoControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.timerVCPUpdate.Enabled = true;
                mouseOutTimeMS = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            }
            else
            {
                this.timerVCPUpdate.Enabled = false;
            }
        }

        private void timerVCPUpdate_Tick(object sender, EventArgs e)
        {
            if (!mouseInside && !mouseLeftButtonDown)
            {
                long msNow = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                if (msNow - mouseOutTimeMS > 4000)
                {
                    this.Visible = false;
                    return;
                }
            }

            MainPlayerConfig config = _myplot.playersConfig.configData.mainPlayerConfig;

            //Play/Pause/Replay button
            if (config.player_status == (int)PlayerStatus.PlayingStarted)
            {
                if (_videoMP.IsPlaying)
                {
                    buttonPlayPause.Image = imagePause;
                }
                else
                {
                    buttonPlayPause.Image = imagePlay;
                }
            }
            else if (config.player_status == (int)PlayerStatus.PlayingEnd)
            {
                buttonPlayPause.Image = imageReplay;
            }
            else
            {
                Debug.WriteLine("Unexpected Video player status: " + config.player_status.ToString());
            }

            //Position tracking
            if (!trackBarPosition.ContainsFocus || !mouseLeftButtonDown)
            {
                if (config.player_status == (int)PlayerStatus.PlayingEnd)
                {
                    _videoMP.Position = 1.0f;
                }
                int pos = (int)(_videoMP.Position * trackBarPosition.Maximum);
                if (pos < trackBarPosition.Minimum)
                    pos = trackBarPosition.Minimum;
                if (pos > trackBarPosition.Maximum)
                    pos = trackBarPosition.Maximum;
                trackBarPosition.Value = pos >= 0 ? pos : 0;
            }

            //Volume Tracking
            if (!trackBarVideoVol.ContainsFocus || !mouseLeftButtonDown)
            {
                int vol = _videoMP.Volume;
                trackBarVideoVol.Value = vol >= 0 ? vol : 0;
            }

            //Video playing position text
            long lenMs = _videoMP.Length;
            if (lenMs > 0) {
                long posMs = (long)(lenMs * _videoMP.Position);
                TimeSpan tTotal = TimeSpan.FromMilliseconds(lenMs + 500);
                TimeSpan tPos = TimeSpan.FromMilliseconds(posMs + 500);
                labelPosition.Text = "";
                if (tPos.Hours > 0)
                    labelPosition.Text += string.Format("{0:D2}:", tPos.Hours);
                labelPosition.Text += string.Format("{0:D2}:", tPos.Minutes);
                labelPosition.Text += string.Format("{0:D2} / ", tPos.Seconds);
                if (tTotal.Hours > 0)
                    labelPosition.Text += string.Format("{0:D2}:", tTotal.Hours);
                labelPosition.Text += string.Format("{0:D2}:", tTotal.Minutes);
                labelPosition.Text += string.Format("{0:D2}", tTotal.Seconds);
            }
            else {
                labelPosition.Text = "    :    ";
            }

            //Video Information
            if (_videoMP.IsPlaying)
            {
                string info = "";
                info += _videoMP.Media.Tracks[0].Data.Video.Width.ToString();
                info += " x ";
                info += _videoMP.Media.Tracks[0].Data.Video.Height.ToString();
                info += ", ";
                if (_videoMP.Media.Tracks[0].Data.Video.Projection == VideoProjection.Rectangular)
                {
                    info += "normal";
                }
                else if (_videoMP.Media.Tracks[0].Data.Video.Projection == VideoProjection.Equirectangular)
                {
                    info += "360°";
                }
                else
                {
                    info += "Cubemap";
                }
                info += " | File: ";
                info += config.media_files[config.play_index];
                labelTitle.Text = info;
            }
        }

        private void trackBarPosition_MouseUp(object sender, MouseEventArgs e)
        {
            mouseLeftButtonDown = false;
            mouseOutTimeMS = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        private void trackBarPosition_MouseDown(object sender, MouseEventArgs e)
        {
            mouseInside = true;
            mouseLeftButtonDown = true;
        }

        private void trackBarPosition_Scroll(object sender, EventArgs e)
        {
            mouseInside = true;
            TrackBar tb = (TrackBar)sender;
            _videoMP.Position = (float)tb.Value / (float)tb.Maximum;
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            mouseInside = true;
            TrackBar tb = (TrackBar)sender;
            _videoMP.Volume = tb.Value;
            if (_myplot.playersConfig != null)
            {
                _myplot.playersConfig.configData.mainPlayerConfig.volume = tb.Value;
            }
        }

        private void VideoControl_MouseEnter(object sender, EventArgs e)
        {
            mouseInside = true;
        }

        private void VideoControl_MouseLeave(object sender, EventArgs e)
        {
            mouseInside = false;
            mouseOutTimeMS = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        private void buttonPlayPause_Click(object sender, EventArgs e)
        {
            mouseInside = true;
            if (buttonPlayPause.Image == imageReplay)
            {
                _myplot.VideoPlayerStart();
                buttonPlayPause.Image = imagePause;
                return;
            }
            if (buttonPlayPause.Image == imagePlay)
            {
                _videoMP.Pause();
                buttonPlayPause.Image = imagePause;
                return;
            }

            //Remaining condition is imagePause
            _videoMP.Pause();
            buttonPlayPause.Image = imagePlay;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            mouseInside = true;
            _videoMP.Position = 0.99999f;
        }

        private void buttonFullScreen_Click(object sender, EventArgs e)
        {
            _myplot.ToogleFullScreenMode();
        }

        private void comboBoxSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            float[] speeds = { 0.25f, 0.50f, 0.75f, 1.00f, 1.25f, 1.50f, 1.75f, 2.00f};
            int index = comboBoxSpeed.SelectedIndex;
            if (index >= 0)
            {
                _videoMP.SetRate(speeds[index]);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private int previousVideoVol = 0;
        private void checkBoxSpeaker_CheckedChanged(object sender, EventArgs e)
        {
            mouseInside = true;
            if (checkBoxSpeaker.Checked)
            {
                checkBoxSpeaker.Image = imageMuted;
                previousVideoVol = trackBarVideoVol.Value;
                trackBarVideoVol.Value = 0;
                trackBarVideoVol.Enabled = false;
            }
            else
            {
                checkBoxSpeaker.Image = imageSpkr;
                trackBarVideoVol.Enabled = true;
                trackBarVideoVol.Value = previousVideoVol;
            }
            _videoMP.Volume = trackBarVideoVol.Value;
            if (_myplot.playersConfig != null)
            {
                _myplot.playersConfig.configData.mainPlayerConfig.volume = trackBarVideoVol.Value;
            }
        }
    }
}
