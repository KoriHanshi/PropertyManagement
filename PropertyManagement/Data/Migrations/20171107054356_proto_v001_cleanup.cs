using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PropertyManagement.Data.Migrations
{
    public partial class proto_v001_cleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InitialContactAddress");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "InitialContact");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "InitialContact",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "InitialContactAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    InitialContactId = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InitialContactAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InitialContactAddress_InitialContact_InitialContactId",
                        column: x => x.InitialContactId,
                        principalTable: "InitialContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InitialContactAddress_InitialContactId",
                table: "InitialContactAddress",
                column: "InitialContactId");
        }
    }
}
