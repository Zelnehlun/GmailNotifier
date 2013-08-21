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
        public double AnimationSpeed
        {
            get
            {
                return animationSpeed;
            }
            set
            {
                animationSpeed = value;

                Save();
            }
        }
        public int CheckInterval
        {
            get
            {
                return checkInterval;
            }
            set
            {
                checkInterval = value;

                UpdateScheduler.Instance.SetCheckIntervalSeconds(value);
                Save();
            }
        }
        public int NotificationVisible
        {
            get
            {
                return notificationVisible;
            }
            set
            {
                notificationVisible = value;

                Save();
            }
        }
        public int NotificationInterval
        {
            get
            {
                return notificationInterval;
            }
            set
            {
                notificationInterval = value;

                NotificationManager.Instance.SetNotificationIntervalSeconds(value);
                Save();
            }
        }
        private double animationSpeed = 1.4;
        private int checkInterval = 60;
        private int notificationVisible = 6;
        private int notificationInterval = 4;

        public static void Load()
        {
            instance = FileUtil.DeserializeJson<Options>(FILE);

            if (instance == null)
                instance = new Options();
        }

        public static void Save()
        {
            FileUtil.SerializeJson(FILE, instance);
        }

        public static void Reset()
        {
            instance = new Options();
        }
    }
}
