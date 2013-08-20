using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GmailNotifier
{
    public class NotificationManager
    {
        public static NotificationManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new NotificationManager();

                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private static NotificationManager instance;
        private Queue<string> notificationQueue = new Queue<string>();
        private Timer timer = new Timer();
        private NotifyForm notification = new NotifyForm();

        private NotificationManager()
        {
            timer.Interval = 5000;
            timer.Elapsed += onElapsed;
        }

        public void ShowNotification(string message)
        {
            notification.Show(message);
        }

        public void QueueNotification(string message)
        {
            if (!timer.Enabled)
                timer.Start();

            lock (notificationQueue)
            {
                notificationQueue.Enqueue(message);
            }
        }

        private void onElapsed(object sender, EventArgs e)
        {
            lock (notificationQueue)
            {
                if (notificationQueue.Count > 0)
                {
                    string message = notificationQueue.Dequeue();

                    ShowNotification(message);
                }
                else
                {
                    timer.Stop();
                }
            }
        }
    }
}
