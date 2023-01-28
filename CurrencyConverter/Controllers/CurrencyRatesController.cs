using Microsoft.AspNetCore.Mvc;
using CurrencyConverter.Domain.CurrencyRateAggregate;
using MediatR;
using CurrencyConverter.Application.Commands.CurrencyRate.Create;
using CurrencyConverter.Application.Commands.CurrencyRate.Delete;
using CurrencyConverter.Application.Commands.CurrencyRate.Update;
using System.Net;
using CurrencyConverter.Application.DataModels;
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
    [ProducesResponseType(typeof(IEnumerable<CurrencyRateDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetAllAsync()
    {
        var currencyRates = await _currencyRateQueries.GetAllCurrencyRatesAsync();

        if (currencyRates == null)
            return NotFound();
        return Ok(currencyRates);
    }

    /// <summary>
    /// Get Currency Rate
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CurrencyRateDto), (int)HttpStatusCode.OK)]
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
    [ProducesResponseType(typeof(CurrencyRateDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(CurrencyRateDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Post([FromBody] CreateCurrencyRateCommand command, CancellationToken token)
    {
        var response = await _mediator.Send(command, token);
        if (!response) return NotFound();

        return Ok();
    }

    /// <summary>
    /// Update Currency Rate
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(CurrencyRateDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(CurrencyRateDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCurrencyRateCommand command)
    {
        command.Id = id;
        var response = await _mediator.Send(command);

        if (!response) return NotFound();

        return Ok(id);
    }

    /// <summary>
    /// Delete Currency Rate
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteCurrencyRateCommand { Id = id });

        if (!response) return NotFound();

        return Ok(id);
    }
}