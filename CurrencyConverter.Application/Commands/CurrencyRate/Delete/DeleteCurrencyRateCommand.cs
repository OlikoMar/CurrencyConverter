using CurrencyConverter.Infrastructure.Commands;
using MediatR;

namespace CurrencyConverter.Application.Commands.CurrencyRate.Delete;

public class DeleteCurrencyRateCommand : ICommand<Unit>
{
    public Guid Id { get; set; }
}