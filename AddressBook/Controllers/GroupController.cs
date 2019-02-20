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
        private CarnadContext carnadContext;
        public GroupController(CarnadContext cc)
        {
            carnadContext = cc;
        }

        public IActionResult Index()
        {
            ViewBag.Page = "groups";
            GroupViewModel data = new GroupViewModel();
            data.groups = carnadContext.Groups;
            return View(data);
        }
    }
}