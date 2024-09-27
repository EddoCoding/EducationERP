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
            migrationBuilder.CreateTable(
                name: "SettingLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LevelName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingDirections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DirectionCode = table.Column<string>(type: "text", nullable: false),
                    DirectionName = table.Column<string>(type: "text", nullable: false),
                    EducationalLevelPreparationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingDirections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingDirections_SettingLevels_EducationalLevelPreparation~",
                        column: x => x.EducationalLevelPreparationId,
                        principalTable: "SettingLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SettingProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfileCode = table.Column<string>(type: "text", nullable: false),
                    ProfileName = table.Column<string>(type: "text", nullable: false),
                    EducationalDirectionTrainingId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SettingProfiles_SettingDirections_EducationalDirectionTrain~",
                        column: x => x.EducationalDirectionTrainingId,
                        principalTable: "SettingDirections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SettingDirections_EducationalLevelPreparationId",
                table: "SettingDirections",
                column: "EducationalLevelPreparationId");

            migrationBuilder.CreateIndex(
                name: "IX_SettingProfiles_EducationalDirectionTrainingId",
                table: "SettingProfiles",
                column: "EducationalDirectionTrainingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SettingProfiles");

            migrationBuilder.DropTable(
                name: "SettingDirections");

            migrationBuilder.DropTable(
                name: "SettingLevels");
        }
    }
}
