using CurrencyConverter.Application.DataModels;

namespace CurrencyConverter.Application.Queries.Customer;

public interface ICustomerQueries
{
    Task<CustomerDto> GetCustomerByIdAsync(Guid id);
    Task<decimal?> GetDailyLimitAsync(Guid id);
}