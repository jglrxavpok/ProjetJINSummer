using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace JINSummer.Saves {
    public class SaveManager {

        public static readonly string SaveFileName = "savedata.txt";
        private static Dictionary<string, string> properties = new Dictionary<string, string>();
        
        static SaveManager() {
            Load();
        }

        private static void Load() {
            if (!File.Exists(SaveFileName)) {
                Save();
            }

            using (StreamReader reader = File.OpenText(SaveFileName)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    LoadLine(line);
                }
            }
        }

        private static void LoadLine(string line) {
            string[] parts = line.Split('=');
            if (parts.Length > 1) {
                string name = parts[0];
                string value = parts[1];
                properties[name] = value;
            } else {
                Debug.LogError("Invalid property line: "+line);
            }
        }

        public static void Save() {
            using (StreamWriter writer = File.CreateText(SaveFileName)) {
                foreach(KeyValuePair<string, string> entry in properties) {
                    writer.WriteLine(entry.Key+"="+entry.Value);
                }
            }
        }

        public static void Set<T>(string name, T value) {
            properties[name] = value.ToString();
        }
        
        public static int ReadInt(string name, int defaultValue) {
            if (!properties.ContainsKey(name)) {
                properties[name] = defaultValue.ToString();
            }
            return int.Parse(properties[name]);
        }
        
        public static bool ReadBoolean(string name, bool defaultValue) {
            if (!properties.ContainsKey(name)) {
                properties[name] = defaultValue.ToString();
            }
            return bool.Parse(properties[name]);
        }
    }
}
