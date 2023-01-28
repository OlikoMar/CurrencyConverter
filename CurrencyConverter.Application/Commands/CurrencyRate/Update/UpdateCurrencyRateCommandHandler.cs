using CurrencyConverter.Domain.CurrencyRateAggregate;
using CurrencyConverter.Infrastructure.Commands;
using MediatR;

namespace CurrencyConverter.Application.Commands.CurrencyRate.Update;

public class UpdateCurrencyRateCommandHandler : ICommandHandler<UpdateCurrencyRateCommand, bool>
{
    private readonly ICurrencyRateRepository _currencyRateRepository;

    public UpdateCurrencyRateCommandHandler(ICurrencyRateRepository currencyRateRepository)
    {
        _currencyRateRepository = currencyRateRepository;
    }

    public async Task<bool> Handle(UpdateCurrencyRateCommand command, CancellationToken cancellationToken)
    {
        var currencyRate = await _currencyRateRepository.GetAsync(command.Id);

        if (currencyRate == null) return false;

        currencyRate.UpdateData(command.RateToSell, command.RateToBuy);
        await _currencyRateRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}