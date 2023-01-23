using CurrencyConverter.Domain.CurrencyRateAggregate;
using CurrencyConverter.Infrastructure.Commands;
using MediatR;

namespace CurrencyConverter.Application.Commands.CurrencyRate.Create;

public class CreateCurrencyRateCommandHandler : ICommandHandler<CreateCurrencyRateCommand, Unit>
{
    private readonly ICurrencyRateRepository _currencyRateRepository;

    public CreateCurrencyRateCommandHandler(ICurrencyRateRepository currencyRateRepository)
    {
        _currencyRateRepository = currencyRateRepository;
    }

    public async Task<Unit> Handle(CreateCurrencyRateCommand request, CancellationToken cancellationToken)
    {
        var currencyRate = new Domain.CurrencyRateAggregate.CurrencyRate()
        {
            Id = new Guid(),
            RateToBuy = request.RateToBuy,
            RateToSell = request.RateToSell,
            Currency = request.Currency
        };
        await _currencyRateRepository.AddAsync(currencyRate);
        await _currencyRateRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}