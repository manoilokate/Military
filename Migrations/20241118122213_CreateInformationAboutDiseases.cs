using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PersonalRecords.Migrations
{
    /// <inheritdoc />
    public partial class CreateInformationAboutDiseases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InformationAboutDiseases",
                columns: table => new
                {
                    InformationDetailsId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonalRecordId = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Soname = table.Column<string>(type: "text", nullable: false),
                    StartedToIll = table.Column<DateOnly>(type: "date", nullable: false),
                    FinishedToIll = table.Column<DateOnly>(type: "date", nullable: false),
                    IllnessDurationDays = table.Column<int>(type: "integer", nullable: false),
                    StayInHospital = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationAboutDiseases", x => x.InformationDetailsId);
                    table.ForeignKey(
                        name: "FK_InformationAboutDiseases_PersonalRecords_PersonalRecordId",
                        column: x => x.PersonalRecordId,
                        principalTable: "PersonalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InformationAboutDiseases_PersonalRecordId",
                table: "InformationAboutDiseases",
                column: "PersonalRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformationAboutDiseases");
        }
    }
}
