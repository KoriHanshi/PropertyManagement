using PropertyManagement.Models.AccountModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyManagement.Models
{
    public class EmailAddress
    {
		[Key]
		public int Id { get; set; }
		public int AccountContactId { get; set; }

		public string Email { get; set; }

		public virtual AccountContact AccountContact { get; set; }
	}
}
