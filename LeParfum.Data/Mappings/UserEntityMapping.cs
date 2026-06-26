using LeParfum.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeParfum.Data.Mappings
{
    public class UserEntityMapping : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("user");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("id")
                .HasColumnType("uuid")
                .IsRequired();

            builder.Property(p => p.UserName)
                .HasColumnName("username")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(p => p.Password)
                .HasColumnName("password")
                .HasColumnType("text")
                .IsRequired();

        }
    }
}