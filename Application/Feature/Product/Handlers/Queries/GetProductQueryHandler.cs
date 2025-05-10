using AutoMapper;
using eMarket.Application.Contracts.Persistence;
using eMarket.Application.DTOs.Product;
using eMarket.Application.Exceptions;
using eMarket.Application.Feature.Product.Requests.Queries;
using eMarket.Application.Patterns.Mediator;

namespace eMarket.Application.Feature.Product.Handlers.Queries;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<ProductDto> Handle(GetProductQuery query)
    {
        var product = await _productRepository.GetByIdAsync(query.Id);
        
        if(product is null) throw new NotFoundException(nameof(Product), query.Id);
        
        return _mapper.Map<ProductDto>(product);
    }
}