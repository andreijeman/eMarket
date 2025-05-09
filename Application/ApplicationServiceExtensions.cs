using System.Reflection;
using eMarket.Application.DTOs.Category;
using eMarket.Application.DTOs.Product;
using eMarket.Application.Feature.Product.Handlers.Queries;
using eMarket.Application.Feature.Product.Requests.Queries;
using eMarket.Application.Patterns.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace eMarket.Application;

public static class ApplicationServiceExtensions
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
        services.AddTransient<IRequestHandler<GetProductRequest, ProductDto>, GetProductRequestHandler>();
        services.AddTransient<IRequestHandler<GetProductListRequest, IEnumerable<ProductListDto>>, GetProductListRequestHandler>();
        
        return services;
    }
}
