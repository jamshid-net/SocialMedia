﻿

namespace SocialMedia.WebUI.Middlewares;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;
    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
           => (_next, _logger) = (next, logger);
       
    

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (NotFoundException ex)
        {
            await HandleException(httpContext, ex.Message, HttpStatusCode.NotFound, ex.Message);
        }


        catch (Exception ex)
        {
            await HandleException(httpContext, ex.Message, HttpStatusCode.InternalServerError, ex.Message);
        }

    }


    public async ValueTask<ActionResult> HandleException(HttpContext httpContext, string exMessage, HttpStatusCode httpStatusCode, string message)
    {
        _logger.LogCritical(message);
        // Log.Error("EXCEPTION:🔴 CLIENT_IP:{ClientIp}  CLIENT:{EnvironmentUserName} AGENT:{ClientAgent}" + $"\nDatetime:{DateTime.Now} | Message:{exMessage} | Path:{httpContext.Request.Path}");
        HttpResponse response = httpContext.Response;
        response.ContentType = "application/json";
        response.StatusCode = (int)httpStatusCode;
        //var path = httpContext.Request.Headers["Referer"].ToString();

        var error = new
        {
            Message = message,
            StatusCode = (int)httpStatusCode
        };

        return await Task.FromResult(new BadRequestObjectResult(error));

    }
}


public static class GlobalExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<GlobalExceptionMiddleware>();
    }
}