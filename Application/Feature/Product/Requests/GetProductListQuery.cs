using eMarket.Application.DTOs.Product;
using eMarket.Application.Patterns.Mediator;

namespace eMarket.Application.Feature.Product.Requests;

public class GetProductListQuery : IRequest<IEnumerable<ProductListDto>>
{
    public int Skip { get; set; }
    public int Take { get; set; }
}