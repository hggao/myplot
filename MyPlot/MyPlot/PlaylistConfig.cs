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

        public PlaylistSetup(ConfigureMain cur_config)
        {
            InitializeComponent();

            config = cur_config.Clone();

            delMenu = new ContextMenu();
            delMenu.MenuItems.Add("Remove", OnMenuItemRemove_Clicked);
            ListBoxVideoList.ContextMenu = delMenu;
            listBoxAudioList.ContextMenu = delMenu;
            listBoxWebUrls.ContextMenu = delMenu;
            listBoxRadioUrls.ContextMenu = delMenu;
        }

        private void PlaylistSetup_Load(object sender, EventArgs e)
        {
            ApplyConfigDataToUI();
        }

        private void ApplyConfigDataToUI()
        {
            //Initialize configure file field with current loaded config file
            textBoxConfigFile.Text = configFile == null ? "" : configFile;

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

            //Initialize audio player controls
            AudioPlayerConfig audioCfg = config.configData.audioPlayerConfig;
            this.checkBoxAudioLoop.Checked = audioCfg.loop;
            this.checkBoxAudioReshuffle.Checked = audioCfg.reshuffle;
            this.trackBarAudioVol.Value = audioCfg.volume;
            this.labelAudioVolText.Text = trackBarAudioVol.Value.ToString();
            this.listBoxAudioList.Items.Clear();
            for (int i = 0; i < audioCfg.audio_files.Count; i++)
            {
                this.listBoxAudioList.Items.Add(audioCfg.audio_files[i]);
            }
            this.checkBoxAudioEnable.Checked = audioCfg.enabled;

            //Initialize web player controls
            WebPlayerConfig webCfg = config.configData.webPlayerConfig;
            this.listBoxWebUrls.Items.Clear();
            for (int i = 0; i < webCfg.web_urls.Count; i++)
            {
                this.listBoxWebUrls.Items.Add(webCfg.web_urls[i]);
            }
            if (webCfg.web_urls.Count > 0)
            {
                listBoxWebUrls.SelectedIndex = 0;
            }
            this.checkBoxWebEnable.Checked = webCfg.enabled;

            //Initialize radio player controls
            RadioPlayerConfig radioCfg = config.configData.radioPlayerConfig;
            this.trackBarRadioVol.Value = radioCfg.volume;
            this.labelRadioVolText.Text = trackBarRadioVol.Value.ToString();
            this.listBoxRadioUrls.Items.Clear();
            for (int i = 0; i < radioCfg.radio_urls.Count; i++)
            {
                this.listBoxRadioUrls.Items.Add(radioCfg.radio_urls[i]);
            }
            if (radioCfg.radio_urls.Count > 0)
            {
                listBoxAudioList.SelectedIndex = 0;
            }
            this.checkBoxRadioEnable.Checked = radioCfg.enabled;
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

            //Update audio player config
            AudioPlayerConfig audioCfg = config.configData.audioPlayerConfig;
            audioCfg.loop = this.checkBoxAudioLoop.Checked;
            audioCfg.reshuffle = this.checkBoxAudioReshuffle.Checked;
            audioCfg.volume = this.trackBarAudioVol.Value;
            audioCfg.audio_files.Clear();
            foreach (string file in this.listBoxAudioList.Items)
            {
                audioCfg.audio_files.Add(file);
            }
            audioCfg.enabled = this.checkBoxAudioEnable.Checked;

            //Update web player
            WebPlayerConfig webCfg = config.configData.webPlayerConfig;
            webCfg.web_urls.Clear();
            string activeURL = textBoxActiveURL.Text.Trim();
            if (activeURL != "")
            {
                webCfg.web_urls.Add(activeURL);
            }
            foreach (string url in listBoxWebUrls.Items)
            {
                if (url != activeURL)
                {
                    webCfg.web_urls.Add(url);
                }
            }
            webCfg.enabled = this.checkBoxWebEnable.Checked;

            //Update radio player
            RadioPlayerConfig radioCfg = config.configData.radioPlayerConfig;
            radioCfg.volume = this.trackBarRadioVol.Value;
            radioCfg.radio_urls.Clear();
            string activeRadioURL = textBoxActiveRadioUrl.Text.Trim();
            if (activeRadioURL != "")
            {
                radioCfg.radio_urls.Add(activeRadioURL);
            }
            foreach (string url in listBoxRadioUrls.Items)
            {
                if (url != activeRadioURL)
                {
                    radioCfg.radio_urls.Add(url);
                }
            }
            radioCfg.enabled = this.checkBoxRadioEnable.Checked;
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "config");
            ofd.Filter = "MyPlot playlist(*.myplot.json)|*.myplot.json";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxConfigFile.Text = ofd.FileName;
                configFile = textBoxConfigFile.Text;
                config = new ConfigureMain(configFile);
                ApplyConfigDataToUI();
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (configFile != null)
            {
                UpdateConfigDataFromUI();
                config.SaveConfigure(configFile);
            }
            else
            {
                SaveAsNewFile();
            }
        }

        private void SaveAsNewFile()
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

        private void ButtonSaveAs_Click(object sender, EventArgs e)
        {
            SaveAsNewFile();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            UpdateConfigDataFromUI();
            if (configFile != null)
            {
                config.SaveConfigure(configFile);
            }
        }

        private void linkLabelVideoDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            linkLabelVideoDownload.LinkVisited = true;

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
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files == null || !files.Any())
                return;

            foreach (string file in files)
            {
                string ext = Path.GetExtension(file);
                if (GlobalDefs.videoExts.Contains(ext) && !ListBoxVideoList.Items.Contains(file))
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
            

            ListBox lb = (ListBox)((MenuItem)sender).GetContextMenu().SourceControl;
            int selectIndex = lb.SelectedIndex;
            if (selectIndex >= 0)
            {
                lb.Items.RemoveAt(selectIndex);
            }
        }

        private void trackBarVideoVol_Scroll(object sender, EventArgs e)
        {
            LabelVideoVolText.Text = trackBarVideoVol.Value.ToString();
        }

        private void tabControlPlaylist_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabPageVideo)
            {
                labelNote.Text = "Note: Drag files(.mp4, .mov, .wmv, .flv, .avi, .mkv) in to add. Del key or right mouse to remove.";
            }
            else if (e.TabPage == tabPageAudio)
            {
                labelNote.Text = "Note: Drag files(.mp3, .wav, .wma, .aac) in to add. Del key or right mouse to remove.";
            }
            else if (e.TabPage == tabPageWeb)
            {
                labelNote.Text = "Note: Please make sure the URL supplied here really working.";
            }
            else
            {
                labelNote.Text = "Note: Make sure URLs are internet audio only.";
            }
        }

        private void linkLabelAudioDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Specify that the link was visited.
            linkLabelAudioDownload.LinkVisited = true;

            // Navigate to a URL.
            System.Diagnostics.Process.Start("http://98.234.74.74/music.html");
        }

        private void listBoxAudioList_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBoxAudioList_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files == null || !files.Any())
                return;

            foreach (string file in files)
            {
                string ext = Path.GetExtension(file);
                if (GlobalDefs.audioExts.Contains(ext) && !listBoxAudioList.Items.Contains(file))
                {
                    listBoxAudioList.Items.Add(file);
                }
            }
        }

        private void listBoxAudioList_KeyDown(object sender, KeyEventArgs e)
        {
            int selectIndex = listBoxAudioList.SelectedIndex;

            if (selectIndex >= 0 && e.KeyCode == Keys.Delete)
            {
                listBoxAudioList.Items.RemoveAt(selectIndex);
            }
        }

        private void trackBarAudioVol_Scroll(object sender, EventArgs e)
        {
            labelAudioVolText.Text = trackBarAudioVol.Value.ToString();
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            string txt = textBoxAddNew.Text.Trim();
            if (txt == "")
                return;
            if (listBoxWebUrls.Items.Contains(txt))
            {
                listBoxWebUrls.SelectedItem = txt;
            }
            else
            {
                listBoxWebUrls.Items.Insert(0, txt);
                listBoxWebUrls.SelectedIndex = 0;
            }
            textBoxAddNew.Text = "";
        }

        private void listBoxWebUrls_KeyDown(object sender, KeyEventArgs e)
        {
            int selectIndex = listBoxWebUrls.SelectedIndex;

            if (selectIndex >= 0 && e.KeyCode == Keys.Delete)
            {
                listBoxWebUrls.Items.RemoveAt(selectIndex);
            }
        }

        private void listBoxWebUrls_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxWebUrls.SelectedItem != null)
            {
                textBoxActiveURL.Text = listBoxWebUrls.SelectedItem.ToString();
            }
            else
            {
                textBoxActiveURL.Text = "";
            }
        }

        private void trackBarRadioVol_Scroll(object sender, EventArgs e)
        {
            labelRadioVolText.Text = trackBarRadioVol.Value.ToString();
        }

        private void buttonRadioAddNew_Click(object sender, EventArgs e)
        {
            string txt = textBoxRadioAddNew.Text.Trim();
            if (txt == "")
                return;

            if (listBoxRadioUrls.Items.Contains(txt))
            {
                listBoxRadioUrls.SelectedItem = txt;
            }
            else
            {
                listBoxRadioUrls.Items.Insert(0, txt);
                listBoxRadioUrls.SelectedIndex = 0;
            }
            textBoxRadioAddNew.Text = "";
        }

        private void listBoxRadioUrls_KeyDown(object sender, KeyEventArgs e)
        {
            int selectIndex = listBoxRadioUrls.SelectedIndex;

            if (selectIndex >= 0 && e.KeyCode == Keys.Delete)
            {
                listBoxRadioUrls.Items.RemoveAt(selectIndex);
            }
        }

        private void listBoxRadioUrls_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxRadioUrls.SelectedItem != null)
            {
                textBoxActiveRadioUrl.Text = listBoxRadioUrls.SelectedItem.ToString();
            }
            else
            {
                textBoxActiveRadioUrl.Text = "";
            }
        }
    }
}
