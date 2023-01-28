using CurrencyConverter.Infrastructure.Commands;

namespace CurrencyConverter.Application.Commands.Currency.Update;

public class UpdateCurrencyCommand : ICommand<bool>
{
    public Guid Id { get; set; }
    public string Code { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string NameEng { get; set; } = default!;
}