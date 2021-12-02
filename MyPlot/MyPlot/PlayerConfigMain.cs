using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MyPlot
{
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

        public void LoadConfigure(string config_file)
        {
            configFile = config_file;
            string jsonString = File.ReadAllText(configFile);
            configData = JsonConvert.DeserializeObject<ConfigData>(jsonString);
        }

        public void SaveConfigure(string config_file)
        {
            string jsonString = JsonConvert.SerializeObject(configData);
            File.WriteAllText(config_file, jsonString);
        }
    }
}