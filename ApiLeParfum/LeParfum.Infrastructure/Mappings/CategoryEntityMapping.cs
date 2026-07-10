using LeParfum.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeParfum.Infrastructure.Mappings
{
    public class CategoryEntityMapping : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("category");
           builder.HasKey(i => i.Id);

            builder.Property(n => n.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .IsRequired();
        }
    }
}