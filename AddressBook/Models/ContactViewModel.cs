using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class ContactViewModel
    {
        public DbSet<Contacts> contacts;
    }
}
