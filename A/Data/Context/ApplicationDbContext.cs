using A.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace A.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Division> Divisions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>().ToTable("divisions");
            modelBuilder.Entity<Division>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Division>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Division>().Property(x => x.Status).IsRequired();
        }
    }
}
