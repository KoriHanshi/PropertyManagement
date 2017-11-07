using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PropertyManagement.Data.Migrations
{
    public partial class Account_Models_4realThisTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InitialContact");

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountContact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountContactType = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleInitial = table.Column<string>(nullable: true),
                    SocialSecurity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountContact_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountCommunication",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountCommunicationType = table.Column<int>(nullable: false),
                    AccountContactId = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: false),
                    ContactTime = table.Column<DateTime>(nullable: false),
                    Outcome = table.Column<string>(nullable: true),
                    Purpose = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCommunication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountCommunication_AccountContact_AccountContactId",
                        column: x => x.AccountContactId,
                        principalTable: "AccountContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountCommunication_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountContactId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailAddress_AccountContact_AccountContactId",
                        column: x => x.AccountContactId,
                        principalTable: "AccountContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumber",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountContactId = table.Column<int>(nullable: false),
                    AreaCode = table.Column<int>(nullable: false),
                    BestTime = table.Column<DateTime>(nullable: false),
                    Extension = table.Column<int>(nullable: false),
                    FirstThree = table.Column<int>(nullable: false),
                    LastFour = table.Column<int>(nullable: false),
                    PhoneNumberType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumber_AccountContact_AccountContactId",
                        column: x => x.AccountContactId,
                        principalTable: "AccountContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountCommunication_AccountContactId",
                table: "AccountCommunication",
                column: "AccountContactId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountCommunication_AccountId",
                table: "AccountCommunication",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountContact_AccountId",
                table: "AccountContact",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddress_AccountContactId",
                table: "EmailAddress",
                column: "AccountContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumber_AccountContactId",
                table: "PhoneNumber",
                column: "AccountContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountCommunication");

            migrationBuilder.DropTable(
                name: "EmailAddress");

            migrationBuilder.DropTable(
                name: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "AccountContact");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.CreateTable(
                name: "InitialContact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BestTime = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    NameFirst = table.Column<string>(nullable: true),
                    NameLast = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Zip = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialContact", x => x.Id);
                });
        }
    }
}
