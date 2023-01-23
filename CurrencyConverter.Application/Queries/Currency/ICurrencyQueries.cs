using CurrencyConverter.Application.DataModels;

namespace CurrencyConverter.Application.Queries.Currency;

public interface ICurrencyQueries
{
    Task<CurrencyDto> GetCurrencyByIdAsync(Guid id);
    Task<IEnumerable<CurrencyDto>> GetAllCurrenciesAsync();
}