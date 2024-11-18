using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalRecords.Migrations
{
    /// <inheritdoc />
    public partial class AddRecordToInformationAboutDiseases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InformationAboutDiseases",
                columns: new[] { "InformationAboutDiseasesId", "FinishedToIll", "FirstName", "IllnessDurationDays", "LastName", "PersonalRecordId", "Soname", "StartedToIll", "StayInHospital" },
                values: new object[] { 1, new DateOnly(2020, 11, 28), "Іван", 0, "Бондарчук", 1, "Андрійович", new DateOnly(2020, 11, 18), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InformationAboutDiseases",
                keyColumn: "InformationAboutDiseasesId",
                keyValue: 1);
        }
    }
}
