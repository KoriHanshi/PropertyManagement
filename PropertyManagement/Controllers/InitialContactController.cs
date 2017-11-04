using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropertyManagement.Data;
using PropertyManagement.Models;

namespace PropertyManagement.Controllers
{
    public class InitialContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InitialContactController(ApplicationDbContext context)
        {
            _context = context;    
        }

		public IActionResult Index()
		{
			return View();
		}

        // GET: InitialContact/List
        public async Task<IActionResult> List()
        {
            return View(await _context.InitialContact.Where(m => m.Status == InitialContactStatus.Initial).ToListAsync());
        }

        // GET: InitialContact/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var initialContact = await _context.InitialContact
                .SingleOrDefaultAsync(m => m.Id == id);
            if (initialContact == null)
            {
                return NotFound();
            }

            return View(initialContact);
        }
		

        // POST: InitialContact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameFirst,NameLast,Email,Phone,Zip,BestTime")] InitialContact initialContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(initialContact);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(initialContact);
        }

        // GET: InitialContact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var initialContact = await _context.InitialContact.SingleOrDefaultAsync(m => m.Id == id);
            if (initialContact == null)
            {
                return NotFound();
            }
            return View(initialContact);
        }

        // POST: InitialContact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameFirst,NameLast,Email,Phone,Zip,BestTime")] InitialContact initialContact)
        {
            if (id != initialContact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(initialContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InitialContactExists(initialContact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(initialContact);
        }

        // GET: InitialContact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var initialContact = await _context.InitialContact
                .SingleOrDefaultAsync(m => m.Id == id);
            if (initialContact == null)
            {
                return NotFound();
            }

            return View(initialContact);
        }

        // POST: InitialContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var initialContact = await _context.InitialContact.SingleOrDefaultAsync(m => m.Id == id);
            _context.InitialContact.Remove(initialContact);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InitialContactExists(int id)
        {
            return _context.InitialContact.Any(e => e.Id == id);
        }
    }
}
