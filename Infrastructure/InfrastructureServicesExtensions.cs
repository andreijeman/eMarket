using System.Text;
using eMarket.Application.Contracts.Infrastructure;
using eMarket.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace eMarket.Infrastructure;

public static class InfrastructureServicesExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFileStorage(configuration)
            .AddScoped<IJwtTokenService, JwtTokenService>()
            .AddJwtAuthentication(configuration);
        
        return services;
    }

    private static IServiceCollection AddFileStorage(this IServiceCollection services, IConfiguration config)
    {
        var relativePath = config["FileStorage:ImageUploadPath"] ?? "";
        var absolutePath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);
        Directory.CreateDirectory(absolutePath);
        
        return services;
    }

    private static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtToken:Issuer"],
                    ValidAudience = configuration["JwtToken:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["JwtToken:Secret"]!)),
                };
            });

        return services;
    }
}