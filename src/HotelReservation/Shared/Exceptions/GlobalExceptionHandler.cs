using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace HotelReservation.Shared.Exceptions;

public class GlobalExceptionHandler(IHostEnvironment environment)
    : IExceptionHandler

{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        httpContext.Response.ContentType = "application/problem+json";

        if (httpContext.RequestServices.GetService<IProblemDetailsService>() is
            not
            {
            } problemDetailsService)
        {
            return true;
        }

        (string Detail, string Title, int StatusCode) details = exception switch
        {
            ValidationException =>
            (
                exception.Message,
                exception.GetType().Name,
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest
            ),
            DomainException domainException => (
                exception.Message,
                exception.GetType().Name,
                httpContext.Response.StatusCode =
                    (int)domainException.StatusCode
            ),
            _ =>
            (
                exception.Message,
                exception.GetType().Name,
                httpContext.Response.StatusCode =
                    StatusCodes
                        .Status500InternalServerError
            )
        };


        var problem = new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails =
            {
                Title = details.Title, Detail =
                    details.Detail,
                Status = details.StatusCode
            }
        };

        if (environment.IsDevelopment())
            problem.ProblemDetails.Extensions.Add(
                "exception",
                exception.ToString());

        await problemDetailsService.WriteAsync(problem);

        return true;
    }
}