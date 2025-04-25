using eMarket.Domain.Entities.Common;

namespace eMarket.Domain.Entities;

public class Category : BaseEntity
{
    public required string Name { get; set; }
    public required ICollection<Product> Products { get; set; }
}