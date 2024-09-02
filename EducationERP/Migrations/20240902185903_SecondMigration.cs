using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationERP.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ModuleAdmissionsCampaign",
                table: "Users",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModuleAdmissionsCampaign",
                table: "Users");
        }
    }
}
