using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Models
{
    public class InitialContact
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

		[DisplayName("Zipcode of Rental Property")]
		public int Zip { get; set; }

		[DisplayName("Best Time To Reach You")]
		[DisplayFormat(DataFormatString = "{0:hh:mm tt}")]
		public DateTime BestTime { get; set; }

		public InitialContactStatus Status { get; set; }
	}

	public enum InitialContactStatus
	{
		Initial = 0,
		Cancelled = 1,
		AppointmentSet = 2
	}
}
