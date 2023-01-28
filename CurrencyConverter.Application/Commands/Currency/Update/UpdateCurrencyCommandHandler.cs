using CurrencyConverter.Domain.CurrencyAggregate;
using CurrencyConverter.Infrastructure.Commands;

namespace CurrencyConverter.Application.Commands.Currency.Update;

public class UpdateCurrencyCommandHandler : ICommandHandler<UpdateCurrencyCommand, bool>
{
    private readonly ICurrencyRepository _currencyRepository;

    public UpdateCurrencyCommandHandler(ICurrencyRepository currencyRepository)
    {
        _currencyRepository = currencyRepository;
    }
    public async Task<bool> Handle(UpdateCurrencyCommand command, CancellationToken cancellationToken)
    {
        var currency = await _currencyRepository.FindByIdAsync(command.Id);

        if (currency == null) return false;

        currency.UpdateData(command.Code, command.Name, command.NameEng);

        await _currencyRepository.SaveChangesAsync(cancellationToken);
        return true;
    }
}