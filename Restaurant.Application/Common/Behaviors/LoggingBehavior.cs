using MediatR;
using Microsoft.Extensions.Logging;

namespace Restaurant.Application.Common.Behaviors;

public sealed class LoggingBehavior<TRequest,TResponse>(ILogger<IRequest> logger) : IPipelineBehavior<TRequest,TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation("Processing request of type {RequestName}", typeof(TRequest).Name);
        var response = await next(cancellationToken);
        logger.LogInformation("Finished processing request {Request}", request);
        return response;
    }
}