﻿using PropertyManagement.Models.PortfolioModels;
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
		public int PortfolioContactId { get; set; }

		public string Email { get; set; }

		public virtual PortfolioContact PortfolioContact { get; set; }

		public EmailAddress(string email)
		{
			Email = email;
		}
	}
}
