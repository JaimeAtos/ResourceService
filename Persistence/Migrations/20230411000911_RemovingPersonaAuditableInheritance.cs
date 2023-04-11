using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class RemovingPersonaAuditableInheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "ResourceExtraSkills");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastDateModified",
                table: "ResourceSkills",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserLastModify",
                table: "ResourceSkills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastDateModified",
                table: "ResourceSkills");

            migrationBuilder.DropColumn(
                name: "UserLastModify",
                table: "ResourceSkills");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "ResourceExtraSkills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
