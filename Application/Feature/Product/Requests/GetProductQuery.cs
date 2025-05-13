using eMarket.Application.DTOs.Product;
using eMarket.Application.Patterns.Mediator;

namespace eMarket.Application.Feature.Product.Requests.Queries;

public class GetProductQuery : IRequest<ProductDto>
{
    public int Id { get; set; }
}