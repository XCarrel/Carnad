using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Models
{
    [ModelMetadataType(typeof(ContactsMetadata))]
    public partial class Contacts
    {
        [NotMapped]
        [Display(Name = "Liste noire")]
        public bool BoolBlackList
        {
            get { return BlackList != 0; }
            set { BlackList = (byte)(value ? 1 : 0); }
        }
    }

    public class ContactsMetadata
    {
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength =2, ErrorMessage ="Le nom doit faire entre deux et cinquante caractères de long")]
        [Required(ErrorMessage ="Le nom doit être défini")]
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [RegularExpression(@"^([0-9\(\)\/\+ \-]*)$", ErrorMessage = "Cela ne ressemble pas à un numéro de téléphone")]
        [Display(Name = "Téléphone")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage ="Ceci n'est pas une adresse email valide")]
        [Display(Name = "Courriel")]
        public string Email { get; set; }

        [Display(Name = "Genre")]
        public byte? Gender { get; set; }

        [Display(Name = "Pays")]
        public Countries Country { get; set; }

        [Display(Name = "Pays")]
        public int CountryId { get; set; }
    }

}
