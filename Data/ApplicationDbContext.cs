namespace PRN222_Group_Project.Data
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        // Constructor with options
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Define your DbSets here
        // public DbSet<YourModel> YourTable { get; set; }
    }
}
