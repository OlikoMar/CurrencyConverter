using CurrencyConverter.Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConverter.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalculationsController : ControllerBase
{
    private readonly CurrencyConverterDbContext _context;

    public CalculationsController(CurrencyConverterDbContext context)
    {
        _context = context;
    }

    [HttpGet("currency-rate")]
    public async Task<decimal?> GetCurrencyRate(string buy, string sell)
    {
        var buyCur = await _context.CurrencyRates.FirstOrDefaultAsync(s => s.Currency.Name == buy);
        var sellCur = await _context.CurrencyRates.FirstOrDefaultAsync(s => s.Currency.Name == sell); //date დავამატო


        return sellCur?.RateToBuy;
    }

    [HttpGet("sell-amount")]
    public async Task<decimal?> Get(string buy, string sell, decimal amount)
    {
        var buyCur = await _context.CurrencyRates.FirstOrDefaultAsync(s => s.Currency.Name == buy);
        var sellCur = await _context.CurrencyRates.FirstOrDefaultAsync(s => s.Currency.Name == sell); //date დავამატო

        return sellCur?.RateToBuy;
    }
}