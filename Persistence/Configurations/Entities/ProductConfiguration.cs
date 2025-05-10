using eMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eMarket.Persistence.Configurations.Entities;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasData(
            new Product
            {
                Id = 1,
                Name = "Product 1",
                Price = 7,
                Description = null,
                ImageUrls = new List<string>(),
                Categories = new List<Category>()
            },
            
            new Product
            {
                Id = 2,
                Name = "Product 2",
                Price = 13,
                Description = null,
                ImageUrls = new  List<string>(),
                Categories = new List<Category>()
            },
            
            new Product
            {
                Id = 3,
                Name = "Product 3",
                Price = 4,
                Description = null,
                ImageUrls = new List<string>(),
                Categories = new List<Category>()
            }
        );
    }
}