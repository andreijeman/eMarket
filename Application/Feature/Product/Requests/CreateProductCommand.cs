using eMarket.Application.DTOs.Product;
using eMarket.Application.Patterns.Mediator;

namespace eMarket.Application.Feature.Product.Requests.Commands;

public class CreateProductCommand : IRequest<int>
{
    public required CreateProductDto CreateProductDto { get; set; }
}