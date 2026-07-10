using LeParfum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeParfum.Infrastructure.Mappings 
{
    public class BrandEntityMapping : IEntityTypeConfiguration<BrandEntity>
    {
        public void Configure(EntityTypeBuilder<BrandEntity> builder)
        {
           builder.ToTable("brand");
           builder.HasKey(i => i.Id);

            builder.Property(n => n.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .IsRequired();     
           
        }
    }
}