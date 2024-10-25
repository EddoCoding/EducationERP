using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationERP.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertiesToStudent2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodeDirection",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodeProfile",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Course",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FormGroup",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LevelGroup",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameDirection",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameEducationGroup",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameProfile",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TypeGroup",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeDirection",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CodeProfile",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Course",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FormGroup",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LevelGroup",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NameDirection",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NameEducationGroup",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NameProfile",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TypeGroup",
                table: "Students");
        }
    }
}
