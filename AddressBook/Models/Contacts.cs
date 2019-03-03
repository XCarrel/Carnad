using System;
using System.Collections.Generic;

namespace AddressBook.Models
{
    public partial class Contacts
    {
        public Contacts()
        {
            Belong = new HashSet<Belong>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte BlackList { get; set; }
        public byte? Gender { get; set; }
        public int CountryId { get; set; }

        public Countries Country { get; set; }
        public ICollection<Belong> Belong { get; set; }
    }
}
