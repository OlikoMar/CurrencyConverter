using CurrencyConverter.Infrastructure.Commands;
using MediatR;

namespace CurrencyConverter.Application.Commands.CurrencyRate.Create;

public class CreateCurrencyRateCommand : Command<bool>
{
    public Guid CurrencyId { get; set; } = default!;
    public decimal RateToSell { get; set; }
    public decimal RateToBuy { get; set; }
}