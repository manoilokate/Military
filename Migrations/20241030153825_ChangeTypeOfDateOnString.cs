using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalRecords.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTypeOfDateOnString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DateOfStartWork",
                table: "PersonalRecords",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "PersonalRecords",
                type: "text",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "PersonalRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "DateOfStartWork" },
                values: new object[] { "1990-01-01", "2008-06-01" });

            migrationBuilder.UpdateData(
                table: "PersonalRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "DateOfStartWork" },
                values: new object[] { "1976-08-21", "2000-04-04" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfStartWork",
                table: "PersonalRecords",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "PersonalRecords",
                type: "date",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "PersonalRecords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateOfBirth", "DateOfStartWork" },
                values: new object[] { new DateOnly(1990, 1, 1), new DateOnly(2008, 6, 11) });

            migrationBuilder.UpdateData(
                table: "PersonalRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateOfBirth", "DateOfStartWork" },
                values: new object[] { new DateOnly(1976, 8, 21), new DateOnly(2000, 4, 3) });
        }
    }
}
