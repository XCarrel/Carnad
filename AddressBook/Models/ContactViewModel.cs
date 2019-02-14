using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Country Country { get; set; }
        public List<Group> groups;

        public Contact(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = null;
            this.groups = new List<Group>();
        }
    }
    public class ContactViewModel
    {
        public List<Contact> contacts;

        public ContactViewModel()
        {
            contacts = new List<Contact>();
        }
    }
}
