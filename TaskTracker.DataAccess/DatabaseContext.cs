using Microsoft.EntityFrameworkCore;
using TaskTracker.DataAccess.Models;

namespace TaskTracker.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Project> Projects { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql("Host=localhost;Database=Tasker;Username=postgres;Password=postgres");
    }
}
