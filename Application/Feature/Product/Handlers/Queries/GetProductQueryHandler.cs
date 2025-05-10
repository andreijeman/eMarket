using AutoMapper;
using eMarket.Application.Contracts.Persistence;
using eMarket.Application.DTOs.Product;
using eMarket.Application.Exceptions;
using eMarket.Application.Feature.Product.Requests.Queries;
using eMarket.Application.Patterns.Mediator;
using Microsoft.Extensions.Configuration;

namespace eMarket.Application.Feature.Product.Handlers.Queries;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper,  IConfiguration configuration)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _configuration = configuration;
    }
    
    public async Task<ProductDto> Handle(GetProductQuery query)
    {
        var product = await _productRepository.GetAsync(query.Id);
        
        if(product is null) throw new NotFoundException(nameof(Product), query.Id);
        
        var dto = _mapper.Map<ProductDto>(product);
        dto.ImageUrls = product.Images
            .Select(img => Path.Combine(_configuration["FileStorage:BaseUrl"]!, img))
            .ToList();
        
        return dto;
    }
}