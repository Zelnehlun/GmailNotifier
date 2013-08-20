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
        public Credentials Credentials { get; set; }
        private Inbox inbox;

        public Account() { }

        public Account(string username, string password)
        {
            this.Credentials = new Credentials(username, password);

            TrySetupInbox();
        }

        public string GetUsername()
        {
            return Credentials.Username;
        }

        public void SetUsername(string username)
        {
            Credentials.Username = username;

            TrySetupInbox();
        }

        public void SetEncryptedPassword(string password)
        {
            Credentials.SetEncryptedPassword(password);

            TrySetupInbox();
        }

        public void TrySetupInbox()
        {
            if (Credentials != null && Credentials.Username != null && Credentials.Password != null)
                this.inbox = new Inbox(Credentials.Username, SecurityUtil.Decrypt(Credentials.Password));
        }

        public Inbox GetInbox()
        {
            return inbox;
        }

        public override string ToString()
        {
            return Credentials.Username;
        }

        public override int GetHashCode()
        {
            return Credentials.Username.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(obj is Account){
                Account account = (Account)obj;

                return account.Credentials.Equals(Credentials);
            }

            return false;
        }
    }
}
