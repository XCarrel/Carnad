﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;

namespace AddressBook.Controllers
{
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Page = "groups";
            CarnadContext db = new CarnadContext();
            GroupViewModel data = new GroupViewModel();
            data.groups = db.Groups;
            return View(data);
        }
    }
}