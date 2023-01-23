using CurrencyConverter.Application.DataModels;
using CurrencyConverter.Domain.CurrencyAggregate;

namespace CurrencyConverter.Application.Queries.Currency;

public class CurrencyQueries : ICurrencyQueries
{
    private readonly ICurrencyRepository _currencyRepository;

    public CurrencyQueries(ICurrencyRepository currencyRepository)
    {
        _currencyRepository = currencyRepository;
    }

    public async Task<CurrencyDto> GetCurrencyByIdAsync(Guid id)
    {
        var currency = await _currencyRepository.GetAsync(id);

        return new CurrencyDto
        {
            Code = currency.Code,
            Name = currency.Name,
            NameEng = currency.NameEng
        };
    }

    public async Task<IEnumerable<CurrencyDto>> GetAllCurrenciesAsync()
    {
        var currencies = await _currencyRepository.GetAllAsync();

        return currencies.Select(currency => new CurrencyDto
        {
            Code = currency.Code,
            Name = currency.Name,
            NameEng = currency.NameEng
        });
    }
}