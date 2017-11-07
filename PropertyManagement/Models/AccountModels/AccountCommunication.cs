using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Models.AccountModels
{
    public class AccountCommunication
    {
		[Key]
		public int Id { get; set; }
		public int AccountId { get; set; }
		public int AccountContactId { get; set; }

		public AccountCommunicationType AccountCommunicationType { get; set; }
		public DateTime ContactTime { get; set; }
		public string Purpose { get; set; }
		public string Outcome { get; set; }

		public virtual Account Account { get; set; }
		public virtual AccountContact AccountContact { get; set; }
	}

	public enum AccountCommunicationType
	{
		email = 0,
		phone = 1,
		fax = 2,
		person = 3
	}
}
