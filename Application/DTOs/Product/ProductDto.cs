using eMarket.Application.DTOs.Category;

namespace eMarket.Application.DTOs.Product;

public class ProductDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public IEnumerable<string> ImageUrls { get; set; } = new List<string>();
    public required IEnumerable<CategoryListDto> Categories { get; set; } = new List<CategoryListDto>();
}