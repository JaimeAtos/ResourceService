using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ResourceName = table.Column<string>(type: "text", nullable: false),
                    ResumeUrl = table.Column<string>(type: "text", nullable: true),
                    WorkEmail = table.Column<string>(type: "text", nullable: true),
                    PersonalEmail = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    CurrentStateId = table.Column<Guid>(type: "uuid", nullable: false),
                    CurrentStateDescription = table.Column<string>(type: "text", nullable: true),
                    CurrentPositionId = table.Column<Guid>(type: "uuid", nullable: true),
                    CurrentPositionDescription = table.Column<string>(type: "text", nullable: true),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: true),
                    LocationDescription = table.Column<string>(type: "text", nullable: true),
                    NessieID = table.Column<string>(type: "text", nullable: true),
                    CurrentClientId = table.Column<Guid>(type: "uuid", nullable: true),
                    CurrentClientName = table.Column<string>(type: "text", nullable: true),
                    IsNational = table.Column<bool>(type: "boolean", nullable: false),
                    State = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserModifierId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateLastModify = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResourceExtraSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ResourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    ExperienceOverallTypeTag = table.Column<string>(type: "text", nullable: false),
                    BriefDescription = table.Column<string>(type: "text", nullable: false),
                    Point = table.Column<byte>(type: "smallint", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false),
                    State = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserModifierId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateLastModify = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceExtraSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceExtraSkills_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    ResourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillName = table.Column<string>(type: "text", nullable: false),
                    SkillAcceptanceURL = table.Column<string>(type: "text", nullable: false),
                    IsCompliance = table.Column<bool>(type: "boolean", nullable: false),
                    State = table.Column<bool>(type: "boolean", nullable: false),
                    UserCreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserModifierId = table.Column<Guid>(type: "uuid", nullable: false),
                    DateLastModify = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResourceSkills_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceExtraSkills_ResourceId",
                table: "ResourceExtraSkills",
                column: "ResourceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceSkills_ResourceId",
                table: "ResourceSkills",
                column: "ResourceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceExtraSkills");

            migrationBuilder.DropTable(
                name: "ResourceSkills");

            migrationBuilder.DropTable(
                name: "Resource");
        }
    }
}
