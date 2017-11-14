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
		private PortfolioContact portfolioContact;

		public PortfolioManager(ApplicationDbContext context)
		{
			this.context = context;
		}

		public async Task<Portfolio> CreatePortfolio(Lead lead)
		{
			context.Portfolios.Add(
				new Portfolio
				{
					PortfolioStatus = PortfolioStatus.Prospect,
					PortfolioContacts = new List<PortfolioContact>
					{
						new PortfolioContact
						{
							PortfolioContactType = PortfolioContactType.Main,
							FirstName = lead.NameFirst,
							LastName = lead.NameLast,
							PhoneNumbers = new List<PhoneNumber>
							{
								new PhoneNumber
								{
									PhoneNumberType = lead.PhoneNumberType,
									AreaCode = lead.AreaCode,
									FirstThree = lead.FirstThree,
									LastFour = lead.LastFour,
									Extension = lead.Extension
								}
							},
							EmailAddresses = new List<EmailAddress>
							{
								new EmailAddress(lead.Email)
							}
						}
					}
				}
			);

			await context.SaveChangesAsync();
			return portfolio;
		}

    }
}
