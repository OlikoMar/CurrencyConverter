using CurrencyConverter.Domain.CurrencyAggregate;
using CurrencyConverter.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConverter.Infrastructure.Repositories;

public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
{
    private readonly CurrencyConverterDbContext _dbContext;

    public CurrencyRepository(CurrencyConverterDbContext context, CurrencyConverterDbContext dbContext) : base(context)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Currency>> GetAllAsync()
    {
        return await _dbContext.Currencies.ToListAsync();
    }

    public async Task<Currency?> GetAsync(Guid id)
    {
        var currency = await _dbContext.Currencies.FirstOrDefaultAsync(s => s.Id == id);
        return currency ?? null;
    }
}