using CurrencyConverter.Domain.CurrencyAggregate;
using CurrencyConverter.Infrastructure.Commands;
using MediatR;

namespace CurrencyConverter.Application.Commands.Currency.Update;

public class UpdateCurrencyCommandHandler : ICommandHandler<UpdateCurrencyCommand, Unit>
{
    private readonly ICurrencyRepository _currencyRepository;

    public UpdateCurrencyCommandHandler(ICurrencyRepository currencyRepository)
    {
        _currencyRepository = currencyRepository;
    }
    public async Task<Unit> Handle(UpdateCurrencyCommand command, CancellationToken cancellationToken)
    {
        var currency = await _currencyRepository.FindByIdAsync(command.Id);

        if (currency == null) return Unit.Value;

        currency.UpdateData(command.Code, command.Name, command.NameEng);

        await _currencyRepository.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}