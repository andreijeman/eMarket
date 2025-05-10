using eMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eMarket.Persistence.Configurations.Entities;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            new Category
            {
                Id = 1,
                Name = "Laptop",
            },
            new Category
            {
                Id = 2,
                Name = "Audio",
            },
            new Category
            {
                Id = 3,
                Name = "Fashion",
            },
            new Category
            {
                Id = 4,
                Name = "Home",
            });
    }
}