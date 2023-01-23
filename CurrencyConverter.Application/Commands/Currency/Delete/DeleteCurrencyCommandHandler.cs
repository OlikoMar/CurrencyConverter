using CurrencyConverter.Domain.CurrencyAggregate;
using CurrencyConverter.Infrastructure.Commands;
using MediatR;

namespace CurrencyConverter.Application.Commands.Currency.Delete;

public class DeleteCurrencyCommandHandler : ICommandHandler<DeleteCurrencyCommand, Unit>
{
    private readonly ICurrencyRepository _currencyRepository;

    public DeleteCurrencyCommandHandler(ICurrencyRepository currencyRepository)
    {
        _currencyRepository = currencyRepository;
    }

    public async Task<Unit> Handle(DeleteCurrencyCommand command, CancellationToken cancellationToken)
    {
        var currency = await _currencyRepository.FindByIdAsync(command.Id);

        if (currency == null) return Unit.Value;
        _currencyRepository.Remove(currency);
        await _currencyRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}