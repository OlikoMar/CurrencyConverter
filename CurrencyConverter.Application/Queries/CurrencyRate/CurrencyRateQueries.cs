using CurrencyConverter.Application.DataModels;
using CurrencyConverter.Domain.CurrencyAggregate;
using CurrencyConverter.Domain.CurrencyRateAggregate;

namespace CurrencyConverter.Application.Queries.CurrencyRate;

public class CurrencyRateQueries : ICurrencyRateQueries
{
    private readonly ICurrencyRateRepository _currencyRateRepository;
    private readonly ICurrencyRepository _currencyRepository;

    public CurrencyRateQueries(ICurrencyRateRepository currencyRateRepository,
        ICurrencyRepository currencyRepository)
    {
        _currencyRateRepository = currencyRateRepository;
        _currencyRepository = currencyRepository;
    }

    public async Task<CurrencyRateDto> GetCurrencyRateByIdAsync(Guid id)
    {
        var currencyRate = await _currencyRateRepository.GetAsync(id);

        if (currencyRate == null) return null;

        return new CurrencyRateDto
        {
            Id = currencyRate.Id,
            CurrencyId = currencyRate.CurrencyId,
            RateToBuy = currencyRate.RateToBuy,
            RateToSell = currencyRate.RateToSell
        };
    }

    public async Task<IEnumerable<CurrencyRateDto>> GetAllCurrencyRatesAsync()
    {
        var currencyRates = await _currencyRateRepository.GetAllAsync();

        return currencyRates?.Select(currencyRate => new CurrencyRateDto
        {
            Id = currencyRate.Id,
            CurrencyId = currencyRate.CurrencyId,
            RateToBuy = currencyRate.RateToBuy,
            RateToSell = currencyRate.RateToSell
        });
    }
}