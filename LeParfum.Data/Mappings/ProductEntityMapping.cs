using LeParfum.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeParfum.Data.Mappings
{
    public class ProductEntityMapping : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("product");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(p => p.Brand)
                .HasColumnName("brand")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("description")
                .HasColumnType("text");
                

            builder.Property(p => p.Price)
                .HasColumnName("price")
                .HasColumnType("double")
                .IsRequired();

            builder.Property(p => p.Gender)
                .HasColumnName("gender")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.Status)
                .HasColumnName("status")
                .HasColumnType("smallint")
                .IsRequired();
        }
    }
}