using eMarket.Application.Contracts.Persistence;
using eMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eMarket.Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<ICollection<Category>> GetByIdsAsync(IEnumerable<int> ids)
    {
        return await _context.Categories
            .Where(c => ids.Contains(c.Id))
            .ToListAsync();
    }
}