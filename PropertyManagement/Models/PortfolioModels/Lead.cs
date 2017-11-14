using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PropertyManagement.Models.PortfolioModels
{
	public class Lead
	{
		[Key]
		public int Id { get; set; }

		[DisplayName("First Name")]
		public string NameFirst { get; set; }

		[DisplayName("Last Name")]
		public string NameLast { get; set; }

		[DisplayName("Email Address")]
		public string Email { get; set; }

		[DisplayName("Phone Number")]
		public string Phone { get; set; }
		public int AreaCode { get; set; }
		public int FirstThree { get; set; }
		public int LastFour { get; set; }
		public int Extension { get; set; }
		public PhoneNumberType PhoneNumberType { get; set; }

		[DisplayName("Zipcode of Rental Property")]
		public int Zip { get; set; }

		[DisplayName("Best Time To Reach You")]
		[DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
		public DateTime BestTime { get; set; }

	}

}
