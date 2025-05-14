using System.Reflection;
using eMarket.Application.DTOs.Category;
using eMarket.Application.DTOs.Product;
using eMarket.Application.Feature.Category.Handlers;
using eMarket.Application.Feature.Category.Requests;
using eMarket.Application.Feature.Product.Handlers;
using eMarket.Application.Feature.Product.Requests;
using eMarket.Application.Feature.User.Handlers;
using eMarket.Application.Feature.User.Requests;
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
        
        services.AddTransient<IRequestHandler<LoginUserCommand, string>, LoginUserCommandHandler>();
        services.AddTransient<IRequestHandler<RegisterUserCommand, string>, RegisterUserCommandHandler>();
        
        return services;
    }
}
