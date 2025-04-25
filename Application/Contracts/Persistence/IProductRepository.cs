using eMarket.Domain.Entities;

namespace eMarket.Application.Contracts.Persistence;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetRangeAsync(int start, int count);
    Task<int> CountAsync();
}