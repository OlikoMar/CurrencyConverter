using CurrencyConverter.Infrastructure.Commands;
using MediatR;

namespace CurrencyConverter.Application.Commands.Currency.Delete;

public class DeleteCurrencyCommand : ICommand<Unit>
{
    public Guid Id { get; set; }
}