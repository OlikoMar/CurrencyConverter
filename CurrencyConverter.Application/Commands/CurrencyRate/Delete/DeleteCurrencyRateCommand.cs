using CurrencyConverter.Infrastructure.Commands;
using MediatR;

namespace CurrencyConverter.Application.Commands.CurrencyRate.Delete;

public class DeleteCurrencyRateCommand : ICommand<bool>
{
    public Guid Id { get; set; }
}