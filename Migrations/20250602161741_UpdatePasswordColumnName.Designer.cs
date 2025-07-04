﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PersonalRecords.Data;

#nullable disable

namespace PersonalRecords.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250602161741_UpdatePasswordColumnName")]
    partial class UpdatePasswordColumnName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.2.24474.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PersonalRecords.Models.AdditionalTraining", b =>
                {
                    b.Property<int>("TrainingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TrainingId"));

                    b.Property<DateOnly>("FinishedTraining")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PersonalRecordId")
                        .HasColumnType("integer");

                    b.Property<string>("Soname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("StartedTraining")
                        .HasColumnType("date");

                    b.Property<string>("TrainingCity")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TrainingCountry")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TrainingName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TrainingId");

                    b.HasIndex("PersonalRecordId");

                    b.ToTable("AdditionalTraining");
                });

            modelBuilder.Entity("PersonalRecords.Models.FamilyContacts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PersonalRecordId")
                        .HasColumnType("integer");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Relationship")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Soname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PersonalRecordId");

                    b.ToTable("FamilyContacts");
                });

            modelBuilder.Entity("PersonalRecords.Models.InformationAboutDiseases", b =>
                {
                    b.Property<int>("InformationAboutDiseasesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InformationAboutDiseasesId"));

                    b.Property<DateOnly>("FinishedToIll")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PersonalRecordId")
                        .HasColumnType("integer");

                    b.Property<string>("Soname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("StartedToIll")
                        .HasColumnType("date");

                    b.Property<bool>("StayInHospital")
                        .HasColumnType("boolean");

                    b.HasKey("InformationAboutDiseasesId");

                    b.HasIndex("PersonalRecordId");

                    b.ToTable("InformationAboutDiseases");
                });

            modelBuilder.Entity("PersonalRecords.Models.InformationAboutVacation", b =>
                {
                    b.Property<int>("InformationAboutVacationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InformationAboutVacationId"));

                    b.Property<DateOnly>("FinishedVacation")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsPaidVacation")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PersonalRecordId")
                        .HasColumnType("integer");

                    b.Property<string>("Soname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateOnly>("StartedVacation")
                        .HasColumnType("date");

                    b.HasKey("InformationAboutVacationId");

                    b.HasIndex("PersonalRecordId");

                    b.ToTable("InformationAboutVacation");
                });

            modelBuilder.Entity("PersonalRecords.Models.PersonalRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateOfStartWork")
                        .HasColumnType("date");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumberOrganization")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Soname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PersonalRecords");
                });

            modelBuilder.Entity("PersonalRecords.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PersonalRecords.Models.AdditionalTraining", b =>
                {
                    b.HasOne("PersonalRecords.Models.PersonalRecord", "PersonalRecord")
                        .WithMany("AdditionalTraining")
                        .HasForeignKey("PersonalRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalRecord");
                });

            modelBuilder.Entity("PersonalRecords.Models.FamilyContacts", b =>
                {
                    b.HasOne("PersonalRecords.Models.PersonalRecord", "PersonalRecord")
                        .WithMany("FamilyContacts")
                        .HasForeignKey("PersonalRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalRecord");
                });

            modelBuilder.Entity("PersonalRecords.Models.InformationAboutDiseases", b =>
                {
                    b.HasOne("PersonalRecords.Models.PersonalRecord", "PersonalRecord")
                        .WithMany("InformationAboutDiseases")
                        .HasForeignKey("PersonalRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalRecord");
                });

            modelBuilder.Entity("PersonalRecords.Models.InformationAboutVacation", b =>
                {
                    b.HasOne("PersonalRecords.Models.PersonalRecord", "PersonalRecord")
                        .WithMany("InformationAboutVacation")
                        .HasForeignKey("PersonalRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonalRecord");
                });

            modelBuilder.Entity("PersonalRecords.Models.PersonalRecord", b =>
                {
                    b.Navigation("AdditionalTraining");

                    b.Navigation("FamilyContacts");

                    b.Navigation("InformationAboutDiseases");

                    b.Navigation("InformationAboutVacation");
                });
#pragma warning restore 612, 618
        }
    }
}
