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
        }
    }
}
