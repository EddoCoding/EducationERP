﻿// <auto-generated />
using System;
using EducationERP.Common.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EducationERP.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("NameDirection")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SettingLevelId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SettingLevelId");

                    b.ToTable("Directions");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingForm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("NameForm")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SettingProfileId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SettingProfileId");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("NameLevel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CodeProfile")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NameProfile")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SettingDirectionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SettingDirectionId");

                    b.ToTable("Profiles");
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

            modelBuilder.Entity("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingDirection", b =>
                {
                    b.HasOne("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingLevel", "SettingLevel")
                        .WithMany("Directions")
                        .HasForeignKey("SettingLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SettingLevel");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingForm", b =>
                {
                    b.HasOne("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingProfile", "SettingProfile")
                        .WithMany("Forms")
                        .HasForeignKey("SettingProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SettingProfile");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingProfile", b =>
                {
                    b.HasOne("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingDirection", "SettingDirection")
                        .WithMany("Profiles")
                        .HasForeignKey("SettingDirectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SettingDirection");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingDirection", b =>
                {
                    b.Navigation("Profiles");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingLevel", b =>
                {
                    b.Navigation("Directions");
                });

            modelBuilder.Entity("EducationERP.Models.Modules.Administration.SettingAdmissionsCampaign.SettingProfile", b =>
                {
                    b.Navigation("Forms");
                });
#pragma warning restore 612, 618
        }
    }
}
