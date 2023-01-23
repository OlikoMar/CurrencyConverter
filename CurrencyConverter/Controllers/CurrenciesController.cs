using CurrencyConverter.Application.Commands.Currency.Create;
using CurrencyConverter.Application.Commands.Currency.Delete;
using CurrencyConverter.Application.Commands.Currency.Update;
using CurrencyConverter.Application.Queries.Currency;
using CurrencyConverter.Application.Queries.Customer;
using CurrencyConverter.Domain.CurrencyAggregate;
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
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var currency = await _currencyQueries.GetCurrencyByIdAsync(id);

        if (currency == null)
            return NotFound();

        return Ok();
    }

    /// <summary>
    /// Create Currency
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCurrencyCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    /// <summary>
    /// Update Currency
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id)
    {
        await _mediator.Send(new UpdateCurrencyCommand { Id = id });
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
        await _mediator.Send(new DeleteCurrencyCommand { Id = id });
        return Ok();
    }
}