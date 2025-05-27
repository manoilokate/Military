using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PersonalRecords.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Soname = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<string>(type: "text", nullable: false),
                    DateOfStartWork = table.Column<string>(type: "text", nullable: false),
                    Rank = table.Column<string>(type: "text", nullable: false),
                    NumberOrganization = table.Column<string>(type: "text", nullable: false),
                    Education = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Password = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

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
                    FinishedTraining = table.Column<DateOnly>(type: "date", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "FamilyContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonalRecordId = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Soname = table.Column<string>(type: "text", nullable: false),
                    Relationship = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FamilyContacts_PersonalRecords_PersonalRecordId",
                        column: x => x.PersonalRecordId,
                        principalTable: "PersonalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InformationAboutDiseases",
                columns: table => new
                {
                    InformationAboutDiseasesId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonalRecordId = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Soname = table.Column<string>(type: "text", nullable: false),
                    StartedToIll = table.Column<DateOnly>(type: "date", nullable: false),
                    FinishedToIll = table.Column<DateOnly>(type: "date", nullable: false),
                    StayInHospital = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationAboutDiseases", x => x.InformationAboutDiseasesId);
                    table.ForeignKey(
                        name: "FK_InformationAboutDiseases_PersonalRecords_PersonalRecordId",
                        column: x => x.PersonalRecordId,
                        principalTable: "PersonalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InformationAboutVacation",
                columns: table => new
                {
                    InformationAboutVacationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonalRecordId = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Soname = table.Column<string>(type: "text", nullable: false),
                    StartedVacation = table.Column<DateOnly>(type: "date", nullable: false),
                    FinishedVacation = table.Column<DateOnly>(type: "date", nullable: false),
                    IsPaidVacation = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationAboutVacation", x => x.InformationAboutVacationId);
                    table.ForeignKey(
                        name: "FK_InformationAboutVacation_PersonalRecords_PersonalRecordId",
                        column: x => x.PersonalRecordId,
                        principalTable: "PersonalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalTraining_PersonalRecordId",
                table: "AdditionalTraining",
                column: "PersonalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyContacts_PersonalRecordId",
                table: "FamilyContacts",
                column: "PersonalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationAboutDiseases_PersonalRecordId",
                table: "InformationAboutDiseases",
                column: "PersonalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationAboutVacation_PersonalRecordId",
                table: "InformationAboutVacation",
                column: "PersonalRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalTraining");

            migrationBuilder.DropTable(
                name: "FamilyContacts");

            migrationBuilder.DropTable(
                name: "InformationAboutDiseases");

            migrationBuilder.DropTable(
                name: "InformationAboutVacation");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PersonalRecords");
        }
    }
}
