using MediatR;

namespace CurrencyConverter.Infrastructure.Commands;

public interface ICommandHandler<T, R> : IRequestHandler<T, R>
    where T : IRequest<R>
{
    new Task<R> Handle(T command, CancellationToken cancellationToken);
}