using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Models.PortfolioModels
{
    public class PortfolioCommunication
	{
		[Key]
		public int Id { get; set; }
		public int PortfolioId { get; set; }
		public int PortfolioContactId { get; set; }

		public PortfolioCommunicationType PortfolioCommunicationType { get; set; }
		public DateTime ContactTime { get; set; }
		public string Purpose { get; set; }
		public string Outcome { get; set; }

		public virtual Portfolio Portfolio { get; set; }
		public virtual PortfolioContact PortfolioContact { get; set; }
	}

	public enum PortfolioCommunicationType
	{
		email = 0,
		phone = 1,
		fax = 2,
		person = 3
	}
}
