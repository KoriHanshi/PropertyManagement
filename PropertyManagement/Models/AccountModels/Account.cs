using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Models.AccountModels
{
    public class Account
    {
		[Key]
		public int Id { get; set; }

		public AccountStatus AccountStatus { get; set; }

		public virtual ICollection<AccountContact> AccountContacts { get; set; }
		public virtual ICollection<AccountCommunication> AccountCommunications { get; set; }
	}

	public enum AccountStatus
	{
		Prospect = 0,
		Current = 1,
		Delinquent = 2,
		Closed = 3
	}
}
