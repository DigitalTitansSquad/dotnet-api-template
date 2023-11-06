using DigitalTitans.DotnetApi.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalTitans.DotnetApi.Infrastructure.ExceptionHandling.Handlers;

public class ResourceNotFoundExceptionHandler : IExceptionHandler<ResourceNotFoundException>
{
    public ProblemDetails CreateProblemDetailsFromException(ResourceNotFoundException exception)
    {
        var resourceDescription = string.IsNullOrWhiteSpace(exception.ResourceDescription)
            ? "The resource"
            : exception.ResourceDescription;
        var detailMessage = string.IsNullOrEmpty(exception.Message)
            ? $"{resourceDescription} was not found."
            : exception.Message;

        return new ProblemDetails
        {
            Title = "Resource not found",
            Status = StatusCodes.Status404NotFound,
            Detail = detailMessage
        };
    }
}

