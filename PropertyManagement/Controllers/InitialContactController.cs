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

        // POST: InitialContact/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Id,NameFirst,NameLast,Email,Phone,Zip,BestTime")] InitialContact initialContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(initialContact);
                await _context.SaveChangesAsync();
                return RedirectToAction("ThankYou");
            }
            return View(initialContact);
        }

		public IActionResult ThankYou()
		{
			return View();
		}
		
    }
}
