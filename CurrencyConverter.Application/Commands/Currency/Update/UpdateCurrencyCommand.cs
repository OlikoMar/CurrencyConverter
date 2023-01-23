using CurrencyConverter.Infrastructure.Commands;
using MediatR;

namespace CurrencyConverter.Application.Commands.Currency.Update;

public class UpdateCurrencyCommand : ICommand<Unit>
{
    public Guid Id { get; set; }
    public string Code { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string NameEng { get; set; } = default!;
}