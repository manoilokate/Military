using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PersonalRecords.Migrations
{
    /// <inheritdoc />
    public partial class CreateAdditionalTraining : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalTraining",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonalRecordId = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Soname = table.Column<string>(type: "text", nullable: false),
                    TrainingName = table.Column<string>(type: "text", nullable: false),
                    TrainingCountry = table.Column<string>(type: "text", nullable: false),
                    TrainingCity = table.Column<string>(type: "text", nullable: false),
                    StartedTraining = table.Column<DateOnly>(type: "date", nullable: false),
                    FinishedTraining = table.Column<DateOnly>(type: "date", nullable: false),
                    TrainingDurationDays = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalTraining", x => x.TrainingId);
                    table.ForeignKey(
                        name: "FK_AdditionalTraining_PersonalRecords_PersonalRecordId",
                        column: x => x.PersonalRecordId,
                        principalTable: "PersonalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalTraining_PersonalRecordId",
                table: "AdditionalTraining",
                column: "PersonalRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalTraining");
        }
    }
}
