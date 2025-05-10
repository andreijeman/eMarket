using eMarket.Domain.Entities;

namespace eMarket.Application.Contracts.Persistence;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<ICollection<Category>> GetByIdsAsync(IEnumerable<int> ids);
    Task<IEnumerable<Category>> GetAllAsync();
}