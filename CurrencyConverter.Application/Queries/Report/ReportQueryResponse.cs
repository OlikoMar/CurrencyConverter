using CurrencyConverter.Application.DataModels;

namespace CurrencyConverter.Application.Queries.Report;

public class ReportQueryResponse
{
    public List<ConversationReportDto> Data { get; set; }
}