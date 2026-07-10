using LeParfum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeParfum.Infrastructure.Mappings
{
    public class GenderEntityMapping : IEntityTypeConfiguration<GenderEntity>
    {
        public void Configure(EntityTypeBuilder<GenderEntity> builder)
        {
            builder.ToTable("gender");
           builder.HasKey(i => i.Id);

            builder.Property(n => n.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .IsRequired();
        }
    }
}