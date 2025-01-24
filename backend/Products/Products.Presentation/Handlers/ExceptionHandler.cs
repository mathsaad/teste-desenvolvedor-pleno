using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Products.Contracts.Exceptions;

namespace Products.Server.Handlers;

public class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problemDetails = CreateProblemDetails(exception);
        
        httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(problemDetails.Detail, cancellationToken);
        return true;
    }

    private static ProblemDetails CreateProblemDetails(Exception exception)
    {
        ProblemDetails problemDetails = exception switch
        {
            NotFoundException => CreateProblemDetails(StatusCodes.Status404NotFound,
                "Not Found", exception.Message),
            CustomValidationException => CreateProblemDetails(StatusCodes.Status400BadRequest,
                "Validation Error", "Uma ou mais validações ocorreram erros."),
            _ => CreateProblemDetails(StatusCodes.Status500InternalServerError,
                "Internal Server Error", "Ocorreu um erro desconhecido")
        };

        if (exception is ValidationException validationException)
        {
            problemDetails.Extensions["errors"] = validationException.Errors;
        }
        
        return problemDetails;
    }

    private static ProblemDetails CreateProblemDetails(int statusCode, string title, string detail)
    {
        return new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = detail,
        };
    }
}