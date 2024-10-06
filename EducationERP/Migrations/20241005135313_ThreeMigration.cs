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
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameFaculty = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameLevel = table.Column<string>(type: "text", nullable: false),
                    SettingFacultyId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Levels_Faculties_SettingFacultyId",
                        column: x => x.SettingFacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Directions",
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
                    table.PrimaryKey("PK_Directions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Directions_Levels_SettingLevelId",
                        column: x => x.SettingLevelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Directions_SettingLevelId",
                table: "Directions",
                column: "SettingLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Levels_SettingFacultyId",
                table: "Levels",
                column: "SettingFacultyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Directions");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
