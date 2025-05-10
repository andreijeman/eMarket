using eMarket.Application.Contracts.Persistence;
using eMarket.Application.Feature.Product.Requests.Commands;
using eMarket.Application.Patterns.Mediator;
using Microsoft.Extensions.Configuration;

namespace eMarket.Application.Feature.Product.Handlers.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IMediator _mediator;
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly string _imageUploadPath;

    public CreateProductCommandHandler(IMediator mediator, IProductRepository productRepository, 
        ICategoryRepository categoryRepository, IConfiguration config)
    {
        _mediator = mediator;
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _imageUploadPath = config.GetSection("FileStorage")["ImageUploadPath"] ?? "";
    }
        
    public async Task<int> Handle(CreateProductCommand request)
    {
        var dto = request.CreateProductDto;
        
        var categories = await _categoryRepository.GetByIdsAsync(dto.CategoryIds);
        
        var imageUrls = new List<string>();
        
        foreach (var image in dto.Images)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            var path = Path.Combine(_imageUploadPath, fileName);
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), path);

            await using var stream = new FileStream(fullPath, FileMode.Create);
            await image.CopyToAsync(stream);

            imageUrls.Add(path);
        }

        var product = new Domain.Entities.Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Description = dto.Description,
            ImageUrls = imageUrls,
            Categories = categories
        };

        await _productRepository.AddAsync(product);

        return product.Id;
    }
}