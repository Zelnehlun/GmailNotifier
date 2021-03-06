﻿namespace GmailNotifier
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkInterval = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.notificationInterval = new System.Windows.Forms.NumericUpDown();
            this.animationSpeed = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.notificationVisible = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.checkInterval)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notificationInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationVisible)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkInterval
            // 
            this.checkInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.checkInterval.Location = new System.Drawing.Point(101, 19);
            this.checkInterval.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.checkInterval.Name = "checkInterval";
            this.checkInterval.Size = new System.Drawing.Size(47, 20);
            this.checkInterval.TabIndex = 1;
            this.checkInterval.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.checkInterval.ValueChanged += new System.EventHandler(this.checkInterval_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(235, 120);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accounts";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(154, 78);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(154, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Edit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(154, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(142, 82);
            this.listBox1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Notification interval (s)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Animation speed";
            // 
            // notificationInterval
            // 
            this.notificationInterval.Location = new System.Drawing.Point(271, 45);
            this.notificationInterval.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.notificationInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.notificationInterval.Name = "notificationInterval";
            this.notificationInterval.Size = new System.Drawing.Size(47, 20);
            this.notificationInterval.TabIndex = 7;
            this.notificationInterval.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.notificationInterval.ValueChanged += new System.EventHandler(this.notificationInterval_ValueChanged);
            // 
            // animationSpeed
            // 
            this.animationSpeed.DecimalPlaces = 1;
            this.animationSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.animationSpeed.Location = new System.Drawing.Point(101, 45);
            this.animationSpeed.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.animationSpeed.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.animationSpeed.Name = "animationSpeed";
            this.animationSpeed.Size = new System.Drawing.Size(47, 20);
            this.animationSpeed.TabIndex = 8;
            this.animationSpeed.Value = new decimal(new int[] {
            14,
            0,
            0,
            65536});
            this.animationSpeed.ValueChanged += new System.EventHandler(this.animationSpeed_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(154, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Notification visible (s)";
            // 
            // notificationVisible
            // 
            this.notificationVisible.Location = new System.Drawing.Point(271, 19);
            this.notificationVisible.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.notificationVisible.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.notificationVisible.Name = "notificationVisible";
            this.notificationVisible.Size = new System.Drawing.Size(47, 20);
            this.notificationVisible.TabIndex = 10;
            this.notificationVisible.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.notificationVisible.ValueChanged += new System.EventHandler(this.notificationVisible_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Check interval (s)";
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.animationSpeed);
            this.groupBox2.Controls.Add(this.notificationVisible);
            this.groupBox2.Controls.Add(this.notificationInterval);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.checkInterval);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(324, 84);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(253, 102);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "Reset";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(343, 258);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.Text = "Gmail Notifier Options";
            ((System.ComponentModel.ISupportInitialize)(this.checkInterval)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.notificationInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animationSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notificationVisible)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown checkInterval;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown notificationInterval;
        private System.Windows.Forms.NumericUpDown animationSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown notificationVisible;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button4;
    }
}