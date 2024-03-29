﻿


using TelegramSink.TelegramBotClient.Domain;

namespace SocialMedia.WebUI.Middlewares;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
   
    public GlobalExceptionMiddleware(RequestDelegate next)
           => (_next) = (next);
       
    

    public async Task Invoke(HttpContext httpContext)
    {
        
           
        try
        {
           
            await _next(httpContext);
            // Log.Error("EXCEPTION:🔴 CLIENT_IP:{ClientIp}  CLIENT:{EnvironmentUserName}  MACHINENAME:{MachineName } AGENT:{ClientAgent}" + $"\nDatetime:{DateTime.Now} | Message:{exMessage} | Path:{httpContext.Request.Path}");
           // Log.Error("EXCEPTION:🔴 CLIENT_IP:{ClientIp}  CLIENT:{ERROR} ELYOR AHAHAHA AHAHAHAH  MACHINENAME:{ } AGENT:{}" + $"\nDatetime:{DateTime.Now} | Path:{httpContext.Request.Path}");
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
        
        Log.Error("EXCEPTION:🔴 CLIENT_IP:{ClientIp}  CLIENT:{ERROR} IN YOUR PC HAVE VIRUS  MACHINENAME:{ } AGENT:{}" + $"\nDatetime:{DateTime.Now} | Message:{exMessage} | Path:{httpContext.Request.Path}");
        HttpResponse response = httpContext.Response;
        response.ContentType = "application/json";
        response.StatusCode = (int)httpStatusCode;
        //var path = httpContext.Request.Headers["Referer"].ToString(); EnvironmentUserName ClientAgent MachineName

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
