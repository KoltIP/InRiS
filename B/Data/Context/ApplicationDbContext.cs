using B.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace B.Data.Context
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
            modelBuilder.Entity<Division>().HasOne(x => x.Parent).WithMany(x => x.Children).HasForeignKey(x => x.ParentName).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
