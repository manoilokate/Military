using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalRecords.Migrations
{
    /// <inheritdoc />
    public partial class CreateRecordsInTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InformationAboutDiseases",
                columns: new[] { "InformationAboutDiseasesId", "FinishedToIll", "FirstName", "IllnessDurationDays", "LastName", "PersonalRecordId", "Soname", "StartedToIll", "StayInHospital" },
                values: new object[,]
                {
                    { 2, new DateOnly(2022, 11, 10), "Іван", 12, "Бондарчук", 1, "Андрійович", new DateOnly(2022, 10, 28), false },
                    { 3, new DateOnly(2022, 8, 18), "Остап", 10, "Бедненко", 2, "Валентинович", new DateOnly(2022, 8, 8), false }
                });

            migrationBuilder.InsertData(
                table: "InformationAboutVacation",
                columns: new[] { "InformationAboutVacationId", "FinishedVacation", "FirstName", "IsPaidVacation", "LastName", "PersonalRecordId", "Soname", "StartedVacation", "VacationDurationDays" },
                values: new object[,]
                {
                    { 1, new DateOnly(2017, 9, 1), "Іван", true, "Бондарчук", 1, "Андрійович", new DateOnly(2017, 8, 15), 16 },
                    { 2, new DateOnly(2019, 9, 21), "Остап", false, "Бедненко", 2, "Валентинович", new DateOnly(2019, 9, 15), 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InformationAboutDiseases",
                keyColumn: "InformationAboutDiseasesId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InformationAboutDiseases",
                keyColumn: "InformationAboutDiseasesId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InformationAboutVacation",
                keyColumn: "InformationAboutVacationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InformationAboutVacation",
                keyColumn: "InformationAboutVacationId",
                keyValue: 2);
        }
    }
}
