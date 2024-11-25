using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PersonalRecords.Migrations
{
    /// <inheritdoc />
    public partial class CreateInformationAboutVacation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InformationDetailsId",
                table: "InformationAboutDiseases",
                newName: "InformationAboutDiseasesId");

            migrationBuilder.CreateTable(
                name: "InformationAboutVacation",
                columns: table => new
                {
                    InformationAboutVacationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonalRecordId = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Soname = table.Column<string>(type: "text", nullable: false),
                    StartedVacation = table.Column<DateOnly>(type: "date", nullable: false),
                    FinishedVacation = table.Column<DateOnly>(type: "date", nullable: false),
                    VacationDurationDays = table.Column<int>(type: "integer", nullable: false),
                    IsPaidVacation = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationAboutVacation", x => x.InformationAboutVacationId);
                    table.ForeignKey(
                        name: "FK_InformationAboutVacation_PersonalRecords_PersonalRecordId",
                        column: x => x.PersonalRecordId,
                        principalTable: "PersonalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InformationAboutVacation_PersonalRecordId",
                table: "InformationAboutVacation",
                column: "PersonalRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformationAboutVacation");

            migrationBuilder.RenameColumn(
                name: "InformationAboutDiseasesId",
                table: "InformationAboutDiseases",
                newName: "InformationDetailsId");
        }
    }
}
