using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PropertyManagement.Data.Migrations
{
    public partial class portfolio_models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailAddress_AccountContact_AccountContactId",
                table: "EmailAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumber_AccountContact_AccountContactId",
                table: "PhoneNumber");

            migrationBuilder.DropTable(
                name: "AccountCommunication");

            migrationBuilder.DropTable(
                name: "AccountContact");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneNumber",
                table: "PhoneNumber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailAddress",
                table: "EmailAddress");

            migrationBuilder.RenameTable(
                name: "PhoneNumber",
                newName: "PhoneNumbers");

            migrationBuilder.RenameTable(
                name: "EmailAddress",
                newName: "EmailAddresses");

            migrationBuilder.RenameColumn(
                name: "AccountContactId",
                table: "PhoneNumbers",
                newName: "PortfolioContactId");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneNumber_AccountContactId",
                table: "PhoneNumbers",
                newName: "IX_PhoneNumbers_PortfolioContactId");

            migrationBuilder.RenameColumn(
                name: "AccountContactId",
                table: "EmailAddresses",
                newName: "PortfolioContactId");

            migrationBuilder.RenameIndex(
                name: "IX_EmailAddress_AccountContactId",
                table: "EmailAddresses",
                newName: "IX_EmailAddresses_PortfolioContactId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneNumbers",
                table: "PhoneNumbers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailAddresses",
                table: "EmailAddresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PortfolioStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioContacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MiddleInitial = table.Column<string>(nullable: true),
                    PortfolioContactType = table.Column<int>(nullable: false),
                    PortfolioId = table.Column<int>(nullable: false),
                    SocialSecurity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioContacts_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioCommunications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactTime = table.Column<DateTime>(nullable: false),
                    Outcome = table.Column<string>(nullable: true),
                    PortfolioCommunicationType = table.Column<int>(nullable: false),
                    PortfolioContactId = table.Column<int>(nullable: false),
                    PortfolioId = table.Column<int>(nullable: false),
                    Purpose = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioCommunications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioCommunications_PortfolioContacts_PortfolioContactId",
                        column: x => x.PortfolioContactId,
                        principalTable: "PortfolioContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioCommunications_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioCommunications_PortfolioContactId",
                table: "PortfolioCommunications",
                column: "PortfolioContactId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioCommunications_PortfolioId",
                table: "PortfolioCommunications",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioContacts_PortfolioId",
                table: "PortfolioContacts",
                column: "PortfolioId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailAddresses_PortfolioContacts_PortfolioContactId",
                table: "EmailAddresses",
                column: "PortfolioContactId",
                principalTable: "PortfolioContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_PortfolioContacts_PortfolioContactId",
                table: "PhoneNumbers",
                column: "PortfolioContactId",
                principalTable: "PortfolioContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
		
    }
}
