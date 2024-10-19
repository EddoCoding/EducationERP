using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationERP.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyFacultiesForStructEducation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainFaculties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameFaculty = table.Column<string>(type: "text", nullable: false),
                    PasswordFaculty = table.Column<string>(type: "text", nullable: false),
                    StructEducationalInstitutionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainFaculties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainFaculties_StructEducationalInstitution_StructEducationa~",
                        column: x => x.StructEducationalInstitutionId,
                        principalTable: "StructEducationalInstitution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainFaculties_StructEducationalInstitutionId",
                table: "MainFaculties",
                column: "StructEducationalInstitutionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainFaculties");
        }
    }
}
