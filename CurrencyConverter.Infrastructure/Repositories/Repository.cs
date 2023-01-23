using CurrencyConverter.Domain.Shared;
using CurrencyConverter.Infrastructure.Context;

namespace CurrencyConverter.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly CurrencyConverterDbContext _context;

    public Repository(CurrencyConverterDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
    }

    public async Task<T?> FindByIdAsync(object id)
    {
        return await _context.FindAsync<T>(id) ?? null;
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
    
    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}