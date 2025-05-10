using AutoMapper;
using eMarket.Application.Contracts.Persistence;
using eMarket.Application.DTOs.Product;
using eMarket.Application.Feature.Product.Requests.Queries;
using eMarket.Application.Patterns.Mediator;

namespace eMarket.Application.Feature.Product.Handlers.Queries;

public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IEnumerable<ProductListDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductListQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ProductListDto>> Handle(GetProductListQuery query)
    {
        var products = await _productRepository.GetRangeAsync(query.Skip, query.Take);
        
        return _mapper.Map<IEnumerable<ProductListDto>>(products);
    }
}