using CurrencyConverter.Domain.Shared;

namespace CurrencyConverter.Domain.CurrencyAggregate;

public interface ICurrencyRepository : IRepository<Currency>
{
    public Task<IEnumerable<Currency>> GetAllAsync();
    public Task<Currency> GetAsync(Guid id);
}