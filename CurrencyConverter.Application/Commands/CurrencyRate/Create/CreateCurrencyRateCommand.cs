using CurrencyConverter.Infrastructure.Commands;
using MediatR;

namespace CurrencyConverter.Application.Commands.CurrencyRate.Create;

public class CreateCurrencyRateCommand : Command<Unit>
{
    public Domain.CurrencyAggregate.Currency Currency { get; set; } = default!;
    public decimal RateToSell { get; set; }
    public decimal RateToBuy { get; set; }
}