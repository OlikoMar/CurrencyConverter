using CurrencyConverter.Infrastructure.Commands;
using MediatR;
using CurrencyConverter.Domain.CustomerAggregate;

namespace CurrencyConverter.Application.Commands.Customer;

public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Unit> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var customer = new Domain.CustomerAggregate.Customer
        {
            Id = new Guid(),
            FirstName = command.FirstName,
            LastName = command.LastName,
            PersonalNumber = command.PersonalNumber,
            RecommenderPersonalNumber = command.RecommenderPersonalNumber
        };

        await _customerRepository.AddAsync(customer);
        await _customerRepository.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}