using System;
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
        private void AudioPlayerStart()
        {
            if (audioView.Visible == false)
            {
                return;
            }

            AudioPlayerConfig config = playersConfig.configData.audioPlayerConfig;
            if (config.audio_files.Count < 1)
            {
                return;
            }
            config.play_index = -1;
            config.play_position = 0.0f;
            config.play_speed = 1.0f;
            audioView.MediaPlayer.Volume = config.volume;
            AudioPlayerPlayNext();
        }

        public void AudioPlayerPlayNext()
        {
            AudioPlayerConfig config = playersConfig.configData.audioPlayerConfig;

            //TODO: add reshuffle flag handling later.
            if (!config.loop && config.play_index + 1 >= config.audio_files.Count)
            {
                return;
            }
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

        private void AudioPlayer_Playing(object sender, EventArgs e)
        {
            audioView.MediaPlayer.EnableKeyInput = false;
            audioView.MediaPlayer.EnableMouseInput = false;
        }

        private void OnWaveInDataAvailable(object sender, WaveInEventArgs e)
        {
            if (e.BytesRecorded == 0)
            {
                for (int i = 0; i < SAMPLE_LEN; i++)
                    samples[i] = 0;
                return;
            }

            var waveBuffer = new WaveBuffer(e.Buffer);
            int nblocks = e.BytesRecorded / waveFormat.BlockAlign;
            int nsamples = nblocks * waveFormat.Channels;
            short value;
            int n = 0;
            for (int i = 0; i < nsamples && n < SAMPLE_LEN;)
            {
                i++; //Skip sample of left channel
                samples[n] = (short)(waveBuffer.FloatBuffer[i++] * 70); //Should be 50, but when overall volume low, the number is too small
                while (i * SAMPLE_LEN / nsamples == n)
                {
                    i++; //Skip sampe of left channel
                    value = (short)(waveBuffer.FloatBuffer[i++] * 70); //Should be 50, but when overall volume low, the number is too small
                    if (samples[n] > 0 && samples[n] < value || samples[n] < 0 && samples[n] > value)
                    {
                        samples[n] = value;
                    }
                }
                n++;
            }
            while (n < SAMPLE_LEN)
                samples[n++] = 0;
        }

        private void audioView_Paint(object sender, PaintEventArgs e)
        {
            var p = new Pen(Color.FromArgb(255, 255, 224, 0));
            e.Graphics.Clear(Color.Black);
            var y = audioView.Height / 2;
            for (int x = 0; x < SAMPLE_LEN; x++)
            {
                e.Graphics.DrawLine(p, 6 + x, y, 6 + x, y + samples[x]);
            }
        }

        private void timerAudio_Tick(object sender, EventArgs e)
        {
            audioView.Invalidate();
        }

        private void relocateAudioControl()
        {
            if (audioCtrl.Visible)
            {
                audioCtrl.Location = PointToScreen(new Point(audioView.Location.X + audioView.Width - 1, audioView.Location.Y));
            }
        }

        private void ToogleAudioCtrlVisible()
        {
            if (audioCtrl.Visible)
            {
                audioCtrl.Hide();
            }
            else
            {
                audioCtrl.Show();
                relocateAudioControl();
            }
        }

        private void audioView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ToogleAudioCtrlVisible();
            }
        }

        private void audioView_MouseDown(object sender, MouseEventArgs e)
        {
            //TODO: Use right mouse down to move audio view location and remember it within config.
        }

        private void audioView_MouseUp(object sender, MouseEventArgs e)
        {
            //TODO: Use right mouse down to move audio view location and remember it within config.
        }

        private void audioView_MouseMove(object sender, MouseEventArgs e)
        {
            //TODO: Use right mouse down to move audio view location and remember it within config.
        }
    }
}