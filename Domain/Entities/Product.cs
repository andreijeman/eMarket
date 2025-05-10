using eMarket.Domain.Entities.Common;

namespace eMarket.Domain.Entities;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public string? Description { get; set; }
    public ICollection<string> Images { get; set; } = new List<string>();
    public ICollection<Category> Categories { get; set; } = new List<Category>();
}
