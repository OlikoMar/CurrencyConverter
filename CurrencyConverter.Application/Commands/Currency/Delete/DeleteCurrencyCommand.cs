using CurrencyConverter.Infrastructure.Commands;

namespace CurrencyConverter.Application.Commands.Currency.Delete;

public class DeleteCurrencyCommand : ICommand<bool>
{
    public Guid Id { get; set; }
}