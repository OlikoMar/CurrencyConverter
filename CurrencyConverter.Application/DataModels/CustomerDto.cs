namespace CurrencyConverter.Application.DataModels;

public class CustomerDto
{
    public string PersonalNumber { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string RecommenderPersonalNumber { get; set; } = default!;
}