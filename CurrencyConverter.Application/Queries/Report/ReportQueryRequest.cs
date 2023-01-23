namespace CurrencyConverter.Application.Queries.Report;

public class ReportQueryRequest
{
    public DateTimeOffset From { get; set; }
    public DateTimeOffset To { get; set; }
}