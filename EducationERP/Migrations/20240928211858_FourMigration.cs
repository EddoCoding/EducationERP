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
            migrationBuilder.DropForeignKey(
                name: "FK_SettingProfiles_SettingDirections_EducationalDirectionTrai~1",
                table: "SettingProfiles");

            migrationBuilder.DropIndex(
                name: "IX_SettingProfiles_EducationalDirectionTrainingId1",
                table: "SettingProfiles");

            migrationBuilder.DropColumn(
                name: "EducationalDirectionTrainingId1",
                table: "SettingProfiles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EducationalDirectionTrainingId1",
                table: "SettingProfiles",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SettingProfiles_EducationalDirectionTrainingId1",
                table: "SettingProfiles",
                column: "EducationalDirectionTrainingId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SettingProfiles_SettingDirections_EducationalDirectionTrai~1",
                table: "SettingProfiles",
                column: "EducationalDirectionTrainingId1",
                principalTable: "SettingDirections",
                principalColumn: "Id");
        }
    }
}
