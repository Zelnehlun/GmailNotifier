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
        private AddEditAccountForm addAccount;
        private AddEditAccountForm editAccount;

        public OptionsForm()
        {
            InitializeComponent();
            updateAccountList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (addAccount == null || addAccount.IsDisposed)
                addAccount = new AddEditAccountForm("Add Account");

            DialogResult result = addAccount.ShowDialog();

            if (result == DialogResult.OK)
            {
                Account account = new Account(addAccount.Username, addAccount.Password);

                AccountManager.Instance.AddAccount(account);
                updateAccountList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Account account = (Account)listBox1.SelectedItem;

            if (account != null)
            {
                if (editAccount == null || editAccount.IsDisposed)
                    editAccount = new AddEditAccountForm("Edit Account");

                editAccount.Username = account.Username;
                editAccount.Password = account.Password;

                DialogResult result = editAccount.ShowDialog();

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
