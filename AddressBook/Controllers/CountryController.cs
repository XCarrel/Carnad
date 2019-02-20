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
            ViewBag.Page = "countries";
            CarnadContext db = new CarnadContext();
            CountryViewModel data = new CountryViewModel();
            data.countries = db.Countries;
            return View(data); 
        }
    }
}