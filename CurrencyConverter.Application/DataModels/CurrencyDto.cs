namespace CurrencyConverter.Application.DataModels;

public class CurrencyDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string NameEng { get; set; } = default!;
}