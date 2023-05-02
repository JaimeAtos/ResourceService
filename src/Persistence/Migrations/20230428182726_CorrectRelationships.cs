using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CorrectRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ResourceSkills_ResourceId",
                table: "ResourceSkills");

            migrationBuilder.DropIndex(
                name: "IX_ResourceExtraSkills_ResourceId",
                table: "ResourceExtraSkills");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceSkills_ResourceId",
                table: "ResourceSkills",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceExtraSkills_ResourceId",
                table: "ResourceExtraSkills",
                column: "ResourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ResourceSkills_ResourceId",
                table: "ResourceSkills");

            migrationBuilder.DropIndex(
                name: "IX_ResourceExtraSkills_ResourceId",
                table: "ResourceExtraSkills");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceSkills_ResourceId",
                table: "ResourceSkills",
                column: "ResourceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResourceExtraSkills_ResourceId",
                table: "ResourceExtraSkills",
                column: "ResourceId",
                unique: true);
        }
    }
}
