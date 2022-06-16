using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Context
{
    public partial class CatalogDbContext : DbContext
    {
        private string _cstring =
            "Data Source=C:\\Users\\firelizard\\RiderProjects\\CatalogService\\Data\\catalog.sqlite";
        
        public CatalogDbContext()
        {
        }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(_cstring);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
