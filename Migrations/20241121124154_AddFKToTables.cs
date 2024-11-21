using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalRecords.Migrations
{
    /// <inheritdoc />
    public partial class AddFKToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Додавання зовнішніх ключів
            migrationBuilder.AddForeignKey(
                name: "FK_FamilyContacts_PersonalRecord",
                table: "FamilyContacts",
                column: "PersonalRecordId",
                principalTable: "PersonalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InformationAboutDiseases_PersonalRecord",
                table: "InformationAboutDiseases",
                column: "PersonalRecordId",
                principalTable: "PersonalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InformationAboutVacation_PersonalRecord",
                table: "InformationAboutVacation",
                column: "PersonalRecordId",
                principalTable: "PersonalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalTraining_PersonalRecord",
                table: "AdditionalTraining",
                column: "PersonalRecordId",
                principalTable: "PersonalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.InsertData(
                table: "AdditionalTraining",
                columns: new[] { "TrainingId", "FinishedTraining", "FirstName", "LastName", "PersonalRecordId", "Soname", "StartedTraining", "TrainingCity", "TrainingCountry", "TrainingDurationDays", "TrainingName" },
                values: new object[] { 1, new DateOnly(2020, 12, 10), "Остап", "Бедненко", 2, "Валентинович", new DateOnly(2020, 11, 10), "Житомир", "Україна", 30, "Підвіщення кваліфікації" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Видалення зовнішніх ключів
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyContacts_PersonalRecord",
                table: "FamilyContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_InformationAboutDiseases_PersonalRecord",
                table: "InformationAboutDiseases");

            migrationBuilder.DropForeignKey(
                name: "FK_InformationAboutVacation_PersonalRecord",
                table: "InformationAboutVacation");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalTraining_PersonalRecord",
                table: "AdditionalTraining");

            migrationBuilder.DeleteData(
                table: "AdditionalTraining",
                keyColumn: "TrainingId",
                keyValue: 1);
        }
    }
}
