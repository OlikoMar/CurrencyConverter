using CurrencyConverter.Infrastructure.Commands;
using MediatR;

namespace CurrencyConverter.Application.Commands.CurrencyRate.Update;

public class UpdateCurrencyRateCommand : ICommand<bool>
{
    public Guid Id { get; set; }
    public decimal RateToSell { get; set; }
    public decimal RateToBuy { get; set; }
}