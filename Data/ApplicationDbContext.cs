using Microsoft.EntityFrameworkCore;
using PersonalRecords.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalRecords.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
    public DbSet<User> Users { get; set; }
    public DbSet<FamilyContacts> FamilyContacts { get; set; }
    public DbSet<PersonalRecord> PersonalRecords { get; set; }
    public DbSet<InformationAboutDiseases> InformationAboutDiseases { get; set; }
    public DbSet<InformationAboutVacation> InformationAboutVacation { get; set; }
    public DbSet<AdditionalTraining> AdditionalTraining { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonalRecord>().HasData(
                new PersonalRecord { Id = 1, FirstName = "Іван", 
                    LastName = "Бондарчук",Soname = "Андрійович", DateOfBirth = "1990-01-01",DateOfStartWork = "2008-06-01", 
                    Rank = "Сержант", NumberOrganization = "A5678", Education = "Повна середня", PhoneNumber = "0956784322"},
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
            modelBuilder.Entity<InformationAboutDiseases>().HasData(
                new InformationAboutDiseases
                {
                    InformationAboutDiseasesId =1,
                    PersonalRecordId=1,
                    FirstName ="Іван",
                    LastName="Бондарчук",
                    Soname="Андрійович",
                    StartedToIll= new DateOnly(2020, 11, 18),
                    FinishedToIll= new DateOnly(2020, 11, 28),
                    StayInHospital =false
                },
                new InformationAboutDiseases
                {
                    InformationAboutDiseasesId = 2,
                    PersonalRecordId = 2,
                    FirstName = "Остап",
                    LastName = "Бедненко",
                    Soname = "Валентинович",
                    StartedToIll = new DateOnly(2022, 11, 18),
                    FinishedToIll = new DateOnly(2022, 11, 28),
                    StayInHospital = false
                }
            );

        }
    }
}
