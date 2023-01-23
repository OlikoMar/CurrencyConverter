using CurrencyConverter.Application.DataModels;
using CurrencyConverter.Domain.CustomerAggregate;

namespace CurrencyConverter.Application.Queries.Customer;

public class CustomerQueries : ICustomerQueries
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerQueries(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDto> GetCustomerByIdAsync(Guid id)
    {
        var customer = await _customerRepository.GetAsync(id);

        return new CustomerDto
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PersonalNumber = customer.PersonalNumber,
            RecommenderPersonalNumber = customer.RecommenderPersonalNumber
        };
    }

    public Task<decimal?> GetDailyLimitAsync(Guid id)
    {
        return _customerRepository.GetDailyLimitAsync(id);
    }
}