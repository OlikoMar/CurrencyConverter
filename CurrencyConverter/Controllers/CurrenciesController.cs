using CurrencyConverter.Application.Commands.Currency.Create;
using CurrencyConverter.Application.Commands.Currency.Delete;
using CurrencyConverter.Application.Commands.Currency.Update;
using CurrencyConverter.Application.Queries.Currency;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurrenciesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICurrencyQueries _currencyQueries;

    public CurrenciesController(
        IMediator mediator,
        ICurrencyQueries currencyQueries)
    {
        _mediator = mediator;
        _currencyQueries = currencyQueries;
    }

    /// <summary>
    /// Get All Currencies
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var currencies = await _currencyQueries.GetAllCurrenciesAsync();

        if (!currencies.Any())
            return NotFound();

        return Ok(currencies);
    }

    /// <summary>
    /// Get Currency
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var currency = await _currencyQueries.GetCurrencyByIdAsync(id);

        if (currency == null)
            return NotFound();

        return Ok(currency);
    }

    /// <summary>
    /// Create Currency
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCurrencyCommand command)
    {
        var response = await _mediator.Send(command);

        if (!response) return BadRequest();

        return Ok();
    }

    /// <summary>
    /// Update Currency
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCurrencyCommand command)
    {
        command.Id = id;
        var response = await _mediator.Send(command);
        if (!response) return NotFound();
        return Ok();
    }

    /// <summary>
    /// Delete Currency
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteCurrencyCommand { Id = id });
        if (!response) return NotFound();
        return Ok();
    }
}