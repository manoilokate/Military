using Microsoft.EntityFrameworkCore;
using PersonalRecords.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalRecords.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
    public DbSet<User> Users { get; set; }
    public DbSet<PersonalRecord> PersonalRecords { get; set; }
    public DbSet<FamilyContacts> FamilyContacts { get; set; }
    public DbSet<InformationAboutDiseases> InformationAboutDiseases { get; set; }
    public DbSet<InformationAboutVacation> InformationAboutVacation { get; set; }
    public DbSet<AdditionalTraining> AdditionalTraining { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<FamilyContacts>()
                .HasOne(fc => fc.PersonalRecord)
                .WithMany(pr => pr.FamilyContacts)
                .HasForeignKey(fc => fc.PersonalRecordId);

            modelBuilder.Entity<InformationAboutDiseases>()
            .HasOne(id => id.PersonalRecord)
            .WithMany(pr => pr.InformationAboutDiseases)
            .HasForeignKey(id => id.PersonalRecordId);

            modelBuilder.Entity<InformationAboutVacation>()
                .HasOne(iv => iv.PersonalRecord)
                .WithMany(pr => pr.InformationAboutVacation)
                .HasForeignKey(iv => iv.PersonalRecordId);

            modelBuilder.Entity<AdditionalTraining>()
                .HasOne(at => at.PersonalRecord)
                .WithMany(pr => pr.AdditionalTraining)
                .HasForeignKey(at => at.PersonalRecordId);

            modelBuilder.Entity<PersonalRecord>().HasData(
                new PersonalRecord
                {
                    Id = 1,
                    FirstName = "Іван",
                    LastName = "Бондарчук",
                    Soname = "Андрійович",
                    DateOfBirth = "1990-01-01",
                    DateOfStartWork = "2008-06-01",
                    Rank = "Сержант",
                    NumberOrganization = "A5678",
                    Education = "Повна середня",
                    PhoneNumber = "0956784322"
                },
                new PersonalRecord
                {
                    Id = 2,
                    FirstName = "Остап",
                    LastName = "Бедненко",
                    Soname = "Валентинович",
                    DateOfBirth = "1976-08-21",
                    DateOfStartWork = "2000-04-04",
                    Rank = "Капітан",
                    NumberOrganization = "A4399",
                    Education = "Повна середня",
                    PhoneNumber = "0957800116"
                }
            );
            modelBuilder.Entity<AdditionalTraining>().HasData(
                new AdditionalTraining
                {
                    TrainingId = 1,
                    PersonalRecordId = 2,
                    FirstName = "Остап",
                    LastName = "Бедненко",
                    Soname = "Валентинович",
                    TrainingName = "Підвіщення кваліфікації",
                    TrainingCountry = "Україна",
                    TrainingCity = "Житомир",
                    StartedTraining = new DateOnly(2020, 11, 10),
                    FinishedTraining = new DateOnly(2020, 12, 10),
                    TrainingDurationDays = 30
                }
            );
            modelBuilder.Entity<AdditionalTraining>().HasData(
               new AdditionalTraining
               {
                   TrainingId = 2,
                   PersonalRecordId = 1,
                   FirstName = "Іван",
                   LastName = "Бондарчук",
                   Soname = "Андрійович",
                   TrainingName = "Навчання зі стрільби ",
                   TrainingCountry = "Україна",
                   TrainingCity = "Луцьк",
                   StartedTraining = new DateOnly(2019, 10, 10),
                   FinishedTraining = new DateOnly(2020, 10, 10),
                   TrainingDurationDays = 365
               }
            );
            modelBuilder.Entity<FamilyContacts>().HasData(
              new FamilyContacts
              {
                  Id=1,
                  PersonalRecordId=1,
                  FirstName="Алла",
                  LastName="Бондарчук",
                  Soname="Василівна",
                  Relationship="Дружина",
                  PhoneNumber="050997805",
                  Email="bondarchyk.alla@gmail.com",
                  City="Миколаїв",
                  Address="Садова 18"
              }
            );
            modelBuilder.Entity<InformationAboutVacation>().HasData(
               new InformationAboutVacation
               {
                   InformationAboutVacationId=1,
                   PersonalRecordId=1,
                   FirstName="Іван",
                   LastName="Бондарчук",
                   Soname="Андрійович",
                   StartedVacation=new DateOnly(2017,08,15),
                   FinishedVacation=new DateOnly(2017,09,01),
                   VacationDurationDays=16,
                   IsPaidVacation=true
               },
               new InformationAboutVacation
               {
                   InformationAboutVacationId = 2,
                   PersonalRecordId = 2,
                   FirstName = "Остап",
                   LastName = "Бедненко",
                   Soname = "Валентинович",
                   StartedVacation = new DateOnly(2019, 09, 15),
                   FinishedVacation = new DateOnly(2019, 09, 21),
                   VacationDurationDays = 6,
                   IsPaidVacation = false
               }
            );
            modelBuilder.Entity<InformationAboutDiseases>().HasData(
              new InformationAboutDiseases
              {
                  InformationAboutDiseasesId=2,
                  PersonalRecordId=1,
                  FirstName="Іван",
                  LastName="Бондарчук",
                  Soname="Андрійович",
                  StartedToIll=new DateOnly(2022,10,28),
                  FinishedToIll=new DateOnly(2022,11,10),
                  IllnessDurationDays=12,
                  StayInHospital=false
              },
              new InformationAboutDiseases
              {
                  InformationAboutDiseasesId = 3,
                  PersonalRecordId = 2,
                  FirstName = "Остап",
                  LastName = "Бедненко",
                  Soname = "Валентинович",
                  StartedToIll = new DateOnly(2022, 08, 08),
                  FinishedToIll = new DateOnly(2022, 08, 18),
                  IllnessDurationDays = 10,
                  StayInHospital = false
              }
            );
        }
    }
}
