using eMarket.Domain.Entities.Common;

namespace eMarket.Domain.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? DetailPageUrl { get; set; }
    public ICollection<string>? ImagesUrl { get; set; }
    public required ICollection<Category> Categories { get; set; }
}
