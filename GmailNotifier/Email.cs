using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailNotifier
{
    public class Email
    {
        public readonly string Title;
        public readonly string Summary;
        public readonly DateTime Issued;
        public readonly Author Author;
        private readonly string TO_STRING;
        private readonly int HASH_CODE;

        public Email(string title, string summary, DateTime issued, Author author)
        {
            this.Title = title;
            this.Summary = summary;
            this.Issued = issued;
            this.Author = author;
            this.TO_STRING = generateContent();
            this.HASH_CODE = TO_STRING.GetHashCode();
        }

        public override string ToString()
        {
            return TO_STRING;
        }

        public override int GetHashCode()
        {
            return HASH_CODE;
        }

        public override bool Equals(object obj)
        {
            if(obj is Email){
                Email email = (Email)obj;

                return email.Title.Equals(Title) &&
                       email.Summary.Equals(Summary) &&
                       email.Issued.Equals(Issued) &&
                       email.Author.Equals(Author);
            }

            return false;
        }

        private string generateContent()
        {
            string format = "";

            if (Issued.Day == DateTime.Now.Day)
            {
                format = "HH:mm";
            }
            else
            {
                format = "MMM dd";
            }

            string shortTitle = Title;

            if (shortTitle.Length > 50)
                shortTitle = shortTitle.Substring(0, 50) + "...";

            return String.Format("{0:" + format + "}", Issued) + " <b>" + Author.Name + "<br>" + shortTitle + "</b><br><span style='font-size:95%;'><i>" + Summary + "</i></span>";
        }
    }
}
