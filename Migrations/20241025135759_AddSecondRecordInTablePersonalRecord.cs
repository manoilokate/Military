using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalRecords.Migrations
{
    /// <inheritdoc />
    public partial class AddSecondRecordInTablePersonalRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PersonalRecords",
                columns: new[] { "Id", "DateOfBirth", "DateOfStartWork", "Education", "FirstName", "LastName", "NumberOrganization", "PhoneNumber", "Rank", "Soname" },
                values: new object[] { 2, new DateOnly(1976, 8, 21), new DateOnly(2000, 4, 3), "Повна середня", "Остап", "Бедненко", "A4399", "0957800116", "Капітан", "Валентинович" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonalRecords",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
