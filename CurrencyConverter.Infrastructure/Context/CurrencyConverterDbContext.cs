using CurrencyConverter.Domain.ConvertHistoryAggregate;
using CurrencyConverter.Domain.CurrencyAggregate;
using CurrencyConverter.Domain.CurrencyRateAggregate;
using CurrencyConverter.Domain.CustomerAggregate;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConverter.Infrastructure.Context;

public class CurrencyConverterDbContext : DbContext
{
    public CurrencyConverterDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
    {

    }

    public DbSet<Currency> Currencies { get; set; } = default!;
    public DbSet<CurrencyRate> CurrencyRates { get; set; } = default!;
    public DbSet<Customer> Customers { get; set; } = default!;
    public DbSet<ConvertHistory> ConvertHistories { get; set; } = default!;
}