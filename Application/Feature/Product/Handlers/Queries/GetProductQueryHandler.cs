using AutoMapper;
using eMarket.Application.Contracts.Persistence;
using eMarket.Application.DTOs.Product;
using eMarket.Application.Feature.Product.Requests.Queries;
using MediatR;

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
    
    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetAsync(request.Id);
        
        return _mapper.Map<ProductDto>(product);
    }
}