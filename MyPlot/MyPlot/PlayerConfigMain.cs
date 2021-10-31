﻿using System;
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
        public IList<string> madia_files { get; set; }
    }
    public class PIPPlayerConfig
    {
        public bool enabled { get; set; }
        public int volume { get; set; }
        public IList<string> pip_urls { get; set; }
    }

    public class AudioPlayerConfig
    {
        public bool enabled { get; set; }
        public int volume { get; set; }
        public IList<string> audio_files { get; set; }
    }

    public class RadioPlayerConfig
    {
        public bool enabled { get; set; }
        public int volume { get; set; }
        public IList<string> radio_urls { get; set; }
    }

    public class ConfigData
    {
        public MainPlayerConfig mainPlayerConfig { get; set; }
        public PIPPlayerConfig pipPlayerConfig { get; set; }
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
        }
    }
}