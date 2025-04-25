using eMarket.Application.Contracts.Persistence;
using eMarket.Domain.Entities;

namespace eMarket.Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}