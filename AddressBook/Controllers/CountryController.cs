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
        private CarnadContext carnadContext;
        public CountryController(CarnadContext cc)
        {
            carnadContext = cc;
        }

        public IActionResult Index()
        {
            ViewBag.Page = "countries";
            CountryViewModel data = new CountryViewModel();
            data.countries = carnadContext.Countries;
            return View(data); 
        }
    }
}