using eMarket.Application.Contracts.Persistence;
using eMarket.Application.Feature.Product.Requests.Commands;
using eMarket.Application.Patterns.Mediator;
using Microsoft.Extensions.Configuration;

namespace eMarket.Application.Feature.Product.Handlers.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IConfiguration _configuration;

    public CreateProductCommandHandler(IProductRepository productRepository, 
        ICategoryRepository categoryRepository, IConfiguration configuration)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _configuration = configuration;
    }
        
    public async Task<int> Handle(CreateProductCommand request)
    {
        var dto = request.CreateProductDto;
        
        var categories = await _categoryRepository.GetByIdsAsync(dto.CategoryIds);
        
        var images = new List<string>();
        
        foreach (var image in dto.Images)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            var relativePath = Path.Combine(_configuration["FileStorage:ImageUploadPath"]!, fileName);
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);

            await using var stream = new FileStream(fullPath, FileMode.Create);
            await image.CopyToAsync(stream);

            images.Add(fileName);
        }

        var product = new Domain.Entities.Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Description = dto.Description,
            Images = images,
            Categories = categories
        };

        await _productRepository.AddAsync(product);

        return product.Id;
    }
}