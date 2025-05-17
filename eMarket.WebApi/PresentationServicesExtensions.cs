using System.Reflection;
using Microsoft.OpenApi.Models;

namespace eMarket.WebApi;

public static class PresentationServicesExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddSwaggerGen();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddSwaggerGenSecurity();
        
        return services;
    }

    private static void AddSwaggerGenSecurity(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }

    private static void AddBlazorCors(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(configuration["Cors:Blazor:Name"]!, policy =>
            {
                policy.WithOrigins(configuration["Cors:Blazor:Origins"]!)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }
}