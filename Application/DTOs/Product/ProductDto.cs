using eMarket.Application.DTOs.Category;
using eMarket.Application.DTOs.Common;

namespace eMarket.Application.DTOs.Product;

public class ProductDto : BaseDto
{
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? DetailPageUrl { get; set; }
    public IEnumerable<string>? ImagesUrl { get; set; }
    public required IEnumerable<CategoryDto> Categories { get; set; }
}