using CurrencyConverter.Domain.CurrencyAggregate;

namespace CurrencyConverter.Application.DataModels;

public class CurrencyRateDto
{
    public Currency Currency { get; set; } = default!;
    public decimal RateToSell { get; set; }
    public decimal RateToBuy { get; set; }
}