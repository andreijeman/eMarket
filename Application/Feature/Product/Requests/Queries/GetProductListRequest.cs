using eMarket.Application.DTOs.Product;
using eMarket.Application.Patterns.Mediator;

namespace eMarket.Application.Feature.Product.Requests.Queries;

public class GetProductListRequest : IRequest<IEnumerable<ProductListDto>>
{
    public int Start { get; set; }
    public int Count { get; set; }
}