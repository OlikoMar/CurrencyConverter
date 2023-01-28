using Microsoft.AspNetCore.Mvc;
using System.Net;
using CurrencyConverter.Application.Commands.Customer;
using CurrencyConverter.Application.DataModels;
using CurrencyConverter.Application.Queries.Customer;
using MediatR;

namespace CurrencyConverter.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerQueries _customerQueries;
    private readonly IMediator _mediator;

    public CustomersController(
        IMediator mediator, ICustomerQueries customerQueries)
    {
        _mediator = mediator;
        _customerQueries = customerQueries;
    }

    /// <summary>
    /// Get Customer By Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetCustomerAsync(Guid id)
    {
        var customer = await _customerQueries.GetCustomerByIdAsync(id);

        if (customer == null)
            return NotFound($"Customer with id = {id} not found");
        return Ok(customer);
    }

    /// <summary>
    /// Create Customer
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Post([FromBody] CreateCustomerCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }

    /// <summary>
    /// Get Customer's Daily Limit
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}/daily-limit")]
    [ProducesResponseType(typeof(decimal?), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetDailyLimit(Guid id)
    {
        var dailyLimit = await _customerQueries.GetDailyLimitAsync(id);

        return Ok(dailyLimit);
    }
}