using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MyPlot
{

    public class ConfigureMain
    {
        public ConfigData configData;
        public string configFile;

        public ConfigureMain(string confFile)
        {
            this.configFile = confFile;
            this.configData = new ConfigData();

            //Video player init with default value
            configData.mainPlayerConfig = new MainPlayerConfig();
            configData.mainPlayerConfig.enabled = false;
            configData.mainPlayerConfig.volume = 0;
            configData.mainPlayerConfig.loop = false;
            configData.mainPlayerConfig.reshuffle = false;
            configData.mainPlayerConfig.media_files = new List<string>();

            //Audio player init with default value
            configData.audioPlayerConfig = new AudioPlayerConfig();
            configData.audioPlayerConfig.enabled = false;
            configData.audioPlayerConfig.volume = 0;
            configData.audioPlayerConfig.loop = false;
            configData.audioPlayerConfig.reshuffle = false;
            configData.audioPlayerConfig.audio_files = new List<string>();

            //Web player init with default value
            configData.webPlayerConfig = new WebPlayerConfig();
            configData.webPlayerConfig.enabled = false;
            configData.webPlayerConfig.web_urls = new List<string>();

            //Radio player init with default value
            configData.radioPlayerConfig = new RadioPlayerConfig();
            configData.radioPlayerConfig.enabled = false;
            configData.radioPlayerConfig.volume = 0;
            configData.radioPlayerConfig.loop = false;
            configData.radioPlayerConfig.reshuffle = false;
            configData.radioPlayerConfig.radio_urls = new List<string>();

            if (configFile != null)
            {
                LoadConfigure(configFile);
            }
        }

        public ConfigureMain Clone()
        {
            ConfigureMain destConf = new ConfigureMain(null);

            //Video settings
            destConf.configData.mainPlayerConfig.enabled = this.configData.mainPlayerConfig.enabled;
            destConf.configData.mainPlayerConfig.volume = this.configData.mainPlayerConfig.volume;
            destConf.configData.mainPlayerConfig.loop = this.configData.mainPlayerConfig.loop;
            destConf.configData.mainPlayerConfig.reshuffle = this.configData.mainPlayerConfig.reshuffle;
            foreach (string file in this.configData.mainPlayerConfig.media_files)
            {
                destConf.configData.mainPlayerConfig.media_files.Add(file);
            }

            //Audio settings
            destConf.configData.audioPlayerConfig.enabled = this.configData.audioPlayerConfig.enabled;
            destConf.configData.audioPlayerConfig.volume = this.configData.audioPlayerConfig.volume;
            destConf.configData.audioPlayerConfig.loop = this.configData.audioPlayerConfig.loop;
            destConf.configData.audioPlayerConfig.reshuffle = this.configData.audioPlayerConfig.reshuffle;
            foreach (string file in this.configData.audioPlayerConfig.audio_files)
            {
                destConf.configData.audioPlayerConfig.audio_files.Add(file);
            }

            //Web settings
            destConf.configData.webPlayerConfig.enabled = this.configData.webPlayerConfig.enabled;
            foreach (string url in this.configData.webPlayerConfig.web_urls)
            {
                destConf.configData.webPlayerConfig.web_urls.Add(url);
            }

            //Radio settings
            destConf.configData.radioPlayerConfig.enabled = this.configData.radioPlayerConfig.enabled;
            destConf.configData.radioPlayerConfig.volume = this.configData.radioPlayerConfig.volume;
            foreach (string url in this.configData.radioPlayerConfig.radio_urls)
            {
                destConf.configData.radioPlayerConfig.radio_urls.Add(url);
            }

            return destConf;
        }

        public int AddMediaToConfigure(string media_file, MediaType type)
        {
            int result = 0;

            switch (type)
            {
                case MediaType.Video:
                    if (configData.mainPlayerConfig.media_files.Count == 0)
                    {
                        configData.mainPlayerConfig.enabled = true;
                        configData.mainPlayerConfig.volume = 60;
                    }
                    configData.mainPlayerConfig.media_files.Remove(media_file);
                    configData.mainPlayerConfig.media_files.Add(media_file);
                    result = configData.mainPlayerConfig.media_files.Count;
                    break;

                case MediaType.Audio:
                    if (configData.audioPlayerConfig.audio_files.Count == 0)
                    {
                        configData.audioPlayerConfig.enabled = true;
                        configData.audioPlayerConfig.volume = 60;
                    }
                    configData.audioPlayerConfig.audio_files.Remove(media_file);
                    configData.audioPlayerConfig.audio_files.Add(media_file);
                    result = configData.audioPlayerConfig.audio_files.Count;
                    break;

                default:
                    Debug.WriteLine("Type {0} Media {1} discarded.", type, media_file);
                    result = -1;
                    break;
            }
            return result;
        }

        public void LoadConfigure(string config_file)
        {
            configFile = config_file;
            string jsonString = File.ReadAllText(configFile);
            configData = JsonConvert.DeserializeObject<ConfigData>(jsonString);
            string missingFiles = "";
            List<string> missed = new List<string>();
            foreach (string file in configData.mainPlayerConfig.media_files)
            {
                if (!File.Exists(file))
                {
                    missingFiles += file;
                    missingFiles += "\n";
                    missed.Add(file);
                }
            }
            foreach (string file in missed)
            {
                configData.mainPlayerConfig.media_files.Remove(file);
            }

            missed.Clear();
            foreach (string file in configData.audioPlayerConfig.audio_files)
            {
                if (!File.Exists(file))
                {
                    missingFiles += file;
                    missingFiles += "\n";
                    missed.Add(file);
                }
            }
            foreach (string file in missed)
            {
                configData.audioPlayerConfig.audio_files.Remove(file);
            }

            if (missingFiles != "")
            {
                MessageBox.Show("Cannot load these media files:\n" + missingFiles + "\n\nNote:\nThe playlist file is not changed for now. Click [Save] button in\n[Playlist Setup]dialog window would change playlist file with\nthese missing files removed.");
            }
        }

        public void SaveConfigure(string config_file)
        {
            string jsonString = JsonConvert.SerializeObject(configData, Formatting.Indented);
            File.WriteAllText(config_file, jsonString);
        }
    }

    public enum MediaType {
        None        = -1,
        Playlist    = 0,
        Video       = 1,
        Audio       = 2,
        Web         = 3,
        Radio       = 4
    };

    public enum MediaStatus
    {
        NotExists   = -1,
        OnlineReady = 0,
        Downloading = 1,
        LocalReady  = 2
    };

    public class GlobalDefs
    {
        public static string serverIP = "98.234.74.74";

        public static string[] videoExts = { ".mp4", ".mov", ".wmv", ".flv", ".avi", ".mkv" };
        public static string[] audioExts = { ".mp3", ".wav", ".wma", ".aac" };
        public static string[] photoExts = { ".jpg", ".png", ".bmp" };

        public static string GetVideoFilter()
        {
            string str = String.Format("*{0}", videoExts[0]);
            for (int i = 1; i < videoExts.Length; i++)
            {
                str += String.Format(";*{0}", videoExts[i]);
            }
            return str;
        }

        public static string GetPhotoFilter()
        {
            string str = String.Format("*{0}", photoExts[0]);
            for (int i = 1; i < photoExts.Length; i++)
            {
                str += String.Format(";*{0}", photoExts[i]);
            }
            return str;
        }

        public static string GetAudioFilter()
        {
            string str = String.Format("*{0}", audioExts[0]);
            for (int i = 1; i < audioExts.Length; i++)
            {
                str += String.Format(";*{0}", audioExts[i]);
            }
            return str;
        }

        public static string GetAllFilter()
        {
            return $"{GetVideoFilter()};{GetPhotoFilter()};{GetAudioFilter()}";
        }

        public static MediaType GetMediaType(string file_path)
        {
            if (file_path == null)
            {
                return MediaType.None;
            }
            if (file_path.EndsWith(".myplot.json"))
            {
                return MediaType.Playlist;
            }
            string ext = Path.GetExtension(file_path);
            if (GlobalDefs.videoExts.Contains(ext) || GlobalDefs.photoExts.Contains(ext))
            {
                return MediaType.Video;
            }
            if (GlobalDefs.audioExts.Contains(ext))
            {
                return MediaType.Audio;
            }
            //TODO: Return Web and Radio type later

            return MediaType.None;
        }

        public static MediaStatus GetMediaStatus(string file_path)
        {
            if (File.Exists(file_path))
            {
                return MediaStatus.LocalReady;
            }
            if (File.Exists(file_path + ".downloading"))
            {
                return MediaStatus.Downloading;
            }
            //TODO: Check if it is online available
            if (false)
            {
                return MediaStatus.OnlineReady;
            }
            return MediaStatus.NotExists;
        }
    }

    public class MainPlayerConfig
    {
        public bool enabled { get; set; }
        public int volume { get; set; }
        public bool loop { get; set; }
        public bool reshuffle { get; set; }
        public IList<string> media_files { get; set; }

        //Runtime values
        public int play_index;
        public float play_position;
        public float play_speed;
    }
    public class WebPlayerConfig
    {
        public bool enabled { get; set; }
        public IList<string> web_urls { get; set; }
    }

    public class AudioPlayerConfig
    {
        public bool enabled { get; set; }
        public int volume { get; set; }
        public bool loop { get; set; }
        public bool reshuffle { get; set; }
        public IList<string> audio_files { get; set; }

        //Runtime values
        public int play_index;
        public float play_position;
        public float play_speed;
    }

    public class RadioPlayerConfig
    {
        public bool enabled { get; set; }
        public int volume { get; set; }
        public bool loop { get; set; }
        public bool reshuffle { get; set; }
        public IList<string> radio_urls { get; set; }
    }

    public class ConfigData
    {
        public MainPlayerConfig mainPlayerConfig { get; set; }
        public WebPlayerConfig webPlayerConfig { get; set; }
        public AudioPlayerConfig audioPlayerConfig { get; set; }
        public RadioPlayerConfig radioPlayerConfig { get; set; }
    }
}