using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationERP.Migrations
{
    /// <inheritdoc />
    public partial class SixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PointsDistinctiveFeatures",
                table: "Applicants",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_DistinctiveFeatures_ApplicantId",
                table: "DistinctiveFeatures",
                column: "ApplicantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistinctiveFeatures");

            migrationBuilder.DropColumn(
                name: "PointsDistinctiveFeatures",
                table: "Applicants");
        }
    }
}
