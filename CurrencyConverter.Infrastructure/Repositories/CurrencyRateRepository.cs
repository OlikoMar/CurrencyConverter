using CurrencyConverter.Domain.CurrencyRateAggregate;
using CurrencyConverter.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConverter.Infrastructure.Repositories;

public class CurrencyRateRepository : Repository<CurrencyRate>, ICurrencyRateRepository
{
    private readonly CurrencyConverterDbContext _dbContext;
    public CurrencyRateRepository(CurrencyConverterDbContext context, CurrencyConverterDbContext dbContext)
        : base(context)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<CurrencyRate>> GetAllAsync()
    {
        return await _dbContext.CurrencyRates.ToListAsync();
    }

    public async Task<CurrencyRate?> GetAsync(Guid id)
    {
        var currency = await _dbContext.CurrencyRates.FirstOrDefaultAsync(s => s.Id == id);
        return currency ?? null;
    }
}