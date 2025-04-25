using eMarket.Application.DTOs.Product;
using MediatR;

namespace eMarket.Application.Feature.Product.Requests.Queries;

public class GetProductListQuery : IRequest<List<ProductListDto>>
{
    public int Start { get; set; }
    public int Count { get; set; }
}