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
        public ICollection<Email> NewEmails = new List<Email>();
        public string ErrorMessage { get; private set; }
        public int NewEmailCount { get; private set; }
        private string username;
        private string password;

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
                WebRequest webRequest = WebRequest.Create(@"https://mail.google.com/mail/feed/atom");
                webRequest.PreAuthenticate = true;
                webRequest.Credentials = new NetworkCredential(username, password);
                WebResponse webResponse = webRequest.GetResponse();
                XElement xmlFeed = XElement.Load(webResponse.GetResponseStream());

                fetchEmails(xmlFeed);

                return true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();

                return false;
            }
        }

        private void fetchEmails(XElement xmlFeed)
        {
            XNamespace ns = xmlFeed.Name.Namespace;
            XElement fullcount = xmlFeed.Element(ns + "fullcount");
            NewEmailCount = Convert.ToInt32(fullcount.Value);

            foreach (XElement entry in xmlFeed.Elements(ns + "entry"))
            {
                XElement title = entry.Element(ns + "title");
                XElement summary = entry.Element(ns + "summary");
                XElement issued = entry.Element(ns + "issued");
                XElement author = entry.Element(ns + "author");
                XElement authorName = author.Element(ns + "name");
                XElement authorEmail = author.Element(ns + "email");

            }
        }
    }
}
