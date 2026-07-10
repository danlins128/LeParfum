using LeParfum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeParfum.Infrastructure.Mappings
{
    public class ProductEntityMapping : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("product");
            builder.HasKey(p => p.Id);

            builder.Property(n => n.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .IsRequired();
            
            builder.HasOne(b => b.Brand)
                .WithMany()
                .HasForeignKey(b => b.BrandId)                
                .IsRequired();
            
            builder.HasOne(c => c.Category)
                .WithMany()
                .HasForeignKey(c => c.CategoryId)                
                .IsRequired();

            builder.Property(d => d.Description)
                .HasColumnName("description")
                .HasColumnType("text");

            builder.Property(p => p.Price)
                .HasColumnName("price")
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            
            builder.HasOne(g => g.Gender)
                .WithMany()
                .HasForeignKey(g => g.GenderId)                
                .IsRequired();
            
            builder.Property(s => s.Status)
                .HasColumnName("status")
                .HasColumnType("smallint");
        }
    }
}