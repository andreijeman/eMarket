using eMarket.Domain.Entities.Common;

namespace eMarket.Domain.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public string? Description { get; set; }
    public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
    public ICollection<Category> Categories { get; set; } = new List<Category>();
}
