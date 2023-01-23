using CurrencyConverter.Application.Queries.Report;
using CurrencyConverter.SharedKernel.Excel;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
    private readonly IReportQuery _reportQuery;

    public ReportsController(IReportQuery reportQuery)
    {
        _reportQuery = reportQuery;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ReportQueryRequest request)
    {
        var response = await _reportQuery.Execute(request);

        return File(
            response.Data.ToExcel(),
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            $"converts-{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.xlsx");
    }
}