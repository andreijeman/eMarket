using AutoMapper;
using eMarket.Application.Contracts.Persistence;
using eMarket.Application.DTOs.Product;
using eMarket.Application.Exceptions;
using eMarket.Application.Feature.Product.Requests.Queries;
using eMarket.Application.Patterns.Mediator;

namespace eMarket.Application.Feature.Product.Handlers.Queries;

public class GetProductRequestHandler : IRequestHandler<GetProductRequest, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductRequestHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public async Task<ProductDto> Handle(GetProductRequest request)
    {
        var product = await _productRepository.GetAsync(request.Id);
        
        if(product is null) throw new NotFoundException(nameof(Product), request.Id);
        
        return _mapper.Map<ProductDto>(product);
    }
}