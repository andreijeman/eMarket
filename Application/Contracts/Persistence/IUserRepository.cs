using eMarket.Domain.Entities;

namespace eMarket.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<bool> AnyEmailAsync(string email);
}