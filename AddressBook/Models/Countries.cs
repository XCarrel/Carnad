using System;
using System.Collections.Generic;

namespace AddressBook.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Contacts = new HashSet<Contacts>();
        }

        public int Id { get; set; }
        public int? Dialcode { get; set; }
        public string Name { get; set; }

        public ICollection<Contacts> Contacts { get; set; }
    }
}
