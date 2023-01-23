using CurrencyConverter.Domain.CurrencyAggregate;
using CurrencyConverter.Domain.CustomerAggregate;
using CurrencyConverter.Domain.Shared;

namespace CurrencyConverter.Domain.ConvertHistoryAggregate;

public class ConvertHistory : BaseEntity
{
    public DateTimeOffset Date { get; set; }
    public Customer Customer { get; set; }
    public Customer Recommender { get; set; }
    public Currency SellCurrency { get; set; }
    public Currency BuyCurrency { get; set; }
    public decimal Amount { get; set; }
}