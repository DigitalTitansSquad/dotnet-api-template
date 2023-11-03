using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalTitans.DotnetApi.Infrastructure.ExceptionHandling.Handlers;

public class InvalidOperationExceptionHandler : IExceptionHandler<InvalidOperationException>
{
    public ProblemDetails CreateProblemDetailsFromException(InvalidOperationException exception)
    {
        var message = exception.Message;

        return new ProblemDetails
        {
            Title = "Bad Request",
            Status = StatusCodes.Status400BadRequest,
            Detail = message
        };
    }
}