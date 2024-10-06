using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationERP.Migrations
{
    /// <inheritdoc />
    public partial class FourMigration : Migration
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
                    Citizenship = table.Column<string>(type: "text", nullable: false),
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
                name: "EducationBase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeEducation = table.Column<string>(type: "text", nullable: false),
                    IdentificationDocument = table.Column<string>(type: "text", nullable: false),
                    IssuedBy = table.Column<string>(type: "text", nullable: false),
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: false),
                    Honours = table.Column<bool>(type: "boolean", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationBase_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationsAsp",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeEducation = table.Column<string>(type: "text", nullable: false),
                    IdentificationDocument = table.Column<string>(type: "text", nullable: false),
                    IssuedBy = table.Column<string>(type: "text", nullable: false),
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: false),
                    Honours = table.Column<bool>(type: "boolean", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false),
                    FormOfEducation = table.Column<string>(type: "text", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "text", nullable: false),
                    DiplomaSeries = table.Column<string>(type: "text", nullable: false),
                    DiplomaNumber = table.Column<string>(type: "text", nullable: false),
                    SupplementSeries = table.Column<string>(type: "text", nullable: false),
                    SupplementNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationsAsp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationsAsp_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationsBak",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeEducation = table.Column<string>(type: "text", nullable: false),
                    IdentificationDocument = table.Column<string>(type: "text", nullable: false),
                    IssuedBy = table.Column<string>(type: "text", nullable: false),
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: false),
                    Honours = table.Column<bool>(type: "boolean", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false),
                    FormOfEducation = table.Column<string>(type: "text", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "text", nullable: false),
                    DiplomaSeries = table.Column<string>(type: "text", nullable: false),
                    DiplomaNumber = table.Column<string>(type: "text", nullable: false),
                    SupplementSeries = table.Column<string>(type: "text", nullable: false),
                    SupplementNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationsBak", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationsBak_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationsEleven",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeEducation = table.Column<string>(type: "text", nullable: false),
                    IdentificationDocument = table.Column<string>(type: "text", nullable: false),
                    IssuedBy = table.Column<string>(type: "text", nullable: false),
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: false),
                    Honours = table.Column<bool>(type: "boolean", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false),
                    CodeSeriesNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationsEleven", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationsEleven_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationsMag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeEducation = table.Column<string>(type: "text", nullable: false),
                    IdentificationDocument = table.Column<string>(type: "text", nullable: false),
                    IssuedBy = table.Column<string>(type: "text", nullable: false),
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: false),
                    Honours = table.Column<bool>(type: "boolean", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false),
                    FormOfEducation = table.Column<string>(type: "text", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "text", nullable: false),
                    DiplomaSeries = table.Column<string>(type: "text", nullable: false),
                    DiplomaNumber = table.Column<string>(type: "text", nullable: false),
                    SupplementSeries = table.Column<string>(type: "text", nullable: false),
                    SupplementNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationsMag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationsMag_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationsNine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeEducation = table.Column<string>(type: "text", nullable: false),
                    IdentificationDocument = table.Column<string>(type: "text", nullable: false),
                    IssuedBy = table.Column<string>(type: "text", nullable: false),
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: false),
                    Honours = table.Column<bool>(type: "boolean", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false),
                    CodeSeriesNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationsNine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationsNine_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationsSPO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeEducation = table.Column<string>(type: "text", nullable: false),
                    IdentificationDocument = table.Column<string>(type: "text", nullable: false),
                    IssuedBy = table.Column<string>(type: "text", nullable: false),
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: false),
                    Honours = table.Column<bool>(type: "boolean", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false),
                    FormOfEducation = table.Column<string>(type: "text", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "text", nullable: false),
                    DiplomaSeries = table.Column<string>(type: "text", nullable: false),
                    DiplomaNumber = table.Column<string>(type: "text", nullable: false),
                    SupplementSeries = table.Column<string>(type: "text", nullable: false),
                    SupplementNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationsSPO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationsSPO_Applicants_ApplicantId",
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
                name: "IX_EducationBase_ApplicantId",
                table: "EducationBase",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationsAsp_ApplicantId",
                table: "EducationsAsp",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationsBak_ApplicantId",
                table: "EducationsBak",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationsEleven_ApplicantId",
                table: "EducationsEleven",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationsMag_ApplicantId",
                table: "EducationsMag",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationsNine_ApplicantId",
                table: "EducationsNine",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationsSPO_ApplicantId",
                table: "EducationsSPO",
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
                name: "EducationBase");

            migrationBuilder.DropTable(
                name: "EducationsAsp");

            migrationBuilder.DropTable(
                name: "EducationsBak");

            migrationBuilder.DropTable(
                name: "EducationsEleven");

            migrationBuilder.DropTable(
                name: "EducationsMag");

            migrationBuilder.DropTable(
                name: "EducationsNine");

            migrationBuilder.DropTable(
                name: "EducationsSPO");

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
