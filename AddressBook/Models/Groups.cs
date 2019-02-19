using System;
using System.Collections.Generic;

namespace AddressBook.Models
{
    public partial class Groups
    {
        public Groups()
        {
            Belong = new HashSet<Belong>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Belong> Belong { get; set; }
    }
}
