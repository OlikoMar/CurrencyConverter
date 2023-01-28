using CurrencyConverter.Domain.CurrencyAggregate;
using CurrencyConverter.Infrastructure.Commands;

namespace CurrencyConverter.Application.Commands.Currency.Delete;

public class DeleteCurrencyCommandHandler : ICommandHandler<DeleteCurrencyCommand, bool>
{
    private readonly ICurrencyRepository _currencyRepository;

    public DeleteCurrencyCommandHandler(ICurrencyRepository currencyRepository)
    {
        _currencyRepository = currencyRepository;
    }

    public async Task<bool> Handle(DeleteCurrencyCommand command, CancellationToken cancellationToken)
    {
        var currency = await _currencyRepository.FindByIdAsync(command.Id);

        if (currency == null) return false;
        _currencyRepository.Remove(currency);
        await _currencyRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}