using LeParfum.Data.Entities;
using LeParfum.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace LeParfum.Data.Context
{
    public class LeParfumDbContext : DbContext
    {
        public LeParfumDbContext(DbContextOptions<LeParfumDbContext> options) : base(options) {}

        public DbSet<BrandEntity> Brands { get; set; }
        public DbSet<GenderEntity> Genders { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<StockEntity> Stocks { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrandEntityMapping());
            modelBuilder.ApplyConfiguration(new GenderEntityMapping());
            modelBuilder.ApplyConfiguration(new ProductEntityMapping());
            modelBuilder.ApplyConfiguration(new StockEntityMapping());
            modelBuilder.ApplyConfiguration(new UserEntityMapping());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=~/Documents/Projetos/ASP.NET/LeParfum/LeParfum.db");
        }
    }
}
