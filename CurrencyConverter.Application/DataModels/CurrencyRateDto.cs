namespace CurrencyConverter.Application.DataModels;

public class CurrencyRateDto
{
    public Guid Id { get; set; }
    public Guid CurrencyId { get; set; } = default!;
    public decimal RateToSell { get; set; }
    public decimal RateToBuy { get; set; }
}