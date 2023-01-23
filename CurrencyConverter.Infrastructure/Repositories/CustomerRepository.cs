using CurrencyConverter.Domain.CustomerAggregate;
using CurrencyConverter.Infrastructure.Configs;
using CurrencyConverter.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CurrencyConverter.Infrastructure.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    private readonly CurrencyConverterDbContext _context;
    private readonly CustomerMaxLimitConfig _config;
    public CustomerRepository(
        CurrencyConverterDbContext context,
        IOptions<CustomerMaxLimitConfig> config)
        : base(context)
    {
        _context = context;
        _config = config.Value;
    }

    public async Task<decimal?> GetDailyLimitAsync(Guid id)
    {
        var transactionsTotalSum = await CalculateTotalTransactionsSumAsync(id);

        if (transactionsTotalSum > _config.MaxLimit)
            return null;

        return _config.MaxLimit - transactionsTotalSum;
    }

    public async Task<Customer?> GetAsync(Guid id)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(s => s.Id == id);
        return customer ?? null;
    }

    private async Task<decimal> CalculateTotalTransactionsSumAsync(Guid id)
    {
        return await _context.ConvertHistories
            .Where(s => s.Date.Day == DateTimeOffset.Now.Day
                        && s.Recommender.Id == id)
            .SumAsync(s => s.Amount);
    }
}