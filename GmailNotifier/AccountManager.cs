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
        private ICollection<Account> accounts = new List<Account>();

        public void AddAccount(Account account)
        {
            accounts.Add(account);
            SaveAccounts();
        }

        public void LoadAccounts()
        {
            string file = getFilePath();
            string json = FileUtil.ReadAllText(file);

            if (json != null)
            {
                accounts = JsonConvert.DeserializeObject<ICollection<Account>>(json);
            }
        }

        public void SaveAccounts()
        {
            string file = getFilePath();
            string json = JsonConvert.SerializeObject(accounts);

            FileUtil.WriteAllText(file, json);
        }

        private string getFilePath()
        {
            string path = Assembly.GetExecutingAssembly().Location;
   
            return path + "/accounts.json";
        }
    }
}
