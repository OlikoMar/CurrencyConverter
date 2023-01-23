using CurrencyConverter.Domain.Shared;

namespace CurrencyConverter.Domain.CustomerAggregate;

public interface ICustomerRepository : IRepository<Customer>
{
    public Task<decimal?> GetDailyLimitAsync(Guid id);
    public Task<Customer> GetAsync(Guid id);
}