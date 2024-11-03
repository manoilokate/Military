using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalRecords.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstRecordInTablePersonalRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PersonalRecords",
                columns: new[] { "Id", "DateOfBirth", "DateOfStartWork", "Education", "FirstName", "LastName", "NumberOrganization", "PhoneNumber", "Rank", "Soname" },
                values: new object[] { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2008, 6, 11, 0, 0, 0, 0, DateTimeKind.Utc), "Повна середня", "Іван", "Бондарчук", "A5678", "0956784322", "Сержант", "Андрійович" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonalRecords",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
