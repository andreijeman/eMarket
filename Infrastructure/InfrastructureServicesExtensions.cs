using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eMarket.Infrastructure;

public static class InfrastructureServicesExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddFileStorage(config);
        
        return services;
    }

    private static IServiceCollection AddFileStorage(this IServiceCollection services, IConfiguration config)
    {
        var relativePath = config.GetSection("FileStorage")["ImageUploadPath"] ?? "";
        var absolutePath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);
        Directory.CreateDirectory(absolutePath);
        
        return services;
    }
}