using CurrencyConverter.Domain.CurrencyRateAggregate;
using CurrencyConverter.Infrastructure.Commands;
using MediatR;

namespace CurrencyConverter.Application.Commands.CurrencyRate.Delete;

public class DeleteCurrencyRateCommandHandler : ICommandHandler<DeleteCurrencyRateCommand, Unit>
{
    private readonly ICurrencyRateRepository _currencyRateRepository;

    public DeleteCurrencyRateCommandHandler(ICurrencyRateRepository currencyRateRepository)
    {
        _currencyRateRepository = currencyRateRepository;
    }

    public async Task<Unit> Handle(DeleteCurrencyRateCommand command, CancellationToken cancellationToken)
    {
        var currencyRate = await _currencyRateRepository.GetAsync(command.Id);
        if (currencyRate == null) return Unit.Value;

        _currencyRateRepository.Remove(currencyRate);
        await _currencyRateRepository.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}