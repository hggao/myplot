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
    public class GlobalDefs
    {
        public static string[] videoExts = {".mp4", ".mov", ".wmv", ".flv", ".avi", ".mkv"};
        public static string[] audioExts = {".mp3", ".wav", ".wma", ".aac"};
        public static string[] photoExts = {".jpg", ".png", ".bmp"};

        public static string GetVideoFilter()
        {
            string str = String.Format("*{0}", videoExts[0]);
            for (int i = 1; i <  videoExts.Length; i++)
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
    }

    public class MainPlayerConfig
    {
        public bool enabled { get; set; }
        public int volume { get; set; }
        public bool loop { get; set; }
        public bool reshuffle { get; set; }
        public IList<string> media_files { get; set; }

        //Runtime values
        public int   play_index;
        public float play_position;
        public float play_speed;
    }
    public class WebPlayerConfig
    {
        public bool enabled { get; set; }
        public int volume { get; set; }
        public bool loop { get; set; }
        public bool reshuffle { get; set; }
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

    public class ConfigureMain
    {
        public ConfigData configData;
        public string configFile;

        public void DefaultConfigure(string media_file, MediaType type)
        {
            this.configFile = null;
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
            configData.webPlayerConfig.volume = 0;
            configData.webPlayerConfig.loop = false;
            configData.webPlayerConfig.reshuffle = false;
            configData.webPlayerConfig.web_urls = new List<string>();

            //Radio player init with default value
            configData.radioPlayerConfig = new RadioPlayerConfig();
            configData.radioPlayerConfig.enabled = false;
            configData.radioPlayerConfig.volume = 0;
            configData.radioPlayerConfig.loop = false;
            configData.radioPlayerConfig.reshuffle = false;
            configData.radioPlayerConfig.radio_urls = new List<string>();

            switch (type)
            {
                case MediaType.None:
                    break;

                case MediaType.Video:
                    configData.mainPlayerConfig.enabled = true;
                    configData.mainPlayerConfig.volume = 60;
                    configData.mainPlayerConfig.media_files.Add(media_file);
                    break;

                case MediaType.Audio:
                    configData.audioPlayerConfig.enabled = true;
                    configData.audioPlayerConfig.volume = 60;
                    configData.audioPlayerConfig.audio_files.Add(media_file);
                    break;
            }
        }

        public void LoadConfigure(string config_file)
        {
            MediaType type = GetMediaType(config_file);
            if (type == MediaType.Playlist)
            {
                this.configFile = config_file;
                string jsonString = File.ReadAllText(configFile);
                this.configData = JsonConvert.DeserializeObject<ConfigData>(jsonString);
                return;
            }

            //For individual media types, we genterate a default config.
            DefaultConfigure(config_file, type);
        }

        public void SaveConfigure(string config_file)
        {
            string jsonString = JsonConvert.SerializeObject(configData);
            File.WriteAllText(config_file, jsonString);
        }

        public enum MediaType { None = -1, Playlist = 0, Video = 1, Audio = 2, Web = 3, Radio = 4 };
        public MediaType GetMediaType(string file_path)
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

    }
}