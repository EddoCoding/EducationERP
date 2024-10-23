using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationERP.Migrations
{
    /// <inheritdoc />
    public partial class dsfsad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfRecruitment",
                table: "EducationGroups",
                newName: "DateOfFormed");

            migrationBuilder.AddColumn<string>(
                name: "Formed",
                table: "EducationGroups",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Formed",
                table: "EducationGroups");

            migrationBuilder.RenameColumn(
                name: "DateOfFormed",
                table: "EducationGroups",
                newName: "DateOfRecruitment");
        }
    }
}
