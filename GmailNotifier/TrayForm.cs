using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GmailNotifier
{
    public class TrayForm : Form
    {
        private ContextMenu trayMenu;
        private NotifyIcon trayIcon;
        private OptionsForm options;

        protected override void OnLoad(EventArgs e)
        {
            this.Visible = false;
            this.ShowInTaskbar = false;
            trayMenu = initTrayMenu();
            trayIcon = initTrayIcon(trayMenu);
        }

        private void onViewInbox(object sender, EventArgs e)
        {
            Process.Start("https://mail.google.com/mail");
        }

        private void onOptions(object sender, EventArgs e)
        {
            if (options == null || options.IsDisposed)
                options = new OptionsForm();

            options.Show();
        }

        private void onAbout(object sender, EventArgs e)
        {
            NotifyForm notification = new NotifyForm("Written and programmed by Mr. Google");

            notification.Show();
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

        private ContextMenu initTrayMenu()
        {
            ContextMenu trayMenu = new ContextMenu();
            MenuItem viewInbox = new MenuItem("View Inbox", onViewInbox);
            viewInbox.DefaultItem = true;

            trayMenu.MenuItems.Add(viewInbox);
            trayMenu.MenuItems.Add("Check Mail Now");
            trayMenu.MenuItems.Add("Tell me Again...");
            trayMenu.MenuItems.Add("Options", onOptions);
            trayMenu.MenuItems.Add("About...", onAbout);
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add("Exit", onExit);

            return trayMenu;
        }

        private NotifyIcon initTrayIcon(ContextMenu trayMenu)
        {
            NotifyIcon trayIcon = new NotifyIcon();
            trayIcon.Text = "No unread mail";
            trayIcon.Icon = new Icon("nounread.ico");
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;

            return trayIcon;
        }
    }
}
