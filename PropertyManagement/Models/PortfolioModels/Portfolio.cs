using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Models.PortfolioModels
{
    public class Portfolio
    {
		[Key]
		public int Id { get; set; }

		public PortfolioStatus PortfolioStatus { get; set; }

		public virtual ICollection<PortfolioContact> PortfolioContacts { get; set; }
		public virtual ICollection<PortfolioCommunication> PortfolioCommunications { get; set; }
	}

	public enum PortfolioStatus
	{
		Prospect = 0,
		Current = 1,
		Delinquent = 2,
		Closed = 3
	}
}
