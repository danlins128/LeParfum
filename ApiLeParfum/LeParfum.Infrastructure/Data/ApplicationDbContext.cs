using LeParfum.Domain.Entities;
using LeParfum.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace LeParfum.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<BrandEntity> Brands { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<GenderEntity> Genders { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<StockEntity> Stocks { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandEntityMapping());
            modelBuilder.ApplyConfiguration(new CategoryEntityMapping());
            modelBuilder.ApplyConfiguration(new GenderEntityMapping());
            modelBuilder.ApplyConfiguration(new ProductEntityMapping());
            modelBuilder.ApplyConfiguration(new StockEntityMapping());
            modelBuilder.ApplyConfiguration(new UserEntityMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}