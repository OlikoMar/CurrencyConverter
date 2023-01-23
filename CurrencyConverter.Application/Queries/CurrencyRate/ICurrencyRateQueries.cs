using CurrencyConverter.Application.DataModels;

namespace CurrencyConverter.Application.Queries.CurrencyRate;

public interface ICurrencyRateQueries
{
    Task<CurrencyRateDto> GetCurrencyRateByIdAsync(Guid id);
    Task<IEnumerable<CurrencyRateDto>> GetAllCurrencyRatesAsync();
}