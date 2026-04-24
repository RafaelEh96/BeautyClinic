using BeautyClinic.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthException = BeautyClinic.Core.Exceptions.AuthenticationException;

namespace BeautyClinic.Api.Middlewares;

public class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger,
    IWebHostEnvironment environment)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            if (context.Response.HasStarted)
            {
                logger.LogError(exception, "An exception occurred after the response started. TraceId: {TraceId}", context.TraceIdentifier);
                throw;
            }

            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = GetExceptionResponse(exception);

        logger.Log(
            response.LogLevel,
            exception,
            "Request failed with status {StatusCode}. TraceId: {TraceId}",
            response.StatusCode,
            context.TraceIdentifier);

        context.Response.Clear();
        context.Response.StatusCode = response.StatusCode;
        context.Response.ContentType = "application/problem+json";

        var problemDetails = new ProblemDetails
        {
            Status = response.StatusCode,
            Title = response.Title,
            Detail = response.Detail,
            Instance = context.Request.Path
        };

        problemDetails.Extensions["traceId"] = context.TraceIdentifier;

        if (environment.IsDevelopment())
            problemDetails.Extensions["exceptionType"] = exception.GetType().Name;

        await context.Response.WriteAsJsonAsync(problemDetails);
    }

    private ExceptionResponse GetExceptionResponse(Exception exception)
    {
        return exception switch
        {
            ResourceNotFoundException => new(
                StatusCodes.Status404NotFound,
                "Recurso nao encontrado.",
                exception.Message,
                LogLevel.Warning),

            AuthException => new(
                StatusCodes.Status401Unauthorized,
                "Falha de autenticacao.",
                exception.Message,
                LogLevel.Warning),

            UnauthorizedAccessException => new(
                StatusCodes.Status403Forbidden,
                "Acesso negado.",
                exception.Message,
                LogLevel.Warning),

            ArgumentException => new(
                StatusCodes.Status400BadRequest,
                "Requisicao invalida.",
                exception.Message,
                LogLevel.Warning),

            BadHttpRequestException => new(
                StatusCodes.Status400BadRequest,
                "Requisicao invalida.",
                exception.Message,
                LogLevel.Warning),

            InvalidOperationException => new(
                StatusCodes.Status400BadRequest,
                "Operacao invalida.",
                exception.Message,
                LogLevel.Warning),

            DbUpdateException => new(
                StatusCodes.Status409Conflict,
                "Conflito ao salvar dados.",
                environment.IsDevelopment()
                    ? exception.Message
                    : "Nao foi possivel salvar os dados. Verifique se as referencias informadas existem e tente novamente.",
                LogLevel.Error),

            _ => new(
                StatusCodes.Status500InternalServerError,
                "Erro interno no servidor.",
                environment.IsDevelopment()
                    ? exception.Message
                    : "Ocorreu um erro inesperado. Tente novamente mais tarde.",
                LogLevel.Error)
        };
    }

    private sealed record ExceptionResponse(
        int StatusCode,
        string Title,
        string Detail,
        LogLevel LogLevel);
}
