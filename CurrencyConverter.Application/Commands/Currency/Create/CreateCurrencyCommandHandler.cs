using CurrencyConverter.Domain.CurrencyAggregate;
using CurrencyConverter.Infrastructure.Commands;
using MediatR;

namespace CurrencyConverter.Application.Commands.Currency.Create;

public class CreateCurrencyCommandHandler : ICommandHandler<CreateCurrencyCommand, bool>
{
    private readonly ICurrencyRepository _currencyRepository;

    public CreateCurrencyCommandHandler(ICurrencyRepository currencyRepository)
    {
        _currencyRepository = currencyRepository;
    }
    public async Task<bool> Handle(CreateCurrencyCommand command, CancellationToken cancellationToken)
    {
        var currency = new Domain.CurrencyAggregate.Currency
        {
            Id = new Guid(),
            Code = command.Code,
            Name = command.Name,
            NameEng = command.NameEng
        };

        await _currencyRepository.AddAsync(currency);
        await _currencyRepository.SaveChangesAsync(cancellationToken);
        return true;
    }
}