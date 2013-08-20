using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GmailNotifier
{
    public static class MainApp
    {
        public static TrayForm Tray { get; private set; }

        public static void Main(string[] args)
        {
            AccountManager accountManager = AccountManager.Instance;

            accountManager.LoadAccounts();

            if (!accountManager.HasAccount())
                accountManager.PromptAddAccount();

            UpdateScheduler updateScheduler = UpdateScheduler.Instance;

            updateScheduler.Start();

            Tray = new TrayForm();

            Application.Run(Tray);
        }
    }
}
