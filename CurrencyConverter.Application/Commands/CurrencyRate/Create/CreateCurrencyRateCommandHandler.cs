using CurrencyConverter.Domain.CurrencyAggregate;
using CurrencyConverter.Domain.CurrencyRateAggregate;
using CurrencyConverter.Infrastructure.Commands;
using MediatR;

namespace CurrencyConverter.Application.Commands.CurrencyRate.Create;

public class CreateCurrencyRateCommandHandler : ICommandHandler<CreateCurrencyRateCommand, bool>
{
    private readonly ICurrencyRateRepository _currencyRateRepository;
    private readonly ICurrencyRepository _currencyRepository;

    public CreateCurrencyRateCommandHandler(ICurrencyRateRepository currencyRateRepository, ICurrencyRepository currencyRepository)
    {
        _currencyRateRepository = currencyRateRepository;
        _currencyRepository = currencyRepository;
    }

    public async Task<bool> Handle(CreateCurrencyRateCommand request, CancellationToken cancellationToken)
    {
        var currency = await _currencyRepository.GetAsync(request.CurrencyId);

        if (currency == null) return false;

        var currencyRate = new Domain.CurrencyRateAggregate.CurrencyRate
        {
            Id = new Guid(),
            RateToBuy = request.RateToBuy,
            RateToSell = request.RateToSell,
            Currency = currency
        };
        await _currencyRateRepository.AddAsync(currencyRate);
        await _currencyRateRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}