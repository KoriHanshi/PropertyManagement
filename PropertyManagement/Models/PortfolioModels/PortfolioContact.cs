using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Models.PortfolioModels
{
    public class PortfolioContact
	{
		[Key]
		public int Id { get; set; }
		public int PortfolioId { get; set; }

		public PortfolioContactType PortfolioContactType { get; set; }
		public string FirstName { get; set; }
		public string MiddleInitial { get; set; }
		public string LastName { get; set; }
		public int SocialSecurity { get; set; }

		public virtual Portfolio Portfolio { get; set; }
		public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
		public virtual ICollection<EmailAddress> EmailAddresses { get; set; }
		public virtual ICollection<PortfolioCommunication> PortfolioCommunications { get; set; }
	}

	public enum PortfolioContactType
	{
		Main = 0,
		Additional = 1,
		Emergency = 2
	}
}
