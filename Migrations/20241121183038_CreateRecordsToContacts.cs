using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PersonalRecords.Migrations
{
    /// <inheritdoc />
    public partial class CreateRecordsToContacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "FamilyContacts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "FamilyContacts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "FamilyContacts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Soname",
                table: "FamilyContacts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AdditionalTraining",
                columns: new[] { "TrainingId", "FinishedTraining", "FirstName", "LastName", "PersonalRecordId", "Soname", "StartedTraining", "TrainingCity", "TrainingCountry", "TrainingDurationDays", "TrainingName" },
                values: new object[] { 2, new DateOnly(2020, 10, 10), "Іван", "Бондарчук", 1, "Андрійович", new DateOnly(2019, 10, 10), "Луцьк", "Україна", 365, "Навчання зі стрільби " });

            migrationBuilder.InsertData(
                table: "FamilyContacts",
                columns: new[] { "Id", "Address", "City", "Email", "FirstName", "LastName", "PersonalRecordId", "PhoneNumber", "Relationship", "Soname" },
                values: new object[] { 1, "Садова 18", "Миколаїв", "bondarchyk.alla@gmail.com", "Алла", "Бондарчук", 1, "050997805", "Дружина", "Василівна" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AdditionalTraining",
                keyColumn: "TrainingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FamilyContacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "City",
                table: "FamilyContacts");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "FamilyContacts");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "FamilyContacts");

            migrationBuilder.DropColumn(
                name: "Soname",
                table: "FamilyContacts");
        }
    }
}
