using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Models.AccountModels
{
    public class AccountContact
    {
		[Key]
		public int Id { get; set; }
		public int AccountId { get; set; }

		public AccountContactType AccountContactType { get; set; }
		public string FirstName { get; set; }
		public string MiddleInitial { get; set; }
		public string LastName { get; set; }
		public int SocialSecurity { get; set; }

		public virtual Account Account { get; set; }
		public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
		public virtual ICollection<EmailAddress> EmailAddresses { get; set; }
		public virtual ICollection<AccountCommunication> AccountCommunications { get; set; }
	}

	public enum AccountContactType
	{
		Owner = 0,
		Additional = 1,
		Emergency = 2
	}
}
