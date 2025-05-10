namespace eMarket.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : class
{ 
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}