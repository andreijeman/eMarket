using eMarket.Application.Contracts.Persistence;
using eMarket.Application.Feature.Product.Requests;
using eMarket.Application.Patterns.Mediator;
using Microsoft.Extensions.Configuration;

namespace eMarket.Application.Feature.Product.Handlers;

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
        var categories = await _categoryRepository.GetByIdsAsync(request.CategoryIds);
        
        var images = new List<string>();
        
        foreach (var image in request.Images)
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
            Name = request.Name,
            Price = request.Price,
            Description = request.Description,
            Images = images,
            Categories = categories
        };

        await _productRepository.AddAsync(product);

        return product.Id;
    }
}