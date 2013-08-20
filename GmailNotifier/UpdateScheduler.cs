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
        public UpdateScheduler Instance
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
        private UpdateScheduler instance;
        private Timer timer = new Timer();

        private UpdateScheduler()
        {
            timer.Interval = 60000;
            timer.Elapsed += onCheckMail;

            timer.Start();
        }

        private void onCheckMail(object sender, EventArgs e)
        {
            AccountManager accountManager = AccountManager.Instance;
            bool errorIcon = false;

            foreach (Account account in accountManager.Accounts)
            {
                Inbox inbox = account.Inbox;

                if (inbox.CheckMailNow())
                {

                }
                else
                {
                    errorIcon = true;
                }
            }
        }

    }
}
