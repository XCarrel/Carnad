using System;
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
            GroupViewModel data = new GroupViewModel();

            data.groups.Add(new Group("Collègues"));
            data.groups.Add(new Group("Tennis"));
            data.groups.Add(new Group("Famille"));

            return View(data);
        }
    }
}