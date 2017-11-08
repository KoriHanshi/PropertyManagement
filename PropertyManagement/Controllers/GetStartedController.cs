using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyManagement.Data;
using PropertyManagement.Managers;
using PropertyManagement.Models.PortfolioModels;

namespace PropertyManagement.Controllers
{
    public class GetStartedController : Controller
    {

		private readonly ApplicationDbContext context;
		private PortfolioManager manager;

		public GetStartedController(ApplicationDbContext context)
		{
			this.context = context;
		}

		public IActionResult Index()
        {
            return View();
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Index([Bind("Id,NameFirst,NameLast,Email,Phone,Zip,BestTime")] Lead lead)
		{
			if (ModelState.IsValid)
			{
				manager = new PortfolioManager(context);
				await manager.CreatePortfolio(lead);
				return RedirectToAction("ThankYou");
			}
			return View(lead);
		}

		public IActionResult ThankYou()
		{
			return View();
		}
    }
}