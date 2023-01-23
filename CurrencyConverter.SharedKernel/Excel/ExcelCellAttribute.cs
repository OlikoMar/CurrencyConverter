namespace CurrencyConverter.SharedKernel.Excel;

public class ExcelCellAttribute : Attribute
{
    public int Column { get; set; }
    public string Name { get; set; } = default!;
}