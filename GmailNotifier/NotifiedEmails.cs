using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailNotifier
{
    public class NotifiedEmails
    {
        private readonly ISet<int> notifiedEmails = new HashSet<int>();

        public bool IsNotifiedEmail(Email email)
        {
            return notifiedEmails.Contains(email.GetHashCode());
        }

        public void AddNotifiedEmail(Email email)
        {
            notifiedEmails.Add(email.GetHashCode());
        }

        public void ClearNotifiedEmails()
        {
            notifiedEmails.Clear();
        }
    }
}
