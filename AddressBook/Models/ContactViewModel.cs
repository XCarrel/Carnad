using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public partial class Contacts
    {
        [NotMapped]
        public bool BoolBlackList
        {
            get { return BlackList != 0; }
            set { BlackList = (byte)(value ? 1 : 0); }
        }
    }

    public class ContactViewModel
    {
        public List<Contacts> contacts;
    }
}
