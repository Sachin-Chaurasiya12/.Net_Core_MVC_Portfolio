using Microsoft.EntityFrameworkCore;
using loginpageusingmvc.Models;

namespace loginpageusingmvc.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        public DbSet<UserLogin> Users { get; set; }

        public DbSet<Project> UserProjects { get; set; }

    }
}