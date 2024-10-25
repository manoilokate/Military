using Microsoft.EntityFrameworkCore;

namespace PersonalRecords.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
    }
}
