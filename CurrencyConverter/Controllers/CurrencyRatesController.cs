using Microsoft.AspNetCore.Mvc;
using CurrencyConverter.Domain.CurrencyRateAggregate;
using MediatR;
using CurrencyConverter.Application.Commands.CurrencyRate.Create;
using CurrencyConverter.Application.Commands.CurrencyRate.Delete;
using CurrencyConverter.Application.Commands.CurrencyRate.Update;
using System.Net;
using CurrencyConverter.Application.Queries.CurrencyRate;

namespace CurrencyConverter.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurrencyRatesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICurrencyRateQueries _currencyRateQueries;

    public CurrencyRatesController(
        IMediator mediator,
        ICurrencyRateQueries currencyRateQueries)
    {
        _mediator = mediator;
        _currencyRateQueries = currencyRateQueries;
    }

    /// <summary>
    /// Get All Currency Rates
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetAllAsync()
    {
        var currencyRates = await _currencyRateQueries.GetAllCurrencyRatesAsync();

        if (currencyRates == null)
            return NotFound();
        return Ok();
    }

    /// <summary>
    /// Get Currency Rate
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        var currency = await _currencyRateQueries.GetCurrencyRateByIdAsync(id);

        if (currency == null)
            return NotFound();
        return Ok(currency);
    }

    /// <summary>
    /// Create Currency Rate
    /// </summary>
    /// <param name="command"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCurrencyRateCommand command, CancellationToken token)
    {
        await _mediator.Send(command, token);

        return Ok();
    }

    /// <summary>
    /// Update Currency Rate
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateCurrencyRateCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    /// <summary>
    /// Delete Currency Rate
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCurrencyRateCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
}