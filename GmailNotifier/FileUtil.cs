using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GmailNotifier
{
    public static class FileUtil
    {
        public static string ReadAllText(string file)
        {
            if (File.Exists(file))
            {
                return File.ReadAllText(file, Encoding.UTF8);
            }

            return null;
        }

        public static void WriteAllText(string file, string text)
        {
            File.WriteAllText(file, text, Encoding.UTF8);
        }
    }
}
