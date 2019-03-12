using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AddressBook.Models;
using Microsoft.AspNetCore.Authorization;

namespace AddressBook.Controllers
{
    public class ContactsController : Controller
    {
        private readonly CarnadContext _context;

        public ContactsController(CarnadContext context)
        {
            _context = context;
        }

        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacts = await _context.Contacts
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contacts == null)
            {
                return NotFound();
            }

            return View(contacts);
        }

        // GET: Contacts/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PhoneNumber,Email,BoolBlackList,Gender,CountryId")] Contacts contacts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contacts);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", contacts.CountryId);
            return View("Details",contacts);
        }

        // GET: Contacts/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacts = await _context.Contacts.FindAsync(id);
            if (contacts == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", contacts.CountryId);
            return View(contacts);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PhoneNumber,Email,BoolBlackList,Gender,CountryId")] Contacts contacts)
        {
            if (id != contacts.Id)
            {
                return NotFound();
            }

            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", contacts.CountryId);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacts);
                    await _context.SaveChangesAsync();
                    contacts = await _context.Contacts.Include(c => c.Country).FirstOrDefaultAsync(m => m.Id == id); // must reload to get related data
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactsExists(contacts.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return View("Details",contacts);
            }
            return View(contacts);
        }

        // GET: Contacts/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacts = await _context.Contacts
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contacts == null)
            {
                return NotFound();
            }

            return View(contacts);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contacts = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contacts);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private bool ContactsExists(int id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
