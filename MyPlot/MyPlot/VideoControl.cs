using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public VideoControl(MyPlot myplot)
        {
            InitializeComponent();

            _myplot = myplot;
            _videoMP = myplot._videoMP;
        }

        private void VideoControl_Paint(object sender, PaintEventArgs e)
        {
            /*
            int l = 0;
            for (l = 0; l < 96; l++)
            {
                var p = new Pen(Color.FromArgb(255, l*2, l*2, l*2));
                e.Graphics.DrawLine(p, 0, Height - l, Width, Height - l);
            }
            */
        }

        public void LayoutControls()
        {
            trackBarPosition.Location = new Point(14, 12);
            trackBarPosition.Size = new Size(ClientSize.Width - 14 * 2, 22);

            int leftMargin = 334;  //left starting point of labelTitle
            int rightMargin = 128; //right size reservation for other controls
            labelTitle.Location = new Point(leftMargin, 48);
            labelTitle.Size = new Size(ClientSize.Width - leftMargin - rightMargin, 22);

            buttonFullScreen.Location = new Point(ClientSize.Width - 14 - 36, 48);
            buttonSpeed.Location = new Point(ClientSize.Width - 14 - 36 - 36, 48);
            buttonSettings.Location = new Point(ClientSize.Width - 14 - 36 - 36 - 36, 48);
        }

        private void VideoControl_Load(object sender, EventArgs e)
        {
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

            //Play/Pause buttons
            if (_videoMP.IsPlaying)
            {
                buttonPlay.Enabled = false;
                buttonPause.Enabled = true;
            } else {
                buttonPlay.Enabled = true;
                buttonPause.Enabled = false;
            }

            //Position tracking
            if (!trackBarPosition.ContainsFocus || !mouseLeftButtonDown)
            {
                int pos = (int)(_videoMP.Position * trackBarPosition.Maximum);
                if (pos < trackBarPosition.Minimum)
                    pos = trackBarPosition.Minimum;
                if (pos > trackBarPosition.Maximum)
                    pos = trackBarPosition.Maximum;
                trackBarPosition.Value = pos >= 0 ? pos : 0;
            }

            //Volume Tracking
            if (!trackBarVolume.ContainsFocus || !mouseLeftButtonDown)
            {
                int vol = _videoMP.Volume;
                trackBarVolume.Value = vol >= 0 ? vol : 0;
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
                MainPlayerConfig config = _myplot.playersConfig.configData.mainPlayerConfig;
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
            float newPos = (float)tb.Value / (float)tb.Maximum;
            _videoMP.Position = newPos;
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

        private void buttonPause_Click(object sender, EventArgs e)
        {
            mouseInside = true;
            _videoMP.Pause();
            buttonPause.Visible = false;
            buttonPlay.Visible = true;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            mouseInside = true;
            _videoMP.Pause();
            buttonPause.Visible = true;
            buttonPlay.Visible = false;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            mouseInside = true;
            _videoMP.Position = 0.99999f;
        }

        private void buttonFullScreen_Click(object sender, EventArgs e)
        {
            if (_myplot.FormBorderStyle == FormBorderStyle.None)
            {
                _myplot.FormBorderStyle = FormBorderStyle.Sizable;
                _myplot.WindowState = FormWindowState.Normal;
            }
            else
            {
                _myplot.FormBorderStyle = FormBorderStyle.None;
                _myplot.WindowState = FormWindowState.Maximized;
            }
        }
    }
}
