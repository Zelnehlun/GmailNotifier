using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GmailNotifier
{
    public class MailForm : Form
    {
        private ContextMenu trayMenu;
        private NotifyIcon trayIcon;

        public MailForm()
        {
            trayMenu = new ContextMenu();

            MenuItem viewInbox = new MenuItem("View Inbox");
            viewInbox.DefaultItem = true;

            trayMenu.MenuItems.Add(viewInbox);
            trayMenu.MenuItems.Add("Check Mail Now");
            trayMenu.MenuItems.Add("Tell me Again...");
            trayMenu.MenuItems.Add("Options");
            trayMenu.MenuItems.Add("About...");
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add("Exit", onExit);

            trayIcon = new NotifyIcon();
            trayIcon.Text = "No unread mail";
            trayIcon.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            this.Visible = false;
            this.ShowInTaskbar = false;
        }

        private void onExit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                trayIcon.Dispose();
            }

            base.Dispose(isDisposing);
        }
    }
}
