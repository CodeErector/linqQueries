using linqQueries.Model;
using Microsoft.EntityFrameworkCore;

namespace linqQueries.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Student>? stu { get; set; }
        public DbSet<Class>? Classes { get; set; }
        public DbSet<Faculty>? Faculties { get; set; }
        public DbSet<Enrolled>? Enrolled { get; set; }
    }
}
