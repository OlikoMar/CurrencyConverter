using CurrencyConverter.Infrastructure.Commands;
using MediatR;

namespace CurrencyConverter.Application.Commands.Customer;

public class CreateCustomerCommand : Command<Unit>
{
    public string PersonalNumber { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string RecommenderPersonalNumber { get; set; } = default!;
}