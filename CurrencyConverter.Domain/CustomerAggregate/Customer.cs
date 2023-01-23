using CurrencyConverter.Domain.Shared;

namespace CurrencyConverter.Domain.CustomerAggregate;

public class Customer : BaseEntity
{
    public string PersonalNumber { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string RecommenderPersonalNumber { get; set; } = default!;
}