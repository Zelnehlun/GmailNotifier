using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace GmailNotifier
{
    public partial class NotifyForm : Form
    {
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private int maxHeight;
        private int targetY;

        public NotifyForm(string message)
        {
            InitializeComponent();

            this.label1.Text = message;
            Screen screen = Screen.PrimaryScreen;
            Rectangle r = screen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(r.Width - this.Width, r.Height);
            this.maxHeight = r.Height;
            this.targetY = r.Height - this.Height;
            timer.Interval = 15;
            timer.Tick += new EventHandler(moveUp);

            timer.Start();
        }

        private void moveUp(object sender, EventArgs e)
        {
            Point p = this.Location;
            int y = p.Y;

            if (y > targetY)
            {
                y -= 2;

                if (y < targetY)
                    y = targetY;

                this.Location = new Point(p.X, y);

                updateVisibleHeight();
            }
            else
            {
                timer.Interval = 6000;
                timer.Tick -= moveUp;
                timer.Tick += startMoveDown;
            }
        }

        private void updateVisibleHeight()
        {
            this.Height = maxHeight - this.Location.Y;
        }

        private void startMoveDown(object sender, EventArgs e)
        {
            timer.Interval = 15;
            timer.Tick -= startMoveDown;
            timer.Tick += moveDown;
            targetY = maxHeight;
        }

        private void moveDown(object sender, EventArgs e)
        {
            Point p = this.Location;
            int y = p.Y;

            if (y < targetY)
            {
                y += 2;

                if (y > targetY)
                    y = targetY;

                this.Location = new Point(p.X, y);

                updateVisibleHeight();
            }
            else
            {
                timer.Tick -= moveDown;

                timer.Stop();
                this.Dispose();
            }
        }
    }
}
