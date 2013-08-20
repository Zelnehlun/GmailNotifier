using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GmailNotifier
{
    public class UpdateScheduler
    {
        public static UpdateScheduler Instance
        {
            get
            {
                if (instance == null)
                    instance = new UpdateScheduler();

                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private static UpdateScheduler instance;
        private Timer timer = new Timer();

        private UpdateScheduler()
        {
            timer.Interval = 60000;
            timer.Elapsed += onCheckMail;
        }

        public void Start()
        {
            timer.Start();
        }

        public void TellMeAgain(bool all)
        {
            AccountManager accountManager = AccountManager.Instance;

            foreach (Account account in accountManager.Accounts)
            {
                Inbox inbox = account.GetInbox();
                Email[] emails = all ? inbox.GetEmails() : inbox.PollNotifyEmails();

                for (int i = 0; i < emails.Length; i++)
                {
                    Email email = emails[i];
                    string message = (i + 1) + " of " + emails.Length + " - " + email.ToString();

                    NotificationManager.Instance.QueueNotification(message);
                }
            }
        }

        public void CheckMailNow()
        {
            AccountManager accountManager = AccountManager.Instance;
            bool errorIcon = false;
            bool unreadIcon = false;

            foreach (Account account in accountManager.Accounts)
            {
                Inbox inbox = account.GetInbox();

                if (inbox.CheckMailNow())
                {
                    if (inbox.HasEmails())
                    {
                        unreadIcon = true;
                    }
                }
                else
                {
                    errorIcon = true;
                }
            }

            if (errorIcon)
            {
                MainApp.Tray.SetIcon("error");
            }
            else if (unreadIcon)
            {
                MainApp.Tray.SetIcon("unread");
            }
            else
            {
                MainApp.Tray.SetIcon("nounread");
            }

            TellMeAgain(false);
        }

        private void onCheckMail(object sender, EventArgs e)
        {
            CheckMailNow();
        }

    }
}
