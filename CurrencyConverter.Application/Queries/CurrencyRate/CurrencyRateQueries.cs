using CurrencyConverter.Application.DataModels;
using CurrencyConverter.Domain.CurrencyRateAggregate;

namespace CurrencyConverter.Application.Queries.CurrencyRate;

public class CurrencyRateQueries : ICurrencyRateQueries
{
    private readonly ICurrencyRateRepository _currencyRateRepository;

    public CurrencyRateQueries(ICurrencyRateRepository currencyRateRepository)
    {
        _currencyRateRepository = currencyRateRepository;
    }

    public async Task<CurrencyRateDto> GetCurrencyRateByIdAsync(Guid id)
    {
        var currencyRate = await _currencyRateRepository.GetAsync(id);

        return new CurrencyRateDto
        {
            Currency = currencyRate.Currency,
            RateToBuy = currencyRate.RateToBuy,
            RateToSell = currencyRate.RateToSell
        };
    }

    public async Task<IEnumerable<CurrencyRateDto>> GetAllCurrencyRatesAsync()
    {
        var currencyRates = await _currencyRateRepository.GetAllAsync();

        return currencyRates.Select(currencyRate => new CurrencyRateDto
        {
            Currency = currencyRate.Currency,
            RateToBuy = currencyRate.RateToBuy,
            RateToSell = currencyRate.RateToSell
        });
    }
}