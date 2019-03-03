using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    [ModelMetadataType(typeof(CountriesMetadata))]
    public partial class Countries
    {
    }

    public class CountriesMetadata
    {
        [Display(Name = "Indicatif international")]
        public int? Dialcode { get; set; }

        [Display(Name = "Pays")]
        public string Name { get; set; }
    }
}
