using MediatR;

namespace CurrencyConverter.Infrastructure.Commands;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}