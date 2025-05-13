using eMarket.Domain.Entities;

namespace eMarket.Application.Contracts.Infrastructure;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}