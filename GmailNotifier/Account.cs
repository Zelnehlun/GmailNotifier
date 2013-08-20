using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailNotifier
{
    public class Account
    {
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;

                if(password != null)
                    createInbox();
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = SecurityUtil.Encrypt(value);

                if(username != null)
                    createInbox();
            }
        }
        [JsonIgnore]
        public Inbox Inbox { get; private set; }
        private string username;
        private string password;

        public Account(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string GetDecryptedPassword()
        {
            return SecurityUtil.Decrypt(password);
        }

        public override string ToString()
        {
            return Username;
        }

        public override int GetHashCode()
        {
            return Username.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(obj is Account){
                Account account = (Account)obj;

                return account.Username.Equals(Username);
            }

            return false;
        }

        private void createInbox()
        {
            this.Inbox = new Inbox(Username, GetDecryptedPassword());
        }
    }
}
