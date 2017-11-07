using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PropertyManagement.Models;

namespace PropertyManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

		public DbSet<PropertyManagement.Models.AccountModels.Account> Account { get; set; }
		public DbSet<PropertyManagement.Models.AccountModels.AccountContact> AccountContact { get; set; }
		public DbSet<PropertyManagement.Models.AccountModels.AccountCommunication> AccountCommunication { get; set; }
		public DbSet<PropertyManagement.Models.PhoneNumber> PhoneNumber { get; set; }
		public DbSet<PropertyManagement.Models.EmailAddress> EmailAddress { get; set; }
	}
}
