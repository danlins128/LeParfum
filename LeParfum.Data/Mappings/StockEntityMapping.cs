using LeParfum.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeParfum.Data.Mappings
{
    public class StockEntityMapping : IEntityTypeConfiguration<StockEntity>
    {
        public void Configure(EntityTypeBuilder<StockEntity> builder)
        {
            builder.ToTable("user");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.Product)
                .HasColumnName("product")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.Quantity)
                .HasColumnName("quantity")
                .HasColumnType("integer");
        }
    }
}