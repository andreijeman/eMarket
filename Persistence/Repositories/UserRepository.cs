using eMarket.Application.Contracts.Persistence;
using eMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eMarket.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<User> GetByEmail(string email)
    {
        return await _context.Users.FirstAsync(u => u.Email == email);
    }
}