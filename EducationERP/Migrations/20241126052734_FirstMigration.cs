using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationERP.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
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
                    FullName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "text", nullable: false),
                    IsCitizenRus = table.Column<bool>(type: "boolean", nullable: true),
                    NotCitizen = table.Column<bool>(type: "boolean", nullable: true),
                    IsForeign = table.Column<bool>(type: "boolean", nullable: true),
                    Citizenship = table.Column<string>(type: "text", nullable: false),
                    CitizenshipValidFrom = table.Column<DateOnly>(type: "date", nullable: false),
                    IsNeedHostel = table.Column<bool>(type: "boolean", nullable: false),
                    IsNotNeedHostel = table.Column<bool>(type: "boolean", nullable: false),
                    ResidentialAddress = table.Column<string>(type: "text", nullable: false),
                    AddressOfRegistration = table.Column<string>(type: "text", nullable: false),
                    HomePhone = table.Column<string>(type: "text", nullable: true),
                    MobilePhone = table.Column<string>(type: "text", nullable: false),
                    Mail = table.Column<string>(type: "text", nullable: false),
                    AdditionalContactInformation = table.Column<string>(type: "text", nullable: false),
                    TotalPoints = table.Column<int>(type: "integer", nullable: false),
                    PointsDistinctiveFeatures = table.Column<int>(type: "integer", nullable: false),
                    SumPointsExam = table.Column<int>(type: "integer", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: false),
                    Accepted = table.Column<string>(type: "text", nullable: false),
                    DateAccepted = table.Column<DateOnly>(type: "date", nullable: false),
                    TimeAccepted = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    ForEnrollment = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StructEducationalInstitution",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameVUZ = table.Column<string>(type: "text", nullable: false),
                    ShortNameVUZ = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StructEducationalInstitution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Identifier = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    SurName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    ModuleAdmissionsCampaign = table.Column<bool>(type: "boolean", nullable: true),
                    ModuleAdministration = table.Column<bool>(type: "boolean", nullable: true),
                    ModuleDeanRoom = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DistinctiveFeatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameFeature = table.Column<string>(type: "text", nullable: false),
                    FeatureScore = table.Column<int>(type: "integer", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistinctiveFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DistinctiveFeatures_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "EGES",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AcademicSubject = table.Column<string>(type: "text", nullable: false),
                    SubjectScores = table.Column<int>(type: "integer", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EGES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EGES_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AcademicSubject = table.Column<string>(type: "text", nullable: false),
                    DateExam = table.Column<DateOnly>(type: "date", nullable: false),
                    TimeExam = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    LocationExam = table.Column<string>(type: "text", nullable: false),
                    IsSpecial = table.Column<bool>(type: "boolean", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: false),
                    SubjectScores = table.Column<int>(type: "integer", nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_Applicants_ApplicantId",
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

            migrationBuilder.CreateTable(
                name: "ACFaculties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameFaculty = table.Column<string>(type: "text", nullable: false),
                    StructEducationalInstitutionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACFaculties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ACFaculties_StructEducationalInstitution_StructEducationalI~",
                        column: x => x.StructEducationalInstitutionId,
                        principalTable: "StructEducationalInstitution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "ACLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameLevel = table.Column<string>(type: "text", nullable: false),
                    SettingFacultyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ACLevels_ACFaculties_SettingFacultyId",
                        column: x => x.SettingFacultyId,
                        principalTable: "ACFaculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CodeEducationGroup = table.Column<string>(type: "text", nullable: false),
                    NameEducationGroup = table.Column<string>(type: "text", nullable: false),
                    LevelGroup = table.Column<string>(type: "text", nullable: false),
                    FormGroup = table.Column<string>(type: "text", nullable: false),
                    TypeGroup = table.Column<string>(type: "text", nullable: false),
                    Course = table.Column<int>(type: "integer", nullable: false),
                    MaxNumberStudents = table.Column<int>(type: "integer", nullable: false),
                    CodeDirection = table.Column<string>(type: "text", nullable: false),
                    NameDirection = table.Column<string>(type: "text", nullable: false),
                    CodeProfile = table.Column<string>(type: "text", nullable: false),
                    NameProfile = table.Column<string>(type: "text", nullable: false),
                    NameCuratorGroup = table.Column<string>(type: "text", nullable: false),
                    NameHeadmanGroup = table.Column<string>(type: "text", nullable: false),
                    Formed = table.Column<string>(type: "text", nullable: false),
                    DateOfFormed = table.Column<DateOnly>(type: "date", nullable: false),
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
                name: "MainDepartments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameDepartment = table.Column<string>(type: "text", nullable: false),
                    FacultyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MainDepartments_MainFaculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "MainFaculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ACDirections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CodeDirection = table.Column<string>(type: "text", nullable: false),
                    NameDirection = table.Column<string>(type: "text", nullable: false),
                    CodeProfile = table.Column<string>(type: "text", nullable: false),
                    NameProfile = table.Column<string>(type: "text", nullable: false),
                    NameFormEducation = table.Column<string>(type: "text", nullable: false),
                    NameFormPayment = table.Column<string>(type: "text", nullable: false),
                    SettingLevelId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACDirections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ACDirections_ACLevels_SettingLevelId",
                        column: x => x.SettingLevelId,
                        principalTable: "ACLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SurName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "text", nullable: false),
                    Citizenship = table.Column<string>(type: "text", nullable: false),
                    CitizenshipValidFrom = table.Column<DateOnly>(type: "date", nullable: false),
                    IsNeedHostel = table.Column<bool>(type: "boolean", nullable: false),
                    IsNotNeedHostel = table.Column<bool>(type: "boolean", nullable: false),
                    ResidentialAddress = table.Column<string>(type: "text", nullable: false),
                    AddressOfRegistration = table.Column<string>(type: "text", nullable: false),
                    HomePhone = table.Column<string>(type: "text", nullable: false),
                    MobilePhone = table.Column<string>(type: "text", nullable: false),
                    Mail = table.Column<string>(type: "text", nullable: false),
                    AdditionalContactInformation = table.Column<string>(type: "text", nullable: false),
                    Accepted = table.Column<string>(type: "text", nullable: false),
                    NameEducationGroup = table.Column<string>(type: "text", nullable: false),
                    LevelGroup = table.Column<string>(type: "text", nullable: false),
                    FormGroup = table.Column<string>(type: "text", nullable: false),
                    TypeGroup = table.Column<int>(type: "integer", nullable: false),
                    Course = table.Column<int>(type: "integer", nullable: false),
                    CodeDirection = table.Column<string>(type: "text", nullable: false),
                    NameDirection = table.Column<string>(type: "text", nullable: false),
                    CodeProfile = table.Column<string>(type: "text", nullable: false),
                    NameProfile = table.Column<string>(type: "text", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "ForeignPassportsStudent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeDocument = table.Column<string>(type: "text", nullable: false),
                    SurName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "text", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    IssuedBy = table.Column<string>(type: "text", nullable: false),
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: false),
                    SeriesNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForeignPassportsStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForeignPassportsStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InnsStudent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeDocument = table.Column<string>(type: "text", nullable: false),
                    SurName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "text", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    NumberINN = table.Column<string>(type: "text", nullable: false),
                    DateAssigned = table.Column<DateOnly>(type: "date", nullable: false),
                    SeriesNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnsStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InnsStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassportsStudent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeDocument = table.Column<string>(type: "text", nullable: false),
                    SurName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "text", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    IssuedBy = table.Column<string>(type: "text", nullable: false),
                    DateOfIssue = table.Column<DateOnly>(type: "date", nullable: false),
                    DepartmentCode = table.Column<string>(type: "text", nullable: false),
                    SeriesNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassportsStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassportsStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SnilssStudent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeDocument = table.Column<string>(type: "text", nullable: false),
                    SurName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "text", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "text", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: false),
                    RegistrationDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnilssStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SnilssStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACDirections_SettingLevelId",
                table: "ACDirections",
                column: "SettingLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ACFaculties_StructEducationalInstitutionId",
                table: "ACFaculties",
                column: "StructEducationalInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ACLevels_SettingFacultyId",
                table: "ACLevels",
                column: "SettingFacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_DistinctiveFeatures_ApplicantId",
                table: "DistinctiveFeatures",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_ApplicantId",
                table: "Document",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationBase_ApplicantId",
                table: "EducationBase",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationGroups_FacultyId",
                table: "EducationGroups",
                column: "FacultyId");

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
                name: "IX_EGES_ApplicantId",
                table: "EGES",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ApplicantId",
                table: "Exams",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignPassports_ApplicantId",
                table: "ForeignPassports",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignPassportsStudent_StudentId",
                table: "ForeignPassportsStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Inns_ApplicantId",
                table: "Inns",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_InnsStudent_StudentId",
                table: "InnsStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_MainDepartments_FacultyId",
                table: "MainDepartments",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_MainFaculties_StructEducationalInstitutionId",
                table: "MainFaculties",
                column: "StructEducationalInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Passports_ApplicantId",
                table: "Passports",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_PassportsStudent_StudentId",
                table: "PassportsStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SelectedDirections_ApplicantId",
                table: "SelectedDirections",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Snilss_ApplicantId",
                table: "Snilss",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_SnilssStudent_StudentId",
                table: "SnilssStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_EducationGroupId",
                table: "Students",
                column: "EducationGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACDirections");

            migrationBuilder.DropTable(
                name: "DistinctiveFeatures");

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
                name: "EGES");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "ForeignPassports");

            migrationBuilder.DropTable(
                name: "ForeignPassportsStudent");

            migrationBuilder.DropTable(
                name: "Inns");

            migrationBuilder.DropTable(
                name: "InnsStudent");

            migrationBuilder.DropTable(
                name: "MainDepartments");

            migrationBuilder.DropTable(
                name: "Passports");

            migrationBuilder.DropTable(
                name: "PassportsStudent");

            migrationBuilder.DropTable(
                name: "SelectedDirections");

            migrationBuilder.DropTable(
                name: "Snilss");

            migrationBuilder.DropTable(
                name: "SnilssStudent");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ACLevels");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "ACFaculties");

            migrationBuilder.DropTable(
                name: "EducationGroups");

            migrationBuilder.DropTable(
                name: "MainFaculties");

            migrationBuilder.DropTable(
                name: "StructEducationalInstitution");
        }
    }
}
