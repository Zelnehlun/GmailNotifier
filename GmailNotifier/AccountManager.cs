using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GmailNotifier
{
    public class AccountManager
    {
        public static AccountManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountManager();

                return instance;
            }
            set
            {
                instance = value;
            }
        }
        private static AccountManager instance;
        private const string FILE = "accounts.json";
        public ICollection<Account> Accounts { get; private set; }

        public void AddAccount(Account account)
        {
            Accounts.Add(account);
            SaveAccounts();
        }

        public void LoadAccounts()
        {
            string json = FileUtil.ReadAllText(FILE);

            if (json != null)
            {
                Accounts = JsonConvert.DeserializeObject<ICollection<Account>>(json);
            }
            else
            {
                Accounts = new List<Account>();
            }
        }

        public void SaveAccounts()
        {
            string json = JsonConvert.SerializeObject(Accounts);

            FileUtil.WriteAllText(FILE, json);
        }
    }
}
