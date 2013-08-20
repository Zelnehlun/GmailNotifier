using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailNotifier
{
    public class Author
    {
        public readonly string Name;
        public readonly string Email;
        private readonly string TO_STRING;
        private readonly int HASH_CODE;

        public Author(string name, string email)
        {
            this.Name = name;
            this.Email = email;
            this.TO_STRING = Name + " <" + Email + ">";
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
            if (obj is Author)
            {
                Author author = (Author)obj;

                return author.Name.Equals(Name) && author.Email.Equals(Email);
            }

            return false;
        }
    }
}
