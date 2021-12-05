using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPlot
{
    public partial class PlaylistSetup : Form
    {
        public string configFile { get; set; }
        public ConfigureMain config = null;
        private ContextMenu delMenu = null;

        public PlaylistSetup()
        {
            InitializeComponent();

            delMenu = new ContextMenu();
            delMenu.MenuItems.Add("Remove", OnMenuItemRemove_Clicked);
            ListBoxVideoList.ContextMenu = delMenu;
        }

        private void PlaylistSetup_Load(object sender, EventArgs e)
        {
            config = new ConfigureMain();
            config.LoadConfigure(configFile);
            ApplyConfigDataToUI();
        }

        private void ApplyConfigDataToUI()
        {
            //Initialize configure file field with current loaded config file
            textBoxConfigFile.Text = configFile;

            //Initialize main player controls
            MainPlayerConfig mainCfg = config.configData.mainPlayerConfig;
            this.CheckBoxMainLoop.Checked = mainCfg.loop;
            this.CheckBoxMainReshuffle.Checked = mainCfg.reshuffle;
            this.trackBarVideoVol.Value = mainCfg.volume;
            this.LabelVideoVolText.Text = trackBarVideoVol.Value.ToString();
            this.ListBoxVideoList.Items.Clear();
            for (int i = 0; i < mainCfg.media_files.Count; i++)
            {
                this.ListBoxVideoList.Items.Add(mainCfg.media_files[i]);
            }
            this.checkBoxVideoEnable.Checked = mainCfg.enabled;

            /*
            //Initialize web player controls
            WebPlayerConfig webCfg = config.configData.webPlayerConfig;
            this.CheckBoxWebLoop.Checked = webCfg.loop;
            this.CheckBoxWebReshuffle.Checked = webCfg.reshuffle;
            this.TrackBarWebVolume.Value = webCfg.volume;
            this.LabelWebVolumeText.Text = TrackBarWebVolume.Value.ToString();
            this.ListBoxWebUrls.Items.Clear();
            for (int i = 0; i < webCfg.web_urls.Count; i++)
            {
                this.ListBoxWebUrls.Items.Add(webCfg.web_urls[i]);
            }
            this.CheckBoxWebPlayer.Checked = webCfg.enabled;
            if (!CheckBoxWebPlayer.Checked)
            {
                GroupBoxWebPlayer.Enabled = false;
            }

            //Initialize audio player controls
            AudioPlayerConfig audioCfg = config.configData.audioPlayerConfig;
            this.CheckBoxAudioLoop.Checked = audioCfg.loop;
            this.CheckBoxAudioReshuffle.Checked = audioCfg.reshuffle;
            this.TrackBarAudioVolume.Value = audioCfg.volume;
            this.LabelAudioVolumeText.Text = TrackBarAudioVolume.Value.ToString();
            this.ListBoxAudioFiles.Items.Clear();
            for (int i = 0; i < audioCfg.audio_files.Count; i++)
            {
                this.ListBoxAudioFiles.Items.Add(audioCfg.audio_files[i]);
            }
            this.CheckBoxAudioPlayer.Checked = audioCfg.enabled;
            if (!CheckBoxAudioPlayer.Checked)
            {
                GroupBoxAudioPlayer.Enabled = false;
            }

            //Initialize radio player controls
            RadioPlayerConfig radioCfg = config.configData.radioPlayerConfig;
            this.CheckBoxRadioLoop.Checked = radioCfg.loop;
            this.CheckBoxRadioReshuffle.Checked = radioCfg.reshuffle;
            this.TrackBarRadioVolume.Value = radioCfg.volume;
            this.LabelRadioVolumeText.Text = TrackBarRadioVolume.Value.ToString();
            this.ListBoxRadioUrls.Items.Clear();
            for (int i = 0; i < radioCfg.radio_urls.Count; i++)
            {
                this.ListBoxRadioUrls.Items.Add(radioCfg.radio_urls[i]);
            }
            this.CheckBoxRadioPlayer.Checked = radioCfg.enabled;
            if (!CheckBoxRadioPlayer.Checked)
            {
                GroupBoxRadioPlayer.Enabled = false;
            }

            //Disable for now until we could save the changes.
            ButtonSave.Enabled = false;
            ButtonSaveAs.Enabled = false;
            CheckBoxMainPlayer.Enabled = false;
            GroupBoxMainPlayer.Enabled = false;
            CheckBoxWebPlayer.Enabled = false;
            GroupBoxWebPlayer.Enabled = false;
            CheckBoxAudioPlayer.Enabled = false;
            GroupBoxAudioPlayer.Enabled = false;
            CheckBoxRadioPlayer.Enabled = false;
            GroupBoxRadioPlayer.Enabled = false;
            */
        }

        private void UpdateConfigDataFromUI()
        {
            //Update main video player config
            MainPlayerConfig mainCfg = config.configData.mainPlayerConfig;
            mainCfg.loop = this.CheckBoxMainLoop.Checked;
            mainCfg.reshuffle = this.CheckBoxMainReshuffle.Checked;
            mainCfg.volume = this.trackBarVideoVol.Value;

            mainCfg.media_files.Clear();
            foreach (string file in this.ListBoxVideoList.Items)
            {
                mainCfg.media_files.Add(file);
            }
            mainCfg.enabled = this.checkBoxVideoEnable.Checked;

        }

        private void textBoxConfigFile_TextChanged(object sender, EventArgs e)
        {
            configFile = textBoxConfigFile.Text;
            config = new ConfigureMain();
            config.LoadConfigure(configFile);
            ApplyConfigDataToUI();
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "config");
            ofd.Filter = "MyPlot Config (*.myplot.json)|*.myplot.json";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxConfigFile.Text = ofd.FileName;
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            UpdateConfigDataFromUI();
            config.SaveConfigure(configFile);
        }

        private void ButtonSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "MyPlot Config (*.myplot.json)|*.myplot.json";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                UpdateConfigDataFromUI();
                config.SaveConfigure(dialog.FileName);
                textBoxConfigFile.Text = dialog.FileName;
            }
        }

        private void linkLabelDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            linkLabelDownload.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start("http://98.234.74.74/");
        }

        private void ListBoxVideoList_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void ListBoxVideoList_DragDrop(object sender, DragEventArgs e)
        {
            string[] videoExts = {".mp4", ".mov", ".wmv", ".flv", ".avi", ".mkv"};
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files == null || !files.Any())
                return;

            foreach (string file in files)
            {
                string ext = Path.GetExtension(file);
                if (videoExts.Contains(ext) && !ListBoxVideoList.Items.Contains(file))
                {
                    ListBoxVideoList.Items.Add(file);
                }
            }
        }

        private void ListBoxVideoList_KeyDown(object sender, KeyEventArgs e)
        {
            int selectIndex = ListBoxVideoList.SelectedIndex;
            
            if (selectIndex >= 0 && e.KeyCode == Keys.Delete)
            {
                ListBoxVideoList.Items.RemoveAt(selectIndex);
            }
        }

        private void OnMenuItemRemove_Clicked(object sender, EventArgs e)
        {
            int selectIndex = ListBoxVideoList.SelectedIndex;
            if (selectIndex >= 0)
            {
                ListBoxVideoList.Items.RemoveAt(selectIndex);
            }
        }

        private void trackBarVideoVol_Scroll(object sender, EventArgs e)
        {
            LabelVideoVolText.Text = trackBarVideoVol.Value.ToString();
        }
    }
}
