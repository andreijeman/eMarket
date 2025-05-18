using eMarket.Application.Contracts.Persistence;
using eMarket.Application.Feature.Product.Requests;
using eMarket.Application.Patterns.Mediator;

namespace eMarket.Application.Feature.Product.Handlers;

public class GetProductCountQueryHandler :  IRequestHandler<GetProductCountQuery, int>
{
    private readonly IProductRepository _productRepository;

    public GetProductCountQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<int> Handle(GetProductCountQuery request)
    {
        return await _productRepository.CountAsync();
    }
}