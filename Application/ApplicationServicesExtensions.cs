using System.Reflection;
using eMarket.Application.DTOs.Category;
using eMarket.Application.DTOs.Product;
using eMarket.Application.Feature.Product.Handlers.Commands;
using eMarket.Application.Feature.Product.Handlers.Queries;
using eMarket.Application.Feature.Product.Requests.Commands;
using eMarket.Application.Feature.Product.Requests.Queries;
using eMarket.Application.Patterns.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace eMarket.Application;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediator();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        return services;
    }

    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddScoped<IMediator, Mediator>(); 
        services.AddTransient<IRequestHandler<GetProductQuery, ProductDto>, GetProductQueryHandler>();
        services.AddTransient<IRequestHandler<GetProductListQuery, IEnumerable<ProductListDto>>, GetProductListQueryHandler>();
        services.AddTransient<IRequestHandler<CreateProductCommand, int>, CreateProductCommandHandler>();
        services.AddTransient<IRequestHandler<CreateCategoryCommand, int>, CreateCategoryCommandHandler>();
        services.AddTransient<IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryListDto>>, GetAllCategoriesQueryHandler>();
        
        return services;
    }
}
