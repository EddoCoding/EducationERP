using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationERP.Migrations
{
    /// <inheritdoc />
    public partial class check : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SurName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "text", nullable: false),
                    IsCitizenRus = table.Column<bool>(type: "boolean", nullable: true),
                    NotCitizen = table.Column<bool>(type: "boolean", nullable: true),
                    IsForeign = table.Column<bool>(type: "boolean", nullable: true),
                    CitizenshipValidFrom = table.Column<DateOnly>(type: "date", nullable: false),
                    ResidentialAddress = table.Column<string>(type: "text", nullable: false),
                    AddressOfRegistration = table.Column<string>(type: "text", nullable: false),
                    HomePhone = table.Column<string>(type: "text", nullable: false),
                    MobilePhone = table.Column<string>(type: "text", nullable: false),
                    Mail = table.Column<string>(type: "text", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeDocument = table.Column<string>(type: "text", nullable: false),
                    SurName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "text", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ForeignPassports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeDocument = table.Column<string>(type: "text", nullable: false),
                    SurName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "text", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false),
                    IssuedBy = table.Column<string>(type: "text", nullable: false),
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: false),
                    SeriesNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignPassports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForeignPassports_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeDocument = table.Column<string>(type: "text", nullable: false),
                    SurName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "text", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false),
                    NumberINN = table.Column<string>(type: "text", nullable: false),
                    DateAssigned = table.Column<DateOnly>(type: "date", nullable: false),
                    SeriesNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inns_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeDocument = table.Column<string>(type: "text", nullable: false),
                    SurName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "text", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false),
                    IssuedBy = table.Column<string>(type: "text", nullable: false),
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: false),
                    DepartmentCode = table.Column<string>(type: "text", nullable: false),
                    SeriesNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passports_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Snilss",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeDocument = table.Column<string>(type: "text", nullable: false),
                    SurName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "text", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    RegistrationDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snilss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Snilss_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_ApplicantId",
                table: "Document",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignPassports_ApplicantId",
                table: "ForeignPassports",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Inns_ApplicantId",
                table: "Inns",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Passports_ApplicantId",
                table: "Passports",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Snilss_ApplicantId",
                table: "Snilss",
                column: "ApplicantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "ForeignPassports");

            migrationBuilder.DropTable(
                name: "Inns");

            migrationBuilder.DropTable(
                name: "Passports");

            migrationBuilder.DropTable(
                name: "Snilss");

            migrationBuilder.DropTable(
                name: "Applicants");
        }
    }
}
