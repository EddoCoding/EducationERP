﻿// <auto-generated />
using System;
using EducationERP.Common.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EducationERP.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241012024330_ElevenMigration")]
    partial class ElevenMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingDirection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CodeDirection")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CodeProfile")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameDirection")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameFormEducation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameFormPayment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameProfile")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SettingLevelId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SettingLevelId");

                    b.ToTable("Directions");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingFaculty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("NameFaculty")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("NameLevel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SettingFacultyId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SettingFacultyId");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.Administration.SettingUser.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Identifier")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("ModuleAdministration")
                        .HasColumnType("boolean");

                    b.Property<bool?>("ModuleAdmissionsCampaign")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Applicant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AdditionalInformation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AddressOfRegistration")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Citizenship")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("CitizenshipValidFrom")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HomePhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("IsCitizenRus")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsForeign")
                        .HasColumnType("boolean");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MobilePhone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool?>("NotCitizen")
                        .HasColumnType("boolean");

                    b.Property<string>("PlaceOfBirth")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PointsDistinctiveFeatures")
                        .HasColumnType("integer");

                    b.Property<string>("ResidentialAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SumPointsExam")
                        .HasColumnType("integer");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TotalPoints")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Applicants");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Directions.SelectedDirection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uuid");

                    b.Property<string>("CodeDirection")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CodeProfile")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameDirection")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameFaculty")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameFormEducation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameFormPayment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameLevel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameProfile")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.ToTable("SelectedDirections");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.DistinctiveFeatures.DistinctiveFeature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uuid");

                    b.Property<int>("FeatureScore")
                        .HasColumnType("integer");

                    b.Property<string>("NameFeature")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.ToTable("DistinctiveFeatures");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AdditionalInformation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PlaceOfBirth")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TypeDocument")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.ToTable("Document");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Educations.EducationBase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AdditionalInformation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("DateOfIssue")
                        .HasColumnType("date");

                    b.Property<bool>("Honours")
                        .HasColumnType("boolean");

                    b.Property<string>("IdentificationDocument")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IssuedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TypeEducation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.ToTable("EducationBase");

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Exams.EGE", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AcademicSubject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uuid");

                    b.Property<int>("SubjectScores")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.ToTable("EGES");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Exams.Exam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AcademicSubject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("AdditionalInformation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ApplicantId")
                        .HasColumnType("uuid");

                    b.Property<DateOnly>("DateExam")
                        .HasColumnType("date");

                    b.Property<bool>("IsSpecial")
                        .HasColumnType("boolean");

                    b.Property<string>("LocationExam")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SubjectScores")
                        .HasColumnType("integer");

                    b.Property<TimeOnly>("TimeExam")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ApplicantId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.ForeignPassport", b =>
                {
                    b.HasBaseType("EducationERP.Models.Modules.AdmissionsCampaign.Document");

                    b.Property<DateOnly>("DateOfIssue")
                        .HasColumnType("date");

                    b.Property<string>("IssuedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SeriesNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("ForeignPassports");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Inn", b =>
                {
                    b.HasBaseType("EducationERP.Models.Modules.AdmissionsCampaign.Document");

                    b.Property<DateOnly>("DateAssigned")
                        .HasColumnType("date");

                    b.Property<string>("NumberINN")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SeriesNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("Inns");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Passport", b =>
                {
                    b.HasBaseType("EducationERP.Models.Modules.AdmissionsCampaign.Document");

                    b.Property<DateOnly>("DateOfIssue")
                        .HasColumnType("date");

                    b.Property<string>("DepartmentCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IssuedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SeriesNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("Passports");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Snils", b =>
                {
                    b.HasBaseType("EducationERP.Models.Modules.AdmissionsCampaign.Document");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("RegistrationDate")
                        .HasColumnType("date");

                    b.ToTable("Snilss");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Educations.EducationAsp", b =>
                {
                    b.HasBaseType("EducationERP.Models.Modules.AdmissionsCampaign.Educations.EducationBase");

                    b.Property<string>("DiplomaNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DiplomaSeries")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FormOfEducation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SupplementNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SupplementSeries")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("EducationsAsp");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Educations.EducationBak", b =>
                {
                    b.HasBaseType("EducationERP.Models.Modules.AdmissionsCampaign.Educations.EducationBase");

                    b.Property<string>("DiplomaNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DiplomaSeries")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FormOfEducation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SupplementNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SupplementSeries")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("EducationsBak");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Educations.EducationEleven", b =>
                {
                    b.HasBaseType("EducationERP.Models.Modules.AdmissionsCampaign.Educations.EducationBase");

                    b.Property<string>("CodeSeriesNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("EducationsEleven");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Educations.EducationMag", b =>
                {
                    b.HasBaseType("EducationERP.Models.Modules.AdmissionsCampaign.Educations.EducationBase");

                    b.Property<string>("DiplomaNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DiplomaSeries")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FormOfEducation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SupplementNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SupplementSeries")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("EducationsMag");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Educations.EducationNine", b =>
                {
                    b.HasBaseType("EducationERP.Models.Modules.AdmissionsCampaign.Educations.EducationBase");

                    b.Property<string>("CodeSeriesNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("EducationsNine");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Educations.EducationSPO", b =>
                {
                    b.HasBaseType("EducationERP.Models.Modules.AdmissionsCampaign.Educations.EducationBase");

                    b.Property<string>("DiplomaNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DiplomaSeries")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FormOfEducation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SupplementNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SupplementSeries")
                        .IsRequired()
                        .HasColumnType("text");

                    b.ToTable("EducationsSPO");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingDirection", b =>
                {
                    b.HasOne("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingLevel", "SettingLevel")
                        .WithMany("Directions")
                        .HasForeignKey("SettingLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SettingLevel");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingLevel", b =>
                {
                    b.HasOne("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingFaculty", "SettingFaculty")
                        .WithMany("Levels")
                        .HasForeignKey("SettingFacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SettingFaculty");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Directions.SelectedDirection", b =>
                {
                    b.HasOne("EducationERP.Models.Modules.AdmissionsCampaign.Applicant", "Applicant")
                        .WithMany("DirectionsOfTraining")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.DistinctiveFeatures.DistinctiveFeature", b =>
                {
                    b.HasOne("EducationERP.Models.Modules.AdmissionsCampaign.Applicant", "Applicant")
                        .WithMany("DistinguishingFeatures")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Document", b =>
                {
                    b.HasOne("EducationERP.Models.Modules.AdmissionsCampaign.Applicant", "Applicant")
                        .WithMany("Documents")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Educations.EducationBase", b =>
                {
                    b.HasOne("EducationERP.Models.Modules.AdmissionsCampaign.Applicant", "Applicant")
                        .WithMany("Educations")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Exams.EGE", b =>
                {
                    b.HasOne("EducationERP.Models.Modules.AdmissionsCampaign.Applicant", "Applicant")
                        .WithMany("EGES")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Exams.Exam", b =>
                {
                    b.HasOne("EducationERP.Models.Modules.AdmissionsCampaign.Applicant", "Applicant")
                        .WithMany("Exams")
                        .HasForeignKey("ApplicantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingFaculty", b =>
                {
                    b.Navigation("Levels");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingLevel", b =>
                {
                    b.Navigation("Directions");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.AdmissionsCampaign.Applicant", b =>
                {
                    b.Navigation("DirectionsOfTraining");

                    b.Navigation("DistinguishingFeatures");

                    b.Navigation("Documents");

                    b.Navigation("EGES");

                    b.Navigation("Educations");

                    b.Navigation("Exams");
                });
#pragma warning restore 612, 618
        }
    }
}
