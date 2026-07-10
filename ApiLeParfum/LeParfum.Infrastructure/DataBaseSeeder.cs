using LeParfum.Domain.Entities;
using LeParfum.Infrastructure.Data;

namespace LeParfum.Infrastructure.Seed
{
    public class DatabaseSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (!context.Brands.Any())
            {
                context.Brands.AddRange(
                    new BrandEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = "Artesanal"
                    },
                    new BrandEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = "Carolina Herrera"
                    },
                    new BrandEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = "Chanel"
                    },
                    new BrandEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = "Dior"
                    }
                    );
                    await context.SaveChangesAsync();
            }
            if (!context.Genders.Any())
            {
                context.AddRange(
                    new GenderEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = "Masculino"
                    },
                    new GenderEntity{
                        Id = Guid.NewGuid(),
                        Name = "Feminino"
                    });
                await context.SaveChangesAsync();
            }
            if (!context.Categories.Any())
            {
                context.AddRange(new CategoryEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Body"
                },
                new CategoryEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Hair"
                },new CategoryEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Home"
                },new CategoryEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Car"
                },
                new CategoryEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Environment"
                });
                await context.SaveChangesAsync();
            }
            await Task.CompletedTask;
        }
    }

}