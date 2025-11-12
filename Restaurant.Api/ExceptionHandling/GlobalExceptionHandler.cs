using Microsoft.AspNetCore.Diagnostics;
using Restaurant.Application.Common.Exceptions;
using FluentValidation;

namespace Restaurant.Api.ExceptionHandling;

public sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext http, Exception ex, CancellationToken cancellationToken)
        => ex switch
        {
            NotFoundException notFoundException => await HandleNotFoundAsync(http, notFoundException, cancellationToken),
            ValidationException validationException => await HandleValidationAsync(http, validationException, cancellationToken),
            _ => await HandleDefaultAsync(http, ex, cancellationToken)
        };

    private static async ValueTask<bool> HandleNotFoundAsync(HttpContext http, NotFoundException ex, CancellationToken ct)
    {
        await TypedResults.Problem(title: ex.Message, detail: ex.Message, statusCode: 404).ExecuteAsync(http);
        return true;
    }

    private static async ValueTask<bool> HandleValidationAsync(HttpContext http, ValidationException ex, CancellationToken ct)
    {
        var errors = ex.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());
        await TypedResults.ValidationProblem(errors).ExecuteAsync(http);
        return true;
    }

    private async ValueTask<bool> HandleDefaultAsync(HttpContext http, Exception ex, CancellationToken ct)
    {
        logger.LogError(ex, "Unhandled exception");
        await TypedResults.Problem(title: "Internal Server Error", statusCode: 500).ExecuteAsync(http);
        return true;
    }
}
