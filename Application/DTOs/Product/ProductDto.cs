using eMarket.Application.DTOs.Category;
using eMarket.Application.DTOs.Common;

namespace eMarket.Application.DTOs.Product;

public class ProductDto : BaseDto
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public IEnumerable<string> ImageUrls { get; set; } = new List<string>();
    public required IEnumerable<CategoryListDto> Categories { get; set; } = new List<CategoryListDto>();
}