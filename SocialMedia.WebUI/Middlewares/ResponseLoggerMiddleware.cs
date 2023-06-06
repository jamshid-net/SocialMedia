

namespace SocialMedia.WebUI.Middlewares;
// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ResponseLoggerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IDistributedCache _dCache;
    private readonly ILogger<ResponseLoggerMiddleware> _logger;

    public ResponseLoggerMiddleware(RequestDelegate next, ILogger<ResponseLoggerMiddleware> logger, IDistributedCache dCache)
           => (_next, _logger, _dCache) = (next, logger, dCache);

    public async Task Invoke(HttpContext context)
    {
        
        
        if(context.Request.Path == "/api/User/getall" && _dCache.GetString(context.Request.Path)  != null)
        {
           await context.Response.WriteAsJsonAsync(_dCache.GetString(context.Request.Path));
            await _next(context);
        }
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
                await _dCache.SetStringAsync(context.Request.Path, responseContent, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(50)
                });

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
