using CurrencyConverter.Application.DataModels;
using CurrencyConverter.Infrastructure.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace CurrencyConverter.Application.Queries.Report;

public class ReportQuery : IReportQuery
{
    private readonly string _connectionString;

    public ReportQuery(CurrencyConverterDbContext context)
    {
        _connectionString = context.Database.GetConnectionString();
    }

    public async Task<ReportQueryResponse> Execute(ReportQueryRequest request)
    {
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        var data = await connection.QueryAsync<ConversationReportDto>(@"
            SELECT
               ""PersonalNumber"",
               COUNT(""Transactions"")
                FROM ""ConvertHistories"" ");

        return new ReportQueryResponse { Data = data.ToList() };
    }
}