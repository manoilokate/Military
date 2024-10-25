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
    }
}
