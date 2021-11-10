using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace MyPlot
{
    public partial class SettingsDialog : Form
    {
        public string configFile { get; set; }
        public ConfigureMain config = null;

        public SettingsDialog()
        {
            InitializeComponent();
        }

        private void SettingsDialog_Load(object sender, EventArgs e)
        {
            config = new ConfigureMain();
            config.LoadConfigure(configFile);
            ApplyConfigDataToUI();
        }

        private void ApplyConfigDataToUI()
        {
            //Initialize configure file field with current loaded config file
            TextBoxConfigFile.Text = configFile;

            //Initialize main player controls
            MainPlayerConfig mainCfg = config.configData.mainPlayerConfig;
            this.CheckBoxMainLoop.Checked = mainCfg.loop;
            this.CheckBoxMainReshuffle.Checked = mainCfg.reshuffle;
            this.TrackBarMainVolume.Value = mainCfg.volume;
            this.LabelMainVolumeText.Text = TrackBarMainVolume.Value.ToString();
            this.ListBoxMainFiles.Items.Clear();
            for (int i = 0; i < mainCfg.media_files.Count; i++)
            {
                this.ListBoxMainFiles.Items.Add(mainCfg.media_files[i]);
            }
            this.CheckBoxMainPlayer.Checked = mainCfg.enabled;
            if (!CheckBoxMainPlayer.Checked)
            {
                GroupBoxMainPlayer.Enabled = false;
            }

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
        }

        private void CheckBoxAudio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBoxWebPlayer_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxConfigFile_TextChanged(object sender, EventArgs e)
        {
            if (configFile != TextBoxConfigFile.Text)
            {
                configFile = TextBoxConfigFile.Text;
                config = new ConfigureMain();
                config.LoadConfigure(configFile);
                ApplyConfigDataToUI();
            }
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "config");
            ofd.Filter = "MyPlot Config (*.myplot.json)|*.myplot.json";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TextBoxConfigFile.Text = ofd.FileName;
            }
        }
    }
}
