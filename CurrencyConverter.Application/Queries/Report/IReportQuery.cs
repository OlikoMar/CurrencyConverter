namespace CurrencyConverter.Application.Queries.Report;

public interface IReportQuery
{
    Task<ReportQueryResponse> Execute(ReportQueryRequest request);
}