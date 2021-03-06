﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {
        private CarnadContext carnadContext;
        public HomeController(CarnadContext cc)
        {
            carnadContext = cc;
        }

        public IActionResult Index()
        {
            ViewBag.Page = "home";

            // Retrieve user name for title
            string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            user = user.Substring(user.LastIndexOf('\\') + 1);  // Strip off domain name
            ViewBag.User = user;

            ContactViewModel data = new ContactViewModel();
            // eagerly load navigation properties
            data.contacts = carnadContext.Contacts.Include(c => c.Country).Include(c => c.Belong).ThenInclude(b => b.Group).ToList();

            return View(data);
        }

        public IActionResult About()
        {
            ViewBag.Page = "about";
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
