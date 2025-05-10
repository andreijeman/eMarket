using eMarket.Application.Contracts.Persistence;
using eMarket.Application.DTOs.Product;
using eMarket.Application.Feature.Product.Requests.Queries;
using eMarket.Application.Patterns.Mediator;
using Microsoft.Extensions.Configuration;

namespace eMarket.Application.Feature.Product.Handlers.Queries;

public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, IEnumerable<ProductListDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IConfiguration _configuration;

    public GetProductListQueryHandler(IProductRepository productRepository, IConfiguration configuration)
    {
        _productRepository = productRepository;
        _configuration = configuration;
    }
    
    public async Task<IEnumerable<ProductListDto>> Handle(GetProductListQuery query)
    {
        var products = await _productRepository.GetRangeAsync(query.Skip, query.Take);

        var dtos = new List<ProductListDto>();
        
        foreach (var product in products)
        {
            var dto = new ProductListDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
            };

            if (product.Images.Count > 0)
                dto.ImageUrl = Path.Combine(_configuration["FileStorage:BaseUrl"]!, product.Images.First());
            
            dtos.Add(dto);
        }
        
        return dtos;
    }
}