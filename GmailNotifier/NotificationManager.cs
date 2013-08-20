using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailNotifier
{
    public static class NotificationManager
    {
        private static NotifyForm notification = new NotifyForm();

        public static void showNotification(string message)
        {
            notification.Show(message);
        }
    }
}
