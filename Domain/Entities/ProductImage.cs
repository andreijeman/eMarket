using eMarket.Domain.Entities.Common;

namespace eMarket.Domain.Entities;

public class ProductImage : BaseEntity
{
    public int ProductId { get; set; }
    public required string FileName { get; set; }
}