using System;
using System.IO;
using System.Xml.Serialization;

namespace SteamCreator
{
    [Serializable]
    public class LoadConfig
    {
        private const string Filename = "settings.xml";
        private static readonly XmlSerializer serial = new XmlSerializer(typeof (LoadConfig));
        private static LoadConfig instance;

        public static LoadConfig Instance
        {
            get
            {
                if (instance != null) return instance;

                using (var sr = new StreamReader(Filename))
                    return instance = (LoadConfig) serial.Deserialize(sr);
            }
        }

        public string SteamPath { get; set; }
        public string SavePath { get; set; }
        public string ImagePath { get; set; }
        public string UsernamesPath { get; set; }
        public int CheckTime { get; set; }
    }
}