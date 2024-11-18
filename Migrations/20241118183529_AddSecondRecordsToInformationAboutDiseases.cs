using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalRecords.Migrations
{
    /// <inheritdoc />
    public partial class AddSecondRecordsToInformationAboutDiseases : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "InformationAboutDiseases",
                columns: new[] { "InformationAboutDiseasesId", "FinishedToIll", "FirstName", "IllnessDurationDays", "LastName", "PersonalRecordId", "Soname", "StartedToIll", "StayInHospital" },
                values: new object[] { 2, new DateOnly(2022, 11, 28), "Остап", 0, "Бедненко", 2, "Валентинович", new DateOnly(2022, 11, 18), false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InformationAboutDiseases",
                keyColumn: "InformationAboutDiseasesId",
                keyValue: 2);
        }
    }
}
