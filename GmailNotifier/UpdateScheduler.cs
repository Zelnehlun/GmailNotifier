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
            timer.Elapsed += onCheckMail;

            SetCheckIntervalSeconds(Options.Instance.CheckInterval);
        }

        public void SetCheckIntervalSeconds(int checkInterval)
        {
            timer.Interval = checkInterval * 1000;
        }

        public void Start()
        {
            timer.Start();
        }

        public void TellMeAgain(bool all)
        {
            AccountManager accountManager = AccountManager.Instance;
            bool hasEmails = false;

            foreach (Account account in accountManager.Accounts)
            {
                Inbox inbox = account.GetInbox();

                if (inbox.HasEmails())
                {
                    Email[] emails = all ? inbox.GetEmails() : inbox.PollNotifyEmails();
                    hasEmails = true;

                    for (int i = 0; i < emails.Length; i++)
                    {
                        Email email = emails[i];
                        string message = "<span style='color:red;'>»</span> " + (i + 1) + " of " + emails.Length + " - " + email.ToString();

                        NotificationManager.Instance.QueueNotification(message);
                    }
                }
            }

            if (!hasEmails && all)
                NotificationManager.Instance.ShowNotification("Your inbox contains no unread conversations.");
        }

        public void CheckMailNow()
        {
            AccountManager accountManager = AccountManager.Instance;
            int totalEmails = 0;
            bool errorIcon = false;
            bool unreadIcon = false;

            foreach (Account account in accountManager.Accounts)
            {
                Inbox inbox = account.GetInbox();

                if (inbox.CheckMailNow())
                {
                    int emailAmount = inbox.GetEmailAmount();
                    totalEmails += emailAmount;

                    if (emailAmount > 0)
                        unreadIcon = true;
                }
                else
                {
                    errorIcon = true;
                }
            }

            TellMeAgain(false);
            MainApp.Tray.SetIcon(errorIcon, unreadIcon);
            MainApp.Tray.SetTooltip(totalEmails);
        }

        private void onCheckMail(object sender, EventArgs e)
        {
            CheckMailNow();
        }

    }
}
