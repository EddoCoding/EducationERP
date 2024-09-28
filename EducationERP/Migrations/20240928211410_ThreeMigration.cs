using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationERP.Migrations
{
    /// <inheritdoc />
    public partial class ThreeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SettingDirections_SettingLevels_EducationalLevelPreparatio~1",
                table: "SettingDirections");

            migrationBuilder.DropIndex(
                name: "IX_SettingDirections_EducationalLevelPreparationId1",
                table: "SettingDirections");

            migrationBuilder.DropColumn(
                name: "EducationalLevelPreparationId1",
                table: "SettingDirections");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EducationalLevelPreparationId1",
                table: "SettingDirections",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SettingDirections_EducationalLevelPreparationId1",
                table: "SettingDirections",
                column: "EducationalLevelPreparationId1");

            migrationBuilder.AddForeignKey(
                name: "FK_SettingDirections_SettingLevels_EducationalLevelPreparatio~1",
                table: "SettingDirections",
                column: "EducationalLevelPreparationId1",
                principalTable: "SettingLevels",
                principalColumn: "Id");
        }
    }
}
