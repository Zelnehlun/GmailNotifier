using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

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
        private System.Timers.Timer timer = new System.Timers.Timer();
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

            if (!notification.Visible)
            {
                ShowNotification(message);
            }
            else
            {
                lock (notificationQueue)
                {
                    notificationQueue.Enqueue(message);
                }
            }
        }

        private void onElapsed(object sender, EventArgs e)
        {
            dequeueNotification();
        }

        private void dequeueNotification()
        {
            lock (notificationQueue)
            {
                if (notificationQueue.Count > 0)
                {
                    string message = notificationQueue.Dequeue();

                    notification.Invoke((MethodInvoker)(() =>
                    {
                        notification.Show(message);
                    }));
                }
                else
                {
                    timer.Stop();
                }
            }
        }
    }
}
