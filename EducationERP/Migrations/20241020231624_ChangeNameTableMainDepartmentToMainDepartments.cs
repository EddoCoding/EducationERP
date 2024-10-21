using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationERP.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameTableMainDepartmentToMainDepartments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainDepartment_MainFaculties_FacultyId",
                table: "MainDepartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainDepartment",
                table: "MainDepartment");

            migrationBuilder.RenameTable(
                name: "MainDepartment",
                newName: "MainDepartments");

            migrationBuilder.RenameIndex(
                name: "IX_MainDepartment_FacultyId",
                table: "MainDepartments",
                newName: "IX_MainDepartments_FacultyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainDepartments",
                table: "MainDepartments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainDepartments_MainFaculties_FacultyId",
                table: "MainDepartments",
                column: "FacultyId",
                principalTable: "MainFaculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MainDepartments_MainFaculties_FacultyId",
                table: "MainDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainDepartments",
                table: "MainDepartments");

            migrationBuilder.RenameTable(
                name: "MainDepartments",
                newName: "MainDepartment");

            migrationBuilder.RenameIndex(
                name: "IX_MainDepartments_FacultyId",
                table: "MainDepartment",
                newName: "IX_MainDepartment_FacultyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainDepartment",
                table: "MainDepartment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MainDepartment_MainFaculties_FacultyId",
                table: "MainDepartment",
                column: "FacultyId",
                principalTable: "MainFaculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
