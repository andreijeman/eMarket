using eMarket.Application.DTOs.Common;

namespace eMarket.Application.DTOs.Product;

public class ProductListDto : BaseDto
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
}