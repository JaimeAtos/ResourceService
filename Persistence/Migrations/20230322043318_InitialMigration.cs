using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResumeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentStateDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentPositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrentPositionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LocationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NessieID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrentClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    UserCreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserLastModify = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastDateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceExtraSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResourceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienceOveralTypeTag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BriefDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Point = table.Column<byte>(type: "tinyint", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    UserCreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserLastModify = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastDateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceExtraSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResourceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillName = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillAcceptanceURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsComplice = table.Column<bool>(type: "bit", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    UserCreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceSkills", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "ResourceExtraSkills");

            migrationBuilder.DropTable(
                name: "ResourceSkills");
        }
    }
}
