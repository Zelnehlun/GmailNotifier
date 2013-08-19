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
        public static void Main(string[] args)
        {
            AccountManager.getInstance().LoadAccounts();
            Application.Run(new MailForm());
        }
    }
}
