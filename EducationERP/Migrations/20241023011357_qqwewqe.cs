using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationERP.Migrations
{
    /// <inheritdoc />
    public partial class qqwewqe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CodeEducationGroup = table.Column<string>(type: "text", nullable: false),
                    NameEducationGroup = table.Column<string>(type: "text", nullable: false),
                    TypeGroup = table.Column<int>(type: "integer", nullable: false),
                    FormGroup = table.Column<string>(type: "text", nullable: false),
                    LevelGroup = table.Column<string>(type: "text", nullable: false),
                    NameCuratorGroup = table.Column<string>(type: "text", nullable: false),
                    NameHeadmanGroup = table.Column<string>(type: "text", nullable: false),
                    Course = table.Column<int>(type: "integer", nullable: false),
                    MaxNumberStudents = table.Column<int>(type: "integer", nullable: false),
                    YearOfRecruitment = table.Column<DateOnly>(type: "date", nullable: false),
                    CodeDirection = table.Column<string>(type: "text", nullable: false),
                    NameDirection = table.Column<string>(type: "text", nullable: false),
                    CodeProfile = table.Column<string>(type: "text", nullable: false),
                    NameProfile = table.Column<string>(type: "text", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationGroups_MainFaculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "MainFaculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EducationGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_EducationGroups_EducationGroupId",
                        column: x => x.EducationGroupId,
                        principalTable: "EducationGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationGroups_FacultyId",
                table: "EducationGroups",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_EducationGroupId",
                table: "Students",
                column: "EducationGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "EducationGroups");
        }
    }
}
