using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceTracker.Application.Exceptions;

namespace ServiceTracker.Api.ExceptionHandling;

public sealed class GlobalExceptionHandling : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandling> _logger;


    public GlobalExceptionHandling(
        ILogger<GlobalExceptionHandling> logger
    )
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        var (statusCode, title, detail, logLevel) = exception switch
        {
            EmailAlredyExistsException => 
                (
                    StatusCodes.Status409Conflict,
                    "Conflict",
                    "A user with this email alredy exists.",
                    LogLevel.Information
                ),

            UsernameAlredyExistsException => 
                (
                    StatusCodes.Status409Conflict,
                    "Conflict",
                    "A user with this username alredy exists.",
                    LogLevel.Information
                ),

            _ => 
            (
                    StatusCodes.Status500InternalServerError,
                    "Internal server error",
                    "An unexepted error occurred",
                    LogLevel.Information
            )
        };

        if(statusCode >= 500)
        {
            _logger.LogError(
                exception,
                "Unhandled exception. Traced: {TracedId}. Method: {Method}. Path: {Path}",
                httpContext.TraceIdentifier,
                httpContext.Request.Method,
                httpContext.Request.Path
            );
        }
        else
        {
            _logger.Log(
                logLevel,
                "Request feiled with status code {StatusCode}: {Title}",
                statusCode,
                title
            );
        }

        httpContext.Response.StatusCode = statusCode;

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = detail,
            Instance = httpContext.Request.Path
        };

        problemDetails.Extensions["traceId"] = httpContext.TraceIdentifier;

        await httpContext.Response.WriteAsJsonAsync(
            problemDetails,
            cancellationToken
        );

        return true;
    }
}