using Microsoft.AspNetCore.Http;

namespace eMarket.Application.DTOs.Product;

public class CreateProductDto
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public string? Description { get; set; }
    public ICollection<IFormFile> Images { get; set; } = new  List<IFormFile>();
    public ICollection<int> CategoryIds { get; set; } = new  List<int>();
}