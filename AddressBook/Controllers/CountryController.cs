using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;

namespace AddressBook.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Index()
        {
            CountryViewModel data = new CountryViewModel();
            data.countries.Add(new Country("Suisse", 41));
            data.countries.Add(new Country("France", 33));
            data.countries.Add(new Country("Allemagne", 49));
            return View(data); 
        }
    }
}