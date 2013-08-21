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
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            updateAccountList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(AccountManager.Instance.PromptAddAccount())
                updateAccountList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Account account = (Account)listBox1.SelectedItem;

            if (account != null)
            {
                AddEditAccountForm editAccount = new AddEditAccountForm("Edit Account", account.GetUsername());
                DialogResult result = editAccount.ShowDialog();

                editAccount.Dispose();

                if (result == DialogResult.OK)
                {
                    account.SetUsername(editAccount.Username);
                    account.SetEncryptedPassword(editAccount.Password);
                    AccountManager.Instance.SaveAccounts();
                    updateAccountList();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void updateAccountList()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = AccountManager.Instance.Accounts;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Account account = (Account)listBox1.SelectedItem;

            if (account != null)
            {
                AccountManager.Instance.DeleteAccount(account);
                updateAccountList();
            }
        }

        private void checkInterval_ValueChanged(object sender, EventArgs e)
        {
            Options.Instance.CheckInterval = (int)checkInterval.Value;
        }

        private void notificationInterval_ValueChanged(object sender, EventArgs e)
        {
            Options.Instance.NotificationInterval = (int)notificationInterval.Value;
        }

        private void animationSpeed_ValueChanged(object sender, EventArgs e)
        {
            Options.Instance.AnimationSpeed = (double)animationSpeed.Value;
        }
    }
}
