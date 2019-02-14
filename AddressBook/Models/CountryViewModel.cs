using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    public class Country
    {
        public string Name { get; set; }
        [DisplayName("+")]
        public int DialCode { get; set; }
        public Country(string name, int dialCode)
        {
            this.Name = name;
            this.DialCode = dialCode;
        }
    }
    public class CountryViewModel
    {
        public List<Country> countries;

        public CountryViewModel()
        {
            countries = new List<Country>();
        }
    }
}
