using CurrencyConverter.Domain.CurrencyRateAggregate;
using CurrencyConverter.Infrastructure.Commands;
using MediatR;

namespace CurrencyConverter.Application.Commands.CurrencyRate.Update;

public class UpdateCurrencyRateCommandHandler : ICommandHandler<UpdateCurrencyRateCommand, Unit>
{
    private readonly ICurrencyRateRepository _currencyRateRepository;

    public UpdateCurrencyRateCommandHandler(ICurrencyRateRepository currencyRateRepository)
    {
        _currencyRateRepository = currencyRateRepository;
    }

    public async Task<Unit> Handle(UpdateCurrencyRateCommand command, CancellationToken cancellationToken)
    {
        var currencyRate = await _currencyRateRepository.GetAsync(command.Id);
        currencyRate?.UpdateData(command.RateToSell, command.RateToBuy);

        return Unit.Value;
    }
}