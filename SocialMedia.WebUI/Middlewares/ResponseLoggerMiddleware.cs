namespace SocialMedia.WebUI.Middlewares;
// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ResponseLoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IMediator _mediator;
    private readonly ILogger<ResponseLoggerMiddleware> _logger;

    public ResponseLoggerMiddleware(RequestDelegate next, IMediator mediator, ILogger<ResponseLoggerMiddleware> logger)
    {
        _next = next;
        _mediator = mediator;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Response.HttpContext.Request.Path == "/api/User/getall")
        {

            var responseCaptureStream = new MemoryStream();
            var originalResponseBody = context.Response.Body;
            try
            {

                context.Response.Body = responseCaptureStream;
                await _next(context);
            }
            finally
            {

                context.Response.Body = originalResponseBody;


                responseCaptureStream.Seek(0, SeekOrigin.Begin);
                var responseContent = await new StreamReader(responseCaptureStream).ReadToEndAsync();

                _logger.LogCritical("Response: {StatusCode} - {ResponseContent}", context.Response.StatusCode, responseContent);
               // await _mediator.Publish(new PostNotification() { Content = responseContent});


                responseCaptureStream.Seek(0, SeekOrigin.Begin);


                await responseCaptureStream.CopyToAsync(originalResponseBody);
            }
        }
        else await _next(context);
       
    }
}

public static class ResponseLoggerMiddlewareExtensions
{
    public static IApplicationBuilder UseResponseLoggerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ResponseLoggerMiddleware>();
    }
}
