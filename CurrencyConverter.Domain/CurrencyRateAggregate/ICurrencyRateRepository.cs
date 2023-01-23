using CurrencyConverter.Domain.Shared;

namespace CurrencyConverter.Domain.CurrencyRateAggregate;

public interface ICurrencyRateRepository : IRepository<CurrencyRate>
{
    public Task<IEnumerable<CurrencyRate>> GetAllAsync();
    public Task<CurrencyRate> GetAsync(Guid id);
}