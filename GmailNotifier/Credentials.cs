using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailNotifier
{
    public class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Credentials() { }

        public Credentials(string username, string password)
        {
            this.Username = username;

            SetEncryptedPassword(password);
        }

        public void SetEncryptedPassword(string password)
        {
            this.Password = SecurityUtil.Encrypt(password);
        }

        public override int GetHashCode()
        {
            return Username.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Credentials)
            {
                Credentials credentials = (Credentials)obj;

                return credentials.Username.Equals(Username);
            }

            return false;
        }
    }
}
