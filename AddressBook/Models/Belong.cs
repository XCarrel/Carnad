using System;
using System.Collections.Generic;

namespace AddressBook.Models
{
    public partial class Belong
    {
        public int Id { get; set; }
        public int? ContactId { get; set; }
        public int? GroupId { get; set; }

        public Contacts Contact { get; set; }
        public Groups Group { get; set; }
    }
}
