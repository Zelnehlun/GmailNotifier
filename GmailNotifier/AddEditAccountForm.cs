using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GmailNotifier
{
    public partial class AddEditAccountForm : Form
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public AddEditAccountForm(string title, string username, string password)
        {
            this.Text = title;
            this.Username = username;
            this.Password = password;

            InitializeComponent();
        }

        public AddEditAccountForm(string title) : this(title, "", "") { }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Username = textBox1.Text;
            this.Password = textBox2.Text;

            this.Dispose();
        }
    }
}
