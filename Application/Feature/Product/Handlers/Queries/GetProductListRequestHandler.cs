using AutoMapper;
using eMarket.Application.Contracts.Persistence;
using eMarket.Application.DTOs.Product;
using eMarket.Application.Feature.Product.Requests.Queries;
using eMarket.Application.Patterns.Mediator;

namespace eMarket.Application.Feature.Product.Handlers.Queries;

public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, IEnumerable<ProductListDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductListRequestHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ProductListDto>> Handle(GetProductListRequest request)
    {
        var products = await _productRepository.GetRangeAsync(request.Start, request.Count);
        
        return _mapper.Map<IEnumerable<ProductListDto>>(products);
    }
}