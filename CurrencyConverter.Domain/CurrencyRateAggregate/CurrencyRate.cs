using CurrencyConverter.Domain.CurrencyAggregate;
using CurrencyConverter.Domain.Shared;

namespace CurrencyConverter.Domain.CurrencyRateAggregate;

public class CurrencyRate : BaseEntity
{
    public Currency Currency { get; set; } = default!;
    public Guid CurrencyId { get; set; }
    public decimal RateToSell { get; set; }
    public decimal RateToBuy { get; set; }

    public void UpdateData(decimal rateToSell, decimal rateToBuy)
    {
        RateToSell = rateToSell;
        RateToBuy = rateToBuy;
    }
}