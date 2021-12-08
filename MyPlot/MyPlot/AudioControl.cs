using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;


namespace MyPlot
{
    public partial class AudioControl : Form
    {
        private MyPlot _myplot;
        private MediaPlayer _audioMP;
        private bool mouseLeftButtonDown = false;
        private bool mouseInside = false;
        private long mouseOutTimeMS = 0;

        public AudioControl(MyPlot myplot)
        {
            InitializeComponent();

            _myplot = myplot;
            _audioMP = myplot._audioMP;
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
        private void AudioControl_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void AudioControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.timerACPUpdate.Enabled = true;
                mouseOutTimeMS = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            }
            else
            {
                this.timerACPUpdate.Enabled = false;
            }
        }

        private void timerACPUpdate_Tick(object sender, EventArgs e)
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

            //Position tracking
            if (!trackBarAudioPos.ContainsFocus || !mouseLeftButtonDown)
            {
                int pos = (int)(_audioMP.Position * trackBarAudioPos.Maximum);
                if (pos < trackBarAudioPos.Minimum)
                    pos = trackBarAudioPos.Minimum;
                if (pos > trackBarAudioPos.Maximum)
                    pos = trackBarAudioPos.Maximum;
                trackBarAudioPos.Value = pos >= 0 ? pos : 0;
            }

            //Volume Tracking
            if (!trackBarAudioVol.ContainsFocus || !mouseLeftButtonDown)
            {
                int vol = _audioMP.Volume;
                trackBarAudioVol.Value = vol >= 0 ? vol : 0;
            }

            //Audio playing position text
            long lenMs = _audioMP.Length;
            if (lenMs > 0)
            {
                long posMs = (long)(lenMs * _audioMP.Position);
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
            else
            {
                labelPosition.Text = "    :    ";
            }

            //Audio Information
            if (_audioMP.IsPlaying)
            {
                AudioPlayerConfig config = _myplot.playersConfig.configData.audioPlayerConfig;
                labelTitle.Text = config.audio_files[config.play_index];
            }
        }

        private void trackBarAudioPos_MouseDown(object sender, MouseEventArgs e)
        {
            mouseInside = true;
            mouseLeftButtonDown = true;
        }

        private void trackBarAudioPos_MouseUp(object sender, MouseEventArgs e)
        {
            mouseLeftButtonDown = false;
            mouseOutTimeMS = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        private void trackBarAudioPos_Scroll(object sender, EventArgs e)
        {
            mouseInside = true;
            TrackBar tb = (TrackBar)sender;
            _audioMP.Position = (float)tb.Value / (float)tb.Maximum;
        }

        private void trackBarAudioVol_Scroll(object sender, EventArgs e)
        {
            mouseInside = true;
            TrackBar tb = (TrackBar)sender;
            _audioMP.Volume = tb.Value;
            if (_myplot.playersConfig != null)
            {
                _myplot.playersConfig.configData.audioPlayerConfig.volume = tb.Value;
            }
        }

        private void AudioControl_MouseEnter(object sender, EventArgs e)
        {
            mouseInside = true;
        }

        private void AudioControl_MouseLeave(object sender, EventArgs e)
        {
            mouseInside = false;
            mouseOutTimeMS = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        private void buttonPlayPause_Click(object sender, EventArgs e)
        {
            mouseInside = true;
            if (_audioMP.IsPlaying)
            {
                _audioMP.Pause();
                buttonPlayPause.Image = Image.FromFile("play.png");
            }
            else
            {
                _audioMP.Pause();
                buttonPlayPause.Image = Image.FromFile("pause.png");
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            mouseInside = true;
            _audioMP.Position = 0.99999f;
        }

        private int previousAudioVol = 0;
        private void checkBoxSpeaker_CheckedChanged(object sender, EventArgs e)
        {
            mouseInside = true;
            if (checkBoxSpeaker.Checked)
            {
                checkBoxSpeaker.Image = Image.FromFile("muted.png");
                previousAudioVol = trackBarAudioVol.Value;
                trackBarAudioVol.Value = 0;
                trackBarAudioVol.Enabled = false;
            }
            else
            {
                checkBoxSpeaker.Image = Image.FromFile("spkr.png");
                trackBarAudioVol.Enabled = true;
                trackBarAudioVol.Value = previousAudioVol;
            }
            _audioMP.Volume = trackBarAudioVol.Value;
            if (_myplot.playersConfig != null)
            {
                _myplot.playersConfig.configData.audioPlayerConfig.volume = trackBarAudioVol.Value;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
        }
    }
}
