using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class Group
    {
        public string Name { get; set; }

        public Group(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
    public class GroupViewModel
    {
        public List<Group> groups;

        public GroupViewModel()
        {
            groups = new List<Group>();
        }
    }
}
