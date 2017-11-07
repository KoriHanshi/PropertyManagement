using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PropertyManagement.Data;
using PropertyManagement.Models.AccountModels;
using PropertyManagement.Models;

namespace PropertyManagement.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171107062404_Account_Models_4realThisTime")]
    partial class Account_Models_4realThisTime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PropertyManagement.Models.AccountModels.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountStatus");

                    b.HasKey("Id");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("PropertyManagement.Models.AccountModels.AccountCommunication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountCommunicationType");

                    b.Property<int>("AccountContactId");

                    b.Property<int>("AccountId");

                    b.Property<DateTime>("ContactTime");

                    b.Property<string>("Outcome");

                    b.Property<string>("Purpose");

                    b.HasKey("Id");

                    b.HasIndex("AccountContactId");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountCommunication");
                });

            modelBuilder.Entity("PropertyManagement.Models.AccountModels.AccountContact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountContactType");

                    b.Property<int>("AccountId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleInitial");

                    b.Property<int>("SocialSecurity");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountContact");
                });

            modelBuilder.Entity("PropertyManagement.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("PropertyManagement.Models.EmailAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountContactId");

                    b.Property<string>("Email");

                    b.HasKey("Id");

                    b.HasIndex("AccountContactId");

                    b.ToTable("EmailAddress");
                });

            modelBuilder.Entity("PropertyManagement.Models.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountContactId");

                    b.Property<int>("AreaCode");

                    b.Property<DateTime>("BestTime");

                    b.Property<int>("Extension");

                    b.Property<int>("FirstThree");

                    b.Property<int>("LastFour");

                    b.Property<int>("PhoneNumberType");

                    b.HasKey("Id");

                    b.HasIndex("AccountContactId");

                    b.ToTable("PhoneNumber");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("PropertyManagement.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("PropertyManagement.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PropertyManagement.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PropertyManagement.Models.AccountModels.AccountCommunication", b =>
                {
                    b.HasOne("PropertyManagement.Models.AccountModels.AccountContact", "AccountContact")
                        .WithMany("AccountCommunications")
                        .HasForeignKey("AccountContactId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PropertyManagement.Models.AccountModels.Account", "Account")
                        .WithMany("AccountCommunications")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PropertyManagement.Models.AccountModels.AccountContact", b =>
                {
                    b.HasOne("PropertyManagement.Models.AccountModels.Account", "Account")
                        .WithMany("AccountContacts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PropertyManagement.Models.EmailAddress", b =>
                {
                    b.HasOne("PropertyManagement.Models.AccountModels.AccountContact", "AccountContact")
                        .WithMany("EmailAddresses")
                        .HasForeignKey("AccountContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PropertyManagement.Models.PhoneNumber", b =>
                {
                    b.HasOne("PropertyManagement.Models.AccountModels.AccountContact", "AccountContact")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("AccountContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
