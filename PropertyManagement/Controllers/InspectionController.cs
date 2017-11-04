using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Models;
using Microsoft.AspNetCore.Authorization;

namespace PropertyManagement.Controllers
{
	[Authorize()]
	public class InspectionController : Controller
    {
		// GET: /Inspection
        public IActionResult Index()
        {
			return View();
        }

    }
}