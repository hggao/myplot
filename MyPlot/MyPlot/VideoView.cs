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
            Debug.WriteLine("======Video playing started");
            Debug.WriteLine(config.media_files[config.play_index]);
            media.Dispose();
        }

        private void VideoPlayer_Playing(object sender, EventArgs e)
        {
            videoView.MediaPlayer.EnableKeyInput = false;
            videoView.MediaPlayer.EnableMouseInput = false;
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

        private void videoView_KeyPress(object sender, KeyPressEventArgs e)
        {
            string controlKeys = "aAdDsSwWqQeEfFrRcC";
            if (videoView.MediaPlayer.Media.Tracks[0].Data.Video.Projection == VideoProjection.Equirectangular &&
                controlKeys.Contains(e.KeyChar.ToString()))
            {
                VideoUpdateViewPoint(e.KeyChar);
                return;
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

            switch (keyChar)
            {
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
                case 'c':
                case 'C':
                    yaw = 0; pitch = 0; roll = 0; fov = 115;
                    break;
            }
            videoView.MediaPlayer.UpdateViewpoint(yaw, pitch, roll, fov);
        }

        private bool videoViewMouseIsDown = false;
        private Point vVMousePos = new Point(0, 0);

        private void videoView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            videoViewMouseIsDown = true;
            vVMousePos = new Point(e.X, e.Y);
        }

        private void videoView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            videoViewMouseIsDown = false;
        }

        private void videoView_MouseMove(object sender, MouseEventArgs e)
        {
            if (!videoViewMouseIsDown || e.Button != MouseButtons.Left ||
                (vVMousePos.X == 0 && vVMousePos.Y == 0))
                return;
            if (e.X == vVMousePos.X && e.Y == vVMousePos.Y)
                return;
            float yawDelta = e.X - vVMousePos.X;
            float pitchDelta = e.Y - vVMousePos.Y;
            vVMousePos = new Point(e.X, e.Y);

            VideoViewpoint vp = videoView.MediaPlayer.Viewpoint;
            float yaw = vp.Yaw;
            float pitch = vp.Pitch;
            float roll = vp.Roll;
            float fov = vp.Fov;

            yaw -= (yawDelta / ClientSize.Width) * fov;
            pitch -= (pitchDelta / ClientSize.Height) * fov;
            videoView.MediaPlayer.UpdateViewpoint(yaw, pitch, roll, fov);
        }

        private void videoView_MouseWheel(object sender, MouseEventArgs e)
        {
            VideoViewpoint vp = videoView.MediaPlayer.Viewpoint;
            float yaw = vp.Yaw;
            float pitch = vp.Pitch;
            float roll = vp.Roll;
            float fov = vp.Fov;

            fov += (float)e.Delta / 60.0f;
            videoView.MediaPlayer.UpdateViewpoint(yaw, pitch, roll, fov);
        }

        private void videoInforShowHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!videoView.Visible)
                return;

            if (labelViewInfo.Visible)
            {
                labelViewInfo.Visible = false;
            }
            else
            {
                string info = " ";
                info += videoView.MediaPlayer.Media.Tracks[0].Data.Video.Width.ToString();
                info += " x ";
                info += videoView.MediaPlayer.Media.Tracks[0].Data.Video.Height.ToString();
                info += ", ";
                if (videoView.MediaPlayer.Media.Tracks[0].Data.Video.Projection == VideoProjection.Rectangular)
                {
                    info += "normal";
                }
                else if (videoView.MediaPlayer.Media.Tracks[0].Data.Video.Projection == VideoProjection.Equirectangular)
                {
                    info += "360°";
                }
                else
                {
                    info += "Cubemap";
                }
                info += " | File: ";
                MainPlayerConfig config = playersConfig.configData.mainPlayerConfig;
                info += config.media_files[config.play_index];

                labelViewInfo.Text = info;
                labelViewInfo.Location = new Point((ClientSize.Width - labelViewInfo.Width) / 2, 48);
                labelViewInfo.Visible = true;
                timerVideoInfo.Enabled = true;
            }
        }

        private void timerVideoInfo_Tick(object sender, EventArgs e)
        {
            if (labelViewInfo.Visible)
            {
                timerVideoInfo.Enabled = false;
                labelViewInfo.Visible = false;
            }
        }
    }
}