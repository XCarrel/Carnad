using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ContactViewModel data = new ContactViewModel();

            data.contacts.Add(new Contact("Sheldon", "Cooper"));
            data.contacts.Add(new Contact("Penny", "Lame"));
            data.contacts.Add(new Contact("Howard", "Wolowitz"));
            data.contacts.Add(new Contact("Bernadette", "Klinks"));

            data.contacts[0].Email = "Sheldon@mit.us";
            data.contacts[1].PhoneNumber = "21 122 12 12";
            data.contacts[1].Country = new Country("Allemagne", 49);
            data.contacts[2].PhoneNumber = "33 444 43 34";
            data.contacts[2].Country = new Country("Suisse", 41);
            data.contacts[2].groups.Add(new Group("Tennis"));
            data.contacts[3].PhoneNumber = "98 765 43 21";
            data.contacts[3].Country = new Country("Suisse", 41);
            data.contacts[3].groups.Add(new Group("Tennis"));
            data.contacts[3].groups.Add(new Group("Collègues"));
            data.contacts[3].groups.Add(new Group("Amis"));


            return View(data);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Carnet d'addresse";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
