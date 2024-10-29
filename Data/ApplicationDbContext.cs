using Microsoft.EntityFrameworkCore;
using PersonalRecords.Models;

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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonalRecord>().HasData(
                new PersonalRecord { Id = 1, FirstName = "Іван", 
                    LastName = "Бондарчук",Soname = "Андрійович", DateOfBirth = new DateOnly(1990, 1, 1),DateOfStartWork = new DateOnly(2008, 6, 11), 
                    Rank = "Сержант", NumberOrganization = "A5678", Education = "Повна середня", PhoneNumber = "0956784322"},
                new PersonalRecord
                {
                    Id = 2,
                    FirstName = "Остап",
                    LastName = "Бедненко",
                    Soname = "Валентинович",
                    DateOfBirth = new DateOnly(1976, 8, 21),
                    DateOfStartWork = new DateOnly(2000, 4, 3),
                    Rank = "Капітан",
                    NumberOrganization = "A4399",
                    Education = "Повна середня",
                    PhoneNumber = "0957800116"
                }
            );
        }

    }
}
