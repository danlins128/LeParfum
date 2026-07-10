using LeParfum.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeParfum.Infrastructure.Mappings
{
    public class UserEntityMapping : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("user");
            builder.HasKey(i => i.Id);

            builder.Property(n => n.UserName)
                .HasColumnName("username")
                .HasColumnType("text")
                .IsRequired();
            
            builder.Property(p => p.Password)
                .HasColumnName("password")
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}