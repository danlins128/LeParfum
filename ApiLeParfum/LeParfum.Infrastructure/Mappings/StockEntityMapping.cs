using LeParfum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeParfum.Infrastructure.Mappings
{
    public class StockEntityMapping : IEntityTypeConfiguration<StockEntity>
    {
        public void Configure(EntityTypeBuilder<StockEntity> builder)
        {
            builder.ToTable("stock");
            builder.HasKey(i => i.Id);

            builder.Property(p => p.Product)
                .HasColumnName("product")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(q => q.Quantity)
                .HasColumnName("quantity")
                .HasColumnType("int")
                .IsRequired();
            
        }
    }
}