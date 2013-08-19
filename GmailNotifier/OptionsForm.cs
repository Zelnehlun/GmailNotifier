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
                AddEditAccountForm editAccount = new AddEditAccountForm("Edit Account", account.Username);
                DialogResult result = editAccount.ShowDialog();

                editAccount.Dispose();

                if (result == DialogResult.OK)
                {
                    account.Username = editAccount.Username;
                    account.Password = editAccount.Password;

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
    }
}
