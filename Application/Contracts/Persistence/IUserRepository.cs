using eMarket.Domain.Entities;

namespace eMarket.Application.Contracts.Persistence;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetByEmail(string email);
}