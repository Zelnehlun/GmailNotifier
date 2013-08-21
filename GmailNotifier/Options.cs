using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailNotifier
{
    public class Options
    {
        public static Options Instance
        {
            get
            {
                if (instance == null)
                    Load();

                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private static Options instance;
        private const string FILE = "options.json";
        public double AnimationSpeed = 1.4;
        public int CheckInterval = 60;
        public int NotificationInterval = 4;

        public static void Load()
        {
            instance = FileUtil.DeserializeJson<Options>(FILE);
        }

        public static void Save()
        {
            FileUtil.SerializeJson(FILE, instance);
        }
    }
}
