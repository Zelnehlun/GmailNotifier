using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailNotifier
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Account(string username, string password)
        {
            this.Username = username;
            this.Password = password;
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
    }
}
