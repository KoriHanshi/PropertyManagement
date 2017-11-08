using PropertyManagement.Data;
using PropertyManagement.Models;
using PropertyManagement.Models.PortfolioModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Managers
{
    public class PortfolioManager
    {
		private readonly ApplicationDbContext context;
		private Portfolio portfolio;

		public PortfolioManager(ApplicationDbContext context)
		{
			this.context = context;
		}

		public async Task<Portfolio> CreatePortfolio(Lead lead)
		{
			portfolio = new Portfolio
			{

			};

			context.Portfolios.Add(portfolio);
			await context.SaveChangesAsync();
			return portfolio;
		}

    }
}
