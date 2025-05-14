using eMarket.Application.Patterns.Mediator;
using Microsoft.AspNetCore.Http;

namespace eMarket.Application.Feature.Product.Requests;

public class CreateProductCommand : IRequest<int>
{
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public string? Description { get; set; }
    public ICollection<IFormFile> Images { get; set; } = new  List<IFormFile>();
    public ICollection<int> CategoryIds { get; set; } = new  List<int>();
}