﻿using System;
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
        private AnimationState animationState = AnimationState.STOPPED;
        private double y;
        private readonly int normalInterval = 1;
        private readonly int maxY;
        private readonly int maxHeight;
        private int targetY;

        public NotifyForm()
        {
            InitializeComponent();

            Screen screen = Screen.PrimaryScreen;
            Rectangle r = screen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.maxY = r.Height;
            this.Location = new Point(r.Width - this.Width, maxY);
            this.y = this.Location.Y;
            this.maxHeight = this.Height;
            timer.Tick += onTick;

            this.Hide();
        }

        public void Show(string message)
        {
            this.label1.Text = message;

            startMoveUp();
            this.Show();
        }

        private void startMoveUp()
        {
            this.animationState = AnimationState.UP;
            this.targetY = maxY - maxHeight;
            timer.Interval = normalInterval;

            timer.Start();
        }

        private void startMoveDown()
        {
            this.animationState = AnimationState.DOWN;
            this.targetY = maxY;
            timer.Interval = normalInterval;
        }

        private void waitAnimation()
        {
            this.animationState = AnimationState.WAIT;
            timer.Interval = Options.Instance.NotificationVisible * 1000;
        }

        private void stopAnimation()
        {
            this.animationState = AnimationState.STOPPED;

            timer.Stop();
            this.Hide();
        }

        private void onTick(object sender, EventArgs e)
        {
            updateAnimationState();
            updateVisibleHeight();
            updateOpacity();
        }

        private void updateAnimationState()
        {
            if (y == targetY)
            {
                switch (animationState)
                {
                    case AnimationState.UP:
                        waitAnimation();
                        break;
                    case AnimationState.WAIT:
                        startMoveDown();
                        break;
                    case AnimationState.DOWN:
                        stopAnimation();
                        break;
                }
            }
            else
            {
                updateLocation();
            }
        }

        private void updateLocation()
        {
            double step = Options.Instance.AnimationSpeed;

            if (y > targetY)
            {
                move(-step);
            }
            else
            {
                move(step);
            }
        }

        private void move(double step)
        {
            y += step;

            if (step < 0)
            {
                if(y < targetY)
                    y = targetY;
            }
            else
            {
                if(y > targetY)
                    y = targetY;
            }

            Point p = this.Location;
            this.Location = new Point(p.X, (int)Math.Round(y));
        }

        private void updateVisibleHeight()
        {
            this.Height = maxY - this.Location.Y;
        }

        private void updateOpacity()
        {
            this.Opacity = 0.9d * this.Height / maxHeight;
        }
    }
}
