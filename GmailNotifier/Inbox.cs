using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GmailNotifier
{
    public class Inbox
    {
        public string ErrorMessage { get; private set; }
        private IEnumerable<Email> emails = Enumerable.Empty<Email>();
        private readonly NotifiedEmails notifiedEmails = new NotifiedEmails();
        private readonly string username;
        private readonly string password;

        public Inbox(string username, string password)
        {
            this.username = username;
            this.password = password;
            
            CheckMailNow();
        }

        public bool CheckMailNow()
        {
            try
            {
                XElement xmlFeed = fetchXmlFeed();
                emails = fetchEmails(xmlFeed);

                if (!emails.Any())
                    notifiedEmails.ClearNotifiedEmails();

                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();

                return false;
            }
        }

        public bool HasEmails()
        {
            return emails.Any();
        }

        public int GetEmailAmount()
        {
            return emails.Count();
        }

        public Email[] GetEmails()
        {
            return emails.ToArray<Email>();
        }

        public Email[] PollNotifyEmails()
        {
            IEnumerable<Email> emails = pollNotifyEmails();

            return emails.ToArray<Email>();
        }

        private IEnumerable<Email> pollNotifyEmails()
        {
            foreach (Email email in emails)
            {
                if (!notifiedEmails.IsNotifiedEmail(email))
                {
                    notifiedEmails.AddNotifiedEmail(email);

                    yield return email;
                }
            }
        }

        private IEnumerable<Email> fetchEmails(XElement xmlFeed)
        {
            XNamespace ns = xmlFeed.Name.Namespace;

            foreach (XElement entry in xmlFeed.Elements(ns + "entry"))
            {
                Email email = fetchEmail(entry, ns);

                yield return email;
            }
        }

        private Email fetchEmail(XElement entry, XNamespace ns)
        {
            string title = entry.Element(ns + "title").Value;
            string summary = entry.Element(ns + "summary").Value;
            DateTime issued = fetchIssued(entry, ns);
            Author author = fetchAuthor(entry, ns);

            return new Email(title, summary, issued, author);
        }

        private DateTime fetchIssued(XElement entry, XNamespace ns)
        {
            XElement issued = entry.Element(ns + "issued");

            return DateTime.Parse(issued.Value);
        }

        private Author fetchAuthor(XElement entry, XNamespace ns)
        {
            XElement author = entry.Element(ns + "author");
            string authorName = author.Element(ns + "name").Value;
            string authorEmail = author.Element(ns + "email").Value;

            return new Author(authorName, authorEmail);
        }

        private XElement fetchXmlFeed()
        {
            WebRequest webRequest = WebRequest.Create(@"https://mail.google.com/mail/feed/atom");
            webRequest.PreAuthenticate = true;
            webRequest.Credentials = new NetworkCredential(username, password);
            WebResponse webResponse = webRequest.GetResponse();

            return XElement.Load(webResponse.GetResponseStream());
        }
    }
}
