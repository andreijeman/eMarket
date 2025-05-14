namespace eMarket.Application.DTOs.Product;

public class ProductListDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
}