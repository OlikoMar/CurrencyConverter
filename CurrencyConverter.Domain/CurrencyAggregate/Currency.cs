using CurrencyConverter.Domain.Shared;

namespace CurrencyConverter.Domain.CurrencyAggregate;

public class Currency : BaseEntity
{
    public string Code { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string NameEng { get; set; } = default!;

    public void UpdateData(
        string code,
        string name,
        string nameEng)
    {
        Code = code;
        Name = name;
        NameEng = nameEng;
    }
}