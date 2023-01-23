using CurrencyConverter.Infrastructure.Commands;

namespace CurrencyConverter.Application.Commands.Currency.Create;

public class CreateCurrencyCommand : Command<bool>
{
    public string Code { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string NameEng { get; set; } = default!;
}