using eMarket.Application.DTOs.Product;
using MediatR;

namespace eMarket.Application.Feature.Product.Requests.Queries;

public class GetProductQuery : IRequest<ProductDto>
{
    public int Id { get; set; }
}