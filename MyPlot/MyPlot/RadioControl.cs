using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;


namespace MyPlot
{
    public partial class RadioControl : Form
    {
        private MyPlot _myplot;
        private MediaPlayer _radioMP;
        private bool mouseLeftButtonDown = false;
        private bool mouseInside = false;
        private long mouseOutTimeMS = 0;
        private Image imagePlay = null;
        private Image imagePause = null;
        private Image imageSpkr = null;
        private Image imageMuted = null;

        public RadioControl(MyPlot myplot)
        {
            InitializeComponent();

            _myplot = myplot;
            _radioMP = myplot._radioMP;

            imagePlay = Image.FromFile("play.png");
            imagePause = Image.FromFile("pause.png");
            imageSpkr = Image.FromFile("spkr.png");
            imageMuted = Image.FromFile("muted.png");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Visible = false;
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
        private void RadioControl_Load(object sender, EventArgs e)
        {
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void RadioControl_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.timerRadioControl.Enabled = true;
                mouseOutTimeMS = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            }
            else
            {
                this.timerRadioControl.Enabled = false;
            }
        }

        private void timerRadioControl_Tick(object sender, EventArgs e)
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

            //Volume Tracking
            if (!trackBarRadioVol.ContainsFocus || !mouseLeftButtonDown)
            {
                int vol = _radioMP.Volume;
                trackBarRadioVol.Value = vol >= 0 ? vol : 0;
            }

            //Radio Information
            if (_radioMP.IsPlaying)
            {
                RadioPlayerConfig config = _myplot.playersConfig.configData.radioPlayerConfig;
                labelTitle.Text = config.radio_urls[0];
            }
        }

        private void trackBarRadioVol_Scroll(object sender, EventArgs e)
        {
            mouseInside = true;
            TrackBar tb = (TrackBar)sender;
            _radioMP.Volume = tb.Value;
            if (_myplot.playersConfig != null)
            {
                _myplot.playersConfig.configData.radioPlayerConfig.volume = tb.Value;
            }
        }

        private void RadioControl_MouseEnter(object sender, EventArgs e)
        {
            mouseInside = true;
        }

        private void RadioControl_MouseLeave(object sender, EventArgs e)
        {
            mouseInside = false;
            mouseOutTimeMS = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        private void buttonPlayPause_Click(object sender, EventArgs e)
        {
            mouseInside = true;
            if (_radioMP.IsPlaying)
            {
                _radioMP.Pause();
                buttonPlayPause.Image = imagePlay;
            }
            else
            {
                _radioMP.Pause();
                buttonPlayPause.Image = imagePause;
            }
        }

        private int previousRadioVol = 0;
        private void checkBoxSpeaker_CheckedChanged(object sender, EventArgs e)
        {
            mouseInside = true;
            if (checkBoxSpeaker.Checked)
            {
                checkBoxSpeaker.Image = imageMuted;
                previousRadioVol = trackBarRadioVol.Value;
                trackBarRadioVol.Value = 0;
                trackBarRadioVol.Enabled = false;
            }
            else
            {
                checkBoxSpeaker.Image = imageSpkr;
                trackBarRadioVol.Enabled = true;
                trackBarRadioVol.Value = previousRadioVol;
            }
            _radioMP.Volume = trackBarRadioVol.Value;
            if (_myplot.playersConfig != null)
            {
                _myplot.playersConfig.configData.radioPlayerConfig.volume = trackBarRadioVol.Value;
            }
        }
    }
}
