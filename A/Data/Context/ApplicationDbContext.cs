using A.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace A.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Division> Divisions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>().ToTable("divisions");
            modelBuilder.Entity<Division>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Division>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Division>().Property(x => x.Status).IsRequired();

            modelBuilder.Entity<Division>().HasOne(x => x.UpperDivision).WithMany(x => x.DownDivisions).HasForeignKey(x => x.UpperName).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
