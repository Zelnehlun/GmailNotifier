using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace GmailNotifier
{
    public static class FileUtil
    {
        public static string ReadAllText(string file)
        {
            if (File.Exists(file))
            {
                try
                {
                    return File.ReadAllText(file, Encoding.UTF8);
                }
                catch (Exception) { }
            }

            return null;
        }

        public static bool WriteAllText(string file, string text)
        {
            try
            {
                File.WriteAllText(file, text, Encoding.UTF8);

                return true;
            }
            catch (Exception) { }

            return false;
        }

        public static bool SerializeJson(string file, object obj)
        {
            try
            {
                string json = JsonConvert.SerializeObject(obj);

                return WriteAllText(file, json);
            }
            catch (Exception) { }

            return false;
        }

        public static T DeserializeJson<T>(string file)
        {
            string json = ReadAllText(file);

            if (json != null)
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(json);
                }
                catch (Exception) { }
            }

            return default(T);
        }
    }
}
