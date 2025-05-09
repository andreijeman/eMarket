namespace eMarket.Application.Patterns.Mediator;

public interface IMediator
{
    Task<TResponse> Send<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>;
}