using CurrencyConverter.Domain.CurrencyRateAggregate;

namespace CurrencyConverter.Domain.Shared;

public interface IRepository<T>
{
    Task AddAsync(T entity);
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<T?> FindByIdAsync(object id);
    void Remove(T entity);
    
}