using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Net;
using System.Collections;

namespace LabelPrinter
{
    class ConfigINI
    {
        public string path;
        Hashtable Settings;


        public ConfigINI(string INIPath)
        {
            path = INIPath;
            Settings = new Hashtable();
        }

        public void Save()
        {
            string key;
            string value;
            System.IO.StreamWriter file = new System.IO.StreamWriter(path, false);

            foreach (DictionaryEntry i in Settings)
            {
                key = i.Key.ToString();
                value = WebUtility.HtmlEncode(i.Value.ToString());
                file.WriteLine(key + "=" + value);
            }
            file.Close();
        }
        public void Load()
        {
            string line;
            string key;
            string value;
            Settings.Clear();
            if (System.IO.File.Exists(path))
            {
                System.IO.StreamReader file = new System.IO.StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    key = line.Split('=')[0];
                    value = WebUtility.HtmlDecode(line.Split('=')[1]);
                    Settings.Add(key, value);
                }
                file.Close();
            }

        }

        public void WriteValue(string Key, bool Value)
        {

            string s = WebUtility.HtmlEncode(Value.ToString());
            if (Settings.ContainsKey(Key))
                Settings[Key] = s;
            else
                Settings.Add(Key, s);

        }
        public void WriteValue(string Key, string Value)
        {

            string s = WebUtility.HtmlEncode(Value);
            if (Settings.ContainsKey(Key))
                Settings[Key] = s;
            else
                Settings.Add(Key, s);

        }
        public void WriteValue(string Key, int Value)
        {
            string s = WebUtility.HtmlEncode(Value.ToString());
            if (Settings.ContainsKey(Key))
                Settings[Key] = s;
            else
                Settings.Add(Key, s);

        }
        public void WriteValue(string Key, DateTime Value)
        {

            string s = WebUtility.HtmlEncode(Value.ToString());
            if (Settings.ContainsKey(Key))
                Settings[Key] = s;
            else
                Settings.Add(Key, s);
        }
        public void WriteValue(string Key, long Value)
        {

            string s = WebUtility.HtmlEncode(Value.ToString());
            if (Settings.ContainsKey(Key))
                Settings[Key] = s;
            else
                Settings.Add(Key, s);
        }




        public string ReadString(string Key)
        {
            String s;
            if (Settings.ContainsKey(Key))
                s = WebUtility.HtmlDecode((String)Settings[Key]);
            else
                s = "";
            return s;
        }
        public int ReadInt(string Key)
        {
            String s;
            if (Settings.ContainsKey(Key))
                s = WebUtility.HtmlDecode((String)Settings[Key]);
            else
                s = "0";
            return Convert.ToInt32(s);

        }
        public bool ReadBool(string Key)
        {
            String s;
            if (Settings.ContainsKey(Key))
                s = WebUtility.HtmlDecode((String)Settings[Key]);
            else
                s = "false";
            return Convert.ToBoolean(s);

        }
        public DateTime ReadDateTime(string Key)
        {
            String s;
            if (Settings.ContainsKey(Key))
                s = WebUtility.HtmlDecode((String)Settings[Key]);
            else
                s = "1/1/1970";
            return Convert.ToDateTime(s);
        }
        public long ReadLong(string Key)
        {
            String s;
            if (Settings.ContainsKey(Key))
                s = WebUtility.HtmlDecode((String)Settings[Key]);
            else
                s = "";
            return Convert.ToInt64(s);
        }

    }

}
