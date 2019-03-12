using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AddressBook.Controllers
{
    [Authorize]
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
            data.groups = carnadContext.Groups.Include(c => c.Belong).ToList();
            return View(data);
        }
    }
}