using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationERP.Migrations
{
    /// <inheritdoc />
    public partial class SevenMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SelectedDirections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameFaculty = table.Column<string>(type: "text", nullable: false),
                    NameLevel = table.Column<string>(type: "text", nullable: false),
                    CodeDirection = table.Column<string>(type: "text", nullable: false),
                    NameDirection = table.Column<string>(type: "text", nullable: false),
                    CodeProfile = table.Column<string>(type: "text", nullable: false),
                    NameProfile = table.Column<string>(type: "text", nullable: false),
                    NameFormEducation = table.Column<string>(type: "text", nullable: false),
                    NameFormPayment = table.Column<string>(type: "text", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedDirections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelectedDirections_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SelectedDirections_ApplicantId",
                table: "SelectedDirections",
                column: "ApplicantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SelectedDirections");
        }
    }
}
