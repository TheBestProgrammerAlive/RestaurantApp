using Microsoft.AspNetCore.Diagnostics;
using Restaurant.Application.Common.Exceptions;

namespace Restaurant.Api.ExceptionHandling;

public sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        if (exception is NotFoundException notFoundException)
        {
            await TypedResults
                .Problem(title: notFoundException.Message, detail: notFoundException.Message, statusCode: 404)
                .ExecuteAsync(httpContext);
            return true;
        }

        logger.LogError(exception, exception.Message);
        await TypedResults.Problem(title: "Internal Server Error", detail: exception.Message, statusCode: 500)
            .ExecuteAsync(httpContext);
        return true;
    }
}