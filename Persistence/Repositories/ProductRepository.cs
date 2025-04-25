using eMarket.Application.Contracts.Persistence;
using eMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eMarket.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetRangeAsync(int start, int count)
    {
      return await _context.Products.Skip(start).Take(count).ToListAsync();
    }

    public async Task<int> CountAsync()
    {
        return await _context.Products.CountAsync();
    }
}