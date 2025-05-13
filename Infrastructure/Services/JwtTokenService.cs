using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using eMarket.Application.Contracts.Infrastructure;
using eMarket.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace eMarket.Infrastructure.Services;

public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;

    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, user.Role)
        };
        
        
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtToken:Secret"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            issuer: _configuration["JwtToken:Issuer"],
            audience: _configuration["JwtToken:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(int.Parse(_configuration["JwtToken:Expires"]!)),
            signingCredentials: creds
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}