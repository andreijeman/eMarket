using eMarket.Application.Contracts.Persistence;
using eMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eMarket.Persistence.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> GetByUserId(int userId)
    {
        return await _context.Orders.Where(e => e.UserId == userId).ToListAsync();
    }
}