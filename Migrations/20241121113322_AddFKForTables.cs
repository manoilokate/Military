using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalRecords.Migrations
{
    /// <inheritdoc />
    public partial class AddFKForTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InformationAboutDiseases",
                keyColumn: "InformationAboutDiseasesId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InformationAboutDiseases",
                keyColumn: "InformationAboutDiseasesId",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InformationAboutDiseases",
                columns: new[] { "InformationAboutDiseasesId", "FinishedToIll", "FirstName", "IllnessDurationDays", "LastName", "PersonalRecordId", "Soname", "StartedToIll", "StayInHospital" },
                values: new object[,]
                {
                    { 1, new DateOnly(2020, 11, 28), "Іван", 0, "Бондарчук", 1, "Андрійович", new DateOnly(2020, 11, 18), false },
                    { 2, new DateOnly(2022, 11, 28), "Остап", 0, "Бедненко", 2, "Валентинович", new DateOnly(2022, 11, 18), false }
                });
        }
    }
}
