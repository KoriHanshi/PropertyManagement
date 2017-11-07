using PropertyManagement.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Models
{
    public class PhoneNumber
    {
		[Key]
		public int Id { get; set; }
		public int AccountContactId { get; set; }

		public PhoneNumberType PhoneNumberType { get; set; }
		public int AreaCode { get; set; }
		public int FirstThree { get; set; }
		public int LastFour { get; set; }
		public int Extension { get; set; }
		public DateTime BestTime { get; set; }

		public virtual AccountContact AccountContact { get; set; }
	}

	public enum PhoneNumberType
	{
		Home = 0,
		Business = 1,
		Mobile = 2,
		Fax = 3
	}
}
